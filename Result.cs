namespace FFFWebApplication
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Result
    {
        public int ResultId { get; set; }

        public string Q1Correct { get; set; }

        public decimal? Q1TimeToAnswer { get; set; }

        public string Q2Correct { get; set; }

        public decimal? Q2TimeToAnswer { get; set; }

        public string Q3Correct { get; set; }

        public decimal? Q3TimeToAnswer { get; set; }

        public string Q4Correct { get; set; }

        public decimal? Q4TimeToAnswer { get; set; }

        public string Q5Correct { get; set; }

        public decimal? Q5TimeToAnswer { get; set; }

        public string Q6Correct { get; set; }

        public decimal? Q6TimeToAnswer { get; set; }

        public string Q7Correct { get; set; }

        public decimal? Q7TimeToAnswer { get; set; }

        public string Q8Correct { get; set; }

        public decimal? Q8TimeToAnswer { get; set; }

        public string Q9Correct { get; set; }

        public decimal? Q9TimeToAnswer { get; set; }

        public string Q10Correct { get; set; }

        public decimal? Q10TimeToAnswer { get; set; }

        public int? UserId { get; set; }

        public virtual User User { get; set; }
    }
}
