using System;
using System.Collections.Generic;
using System.Text;

namespace Project1_Final
{
    public static class CV_AllFields
    {
        static List<string> Experience = new List<string>()
            {"CompanyName",  "StartYear at company(int)",  "EndingYear at company(int)", "Overview"};

        static List<string> Education = new List<string>()
            {"Course","Year of Education (1,2,3)(int)",  "Module Many" };

        static List<string> Skills = new List<string>()
            {"skills Many"};

        static List<string> Technological_Skills = new List<string>()
            {"Technological_Skills Many"};

        static List<string> ContactDetails = new List<string>()
            {"Telephone Number(int)",  "Mail"};


        public static List<string> GetExperience() => Experience;


        public static List<string> GetEducation() => Education;


        public static List<string> GetSkills() => Skills;


        public static List<string> GetTechnological_Skills() => Technological_Skills;


        public static List<string> GetContactDetails() => ContactDetails;
    }
}
