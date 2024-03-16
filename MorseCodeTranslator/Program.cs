using System.Diagnostics.Tracing;

internal class Program
{
    private static void Main(string[] args)
    {
        InitializeDictionary();
        Console.WriteLine("Hello, World!");
        Console.WriteLine();
        string textToTranslate = Console.ReadLine();
        Console.WriteLine();
        Console.WriteLine(textToTranslate + " Will be translated to morse code:");
        Console.WriteLine();
        Console.WriteLine(TranslateFromEnglish(textToTranslate));


    }

    public static Dictionary<string,string> MorseDictionary;

    public static void InitializeDictionary()
    {
        MorseDictionary = new Dictionary<string, string>()
        {
            {"a", ".-" },
            {"b", "-..." },
            {"c", "-.-." },
            {"d", "-.." },
            {"e", "." },
            {"f", "..-." },
            {"g", "--." },
            {"h", "...." },
            {"i", ".." },
            {"j", ".---" },
            {"k", "-.-" },
            {"l", ".-.." },
            {"m", "--" },
            {"n", "-." },
            {"o", "---" },
            {"p", ".--." },
            {"q", "--.-" },
            {"r", ".-." },
            {"s", "..." },
            {"t", "-" },
            {"u", "..-" },
            {"v", "...-" },
            {"w", ".--" },
            {"x", "-..-" },
            {"y", "-.--" },
            {"z", "--.." }
        };
    }

    public static string TranslateFromEnglish(string sentence)
    {
        string translatedText = "";
        string[] splitted = sentence.Split(' ');

        foreach (string word in splitted)
        {
            for (int i=0;i<word.Length;i++) 
            {
                bool v = MorseDictionary.TryGetValue(Convert.ToString(word[i]).ToLower(), out string morseEquivalent);
                translatedText += morseEquivalent;
                translatedText += " ";
            }
            translatedText += "/ ";
        }

        return translatedText;
    }

    public static string TranslateFormMorse(string morseSentence)
    {
        string translatedText = "";
        string[] splitted = morseSentence.Split(' ');

        foreach (string word in splitted)
        {
            KeyValuePair<string,string> found = MorseDictionary.FirstOrDefault(x => x.Value == word);
            translatedText += found.Key;
        }

        return translatedText;
    }
}