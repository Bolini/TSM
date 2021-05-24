using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace TSM.Models
{
    public class MedlemDetail
    {
        public int Me_ID { get; set; }

        [StringLength(50, MinimumLength = 3, ErrorMessage = " Du måste fylla i minst 3 och maximalt 50 tecken")]
        public string Me_Fornamn { get; set; }

        [StringLength(50, MinimumLength = 2, ErrorMessage = " Du måste fylla i minst 2 och maximalt 50 tecken")]
        public string Me_Efternamn { get; set; }

        [StringLength(50, MinimumLength = 5, ErrorMessage = " Du måste fylla i minst 5 och maximalt 50 tecken")]
        public string Me_Email { get; set; }
        public string Me_Password { get; set; }

        public int checklogin(IFormCollection L, out string errormsg)
        {

            errormsg = "";
            return 1;
        }

        public int GetMember(out string errormsg)
        {
            errormsg = "";
            return 1;
        }
        public int Register(IFormCollection L, out string errormsg)
        {
            errormsg = "";
            return 1;
        }
    }

}



