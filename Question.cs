namespace FFFWebApplication
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Question
    {
        public int QuestionId { get; set; }
        [Required]
        [Display(Name = "Question")]
        public string QuestionDesc { get; set; }
        [Required]
        [Display(Name = "Answer A")]
        public string QuestionOptionA { get; set; }
        [Required]
        [Display(Name = "Answer B")]
        public string QuestionOptionB { get; set; }
        [Required]
        [Display(Name = "Answer C")]
        public string QuestionOptionC { get; set; }
        [Required]
        [Display(Name = "Answer D")]
        public string QuestionOptionD { get; set; }
        [Required]
        [Display(Name = "Question Set")]
        public int? QuestionSet { get; set; }
    }
}
