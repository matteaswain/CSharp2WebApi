using System;
using System.Collections.Generic;
using System.Text;

namespace CSharp2WebApi
{
// created class so we can interact with the employee controller 
    class Employee
    {
        public int Id { get; set; }        
        public string Login { get; set; }       
        public string Password { get; set; }     
        public string Firstname { get; set; }     
        public string Lastname { get; set; }
        public bool IsManager { get; set; } // will default to false so can leave it 
        public Employee()
        {
            // default constructor
        }
    }
}
