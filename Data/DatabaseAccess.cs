using Dapper;
using Microsoft.VisualBasic;
using MiniProject.Models;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniProject.Data
{
    public class DatabaseAccess
    {
        //String for the connection to database
        public string ConnectionString { get; set; } = "Server=dev.kjeldcon.se;Port=5432;Userid=monsters;Password=monsters123;Pooling=false;MinPoolSize=1;MaxPoolSize=20;Timeout=15;SslMode=Disable;Database=monsters";
        

        //Get all persons from database
        public  List<Person> GetAllPersons()
        {
            using (IDbConnection con = new NpgsqlConnection(ConnectionString))
            {
                //Get the list order by person_name
                var output = con.Query<Person>("SELECT * FROM mosh_person ORDER BY person_name ASC");

                int index = 0;
                foreach (var item in output)
                {
                    Console.WriteLine($"Index: {index} | Name: {item.person_name}");
                    index++;
                }
                return output.ToList();
            }

        }


        //Get all projects from database
        public  List<Project> GetAllProjects()
        {
            
            using (IDbConnection con = new NpgsqlConnection(ConnectionString))

            {
                //get the list order by project name
                var output = con.Query<Project>("SELECT * FROM mosh_project ORDER BY project_name");
                
                int Index = 0;
                foreach (var item in output)
                {
                    Console.WriteLine($"Index: {Index} | Project: {item.project_name}");
                    Index++;
                }
                return output.ToList();
            }

        }

       
        //Add new person to database
        public  void AddPerson()
        {
            var _person = new Person();
            Console.WriteLine("Choose a name for the person");
            //Choosing a name for the person
            _person.person_name = Console.ReadLine();

            using (IDbConnection con = new NpgsqlConnection(ConnectionString))
            {
                con.Execute("INSERT INTO mosh_person (person_name) VALUES (@person_name)", _person);
            }

            Console.WriteLine($"{_person.person_name} has been added");
            Console.WriteLine("Press enter to return to menu--------------");

        }


        //Add new project to database
        public void AddProject()
        {
            var _project = new Project();
            Console.WriteLine("Choose a name for the project");
            //Choosing a name for the project
            _project.project_name = Console.ReadLine();

            using (IDbConnection con = new NpgsqlConnection(ConnectionString))
            {
                con.Execute("INSERT INTO mosh_project (project_name) VALUES (@project_name)", _project);
            }

            Console.WriteLine($"{_project.project_name} has been added");
            Console.WriteLine("Press enter to return to menu--------------");
        }


        //Add existing person and project to database
        public void AddPersonAndProject()
        {
            Console.WriteLine("List of all person------------------\n");

            //Show all persons from the database
            var ListOfPersons = GetAllPersons();

            Console.WriteLine();
            Console.WriteLine("List of all project------------------\n");

            //Show all project from database
            var ListOfProjects = GetAllProjects();

            Console.WriteLine();

            Console.WriteLine("Select index from person list"); 
            //Select index from the person
            int selectIndexOfPerson = int.Parse(Console.ReadLine());

            Console.WriteLine("Select index from project list");
            //Select index from project
            int selectIndexProject = int.Parse(Console.ReadLine());

            Console.WriteLine("Select hours");
            //select hours to the project
            int hours = int.Parse(Console.ReadLine());

            //Index from the person you selected
            var indexOfPerson = ListOfPersons[selectIndexOfPerson].id;
            //Index from project you selected
            var indexOfProject = ListOfProjects[selectIndexProject].id;

            using (IDbConnection con = new NpgsqlConnection(ConnectionString))
            {
                con.Execute($"INSERT INTO mosh_project_person (project_id, person_id, hours) VALUES ('{indexOfProject}', '{indexOfPerson}', '{hours}')");
            }

            Console.WriteLine();
            Console.WriteLine($"You added {ListOfPersons[selectIndexOfPerson].person_name}, {ListOfProjects[selectIndexProject].project_name} and {hours} hours");

            Console.WriteLine("Press enter to return to menu--------------");
            
        }



    }
}
