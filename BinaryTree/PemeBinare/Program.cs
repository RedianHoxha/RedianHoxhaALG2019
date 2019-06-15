using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PemeBinare
{
    public class Node
    {
        public string Vlera { get; set; }
        public Node Majte { get; set; }
        public Node Djathte { get; set; }
        public Node Prindi { get; set; }
        public Node()
        {

        }
        public Node(string fjala)
        {
            this.Vlera = fjala;

        }
    }
    public class BinaryTree
    {
        private Node _root;
        public BinaryTree()
        {
            _root = null;
        }

        public bool Search(Node fjala, Node _root)
        {
            Node tmp = _root;



            if (_root == null)

                return false;

            if (fjala.Vlera == tmp.Vlera)

                return true;

            int krahesimi = String.Compare(fjala.Vlera, _root.Vlera);
            if (krahesimi == -1)


                return this.Search(fjala, tmp.Majte);

            else

                return this.Search(fjala, tmp.Djathte);

        }


        public void Insert(string fjala)
        {

            if (_root == null)
            {
                _root = new Node(fjala);
                return;
            }

            InsertRec(_root, new Node(fjala));
        }
        private void InsertRec(Node root, Node newNode)
        {
            if (root == null)
                root = newNode;

            if (Search(newNode, root) == false)
            {
                int krahesimi = String.Compare(newNode.Vlera.ToLower(), root.Vlera.ToLower());
                if (krahesimi == -1)
                {


                    if (root.Majte == null)
                        root.Majte = newNode;
                    else
                        InsertRec(root.Majte, newNode);

                }
                else
                {
                    if (root.Djathte == null)
                        root.Djathte = newNode;
                    else
                        InsertRec(root.Djathte, newNode);
                }
            }
        }
        private void DisplayTree(Node root)
        {
            if (root == null) return;

            DisplayTree(root.Majte);
            System.Console.Write(root.Vlera + "  ");
            DisplayTree(root.Djathte);
        }
        public void DisplayTree()
        {
            DisplayTree(_root);
        }


    }
    class Program
    {
        public static void Main(string[] args)
        {

            BinaryTree tree = new BinaryTree();
            Node root = new Node();
            // Create new stopwatch.
            Stopwatch stopwatch = new Stopwatch();
            // Begin timing.
            stopwatch.Start();


            // StreamReader sr = new StreamReader(Environment.CurrentDirectory + "\\word10000.txt.txt");
            var fileStream = new FileStream(@"C:\Users\Markel\Desktop\detyrakusitc++\GeneratorWord\WriteLines2.txt", FileMode.Open, FileAccess.Read);
            using (var sr = new StreamReader(fileStream, Encoding.UTF8))
            {
                string line = null;
                do
                {
                    line = sr.ReadLine();

                    if ((line != null))
                    {

                        string[] words = line.Split(' ');
                        foreach (string word in words)
                        {


                            tree.Insert(word);
                        }


                    }
                } while (!(line == null));
                sr.Close();

                tree.DisplayTree();
                Console.WriteLine();
                // Stop timing.
                stopwatch.Stop();

                // Write result.
                Console.WriteLine("Time elapsed: {0}", stopwatch.Elapsed);

                Console.ReadKey();



            }

        }
    }
}

