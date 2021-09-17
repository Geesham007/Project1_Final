using System;
using System.Collections.Generic;
using System.Text;

namespace Project1_Final
{
    class Experience : IMenuCVDetails
    {

        List<string> ExperienceList = new List<string>()
            {"CompanyName",  "StartYear at company(int)",  "EndingYear at company(int)", "Overview"};

        public void view(string[] linesInFile)
        {
            List<string> Experience = new List<string>();
            List<String> ExperienceDescription = new List<String>();

            foreach (string line in linesInFile)
            {
                string[] columns = line.Split(',');
                if (columns[0] == "Experience")
                {
                    string concatenation = null;
                    Experience.Add(columns[1]);
                    for (int i = 2; i < columns.Length; i++)
                    {
                        concatenation += columns[i] + ' ';

                    }
                    ExperienceDescription.Add(concatenation);
                }
            }

            int valueChosen = 0;
            while (valueChosen != -1)
            {
                valueChosen = Validation.verifyValue(Experience);
                if (valueChosen != -1) Console.WriteLine($"Description: {ExperienceDescription[valueChosen - 1]}");
            }

            MainMenu.GuestMenuList();

        }

        public void add()
        {
            string fieldToBeInput = "Experience";
            string dummy;

            foreach (var value in ExperienceList)
            {
                Console.WriteLine($"Input {value}");
                dummy = Console.ReadLine();


                if (value.Contains("StartYear"))
                {
                    dummy = Validation.VerifyInteger(dummy);
                    fieldToBeInput += "(" + dummy + "-";
                }

                else if (value.Contains("EndingYear"))
                {
                    dummy = Validation.VerifyInteger(dummy);
                    fieldToBeInput += dummy + ")";
                }

                else
                {
                    fieldToBeInput += "," + dummy;

                }

            }//end of foreach
            new FileOperation().WriteTofile(fieldToBeInput);///Writing to file
            Console.WriteLine("sucessfulinput");
            MainMenu.AdminMenuList();

        }
        public void update() { }



    }
}
