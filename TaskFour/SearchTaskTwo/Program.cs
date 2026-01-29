namespace SearchTaskTwo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.Write("Enter a word: ");
                string word = Console.ReadLine();
                CheckVowels(word);
                Console.WriteLine("The string contains vowels.");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        static void CheckVowels(string word)
        {
            if (string.IsNullOrWhiteSpace(word))
            {
                throw new Exception("Invalid input. Please enter a valid word.");

            }
            word = word.ToLower();
            char[] vowels = { 'a', 'e', 'i', 'o', 'u' };
            foreach (char c in word)
            {
                if (vowels.Contains(c))
                    return;
            }
            throw new Exception("The string does not contain any vowels.");
        }
    }
}
