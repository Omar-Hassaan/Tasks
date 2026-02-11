using System.Reflection.PortableExecutable;
using TaskFive.Models;

namespace TaskFive
{
    internal class Program
    {
        static List<Question> questionBank = new List<Question>();
        static void Main(string[] args)
        {
            string choice = "";

            do
            {
                Console.WriteLine("= = = = = Main Menu = = = = =");
                Console.WriteLine("1. Doctor Mode");
                Console.WriteLine("2. Student Mode");
                Console.WriteLine("3. Exit");
                Console.Write("Enter Choice: ");
                choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        DoctorMode();
                        break;
                    case "2":
                        StudentMode();
                        break;
                    case "3":
                        Console.WriteLine("Goodbye...");
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }

            } while (choice != "3");
        }

        public static void DoctorMode()
        {
            Console.Write("How many questions do you want to add?: ");
            int questionsCount = Convert.ToInt32(Console.ReadLine());

            for (int i = 0; i < questionsCount; i++)
            {
                Console.WriteLine($"Adding Question {i + 1}:");
                Console.WriteLine("= = = = = Question types = = = = =");
                Console.WriteLine("1. True/False");
                Console.WriteLine("2. Choose One");
                Console.WriteLine("3. Multiple Choice");
                Console.Write("\nSelect Question Type: ");
                string questionType = Console.ReadLine();

                Console.Write("Enter Question Level (1-Easy, 2-Medium, 3-Hard): ");
                QuestionLevel level = (QuestionLevel)Convert.ToInt32(Console.ReadLine());

                Console.Write("Enter Question Header: ");
                string questionHeader = Console.ReadLine();

                Console.Write("Enter Question Marks: ");
                int questionMarks = Convert.ToInt32(Console.ReadLine());

                switch (questionType)
                {
                    case "1":
                        // Create True/False question
                        Console.Write("Enter Correct Answer (1 for True, 2 for False): ");
                        bool tfCorrect = Console.ReadLine() == "1";

                        questionBank.Add(new TrueFalseQuestion(questionHeader, questionMarks, level, tfCorrect));
                        break;
                    case "2":
                        // Create Choose One question
                        List<string> oneChoice = new List<string>();
                        for (int j = 0; j < 4; j++)
                        {
                            Console.Write($"Enter Choice {j + 1}: ");
                            oneChoice.Add(Console.ReadLine());
                        }

                        Console.Write("Enter Correct Choice Number (1-4): ");
                        int correctChoice = Convert.ToInt32(Console.ReadLine());

                        questionBank.Add(new ChooseOneQuestion(questionHeader, questionMarks, level, oneChoice, correctChoice));
                        break;
                    case "3":
                        // Create Multiple Choice question
                        List<string> multipleChoices = new List<string>();
                        for (int j = 0; j < 4; j++)
                        {
                            Console.Write($"Enter Choice {j + 1}: ");
                            multipleChoices.Add(Console.ReadLine());
                        }

                        Console.Write("Enter Correct Choice Numbers (1-4) separated by comma: ");
                        List<int> correctChoices = Console.ReadLine().Split(',').Select(int.Parse).ToList();

                        questionBank.Add(new MultipleChoiceQuestion(questionHeader, questionMarks, level, multipleChoices, correctChoices));
                        break;
                    default:
                        Console.WriteLine("Invalid question type.");
                        break;
                }
                Console.WriteLine("========================================");
            }

        }

        public static void StudentMode()
        {
            int count = 0;
            int limit;
            int asked = 0;
            int totalMarks = 0;
            int result = 0;

            if (questionBank.Count == 0)
            {
                Console.WriteLine("\nNo questions available.\n");
                return;
            }

            Console.WriteLine("= = = = = Exam types = = = = =");
            Console.WriteLine("1. Practical Exam");
            Console.WriteLine("2. Final Exam");
            Console.Write("Choose Exam Type: ");
            int examType = Convert.ToInt32(Console.ReadLine());

            Console.Write("Choose Level (1-Easy, 2-Medium, 3-Hard): ");
            QuestionLevel level = (QuestionLevel)Convert.ToInt32(Console.ReadLine());

            for (int i = 0; i < questionBank.Count; i++)
            {
                if (questionBank[i].Level == level)
                    count++;
            }

            if (count == 0)
            {
                Console.WriteLine("\nNo questions available for this level.\n");
                return;
            }

            if (examType == 1)
                limit = count < 2 ? 1 : count / 2;
            else if (examType == 2)
                limit = count;
            else
            {
                Console.WriteLine("Invalid Exam Type");
                return;
            }

            Console.WriteLine("\n= = = = Exam Started = = = =\n");
            for (int i = 0; i < questionBank.Count && asked < limit; i++)
            {
                if (questionBank[i].Level == level)
                {
                    Console.WriteLine($"Question {i + 1}:");
                    questionBank[i].Display();
                    string answer = Console.ReadLine();

                    totalMarks += questionBank[i].Marks;
                    if (questionBank[i].CheckAnswer(answer))
                        result += questionBank[i].Marks;

                    asked++;
                    Console.WriteLine("----------------------");
                }
            }
            Console.WriteLine($"\nYour Result: {result} / {totalMarks}");
            Console.WriteLine("========================================");
        }
    }
}
