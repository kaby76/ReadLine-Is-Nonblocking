using System;
using System.Collections.Generic;

namespace r
{
    class Program
    {
        static void Main(string[] args)
        {
            //bool first = true;
            List<string> lines = new List<string>();
            for (; ; )
            {
                var s = System.Console.ReadLine();
                if (s == null)
                {
                    //if (lines.Count == 0 && first)
                    //    continue;
                    break;
                }
                lines.Add(s);
            }
            System.Console.WriteLine("Got " + String.Join(" ", lines));
        }
    }
}
