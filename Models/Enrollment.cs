using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication04G.Models
{
    public class Enrollment
    {
        [Key]
        [ForeignKey("Student")]
        public int StudentId { get; set; }
        public Student Student { get; set; }

        [Display(Name = "Enrollment No")]
        [StringLength(50)]
        public string ENumber { get; set; }

    }
}
