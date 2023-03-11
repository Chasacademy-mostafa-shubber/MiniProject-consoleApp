using MiniProject.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniProject.Models
{
    public class Menu
    {
        //Variable from databse class
        DatabaseAccess dbAccess = new DatabaseAccess();
      

        //Menu with 3 options
         public void MainMenu()
        {
            Console.Clear();
            Console.WriteLine("1. Add new person");
            Console.WriteLine("2. Add new project");
            Console.WriteLine("3. Add person to the project");

            while (true)
            {
                string select = Console.ReadLine();

                if(select == "1")
                {
                    Console.Clear();
                    dbAccess.AddPerson();
                    ReturnToMainMenu();
                    
                }
                else if(select == "2")
                {
                    Console.Clear();
                    dbAccess.AddProject();
                    ReturnToMainMenu();
                }
                else if(select == "3")
                {
                    Console.Clear();
                    dbAccess.AddPersonAndProject();
                    ReturnToMainMenu();
                }
            }
        }

        //Return to main menu if you press enter
        public void ReturnToMainMenu()
        {
            if (Console.ReadKey().Key == ConsoleKey.Enter)
            {
                MainMenu();
            }
        }
    }
}
