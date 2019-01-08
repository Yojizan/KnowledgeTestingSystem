using System;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity.EntityFramework;
using DAL.EF;
using DAL.Entities;
using DAL.Identity;
using DAL.Interfaces;

namespace DAL.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private KnowledgeTestingSystemDbContext db;
        private ApplicationUserManager userManager;
        private ApplicationRoleManager roleManager;
        private IRepository<UserProfile> userProfilesRepository;
        private IRepository<Subject> subjectsRepository;
        private IRepository<Test> testsRepository;
        private IRepository<Question> questionsRepository;
        private IRepository<Answear> answearsRepository;
        private IRepository<CompletedTest> completedTestsRepository;
        private IRepository<CompletedQuestion> completedQuestionsRepository;

        public UnitOfWork(string connectionString)
        {
            db = new KnowledgeTestingSystemDbContext(connectionString);
        }

        public ApplicationUserManager UserManager
        {
            get
            {
                if(userManager == null)
                {
                    userManager = new ApplicationUserManager(new UserStore<ApplicationUser>(db));
                }
                return userManager;
            }
        }

        public ApplicationRoleManager RoleManager
        {
            get
            {
                if(roleManager == null)
                {
                    roleManager = new ApplicationRoleManager(new RoleStore<ApplicationRole>(db));
                }
                return roleManager;
            }
        }

        public IRepository<UserProfile> UserProfilesRepository
        {
            get
            {
                if(userProfilesRepository == null)
                {
                    userProfilesRepository = new Repository<UserProfile>(db);
                }
                return userProfilesRepository;
            }
        }

        public IRepository<Subject> SubjectsRepository
        {
            get
            {
                if(subjectsRepository == null)
                {
                    subjectsRepository = new Repository<Subject>(db);
                }
                return subjectsRepository;
            }
        }

        public IRepository<Test> TestsRepository
        {
            get
            {
                if (testsRepository == null)
                {
                    testsRepository = new Repository<Test>(db);
                }
                var s = testsRepository.GetAll();
                return testsRepository;
            }
        }

        public IRepository<Question> QuestionsRepository
        {
            get
            {
                if (questionsRepository == null)
                {
                    questionsRepository = new Repository<Question>(db);
                }
                return questionsRepository;
            }
        }

        public IRepository<Answear> AnswearsRepository
        {
            get
            {
                if (answearsRepository == null)
                {
                    answearsRepository = new Repository<Answear>(db);
                }
                return answearsRepository;
            }
        }

        public IRepository<CompletedTest> CompletedTestsRepository
        {
            get
            {
                if (completedTestsRepository == null)
                {
                    completedTestsRepository = new Repository<CompletedTest>(db);
                }
                return completedTestsRepository;
            }
        }

        public IRepository<CompletedQuestion> CompletedQuestionsRepository
        {
            get
            {
                if (completedQuestionsRepository == null)
                {
                    completedQuestionsRepository = new Repository<CompletedQuestion>(db);
                }
                return completedQuestionsRepository;
            }
        }

        public async Task SaveAsync()
        {
            await db.SaveChangesAsync();
        }

        public void Dispose()
        {
            Dispose(true);
        }

        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if(this.disposed == false)
            {
                if(disposing)
                {
                    db.Dispose();
                }
            }
        }
    }
}
