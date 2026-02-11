using System;
using System.Collections.Generic;
using System.Text;

namespace TaskFive.Models
{
    public class ChooseOneQuestion : Question
    {
        private List<string> Choices;
        private int CorrectChoice;

        public ChooseOneQuestion(string header, int marks, QuestionLevel level, List<string> choices, int correctChoice)
            : base(header, marks, level)
        {
            Choices = choices;
            CorrectChoice = correctChoice;
        }

        public override void Display()
        {
            Console.WriteLine($"{Header} (Choose One) - Marks: {Marks}");
            for (int i = 0; i < Choices.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {Choices[i]}");
            }
            Console.Write("Enter your answer (number): ");
        }

        public override bool CheckAnswer(string answer)
        {
            return Convert.ToInt32(answer) == CorrectChoice;
        }
    }
}
