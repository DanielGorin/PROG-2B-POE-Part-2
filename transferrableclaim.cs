using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROG_2B_POE_Part_2
{
    public class transferrableclaim
    {
        public int ClaimId { get; set; }
        public string ClaimantName { get; set; }
        public decimal HourlyRate { get; set; }
        public int HoursWorked { get; set; }
        public string ClaimantComments { get; set; }
        public DateOnly DateLogged { get; set; }
        public string UploadedFiles { get; set; }
        public string Status { get; set; }

        public void CreateClaim(int id, string name, decimal rate, int worked, string comments, DateOnly date, string file, string stat)
        {
            ClaimId = id;
            ClaimantName = name;
            HourlyRate = rate;
            HoursWorked = worked;
            ClaimantComments = comments;
            DateLogged = date;
            UploadedFiles = file;
            Status = stat;
        }
        public string DisplayClaim()
        {
            return $"{ClaimId.ToString()}, {ClaimantName}, {DateLogged:yyyy-MM-dd}, {Status}";
        }
        public decimal amountOwed()
        {
            return (Math.Round(HoursWorked * HourlyRate, 2));
        }
    }
}
