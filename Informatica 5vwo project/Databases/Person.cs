using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Informatica_5vwo_project.Databases
{
    public class Person
    {
        [Required(ErrorMessage = "Dit is een verplicht veld")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Dit is een verplicht veld")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Dit is een verplicht veld")]
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        [Required(ErrorMessage = "Dit is een verplicht veld")]
        public string Description { get; set; }
    }
}

