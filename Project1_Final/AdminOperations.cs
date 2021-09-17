using System;
using System.Collections.Generic;
using System.Text;

namespace Project1_Final
{
    public static class AdminOperations
    {

       

       static List<string> AdminMenu = new List<string>()
            {"Create",  "Update", "Delete"};

        public static void setChosevalue(int value)
        {
            int OperationChosen = Validation.verifyValue(AdminMenu);
            string FieldValue;

            if (OperationChosen == (int)GOBack.GOBack)
            {
                MainMenu.AdminMenuList();

            }

            if (value == (int)Fields.Experience)//Experience
            {
                FieldValue = "Experience";

                if (OperationChosen == (int)CRUD.AddNewInformation)
                    AppendTofile(FieldValue, CV_AllFields.GetExperience()); 

                else if (OperationChosen == (int)CRUD.Update)
                    UpdateFile(FieldValue, CV_AllFields.GetExperience());

                else if (OperationChosen == (int)CRUD.Delete)
                    Delete(FieldValue);


            }

            else if (value == (int)Fields.Education)
            {

                FieldValue = "Education";
                if (OperationChosen == (int)CRUD.AddNewInformation)
                    AppendTofile(FieldValue, CV_AllFields.GetEducation());

                else if (OperationChosen == (int)CRUD.Update)
                    UpdateFile(FieldValue, CV_AllFields.GetEducation());

                else if (OperationChosen == (int)CRUD.Delete)
                    Delete(FieldValue);

            }//Educaion


            else if (value == (int)Fields.Skills)//skills
            {
                FieldValue = "Skills";

                if (OperationChosen == (int)CRUD.AddNewInformation)
                    AppendTofile(FieldValue, CV_AllFields.GetSkills());

                else if (OperationChosen == (int)CRUD.Update)
                    UpdateFile(FieldValue, CV_AllFields.GetSkills());

                else if (OperationChosen == (int)CRUD.Delete)
                    Delete(FieldValue);
            }

            else if (value == (int)Fields.Technological_Skills)//Technological_Skills
            {
                FieldValue = "Technological Skills";

                if (OperationChosen == (int)CRUD.AddNewInformation)
                    AppendTofile(FieldValue, CV_AllFields.GetTechnological_Skills());
                else if (OperationChosen == (int)CRUD.Update)
                    UpdateFile(FieldValue, CV_AllFields.GetTechnological_Skills());

                else if (OperationChosen == (int)CRUD.Delete)
                    Delete(FieldValue);

            }

            else if (value == (int)Fields.Contact_Detail)//Contact
            {
                FieldValue = "Contact Details";

                if (OperationChosen == (int)CRUD.AddNewInformation)
                    AppendTofile(FieldValue, CV_AllFields.GetContactDetails());

                else if (OperationChosen == (int)CRUD.Update)
                    UpdateFile(FieldValue, CV_AllFields.GetContactDetails());

                else if (OperationChosen == (int)CRUD.Delete)
                    Delete(FieldValue);
            }

            else
            {
                MainMenu.AdminMenuList();
            }

        }

        public static void AppendTofile(String fieldToBeInput, List<string> Values)
        {
            string dummy = null;
            foreach (var value in Values)
            {
                Console.WriteLine($"String so far {fieldToBeInput}");

                Console.WriteLine($"Input {value}");
                if (value.Contains("Many")) Console.WriteLine($"Input  all {value} sperated by comma");

                dummy = Console.ReadLine();
                dummy = Validation.VerifyNullString(dummy);


                if (value.Contains("int"))
                {
                    dummy = Validation.VerifyInteger(dummy);
                }

                if (value.Contains("Year of Education"))
                {
                    dummy = "Year " + dummy;
                }

                fieldToBeInput += "," + dummy;

            }//end of foreach
            new FileOperation().WriteTofile(fieldToBeInput);///Writing to file
            Console.WriteLine("sucessfulinput");
            MainMenu.AdminMenuList();

        }

        public static void UpdateFile(String fieldToBeInput, List<string> fields)
        {
            String[] linesInFile = new FileOperation().readFile();
            List<String> InfomationStored = new List<String>();
            List<int> lineIndex = new List<int>();
            List<List<string>> EachFieldList = new List<List<string>>();

            int index = 0;
            foreach (string line in linesInFile)
            {
                index += 1;
                string[] columns = line.Split(',');
                Console.WriteLine($"value 0 is {columns[0]}");
                if (columns[0] == fieldToBeInput)
                {
                    List<string> newline = new List<string>();
                    InfomationStored.Add(line);
                    lineIndex.Add(index);
                    for (int i = 1; i < columns.Length; i++)
                    {
                        newline.Add(columns[i]);

                    }
                    EachFieldList.Add(newline);

                }
            }

            int valueChosen = Validation.updateValidation(InfomationStored);

            string concatenation = fieldToBeInput;
            int currentFieldInExperience = 0;

            foreach (var NewValue in fields)
            {
                Console.Write($"Input {NewValue} ");
                Console.WriteLine("(Input 'N' for using same value)");
                var x = Console.ReadLine();
                if (x == "N")
                {
                    concatenation += "," + EachFieldList[valueChosen][currentFieldInExperience];
                    if (fields.Count == (currentFieldInExperience + 1))
                    {
                        for (int i = fields.Count; i < EachFieldList[valueChosen].Count; i++)
                        {
                            currentFieldInExperience++;
                            concatenation += "," + EachFieldList[valueChosen][currentFieldInExperience];
                        }
                    }
                }
                else
                {
                    if (NewValue.Contains("int"))
                    {
                        x = Validation.VerifyInteger(x);
                    }
                    concatenation += "," + x;
                }
                currentFieldInExperience++;
            }
            linesInFile[lineIndex[valueChosen] - 1] = concatenation;

            Console.WriteLine(linesInFile[lineIndex[valueChosen] - 1]);

            new FileOperation().WriteAllLines(linesInFile);
            Console.WriteLine("sucessfulinput");
            MainMenu.AdminMenuList();
        }




        public static void Delete(String fieldToBeInput)
        {
            String[] linesInFile = new FileOperation().readFile();
            List<String> InfomationStored = new List<String>();
            List<int> lineIndex = new List<int>();
            int index = 0;
            foreach (string line in linesInFile)
            {
                index += 1;
                string[] columns = line.Split(',');
                if (columns[0] == fieldToBeInput)
                {
                    lineIndex.Add(index);
                    InfomationStored.Add(line);
                }
            }
            int valueChosen = Validation.updateValidation(InfomationStored);
            Console.WriteLine(linesInFile[lineIndex[valueChosen] - 1]);

            linesInFile[lineIndex[valueChosen] - 1] = "";
            Console.WriteLine(linesInFile[lineIndex[valueChosen] - 1]);

            System.IO.File.WriteAllLines(@"C:\Users\p128613\source\repos\Training_Project1_CV\Training_Project1_CV\CV.csv", linesInFile);
            MainMenu.AdminMenuList();
        }


    }
}
