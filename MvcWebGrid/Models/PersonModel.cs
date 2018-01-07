using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace MvcWebGrid.Models
{
    public class PersonModel
    {
        
        [Key]
        public int PersonId { get; set; }

        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Surname is required")]
        public string Surname { get; set; }
        //[Required(ErrorMessage = "Email is required")]
        //[DataType(DataType.EmailAddress)]

        //[Required]
        //[DataType(DataType.EmailAddress)]
        //[Display(Name = "Email address")]
        //public string Email { get; set; }


        [Required]
        [RegularExpression(@"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$", ErrorMessage = "Please enter a valid e-mail adress")]

        [DataType(DataType.EmailAddress)]
        [Display(Name = "Email address*")]
        public string Email { get; set; }



        //[Required(ErrorMessage = "Description is required")]
        //[StringLength(120, ErrorMessage = "Description Name Not exceed more than 120 words")]
        //public string Description { get; set; }
        //public string Body { get; set; }

      


    }
}