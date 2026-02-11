using System;
using System.Collections.Generic;
using System.Text;

namespace TaskFive.Models
{
    public class MultipleChoiceQuestion : Question
    {
        private List<string> Choices;
        private List<int> CorrectAnswers;

        public MultipleChoiceQuestion(string header, int marks, QuestionLevel level, List<string> choices, List<int> correctAnswers)
            : base(header, marks, level)
        {
            Choices = choices;
            CorrectAnswers = correctAnswers;
        }

        public override void Display()
        {
            Console.WriteLine($"{Header} (Multiple Choice) - Marks: {Marks}");
            for (int i = 0; i < Choices.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {Choices[i]}");
            }
            Console.Write("Enter answers separated by comma (Example: 1,3): ");
        }

        public override bool CheckAnswer(string answer)
        {
            string[] studentAnswers = answer.Split(',');
            if (studentAnswers.Length != CorrectAnswers.Count)
                return false;

            List<int> parsedAnswers = new List<int>(); 
            
            foreach (string ans in studentAnswers)
            {
                int value;
                if (!int.TryParse(ans.Trim(), out value))
                    return false;

                if (parsedAnswers.Contains(value))
                    return false;

                parsedAnswers.Add(value);
            }
           
            for (int i = 0; i < CorrectAnswers.Count; i++)
            {
                if (!parsedAnswers.Contains(CorrectAnswers[i]))
                    return false;
            }
            
            return true;
        }
    }
}
