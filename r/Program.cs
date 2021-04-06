using System;
using System.Collections.Generic;

namespace r
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> lines = new List<string>();
            for (; ; )
            {
                var s = System.Console.ReadLine();
                if (s == null)
                {
                    break;
                }
                lines.Add(s);
            }
            System.Console.WriteLine("Got " + String.Join(" ", lines));
        }
    }
}
