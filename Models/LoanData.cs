using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PrjLcApi.Models
{
   
    public class LoanData
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public decimal Id { get; set; }
        public decimal PropertyValue { get; set; }
        public decimal LoanAmount { get; set; }
        public string ?Lvr { get; set; }
    }
}
