using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Spikes.Model;
using Spikes.Services;
using Xamarin.Forms;

namespace Spikes.Pages {

    public class QuizView : BaseView {

        public QuizView() {
            IQuizDataService quizService = new QuizDataService();
            var quiz = quizService.GetById("");

            var stack = new StackLayout {
                Padding = new Thickness(10, 10),
            };

            foreach (var question in quiz.Questions) {
                stack.Children.Add(CreateLayoutForQuestion(question));
            }

            Content = new ScrollView {Content = stack};

        }

        private StackLayout CreateLayoutForQuestion(Question question) {
            var questionLabel = new Label {
                Text = question.Text,
                HorizontalOptions = LayoutOptions.Start,
                TextColor = Color.Black,
            };

            var answersStack = new StackLayout() {
                Orientation = StackOrientation.Vertical
            };

            foreach (var answer in question.Answers) {


                var answerSwitch = new Switch {
                    ClassId = question.Id.ToString(),
                };
                answerSwitch.Toggled += (sender, args) => {
                    var toggledSwitch = (Switch) sender;

                    if (args.Value) {
                        var questionContainer = toggledSwitch.Parent.Parent.Parent.Parent as StackLayout;
                        foreach (var otherSwitch in questionContainer.Children.OfType<Switch>()) {
                            if (otherSwitch.Id != toggledSwitch.Id) {
                                otherSwitch.IsToggled = false;
                            }
                        }
                    }
                    Debug.WriteLine("Switch toggled for question = {0}", ((Switch) sender).ClassId);
                };

                var answerLabel = new Label() {
                    Text = answer.Text,
                    HorizontalOptions = LayoutOptions.StartAndExpand
                };

                var answerStack = new StackLayout() {
                    Orientation = StackOrientation.Horizontal,
                    Children = {
                        answerSwitch,
                        answerLabel
                    }
                };

                answersStack.Children.Add(answerStack);
            }


            var stack = new StackLayout {
                Padding = new Thickness(10,10),
                Children = {
                    questionLabel,
                    answersStack
                }
            };

            return stack;
        }
    }

}