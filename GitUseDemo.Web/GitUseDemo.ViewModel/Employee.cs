using System;

namespace GitUseDemo.ViewModel
{
    public class Employee:BaseModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
    }
}
