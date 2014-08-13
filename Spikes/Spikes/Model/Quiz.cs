using System;

namespace Spikes.Model {

    public class Quiz {
        public Guid Id { get; set; }
        public Question[] Questions { get; set; }
    }

    public class Question {
        public Guid Id { get; set; }
        public string Text { get; set; }
        public Answer[] Answers { get; set; }
    }

    public class Answer {
        public Guid Id { get; set; }
        public string Text { get; set; }
        public bool IsCorrect { get; set; }
    }

}