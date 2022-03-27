using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SchoolManagementSystem.Models
{
    public class generateFeeSlipModel
    {
        public int fee_slip_id { get; set; }
        public DateTime created_date { get; set; }
        public int slip_no { get; set; }
        public int class_id { get; set; }
        public int month { get; set; }
        public int status { get; set; }
        public int active { get; set; }
        public int craeted_by { get; set; }
        public decimal total_amount { get; set; }
        public int company_id { get; set; }
        public int total_student { get; set; }
        public int fees { get; set; }

    }
}