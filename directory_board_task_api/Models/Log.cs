using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace directory_board_task_api.Models
{
    public class Log
    {
        [DisplayName("Log ID")]
        public int Id { get; set; }

        [DisplayName("Directory ID")]
        public int? DirectoryId { get; set; }

        [DisplayName("Field")]
        [StringLength(50)]
        public string Field { get; set; }

        [DisplayName("From")]
        [StringLength(50)]
        public string From { get; set; }

        [DisplayName("To")]
        [StringLength(50)]
        public string To { get; set; }

        [DisplayName("Logged")]
        public DateTime Date { get; set; }

    }
}