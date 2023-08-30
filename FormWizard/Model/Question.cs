using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FormWizard.Model
{
    public class Question
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string QuestionText { get; set; }
        public string? QuestionDescription { get; set; }
        public enum QuestionType
        {
            text,
            radio,
            checkbox, 
            number,
            date,
            list
        }
        [Required]
        public QuestionType Type { get; set; }
        public int? OrderOfDisplay { get; set; }
        public bool? Extension { get; set; }
        public string? Value { get; set; }
        [ValidateNever]
        public MyForm MyForm { get; set; }
        [Required]
        public int MyFormId { get; set; }

    }
}
