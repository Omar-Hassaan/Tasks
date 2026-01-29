namespace SearchTaskOne
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.Write("Enter list length: ");
                int length = int.Parse(Console.ReadLine());
                List<int> numbers = new List<int>(length);
                for (int i = 0; i < length; i++)
                {
                    Console.Write("Enter number: ");
                    int number = int.Parse(Console.ReadLine());
                    if (numbers.Contains(number))
                    {
                        throw new Exception($"Duplicate number found: {number}");
                    }
                    numbers.Add(number);
                }
                Console.WriteLine("All numbers are unique.");
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid input. Please enter only integers.");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }
    }
}
