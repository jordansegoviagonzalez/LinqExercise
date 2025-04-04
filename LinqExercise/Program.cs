using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;

namespace LinqExercise
{
    class Program
    {
        //Static array of integers
        private static int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 0 };

        static void Main(string[] args)
        {
            /*
             * 
             * Complete every task using Method OR Query syntax. 
             * You may find that Method syntax is easier to use since it is most like C#
             * Every one of these can be completed using Linq and then printing with a foreach loop.
             * Push to your github when completed!
             * 
             */

            //TODO 1: Print the Sum of numbers
            Console.WriteLine($"Sum: {numbers.Sum()}");
            //'Console.WriteLine' prints output to the console.
            // 'Console.WriteLine() is a method.
            // The '()' are used here because 'Sum' is a method that performs an operation on the array and returns a results.
            // Use parentheses () when calling a method.
            // Don't use parentheses when accessing a property 
            // '$' allows string interpolation to insert values inside the string.
            // 'numbers.Sum()' calculates the sum of all ints in the 'numbers' array.
            
            

            //TODO 2: Print the Average of numbers
            Console.WriteLine($"Average: {numbers.Average()}");
            //Console.WriteLine() is a method.
            //The '()' are used here because 'Average' is a method that performs an operation on the array and returns a result.
            //Use parentheses () when calling a method.
            //'$' allows string interpolation to insert value inside the string.
            //'number.Average()' calculates the aveage value of all numbers in the 'numbers' array.
            

            //TODO 3: Order numbers in ascending order and print to the console
            Console.WriteLine("Number ascending:");
            //The string "Number asc;" is a display to indicate the numbers will be shown in ascending order.
            numbers.OrderBy(x => x).ToList().ForEach(x => Console.WriteLine(x));
            //'numbers.OrderBy(x => x)' sorts the numbers array in ascending order.
            //'OrderBy' is a method, so it uses '()'. It orders elements based on the given key selection 'x => x', which means sorting by itself.
            //'.ToList()' converts the sorted sequence into a list so that the 'ForEach' method can be used.
            //'.ForEach(x => Console.WriteLine(x))' loops though each number in the sorted list and print it to the console.
            //'x => Console.WriteLine(x)' is a lambda expression that takes each number 'x' and prints it .

            //TODO 4: Order numbers in descending order and print to the console
            Console.WriteLine("Number descending:");
            numbers.OrderByDescending(x => x).ToList().ForEach(x => Console.WriteLine(x));
            //Same that we did above just in reverse.

            //TODO 5: Print to the console only the numbers greater than 6
            Console.WriteLine("Greater than six:");
            //'Console.WriteLine' prints output to the console.
            // The string "Greater than six:" indicates that only numbers greater than 6 will printed
            numbers.Where(x => x > 6).ToList().ForEach(x => Console.WriteLine(x)); 
            //'numbers.Where(x => x > 6)' filters the 'numbers' arrays to include only those elements greater than 6.
            //'where' is a LINQ method that applies the ("lambada expression" according to lord google.) 'x => x > 6' to each element.
            //'.ToList()'converts the filtered IEnumerable<int> into a List<int> so that we can use the 'ForEach' method.
            //'.ForEach(x => Console.WriteLine(x))' iterates over each element in the list and prints it to the console.
            

            //TODO 6: Order numbers in any order (ascending or desc) but only print 4 of them **foreach loop only!**
            Console.WriteLine("Less than six:");
            //The string "Less than six:" acts as a heading for the numbers that follow 
            //Using the Console.WriteLine method that prints the specified text to the console.
            
            var orderedNumbers = numbers.Where(x => x < 6).OrderBy(x => x);
            // 'var' is a keyword that lets the compiler automatically determine the variable's type based on the assigned value.
            //'orderdNumbers' is the variable that stores the sorted sequence of numbers.
            //'numbers' is the original array of numbers.
            //'OrderBy(x => x)' sorts the numbers in ascending order using LINQ.

            foreach (var number in orderedNumbers.Take(4))
           //'foreach' is a loop that goes through each item in this case numbers in the collection.
            // 'var' lets the compiler figure out the type of 'number' automatically.
            //'number' is the current item being processed in the loop.
            //'orderedNumbers.Take(4)' retrieves the first 4 numbers from the sorted sequence.
            
            
            {
                Console.WriteLine(number);
                //This method prints the current number in the loop to the console.
            }
            

            //TODO 7: Change the value at index 4 to your age, then print the numbers in descending order
            Console.WriteLine("Index four:");
            //"Index four:" is a heading for the following output.
            numbers.Select((number, index) => index == 4 ? 30 : number).OrderByDescending(x => x).ToList().ForEach(x => Console.WriteLine(x));
            //'numbers.Select' applies a transformation to each element in the 'number' array.
            //'(number, index)' allows access to both the elements 'number' and its index.
            //'index == 4 ? 30 : number' is a conditional operator.
            //if the index is a 4, it replaces that number with 30; otherwise, it keeps the number as is.
            //'OrderByDescending(x => x)' sorts the sequence in descending order based on the value of x.
            //'ToList()' converts the sorted sequence to a list.
            //.ForEach(x => Console.WriteLine(x))' goes thought each number in the list and prints it.
            // List of employees ****Do not remove this****
            //Bellow we have to create a method
            var employees = CreateEmployees();

            //TODO 8: Print all the employees' FullName properties to the console only if their FirstName starts with a C OR an S and order this in ascending order by FirstName.
            var filteredEmployees = employees.Where(x => x.FirstName.StartsWith('C') || x.FirstName.StartsWith('S')).OrderBy(x => x.FirstName);

            foreach (var person in filteredEmployees)
            {
                Console.WriteLine(person.FullName);
            }

            //TODO 9: Print all the employees' FullName and Age who are over the age 26 to the console and order this by Age first and then by FirstName in the same result.
            
            var employeesOver26 = employees.Where(x => x.Age >= 26).OrderBy(x => x.Age).ThenBy(x => x.FirstName);

            foreach (var person in employeesOver26)
            {
                Console.WriteLine($"Name: {person.FullName} {person.Age}");
            }

            //TODO 10: Print the Sum of the employees' YearsOfExperience if their YOE is less than or equal to 10 AND Age is greater than 35.
            var specialFilteredEmployees = employees.Where(x => x.YearsOfExperience <= 10 && x.Age > 35);
            
            Console.WriteLine($"Total years of experience: {specialFilteredEmployees.Sum(x => x.YearsOfExperience)}");

            //TODO 11: Now print the Average of the employees' YearsOfExperience if their YOE is less than or equal to 10 AND Age is greater than 35.
            Console.WriteLine($"Average year of experience: {specialFilteredEmployees.Average(x => x.YearsOfExperience)}");

            //TODO 12: Add an employee to the end of the list without using employees.Add()
            employees = employees.Append(new Employee("Seth", "Bowman", 30, yearsOfExperience: 5)).ToList();
            //Append is a linked method that allows you to add something to the end of the sequence
            
            //Bellow we have a loop, and it will loop though each employee in the 'employees' list,
            

            foreach (var empoyee in employees)
                
            {
                Console.WriteLine(empoyee.FirstName);
                //Console.WriteLine() method will invoke the output to the user. 
                
            }
            


            Console.WriteLine();

            Console.ReadLine();
        }
        
        //Method that was already build for us.

        #region CreateEmployeesMethod
        private static List<Employee> CreateEmployees()
        {
            List<Employee> employees = new List<Employee>();
            employees.Add(new Employee("Cruz", "Sanchez", 25, 10));
            employees.Add(new Employee("Steven", "Bustamento", 56, 5));
            employees.Add(new Employee("Micheal", "Doyle", 36, 8));
            employees.Add(new Employee("Daniel", "Walsh", 72, 22));
            employees.Add(new Employee("Jill", "Valentine", 32, 43));
            employees.Add(new Employee("Yusuke", "Urameshi", 14, 1));
            employees.Add(new Employee("Big", "Boss", 23, 14));
            employees.Add(new Employee("Solid", "Snake", 18, 3));
            employees.Add(new Employee("Chris", "Redfield", 44, 7));
            employees.Add(new Employee("Faye", "Valentine", 32, 10));

            return employees;
        }
        #endregion
    }
}
