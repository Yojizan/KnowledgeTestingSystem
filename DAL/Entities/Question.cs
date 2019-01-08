using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace DAL.Entities
{
    public class Question
    {
        [Key]
        public int Id { get; set; }
        public string Text { get; set; }
        public virtual ICollection<Answear> Answears { get; set; }
    }
}
