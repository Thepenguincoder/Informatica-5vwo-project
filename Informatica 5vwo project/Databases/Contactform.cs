using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Informatica_5vwo_project.Databases
{
    public class Contactform
    {
        [Required(ErrorMessage = "Het invullen van uw e-mailadress is verplicht")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Het invullen van een bericht is verplicht")]
        public string Bericht { get; set; }
    }
}

