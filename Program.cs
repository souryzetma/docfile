using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReaderAndWriterCSV
{
    class Program
    {
        static void Main(string[] args)
        {
            //string desktop = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
            //csvWriter_Example(desktop + @"\test.csv");
            //csvReader_Example(desktop + @"\employees.csv");
            csvWriter_Example(@"test.csv");
            csvReader_Example(@"employees.csv");
            Console.ReadLine();
        }

        static void csvWriter_Example(string path)
        {
            Writer csv = new Writer(path);
            //Header
            string[] header = new string[3];
            header[0] = "\"Name\"";
            header[1] = "\"Age\"";
            header[2] = "\"Street\"";
            //Param
            string[] param = new string[3];
            param[0] = "Jhon";
            param[1] = "23";
            param[2] = "Aldgate";
            //Open file
            csv.Open();
            //Write header
            csv.WriteHeader(header);
            //Write param
            csv.Write(param);
            //Close file
            csv.Close();
        }

        static void csvReader_Example(string path)
        {
            Reader csv = new Reader(path);
            //open file
            csv.Open();
            //Reading loop
            while (true)
            {
                //Get parameters
                string[] parameters = csv.Next();
                if (parameters != null)
                {
                    //Print parameters into console
                    PrintParams(parameters);
                }
                else
                {
                    //end of file
                    break;
                }
            }

        }

        static void PrintParams(string[] parameters)
        {
            for (int i = 0; i < parameters.Length; i++)
            {
                Console.Write(parameters[i] + " ");
            }
            Console.Write(System.Environment.NewLine);
        }
    }
}
