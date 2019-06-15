using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lista
{
    public class Node
    {
        public Node Pas;
        public string Vlera;
    }

    public class LinkedList
    {
        private Node head;

        public void printAllNodes()
        {
            Node current = head;
            while (current != null)
            {
                Console.WriteLine(current.Vlera);
                current = current.Pas;
            }
        }

        public void AddFirst(string data)
        {
            Node toAdd = new Node();

            toAdd.Vlera = data;
            toAdd.Pas = head;

            head = toAdd;
        }

        public void AddEnd(string x)
        {
            if (Search(x) == false)
            {
                Node tmp = new Node();
                tmp.Vlera = x;
                tmp.Pas = null;

                Node p = head;

                while (p.Pas != null)
                {
                    p = p.Pas;
                }

                p.Pas = tmp;
            }

        }

        public bool Search(string fjala)
        {
            Node tmp = head;
            while (tmp.Pas != null)
            {
                if (tmp.Vlera == fjala)
                    return true;
                else
                    tmp = tmp.Pas;

            }
            return false;
        }


    }

    class Program
    {
        static void Main(string[] args)
        {

            LinkedList myList1 = new LinkedList();
            int c = 1;
            // Create new stopwatch.
            Stopwatch stopwatch = new Stopwatch();
            // Begin timing.
            stopwatch.Start();
            
            var fileStream = new FileStream(@"C:\Users\Markel\Desktop\detyrakusitc++\GeneratorWord\WriteLines2.txt", FileMode.Open, FileAccess.Read);
            using (var streamReader = new StreamReader(fileStream, Encoding.UTF8))
            {
                string line;
                do
                {
                    line = streamReader.ReadLine();

                    if ((line != null))
                    {

                        string[] words = line.Split(' ');
                        foreach (string word in words)
                        {
                            if (c == 1)
                            {
                                myList1.AddFirst(word);
                                c++;
                            }
                            else
                            {
                                myList1.AddEnd(word);
                            }

                        }


                    }
                } while (!(line == null));
                streamReader.Close();

                myList1.printAllNodes();
                // Stop timing.
                stopwatch.Stop();

                // Write result.
                Console.WriteLine("Time elapsed: {0}", stopwatch.Elapsed);
                Console.ReadLine();
            }
        }
    }
}

