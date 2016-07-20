using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace RegularExpressionReadText
{
    class Program
    {
        static void Main(string[] args)
        {
            string lineText;
            int cont = 0;

            StreamReader file = new StreamReader(@"in.txt");
            using (StreamWriter newfile = new StreamWriter(@"out.txt"))
            {
                int maxCharacters = Convert.ToInt32(file.ReadLine());
                if (maxCharacters > 0)
                {
                    lineText = file.ReadLine();
                    string pattern = @"\w{1,}.\s|\w{1,}.$";
                    foreach (Match match in Regex.Matches(lineText, pattern))
                    {
                        cont += match.Value.Length;
                        if (cont <= maxCharacters)
                            newfile.Write(match.Value);
                        else
                        {
                            newfile.WriteLine();
                            newfile.Write(match.Value);
                            cont = match.Value.Length;
                        }
                    }
                }
                else
                {
                   Console.WriteLine("Numero inteiro deve ser maior que 0");
                }
                
            }
        }
    }
}
