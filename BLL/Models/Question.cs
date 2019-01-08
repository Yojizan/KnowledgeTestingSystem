using System.Collections.Generic;

namespace BLL.Models
{
    public class Question
    {
        public string Text { get; set; }
        public ICollection<Answear> Answears { get; set; }
    }
}
