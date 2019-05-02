using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Mvc.Models
{
    public class mvcDiseaseModel
    {


        



        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public mvcDiseaseModel()
        {
            this.Disease_Prevention = new HashSet<mvcDisease_PreventionModel>();
        }

        public int Disease_ID { get; set; }

        [Required(ErrorMessage = "This Field is required")]
        public string Disease_Name { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<mvcDisease_PreventionModel> Disease_Prevention { get; set; }

    }
}