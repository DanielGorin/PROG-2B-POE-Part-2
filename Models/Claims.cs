using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROG_2B_POE_Part_2.Models
{
    public class Claims
    {
        [Key]
        public int ClaimId { get; set; }
        public string ClaimantName { get; set; } //will infuture be integrated to the lecture table
        public decimal HourlyRate { get; set; }
        public int HoursWorked { get; set; }
        public string ClaimantComments { get; set;}
        public DateOnly DateLogged { get; set; }
        public string UploadedFiles { get; set; }//will infuture be updated to facilitate uploading of files for now just text
        public string Status { get; set; }
    }
}
