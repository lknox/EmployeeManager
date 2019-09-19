using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Employee_Manager
{
    public class EmployeeMetaData
    {
        public int EmployeeId { get; set; }

        public int DepartmentId { get; set; }

        [Required(ErrorMessage = "First Name is required.")]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last Name is required.")]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Work Phone is required.")]
        [Display(Name = "Work Phone")]
        public string WorkPhone { get; set; }

        [Required(ErrorMessage = "Desk Location is required.")]
        [Display(Name = "Desk Location")]
        public string DeskLocation { get; set; }

        [Required(ErrorMessage = "Phone is required.")]
        [Display(Name = "Home Phone")]
        public string HomePhone { get; set; }

        [Required(ErrorMessage = "Address 1 is required.")]
        [Display(Name = "Address 1")]
        public string HomeAddress1 { get; set; }

        [Display(Name = "Address 2")]
        public string HomeAddress2 { get; set; }

        [Required(ErrorMessage = "City is required.")]
        [Display(Name = "City")]
        public string HomeCity { get; set; }

        [Required(ErrorMessage = "State is required.")]
        [Display(Name = "State")]
        public string HomeState { get; set; }

        [Required(ErrorMessage = "Zip is required.")]
        [Display(Name = "Zip")]
        public string HomeZip { get; set; }

        //public virtual Department Department { get; set; }

    }
}
