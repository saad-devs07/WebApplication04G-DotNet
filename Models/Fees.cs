using System.ComponentModel.DataAnnotations;
namespace WebApplication04G.Models
{
    public enum SMonth
    {
        Jan, Feb, Mar, Apr, May, June, July, Aug, Sept, Oct, Nov, Dec
    }

    public class Fees
    {
        public int id { get;set; }
        public SMonth SMonth { get; set; }
        public int FAmount { get;set; }
        public DateTime SDate { get;set; }
        public int StudentId { get; set; }
        public Student Student { get; set; }


    }
}
