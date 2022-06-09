using System;
using System.Collections.Generic;
using System.Linq;

namespace Implement_Linq
{
    class Program
    {
        static void Main(string[] args)
        {

            //Select With Linq
                string words = "i am studying C# programming language";
                var query = from word in words.Split(" ") select word;
                foreach (var word in query)
                {
                    Console.WriteLine(word);
                }

                int[] numbers1 = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };
                var q1 = from number1 in numbers1 select number1;
                foreach (var number1 in q1)
                {
                    Console.Write($"{number1} ");
                }

                int[] numbers2 = { 1, 3, 5, 7, 9, 7, 6, 5, 4, 3 };
                var q2 = from number1 in numbers1 from number2 in numbers2 where number1 < number2 select new { number1, number2 };
                foreach (var dataQ2 in q2)
                {
                    Console.WriteLine("{0} is less than {1}", dataQ2.number1, dataQ2.number2);
                }

            //OrderBy With Linq
                //ASCENDING  
                var q3 = from num1 in numbers1 orderby num1 select num1;
                Console.WriteLine("The sorted list of words:");
                foreach (var number in q3)
                {
                    Console.WriteLine(number);
                }

                //DESCENDING
                var q4 = from num1 in numbers1 orderby num1 descending select num1;
                Console.WriteLine("The sorted list of words (Descending):");
                foreach (var number in q4)
                {
                    Console.WriteLine(number);
                }


            //Count function With Linq
            var q5 = from num2 in numbers2 select num2;

                //Print Uniq Data
                Console.WriteLine("There are {0} unique factors of 300.", q4.Distinct().Count());

                //Print Count Data
                Console.WriteLine("Count Numbers2 Is: {0}.", q4.Count());

                //Print Data Ganjil
                Console.WriteLine("There are {0} odd numbers in the list.", q4.Count(n => n % 2 == 1));

                //Print Data Genap
                Console.WriteLine("There are {0} even numbers in the list.", q4.Count(n => n % 2 == 0));

            //FIRST With Linq
                var testFirst = q5.First();
                Console.WriteLine("first number is " + testFirst);

            //FIRST OR DEFAULT With Linq
                var testFirstOrDefult = q5.FirstOrDefault();
                Console.WriteLine(testFirstOrDefult);

            //Insert Data Test 
                List<Employee> employees = new List<Employee>();
                List<Project> projects = new List<Project>();
                employees.Add(new Employee
                {
                    EmployeeId = 1,
                    EmployeeName = "Tuba",
                    ProjectId = 100
                });

                employees.Add(new Employee
                {
                    EmployeeId = 2,
                    EmployeeName = "Atul",
                    ProjectId = 101
                });

                employees.Add(new Employee
                {
                    EmployeeId = 3,
                    EmployeeName = "Theran",
                    ProjectId = 101
                });

                projects.Add(new Project
                {
                    ProjectId = 100,
                    ProjectName = "ABC"

                });

                projects.Add(new Project
                {
                    ProjectId = 101,
                    ProjectName = "PQR"

                });

            //GROUP With Linq
                var getData = from employee in employees group employee by employee.ProjectId;
            
                var methodSyntaxGet = employees.GroupBy(e => e.ProjectId);

                Console.WriteLine();
                Console.WriteLine("Group in methodSyntax------");
                foreach (var item in getData)
                {
                    Console.WriteLine(item.Key + ":" + item.Count());
                }

            //Join With Linq
                var querySyntaxGetJoin = from employee in employees
                                    join project in projects on employee.ProjectId equals project.ProjectId
                                    select new { employee.EmployeeName, project.ProjectName };

                var methodSyntaxGetJoin = employees.Join(projects,
                                                  e => e.ProjectId,
                                                  p => p.ProjectId,
                                                  (e, p) => new { e.EmployeeName, p.ProjectName });
                Console.WriteLine();
                Console.WriteLine("Join in methodSyntax------");
                foreach (var item in querySyntaxGetJoin)
                {
                    Console.WriteLine(item.EmployeeName + ":" + item.ProjectName);
                }

            //Left Join With Linq
                var querySyntaxGetLeftJoin = from employee in employees
                                    join project in projects on employee.ProjectId equals project.ProjectId into group1
                                    from project in group1.DefaultIfEmpty()
                                    select new { employee.EmployeeName, ProjectName = project?.ProjectName ?? "NULL" };
                Console.WriteLine();
                Console.WriteLine("Left Join in querySyntax------");
                foreach (var item in querySyntaxGetLeftJoin)
                {
                    Console.WriteLine(item.EmployeeName + ":" + item.ProjectName);
                }



            //Logic Mengurutkan Huruf pertama Kapital
                string words1 = "i aM stuDying c# Programming lanGuage";
                var query1 = words1.Split(" "); ;
                string listData = "";
                for (int i = 0; i < query1.Count(); i++)
                {
                    for (int j = 0; j < query1[i].Count(); j++)
                    {
                        if (j == 0)
                        {
                            listData += query1[i][j].ToString().ToUpper();
                        }
                        else
                        {
                            listData += query1[i][j].ToString().ToLower();
                        }

                    }
                    listData += " ";
                }
                Console.WriteLine("\nKata Pertama Huruf Kapital : " + listData);

            //Logic Mengurutkan Huruf pertama Kapital
            string words2 = "i aM stuDying c# Programming lanGuage";
            var query2 = words2.Split(" "); ;
            string listData1 = "";
            for (int i = 0; i < query2.Count(); i++)
            {
                for (int j = 0; j < query2[i].Count(); j++)
                {
                    if (j == 0 && i == 0)
                    {
                        listData += query2[i][j].ToString().ToUpper();
                    }
                    else
                    {
                        listData += query2[i][j].ToString().ToLower();
                    }

                }
                listData1 += " ";
            }
            Console.WriteLine("\nKata Pertama Huruf Kapital : " + listData1);
        }
    }
}
