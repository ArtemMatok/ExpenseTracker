using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;

namespace Expense_Tracker.Models
{
    public class Transaction
    {
        [Key]
        public int TransactionId { get; set; }

        #region Category
            public int CategoryId { get; set; }
            public Category? Category { get; set; }
        #endregion


        public int Amount { get; set; }
        [Column(TypeName ="nvarchar(75)")]
        public string? Note { get; set; }
        public DateTime Date { get; set; } = DateTime.Now;

        [NotMapped]
        public string? CategoryTitleWithIcon 
        { 
            get
            {
                return Category == null ? "" : Category.Icon + " " + Category.Title;
            }
        }


        [NotMapped]
        public string? FormatAmount
        {
            get
            {
                return ((Category == null || Category.Type=="Expense") ? "- " : "+ ")+Amount.ToString("C", new CultureInfo("uk-UA"));
            }
        }
    }
}
