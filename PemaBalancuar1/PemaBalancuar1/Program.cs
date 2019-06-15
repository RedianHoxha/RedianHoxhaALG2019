using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// C# program to convert a left unbalanced BST to a balanced BST  
  
/* A binary tree node has data, pointer to left child  
   and a pointer to right child */
//    {
//        public string data;
//        public Node left, right;

//        public Node(string data)
//        {
//            this.data = data;
//            left = right = null;
//        }

//    public Node(string fjala)
//    {
//        this.data = fjala;

//    }
//}

//    public class BinaryTree
//    {
//        public Node _root;


/* This function traverse the skewed binary tree and  
   stores its nodes pointers in vector nodes[] */
//public virtual void storeBSTNodes(Node root, List<Node> nodes)
//{
//    // Base case  
//    if (root == null)
//    {
//        return;
//    }

//    // Store nodes in Inorder (which is sorted  
//    // order for BST)  
//    storeBSTNodes(root.left, nodes);
//    nodes.Add(root);
//    storeBSTNodes(root.right, nodes);
//}
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

    public void cratelist(Node root, List<Node> listamefjale)
    {
        if (root == null)
        {
            return;
        }


        cratelist(root.Majte, listamefjale);
        listamefjale.Add(root);
        cratelist(root.Djathte, listamefjale);
    }

    /* Fux rekrusiv per te ndertu pemen binare*/
    public virtual Node buildTreeUtil(List<Node> nodes, int start, int end)
    {

        if (start > end)
        {
            return null;
        }

        /* Gjejm elementine mesit */
        int mid = (start + end) / 2;
        Node node = nodes[mid];


        node.Majte = buildTreeUtil(nodes, start, mid - 1);
        node.Djathte = buildTreeUtil(nodes, mid + 1, end);

        return node;
    }


    public virtual Node buildTree(Node root)
    {
        // Krijojm Listen   
        List<Node> nodes = new List<Node>();
        cratelist(root, nodes);

        // Ndertojme pemen  
        int n = nodes.Count;
        return buildTreeUtil(nodes, 0, n - 1);
    }

    /* Afishon pemen */
    public virtual void preOrder(Node node)
    {
        if (node == null)
        {
            return;
        }
        Console.Write(node.Vlera + "  ");
        preOrder(node.Majte);
        preOrder(node.Djathte);
    }




    public static void Main(string[] args)
    {

        BinaryTree tree = new BinaryTree();
        Node root = new Node();
        int c = 0;
        // Create new stopwatch.
        Stopwatch stopwatch = new Stopwatch();

        // Begin timing.
        stopwatch.Start();
        //StreamReader sr = new StreamReader(Environment.CurrentDirectory + "\\worddd.txt");
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

                        c++;
                        tree.Insert(word);
                    }


                }
            } while (!(line == null));
            sr.Close();

            tree.preOrder(tree._root);
            Console.WriteLine();
            // Stop timing.
            stopwatch.Stop();
            // Write result.
            Console.WriteLine("Time elapsed: {0}", stopwatch.Elapsed);
            Console.WriteLine(c);

            Console.ReadKey();

        }
    }

}  

