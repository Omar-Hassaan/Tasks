using System;
using System.Collections.Generic;
using System.Text;

namespace TaskFive.Models
{
    public class TrueFalseQuestion : Question
    {
        private bool CorrectAnswer { get; set; }

        public TrueFalseQuestion(string header, int marks, QuestionLevel level, bool correctAnswer)
            : base(header, marks, level)
        {
            CorrectAnswer = correctAnswer;
        }

        public override void Display()
        {
            Console.WriteLine($"{Header} (1. True, 2.False) - Marks: {Marks}");
            Console.Write("Enter your answer (1 for True, 2 for False): ");
        }

        public override bool CheckAnswer(string answer)
        {
            bool studentAnswer = answer == "1";
            return studentAnswer == CorrectAnswer;
        }
    }
}
