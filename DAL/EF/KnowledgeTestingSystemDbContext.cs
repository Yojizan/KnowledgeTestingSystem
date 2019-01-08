using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Collections.Generic;
using DAL.Entities;

namespace DAL.EF
{
    public class KnowledgeTestingSystemDbContext : IdentityDbContext<ApplicationUser>
    {
        public KnowledgeTestingSystemDbContext(string connectionString) : base(connectionString)
        {
            Database.SetInitializer(new KnowledgeTestingSystemDbInitializer());
        }

        public DbSet<UserProfile> UserProfiles { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<Test> Tests { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Answear> Answears { get; set; }
        public DbSet<CompletedTest> CompletedTests { get; set; }
        public DbSet<CompletedQuestion> CompletedQuestions { get; set; }


    }

    public class KnowledgeTestingSystemDbInitializer : DropCreateDatabaseIfModelChanges<KnowledgeTestingSystemDbContext>
    {
        protected override void Seed(KnowledgeTestingSystemDbContext context)
        {
            context.Tests.Add(new Test()
            {
                Id = 0,
                Name = "Basic",
                Subject = new Subject() { Id = 0, Name = "Programming" },
                Description = "Basic questions for c# programmers",
                Questions = new List<Question>() { new Question()
                {
                    Id = 0,
                    Text = "Sample question text1",
                    Answears = new List<Answear>()
                    {
                        new Answear()
                        {
                            Id = 0,
                            Text = "Sample answear text1",
                            Grade = 5
                        },
                        new Answear()
                        {
                            Id = 0,
                            Text = "Sample answear text2",
                            Grade = 0
                        }
                    }
                },
                new Question()
                {
                    Id = 0,
                    Text = "Sample question text2",
                    Answears = new List<Answear>()
                    {
                        new Answear()
                        {
                            Id = 0,
                            Text = "Sample answear text3",
                            Grade = 0
                        },
                        new Answear()
                        {
                            Id = 0,
                            Text = "Sample answear text4",
                            Grade = 4
                        },
                        new Answear()
                        {
                            Id = 0,
                            Text = "Sample answear text5",
                            Grade = 0
                        }
                    }
                }
                }
            });

            base.Seed(context);
        }
    }
}
