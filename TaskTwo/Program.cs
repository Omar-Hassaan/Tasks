namespace TaskTwo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = new();
            string selectedOption = "";

            do
            {
                Console.WriteLine("Menu Options:");
                Console.WriteLine("P - Print numbers");
                Console.WriteLine("A - Add a number");
                Console.WriteLine("M - Display mean of the numbers");
                Console.WriteLine("S - Display the smallest number");
                Console.WriteLine("L - Display the largest number");
                Console.WriteLine("F - Find a number in the list");
                Console.WriteLine("C - Clear the list");
                Console.WriteLine("Q - Quit");
                Console.Write("Enter your choice: ");

                selectedOption = Console.ReadLine();

                switch (selectedOption.ToUpper())
                {
                    case "P":
                        if (numbers.Count == 0)
                        {
                            Console.WriteLine("[] - the list is empty");
                        }
                        else
                        {
                            Console.Write("[");
                            for (int i = 0; i < numbers.Count; i++)
                            {
                                Console.Write($"{numbers[i]} ");
                            }
                            Console.WriteLine("]");
                        }
                        break;
                    case "A":
                        Console.Write("Enter an integer to add: ");
                        int newNumber = Convert.ToInt32(Console.ReadLine());
                        if (numbers.Contains(newNumber))
                        {
                            Console.WriteLine("The number is already in the list");
                        }
                        else
                        {
                            numbers.Add(newNumber);
                            Console.WriteLine($"{newNumber} added");
                        }
                        break;
                    case "M":
                        if (numbers.Count == 0)
                        {
                            Console.WriteLine("Unable to calculate the mean - no data");
                        }
                        else
                        {
                            int sum = 0;
                            for (int i = 0; i < numbers.Count; i++)
                                sum += numbers[i];
                            double average = sum / numbers.Count;
                            Console.WriteLine($"Mean: {average}");
                        }
                        break;
                    case "S":
                        if (numbers.Count == 0)
                        {
                            Console.WriteLine("Unable to determine the smallest number - list is empty");
                        }
                        else
                        {
                            int min = numbers[0];
                            for (int i = 0; i < numbers.Count; i++)
                            {
                                if (min > numbers[i])
                                {
                                    min = numbers[i];
                                }
                            }
                            Console.WriteLine($"The smallest number is {min}");
                        }
                        break;
                    case "L":
                        if (numbers.Count == 0)
                        {
                            Console.WriteLine("Unable to determine the largest number - list is empty");
                        }
                        else
                        {
                            int max = numbers[0];
                            for (int i = 0; i < numbers.Count; i++)
                            {
                                if (max < numbers[i])
                                {
                                    max = numbers[i];
                                }
                            }
                            Console.WriteLine($"The largest number is {max}");
                        }
                        break;
                    case "F":
                        Console.Write("Enter a number to find: ");
                        int searchNumber = Convert.ToInt32(Console.ReadLine());
                        if (numbers.Count == 0)
                        {
                            Console.WriteLine("Unable to determine the search number - list is empty");
                        }
                        else
                        {
                            for (int i = 0; i < numbers.Count; i++)
                            {
                                if (searchNumber == numbers[i])
                                {
                                    Console.WriteLine($"{searchNumber} found at index {i}");
                                }
                            }
                        }
                        break;
                    case "C":
                        if (numbers.Count == 0)
                        {
                            Console.WriteLine("list is already empty");
                        }
                        else
                        {
                            numbers.Clear();
                            Console.WriteLine("List Cleared");
                        }
                        break;
                    case "Q":
                        Console.WriteLine("Goodbye");
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Unknown selection, please try again");
                        break;
                }
                Console.WriteLine("_____________________");
            }
            while (selectedOption != "Q");
        }
    }
}
