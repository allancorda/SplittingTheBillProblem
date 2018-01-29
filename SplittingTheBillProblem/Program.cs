using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SplittingTheBillProblem
{
    class Program
    {
        static void Main(string[] args)
        {
            TextFileManager tfm = new TextFileManager();

            Console.WriteLine("Enter file name (Extension not needed and Case Sensitive i.e expenses)");
            string fileName = Console.ReadLine();
            string pathReadFile = Path.GetDirectoryName(Path.GetDirectoryName(System.IO.Directory.GetCurrentDirectory())) + "\\TextFileInput\\" + fileName + ".txt";
            

            while (!File.Exists(pathReadFile))
            {
                Console.WriteLine("file does not exist. please try again:");
                fileName = Console.ReadLine();
                pathReadFile = Path.GetDirectoryName(Path.GetDirectoryName(System.IO.Directory.GetCurrentDirectory())) + "\\TextFileInput\\" + fileName + ".txt";
            }

            string pathWriteFile = Path.GetDirectoryName(Path.GetDirectoryName(System.IO.Directory.GetCurrentDirectory())) + "\\TextFileOutput\\" + fileName + ".txt.out";

            IDictionary<int, TripExpense> result = tfm.GetTripExpense(pathReadFile);
            tfm.WriteToFile(result, pathWriteFile);
            Console.WriteLine("------------- Task Completed ----------------");
            Console.ReadLine();
        }
    }
}
