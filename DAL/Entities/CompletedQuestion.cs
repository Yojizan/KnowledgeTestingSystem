using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace DAL.Entities
{
    public class CompletedQuestion
    {
        [Key]
        public int Id { get; set; }
        public virtual Question Question { get; set; }
        public virtual Answear ChoosedAnswear { get; set; }
    }
}
