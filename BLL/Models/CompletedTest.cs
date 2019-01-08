using System.Collections.Generic;

namespace BLL.Models
{
    public class CompletedTest
    {
        public int Grade { get; set; }
        public int Time { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Subject Subject { get; set; }
        public ICollection<CompletedQuestion> CompletedQuestions { get; set; }
    }
}
