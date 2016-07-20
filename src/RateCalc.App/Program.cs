using System;
using System.IO;

using RateCalc.Engine;

namespace RateCalc.App
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine(File.ReadAllText("market.csv"));
            new Rates().Show();
        }
    }
}
