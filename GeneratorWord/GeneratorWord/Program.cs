using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneratorWord
{
    class Program
    {
        public static void GenerateWords(int num_wordss)
        {

            List<string> listwithRandomStrings = new List<string>();
            // Get the number of words and letters per word.
            int num_letters = 6;
            int num_words = num_wordss;

            // Make an array of the letters we will use.
            char[] letters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();

            // Make a random number generator.
            Random rand = new Random();

            // Make the words.
            for (int i = 1; i <= num_words; i++)
            {
                // Make a word.
                string word = "";
                for (int j = 1; j <= num_letters; j++)
                {
                    // Pick a random number between 0 and 25
                    // to select a letter from the letters array.
                    int letter_num = rand.Next(0, letters.Length - 1);

                    // Append the letter.
                    word += letters[letter_num];
                }

                // Add the word to the list.
                listwithRandomStrings.Add(word);
            }

            using (System.IO.StreamWriter file =
           new System.IO.StreamWriter(@" C: \Users\Markel\Desktop\detyrakusitc++\GeneratorWord\WriteLines2.txt"))
                //C: \Users\Markel\Desktop\detyrakusitc++\GeneratorWord\WriteLines2.txt"
                foreach (string word in listwithRandomStrings)
                {

                    file.Write(word + " ");
                }

        }
        static void Main(string[] args)
        {
            GenerateWords(1000000);
        }

    }
}
