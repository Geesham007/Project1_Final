using System;
using System.Collections.Generic;
using System.Text;

namespace Project1_Final
{
    public static class MainMenu
    {


        static List<string> GuestMenu = new List<string>()
            {"Experience / Job History",  "Education / Training",  "Skills", "Technological Skills"};

        public static void getChosenValue(int i)
        {
            if (i == (int)user.Admin)
            {
                //Admin
                Console.WriteLine("Admin");
                AdminMenuList();

            }

            else if (i == (int)user.Guest)
            {
                //Guest
                Console.WriteLine("\nHello. My name is Geesham Hosanee. I was a student in BSc(Hons) Computer Science.\n");
                GuestMenuList();
            }
        }

        public static void GuestMenuList()
        {
            var valueChosen = Validation.verifyValue(GuestMenu);

            if (valueChosen == -1) { userMode.SelectUserMode(); }
            else { GuestModeOperations.setChosevalue(valueChosen); }
        }

        public static void AdminMenuList()
        {
            var valueChosen = Validation.verifyValue(GuestMenu);

            if (valueChosen == -1) { userMode.SelectUserMode(); }
            else { AdminOperations.setChosevalue(valueChosen); }
        }

    }
}
