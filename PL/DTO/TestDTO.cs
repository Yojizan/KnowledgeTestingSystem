using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PL.DTO
{
    public class TestDTO
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Subject { get; set; }
        public IEnumerable<QuestionDTO> Questions { get; set; }
    }
}