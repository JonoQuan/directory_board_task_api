using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace directory_board_task_api.Models
{
    public class Directory
    {
        [DisplayName("Directory ID")]
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter the company name")]
        [DisplayName("Company")]
        [StringLength(50, MinimumLength = 2)]
        public string Company { get; set; }

        [Required(ErrorMessage = "Please enter the level number")]
        [DisplayName("Level")]
        [StringLength(3)]
        public string Level { get; set; }

        [Required(ErrorMessage = "Please enter the suite number")]
        [DisplayName("Suite")]
        [StringLength(4)]
        public string Suite { get; set; }


    }
}