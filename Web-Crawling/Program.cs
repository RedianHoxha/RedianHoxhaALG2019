using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using HtmlAgilityPack;
using System.Text;
using System.Data.Odbc;
using System.Threading.Tasks;
using System.IO;

namespace WebCrawler
{
    class Program
    {
        public static Dictionary<int, List<string>> allListLinks = new Dictionary<int, List<string>>();
        static void Main(string[] args)
        {
            string path = @"C:\Users\Markel\Desktop\detyrakusitc++\Web-Crawling\linqett.txt";
            int niveli = 2;
            string initialLink = "http://www.fshn.edu.al/";
            SearchMain(niveli, initialLink, path);
            Console.ReadLine();
        }

        private static async void SearchMain(int niveli, string initialLink , string path)
        {
            if (niveli == 1)
            {
                List<string> str = await Search(initialLink);
                allListLinks.Add(1, str);
            }
            else
            {
                int j = 1;
                List<string> str = await Search(initialLink);
                allListLinks.Add(j, str);
                j++;

                for (int i = 1; i < niveli; i++)
                {
                    List<string> lista = new List<string>();
                    foreach (var link in allListLinks[i])
                    {
                        List<string> strList = await Search(link);
                        if(strList.Count>0)
                            lista.AddRange(strList);
                    }

                    allListLinks.Add(j, lista);
                    j++;

                }
            }
            Shkruaj(path);
        }


        public static void Shkruaj(string path)
        {
            using (var stream = File.Create(path))
            {

                using (TextWriter tw = new StreamWriter(stream))
                {
                    for (var i = 0; i < allListLinks.Keys.Count; i++)
                    {
                        foreach (var item in allListLinks[i + 1])
                        {
                            tw.WriteLine(item);
                        }
                    }
                }
            }
    }

        private static async Task<List<string>> Search(string urlkerkimi)
        {

            List<string> linksList = new List<string>();
            try
            {

                var url = urlkerkimi;
                var httpClient = new HttpClient();
                var html = await httpClient.GetStringAsync(url);
                var htmlDocument = new HtmlDocument();
                htmlDocument.LoadHtml(html);

                var divs = htmlDocument.DocumentNode.Descendants("a").ToList();
                string s = string.Empty;
                foreach (var div in divs)
                {
                    if (div.Attributes["href"] != null)
                    {
                        s = div.Attributes["href"].Value;
                    }
                    else
                    {
                        continue;
                    }


                    if (!s.Contains("http"))
                        continue;


                    if (!Gjendet(s, linksList))
                    {
                        linksList.Add(s);
                    }
                }

                return linksList;

            }
            catch (Exception ex)
            {
                return linksList;
            }

        }
        static bool Gjendet(string s, List<string> lista)
        {
            return lista.Contains(s);
        }
    }
}