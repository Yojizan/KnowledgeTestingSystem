﻿using System.Collections.Generic;

namespace BLL.Models
{
    public class Test
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public Subject Subject { get; set; }
        public ICollection<Question> Questions { get; set; }
    }
}
