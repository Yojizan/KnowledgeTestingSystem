using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace DAL.Entities
{
    public class CompletedTest
    {
        [Key]
        public int Id { get; set; }
        public int Grade { get; set; }
        public int Time { get; set; }
        public virtual Test Test { get; set; }
        public virtual ICollection<CompletedQuestion> CompletedQuestions { get; set; }
    }
}
