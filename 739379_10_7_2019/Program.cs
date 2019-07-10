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
        static void Main(string[] args)
        {
            var tp = new TextProcessing();
            tp.Run();
            Console.ReadKey();
        }
    }

    class TextProcessing
    {
        Queue<string> names = new Queue<string>();

        //Stack<string> namesStack = new Stack<string>();
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

                PlayingWithStacks.Run(names);


            }

        }

        class PlayingWithStacks
        {
            public static void Run(Queue<string> tangerine)
            {
                Stack<string> nameStack = new Stack<string>();
                // how can I access the Queue variables "names" here in this class???
                // iterate OVER our Queue 
                // get each element
                // push it into the Stack
                //foreach (Object item in tangerine)
                //{
                //    while (tangerine.Count() > 0)
                //        nameStack.Push(tangerine.Dequeue());
                //}

                for(int i=0; i < tangerine.Count(); i++)
                {
                    nameStack.Push(tangerine.Dequeue());
                    i--;
                }
                foreach (var itm in nameStack)
                    Console.WriteLine(itm);


            }
        }
    }
}
