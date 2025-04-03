using System;
using System.Collections.Generic;
using System.Text;

namespace LinqExercise
{
    internal class Employee
    {
        //Bellow we have what we call properties 
        public int Age { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName
        {
            get
            {
                return $"{FirstName} {LastName}";
            }
        }
        //Bellow we have years of experice, just an int.
        public int YearsOfExperience { get; set; }
        
        
        
        //Bellow we have a costume constructor 

        public Employee(string firstName, string lastName, int age, int yearsOfExperience)
        {
            FirstName = firstName;
            LastName = lastName;
            Age = age;
            YearsOfExperience = yearsOfExperience;
        }
        
        
        //Bellow we have a default constructor 
        public Employee()
        {
            
        }
    }
}
