using System;
using System.Collections.Generic;
using System.Text;

namespace Project1_Final
{
    public static class userMode
    {


        private static List<string> usersName = new List<string>(){
               "Admin",
               "Guest",
        };


        public static void SelectUserMode()
        {
            int GuestOrAdminValue = Validation.verifyValue(usersName);

            if (GuestOrAdminValue == -1)
            {
                Console.WriteLine("End of program");

            }

            else
            {
                MainMenu.getChosenValue(GuestOrAdminValue);
            }
        }

    }
}
