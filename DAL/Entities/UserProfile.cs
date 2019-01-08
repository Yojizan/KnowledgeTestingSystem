using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace DAL.Entities
{
    public class UserProfile
    {
        [Key]
        [ForeignKey("ApplicationUser")]
        public string Id { get; set; }
        public virtual ICollection<CompletedTest> CompletedTests { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }
        public virtual ApplicationRole ApplicationRole { get; set; }
    }
}
