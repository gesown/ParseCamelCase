using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.RegularExpressions;

namespace ParseCamelCase
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length < 2)
            {
                Console.WriteLine("Usage: ParseCamelCase {file In} {file Out}");
                Console.WriteLine("ParseCamelCase uses the following regex to split each line: '([A-Z][A-Z]*)' at points of uppercase characters.");
                Console.WriteLine("Lines generated produce word arrays then written to lines in the output file seperated by tab characters.");
                return;
            }
         //   string regPattern = "(?<!^)([A-Z][a-z]|(?<=[a-z])[A-Z])"; pickups up cap and following
            var regP1 = "([A-Z][A-Z]*)";
           // Regex regEx = new Regex(regPattern, RegexOptions.None);
            Regex regEx1 = new Regex(regP1, RegexOptions.None);
            string fileIn = args[0];
            StreamReader sr = new StreamReader(fileIn);
            string fileOut = args[1];
            StreamWriter sw = new StreamWriter(fileOut);
            while (!sr.EndOfStream)
            {
                string lineIn = sr.ReadLine();
             //   var wordsOut = regEx.Split(lineIn);
                var w1 = regEx1.Split(lineIn);
                var lineOut = "";
                for (int charIx = 0; charIx < w1.Length - 1; charIx++)
                {
                    lineOut = lineOut + w1[charIx] + '\t' + w1[charIx + 1];
                    charIx++;
                }
                lineOut = lineOut + w1[w1.Length - 1];
                sw.WriteLine(lineOut);
            }
            sr.Close();
            sw.Close();
        }
    }
}
