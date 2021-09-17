using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Project1_Final
{
    class FileOperation
    {

        public void WriteTofile(String inputValue)
        {
            try
            {
                using (StreamWriter file = new StreamWriter(@"C:\Users\p128613\source\repos\Project1_Final\Project1_Final\CV_Final.csv", true))
                {
                    file.WriteLine(inputValue);
                }
               
            }
            catch (Exception ex)
            {
                throw new ApplicationException();

            }
        }

        public String[] readFile()
        {
            string path = @"C:\Users\p128613\source\repos\Project1_Final\Project1_Final\CV_Final.csv";
            string[] lines = System.IO.File.ReadAllLines(path);
            return lines;
        }

        public void WriteAllLines(String[] linesInFile) => System.IO.File.WriteAllLines(@"C:\Users\p128613\source\repos\Project1_Final\Project1_Final\CV_Final.csv", linesInFile);

    }
}
