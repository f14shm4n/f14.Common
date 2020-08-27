using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace f14.Common.Tests.Models
{
    public class ExpressionTestModel
    {
        [Display(Name = "IntType")]
        public int IntType { get; set; }
        [Required]
        public string StringType { get; set; }        
        public List<int> ListOfInt { get; set; }
    }
}
