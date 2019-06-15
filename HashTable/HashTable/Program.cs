using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace HashTable
{
    class Program
    {
        
        static void Main(string[] args)
        {
            
            List<string> KeyA = new List<string>();
            List<string> KeyB = new List<string>();
            List<string> KeyC = new List<string>();
            List<string> KeyD = new List<string>();
            List<string> KeyE = new List<string>();
            List<string> KeyF = new List<string>();
            List<string> KeyG = new List<string>();
            List<string> KeyH = new List<string>();
            List<string> KeyI = new List<string>();
            List<string> KeyJ = new List<string>();
            List<string> KeyK = new List<string>();
            List<string> KeyL = new List<string>();
            List<string> KeyM = new List<string>();
            List<string> KeyN = new List<string>();
            List<string> KeyO = new List<string>();
            List<string> KeyP = new List<string>();
            List<string> KeyQ = new List<string>();
            List<string> KeyR = new List<string>();
            List<string> KeyS = new List<string>();
            List<string> KeyT = new List<string>();
            List<string> KeyU = new List<string>();
            List<string> KeyV = new List<string>();
            List<string> KeyW = new List<string>();
            List<string> KeyX = new List<string>();
            List<string> KeyY = new List<string>();
            List<string> KeyZ = new List<string>();

            // Create new stopwatch.
            Stopwatch stopwatch = new Stopwatch();

            // Begin timing.
            stopwatch.Start();

           // List<string> listaWords = GenerateWords(100000);


          List<string> listaWords = ReadFile();

            foreach (string fjala in listaWords)
            {


                string c = Gjejcels(fjala);
                
                switch (c)
                {
                    case "a":
                        Kontrollo(KeyA, fjala);
                        break;

                    case "b":
                        Kontrollo(KeyB, fjala);
                        break;

                    case "c":
                        Kontrollo(KeyC, fjala);
                        break;

                    case "d":
                        Kontrollo(KeyD, fjala);
                        break;

                    case "e":
                        Kontrollo(KeyE, fjala);
                        break;

                    case "f":
                        Kontrollo(KeyF, fjala);
                        break;

                    case "g":
                        Kontrollo(KeyG, fjala);
                        break;

                    case "h":
                        Kontrollo(KeyH, fjala);
                        break;

                    case "i":
                        Kontrollo(KeyI, fjala);
                        break;

                    case "j":
                        Kontrollo(KeyJ, fjala);
                        break;

                    case "k":
                        Kontrollo(KeyK, fjala);
                        break;

                    case "l":
                        Kontrollo(KeyL, fjala);
                        break;

                    case "m":
                        Kontrollo(KeyM, fjala);
                        break;

                    case "n":
                        Kontrollo(KeyN, fjala);
                        break;

                    case "o":
                        Kontrollo(KeyO, fjala);
                        break;

                    case "p":
                        Kontrollo(KeyP, fjala);
                        break;

                    case "q":
                        Kontrollo(KeyQ, fjala);
                        break;

                    case "r":
                        Kontrollo(KeyR, fjala);
                        break;

                    case "s":
                        Kontrollo(KeyS, fjala);
                        break;

                    case "t":
                        Kontrollo(KeyT, fjala);
                        break;

                    case "u":
                        Kontrollo(KeyU, fjala);
                        break;

                    case "v":
                        Kontrollo(KeyV, fjala);
                        break;

                    case "w":
                        Kontrollo(KeyW, fjala);
                        break;

                    case "x":
                        Kontrollo(KeyX, fjala);
                        break;

                    case "y":
                        Kontrollo(KeyY, fjala);
                        break;

                    case "z":
                        Kontrollo(KeyZ, fjala);
                        break;


                    default:
                        Console.WriteLine($"fusni nje fjale tjt {fjala}");
                        break;


                }

            }

         

            
            Hashtable hashtable = new Hashtable
            {
                { "a", KeyA },
                { "b", KeyB },
                { "c", KeyC },
                { "d", KeyD },
                { "e", KeyE },
                { "f", KeyF },
                { "g", KeyG },
                { "h", KeyH },
                { "i", KeyI },
                { "j", KeyJ },
                { "k", KeyK },
                { "l", KeyL },
                { "m", KeyM },
                { "n", KeyN },
                { "o", KeyO },
                { "p", KeyP },
                { "q", KeyQ },
                { "r", KeyR },
                { "s", KeyS },
                { "t", KeyT },
                { "u", KeyU },
                { "v", KeyV },
                { "w", KeyW },
                { "x", KeyX },
                { "y", KeyY },
                { "z", KeyZ },
            };
            var orderedKeys = hashtable.Keys.Cast<string>().OrderBy(c => c);//Afishon hashtable
            int count = 0;
            foreach (string key in orderedKeys)
            {
                if ((hashtable[key] as List<string>).Count > 0)
                {
                    foreach (string word in hashtable[key] as List<string>)
                    {
                        count++;
                        Console.WriteLine(word);
                    }

                }
            }
            Console.WriteLine("Sasia eshte " + count);
            // Stop timing.
            stopwatch.Stop();
            // Write result.
            Console.WriteLine("Time elapsed: {0}", stopwatch.Elapsed);

            Console.ReadKey();

           
        }

        public static List<string> ReadFile()//Lexon skedarin dhe mbush nje liste me gjith fjalet
        {
             List<string> list = new List<string>();
            //StreamReader sr = new StreamReader();
            // using (StreamReader sr = new StreamReader(Environment.CurrentDirectory + ""))
            //@" C: \Users\Markel\Desktop\detyrakusitc++\GeneratorWord\WriteLines2.txt"
            //  public  static readonly string sr = @"C:\Users\Markel\Desktop\detyrakusitc++\GeneratorWord\WriteLines2.txt";

            var fileStream = new FileStream(@"C:\Users\Markel\Desktop\detyrakusitc++\GeneratorWord\WriteLines2.txt", FileMode.Open, FileAccess.Read);
            using (var streamReader = new StreamReader(fileStream, Encoding.UTF8))
            {
                string line;
                while ((line = streamReader.ReadLine()) != null)   
               
                {
                    string[] words = line.Split(' ');

                    foreach (string word in words)


                        list.Add(word);
                }
            }
            return list;
        }

        public static string Gjejcels(string fjala)
        {
            string celsi = string.Empty;
            if (!string.IsNullOrEmpty(fjala))
            {
                celsi = fjala.Substring(0, 1).ToLower();
                //Console.WriteLine($"Karakteri{celsi}");
                return celsi;
            }
            return celsi;
        }
        public static int Search(string fjala ,List<string> list)
       
        {
          int returnValue = 0;
          foreach(string word in list)
            {
                if (word.ToLower() == fjala.ToLower())
                {
                    returnValue = 1;
                    break;
                }
                
                   
            }
          return returnValue;
        }

        public static void Kontrollo(List<String> lista, string fjala)
        {
           
            if(lista.Count == 0)
            {
                lista.Add(fjala);
            }
            else
            {
                foreach (string word in lista)
                {
                    if (Search(fjala, lista) == 0)
                    {
                        lista.Add(fjala);
                        break;
                    }
                }
            };
        }
        #region provgjenerimi
        //public static List<string> GenerateWords(int num_wordss)
        //{

        //    List<string> listwithRandomStrings = new List<string>();
        //    // Get the number of words and letters per word.
        //    int num_letters = 6;
        //    int num_words = num_wordss;

        //    // Make an array of the letters we will use.
        //    char[] letters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();

        //    // Make a random number generator.
        //    Random rand = new Random();

        //    // Make the words.
        //    for (int i = 1; i <= num_words; i++)
        //    {
        //        // Make a word.
        //        string word = "";
        //        for (int j = 1; j <= num_letters; j++)
        //        {
        //            // Pick a random number between 0 and 25
        //            // to select a letter from the letters array.
        //            int letter_num = rand.Next(0, letters.Length - 1);

        //            // Append the letter.
        //            word += letters[letter_num];
        //        }

        //        // Add the word to the list.
        //        listwithRandomStrings.Add(word);
        //    }
        //    return listwithRandomStrings;
        //}

        #endregion
    }
}
