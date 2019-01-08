using System;
using System.Threading.Tasks;
using DAL.Identity;
using DAL.Entities;

namespace DAL.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        ApplicationUserManager UserManager { get; }
        ApplicationRoleManager RoleManager { get; }
        IRepository<UserProfile> UserProfilesRepository { get; }
        IRepository<Subject> SubjectsRepository { get; }
        IRepository<Test> TestsRepository { get; }
        IRepository<Question> QuestionsRepository { get; }
        IRepository<Answear> AnswearsRepository { get; }
        IRepository<CompletedTest> CompletedTestsRepository { get; }
        IRepository<CompletedQuestion> CompletedQuestionsRepository { get; }
        Task SaveAsync();
    }
}
