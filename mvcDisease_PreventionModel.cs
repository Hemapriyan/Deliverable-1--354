using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Mvc.Models
{
    public class mvcDisease_PreventionModel
    {
        public int Prevention_ID { get; set; }

        [Required(ErrorMessage = "This Field is required")]
        public string Prevention_Description { get; set; }
        public Nullable<int> Disease_ID { get; set; }

        public virtual mvcDiseaseModel Disease { get; set; }

    }
}