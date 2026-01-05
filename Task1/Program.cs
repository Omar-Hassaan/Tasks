namespace Task1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter the number of small carpets: ");
            int smallCarpets = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter the number of large carpets: ");
            int largeCarpets = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("=====================================");
            Console.WriteLine("Estimate for carpet cleaning service");
            Console.WriteLine($"Number of small carpets: {smallCarpets}");
            Console.WriteLine($"Number of large carpets: {largeCarpets}");
            Console.WriteLine("Price per small room: $25");
            Console.WriteLine("Price per large room: $35");
            double cost = (smallCarpets * 25) + (largeCarpets * 35);
            Console.WriteLine($"Cost: ${cost}");
            double tax = cost * 0.06;
            Console.WriteLine($"Tax: {tax}");
            Console.WriteLine("===============================");
            double total = cost + tax;
            Console.WriteLine($"Total estimate: ${total}");
            Console.WriteLine("This estimate is valid for 30 days");
        }
    }
}
