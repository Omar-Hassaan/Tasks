namespace TaskOne
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int perSmallCharge = 25;
            int perLargeCharge = 35;
            const double tax = 0.06;
            const int estimateDays = 30;

            Console.WriteLine("Estimate for carpet cleaning service");
            Console.Write("Enter the number of small carpets: ");
            int numSmallCarpets = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter the number of large carpets: ");
            int numLargeCarpets = Convert.ToInt32(Console.ReadLine());

            double TotalWithNoTax = (perSmallCharge * numSmallCarpets) + (perLargeCharge * numLargeCarpets);

            Console.WriteLine($"Price per small Carpet: {perSmallCharge}");
            Console.WriteLine($"Price per large Carpet: {perLargeCharge}");
            Console.WriteLine($"Cost: {TotalWithNoTax:C}");
            Console.WriteLine($"Tax:  {tax * TotalWithNoTax:C}");
            Console.WriteLine("===============================");
            Console.WriteLine($"Total estimate: {TotalWithNoTax + (tax * TotalWithNoTax):C}");
            Console.WriteLine($"This estimate is valid for {estimateDays} days");
        }
    }
}
