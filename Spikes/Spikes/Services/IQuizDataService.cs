using System;
using Spikes.Model;

namespace Spikes.Services {

    public interface IQuizDataService {
        Quiz GetById(string id);
    }

    public class QuizDataService : IQuizDataService {

        public Quiz GetById(string id) {
            var quiz = new Quiz {
                Id = Guid.NewGuid(),
                Questions = new[] {
                    new Question { Id = Guid.NewGuid(), Text = "What is 5 + 4 - 4 - 5 + 5 + 4 - 4 - 5 + 5 + 4 - 4 - 5 + 5 + 4 - 4 - 5 + 5 + 4 - 4 - 5 + 5 + 4 - 4 - 5 + 5 + 4 - 4 - 5 + 5 + 4 - 4 - 5 + 5 + 4 - 4 - 5 ?",
                        Answers = new [] {
                            new Answer { Id = Guid.NewGuid(), Text = "8", IsCorrect = false },
                            new Answer { Id = Guid.NewGuid(), Text = "7", IsCorrect = false },
                            new Answer { Id = Guid.NewGuid(), Text = "9", IsCorrect = true },
                            new Answer { Id = Guid.NewGuid(), Text = "10", IsCorrect = false },
                        }
                    },
                    new Question { Id = Guid.NewGuid(), Text = "What is 3 + 8?",
                        Answers = new [] {
                            new Answer { Id = Guid.NewGuid(), Text = "Infinity", IsCorrect = false },
                            new Answer { Id = Guid.NewGuid(), Text = "5", IsCorrect = false },
                            new Answer { Id = Guid.NewGuid(), Text = "11", IsCorrect = true },
                            new Answer { Id = Guid.NewGuid(), Text = "10", IsCorrect = false },
                        }
                    },
                    new Question { Id = Guid.NewGuid(), Text = "What is 3^2?",
                        Answers = new [] {
                            new Answer { Id = Guid.NewGuid(), Text = "7", IsCorrect = false },
                            new Answer { Id = Guid.NewGuid(), Text = "3", IsCorrect = false },
                            new Answer { Id = Guid.NewGuid(), Text = "9", IsCorrect = true },
                            new Answer { Id = Guid.NewGuid(), Text = "6", IsCorrect = false },
                        }
                    },
                }
            };

            return quiz;
        }

    }

}