using System;
using System.Collections.Generic;
using System.Text;

namespace Project1_Final
{
    public static class GuestModeOperations
    {

        public static void setChosevalue(int value)
        {
            var lines = new FileOperation().readFile();

            if (value == (int)Fields.Experience)
            {
                EducationORExperienceReading("Experience", lines);
                //call to class
                //IMenuCVDetails Menu1 = new Experience();
                //Menu1.view(lines);
            }

            if (value == (int)Fields.Education)
            {
                EducationORExperienceReading("Education", lines);
            }

            if (value == (int)Fields.Skills)
            {
                OtherDetails("Skills", lines);
            }

            if (value == (int)Fields.Technological_Skills)
            {
                OtherDetails("Technological Skills", lines);
            }

            if (value == (int)Fields.Contact_Detail)
            {
                OtherDetails("Contact_Details", lines);
            }
        }


        public static void EducationORExperienceReading(String Specific_Detail_In_CV, String[] linesInFile)
        {

            List<string> ExperienceOrEducation = new List<string>();
            List<String> ExperienceOrEducationDescription = new List<String>();

            foreach (string line in linesInFile)
            {
                string[] columns = line.Split(',');
                if (columns[0] == Specific_Detail_In_CV)
                {
                    StringBuilder concatenation = new StringBuilder();
                    concatenation.Append(columns[1] + "( ");


                    var numOfYear = (columns[0] == "Experience") ? 3 : 2; // 3 and 2 represents postion of year in Experience Line and in Education line respectively.
                    for (int i = 2; i <= numOfYear; i++)
                    {
                        concatenation.Append(columns[i] + " ");
                    }

                    concatenation.Append(") ");

                    ExperienceOrEducation.Add(concatenation.ToString());


                    concatenation.Remove(0, concatenation.Length - 1);
                    numOfYear++;

                    for (int i = numOfYear; i < columns.Length; i++)
                    {
                        concatenation.Append(columns[i] + ' ');
                    }

                    ExperienceOrEducationDescription.Add(concatenation.ToString());
                }
            }
            int valueChosen = 0;
            while (valueChosen != -1)
            {
                valueChosen = Validation.verifyValue(ExperienceOrEducation);
                if (valueChosen != -1) Console.WriteLine($"Description: {ExperienceOrEducationDescription[valueChosen - 1]}");
            }

            MainMenu.GuestMenuList();

        }

        public static void OtherDetails(String Specific_Detail_In_CV, String[] linesInFile)
        {
            foreach (string line in linesInFile)
            {
                string[] columns = line.Split(',');
                if (columns[0] == Specific_Detail_In_CV)
                {
                    Console.WriteLine($"{line}\n");

                }
            }
            MainMenu.GuestMenuList();

        }
    }
}
