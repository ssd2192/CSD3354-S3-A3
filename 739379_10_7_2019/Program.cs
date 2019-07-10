using System;
using System.Collections.Generic;
using System.IO;
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
        }
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
                file.Close();
                Console.WriteLine($"File has {counter} lines.");
            }
        }
    }
}
