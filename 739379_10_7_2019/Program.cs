using System;
using System.Collections.Generic;
using System.IO;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _739379_10_7_2019
{
    
    
    class Program
    {
        //static void Main(string[] args)
        //{
        //    var tp = new TextProcessing();
        //    tp.Run();
        //    Console.ReadKey();
        //}
    }

    class TextProcessing
    {
        Queue<string> names = new Queue<string>();

        
        public void Run()
        {

            // Open the names file and access the data

            using (StreamReader file = new StreamReader("D:/CSHARP/739379_10_7_2019/739379_10_7_2019/Names.txt"))
            {
                int counter = 0;
                string ln;

                while ((ln = file.ReadLine()) != null)
                {
                    //Console.WriteLine(ln);
                    names.Enqueue(ln);
                    counter++;
                }
                //Printing names for queue

                foreach (Object obj in names)
                {
                    Console.WriteLine(obj);

                }

                //closing file
                file.Close();
                Console.WriteLine($"File has {counter} lines.");

                // Calling Functions Using Class
                Stack<string> nameStack = PlayingWithStacks.Run(names);
                LinkedList<string> namesList = PlayingWithLinkedList.Run(nameStack);
                PlayingWithLinkedList.Sort(namesList);

            }

        }
    }
    class PlayingWithStacks
    {
        static Stack<string> nameStack = new Stack<string>();
        public static Stack<string> Run(Queue<string> tangerine)
        {
            //Stack<string> nameStack = new Stack<string>();
            // how can I access the Queue variables "names" here in this class???
            // iterate OVER our Queue 
            // get each element
            // push it into the Stack
            //foreach (Object item in tangerine)
            //{
            //    while (tangerine.Count() > 0)
            //        nameStack.Push(tangerine.Dequeue());
            //}

            for (int i = 0; i < tangerine.Count(); i++)
            {
                nameStack.Push(tangerine.Dequeue());
                i--;
            }
            foreach (var itm in nameStack)
                Console.Write(itm + ", ");

            return nameStack;

        }
    }
    class PlayingWithLinkedList
    {
        static LinkedList<string> namesList = new LinkedList<string>();
        public static LinkedList<string> Run(Stack<string> tangerine)
        {
            //LinkedList<string> namesList = new LinkedList<string>();

            while (tangerine.Count() > 0)
            {
                namesList.AddFirst(tangerine.Pop());

            }
            Console.WriteLine("______________________________");
            foreach (var itm in namesList)
                Console.Write(itm + ", ");

            return namesList;

        }
        // Sort Method For Linked List
        public static void Sort(LinkedList<string> listsort)
        {
            Console.WriteLine("______________________________");
            foreach (var itm in listsort.OrderBy(i => i))
                Console.Write(itm + ", ");
        }
    }
    //class Node
    //{
    //    public Node nextLink;
    //    public Node prevLink;
    //    public string nodeName;
    //}

    //class LinkedList
    //{
    //    Node Head, Orange, Tangerine, Tail;
    //    public void CreateLinkedList()
    //    {
    //        Head = new Node();
    //        Head.nextLink = Orange();
    //    }
    //}

}
