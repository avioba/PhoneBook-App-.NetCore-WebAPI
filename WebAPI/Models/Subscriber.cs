using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Models
{
    public class Subscriber
    {
        [Key]
        public int id { get; set; }
        [Required]
        [Column(TypeName="nvarchar(100)")]
        public string family { get; set; }
        [Column(TypeName = "nvarchar(100)")]
        public string phone1 { get; set; }
        [Column(TypeName = "nvarchar(100)")]
        public string phone2 { get; set; }
        [Column(TypeName = "nvarchar(100)")]
        public string phone3 { get; set; }
        [Column(TypeName = "nvarchar(100)")]
        public string pobox { get; set; }
    }
}
