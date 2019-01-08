using System;
using System.Collections.Generic;
using System.Linq;
using DAL.Interfaces;
using BLL.Models;
using BLL.Interfaces;
using static BLL.Configuration.MapperConfig;

namespace BLL.Services
{
    public class TestingService : ITestingService
    {
        private IUnitOfWork database;

        public TestingService(IUnitOfWork db)
        {
            database = db;
        }

        public bool CreateCompletedTest(int time, int grade, User user, CompletedTest completedTest)
        {
            DAL.Entities.Test test = database.TestsRepository.Find(x => x.Name == completedTest.Name).FirstOrDefault();
            if(test == null)
            {
                return false;
            }
            database.CompletedTestsRepository.Create(new DAL.Entities.CompletedTest()
            {
                Id = 0,
                Time = time,
                Grade = grade,
                CompletedQuestions = Mapper.Map<ICollection<DAL.Entities.CompletedQuestion>>(completedTest.CompletedQuestions),
                Test = test
            });
            return true;
        }

        public bool CreateNewTest(Test test)
        {
            try
            {
                database.TestsRepository.Create(Mapper.Map<DAL.Entities.Test>(test));
            }
            catch(Exception)
            {
                return false;
            }
            return true;
        }

        public bool DeleteTest(Test test)
        {
            DAL.Entities.Test testForDelete = database.TestsRepository.Find(x => x.Name == test.Name).FirstOrDefault();
            if(testForDelete == null)
            {
                throw new NullReferenceException("Delete test doesn't exist");
            }
            try
            {
                database.TestsRepository.Delete(testForDelete.Id);
            }
            catch(Exception)
            {
                return false;
            }
            return true;
        }

        public IEnumerable<Test> GetTestsByDiscipline(string subject)
        {
            return Mapper.Map<IEnumerable<Test>>(database.TestsRepository.Find(x => x.Subject.Name == subject));
        }

        public IEnumerable<Test> GetTestsByName(string name)
        {
            var res = Mapper.Map<IEnumerable<Test>>(database.TestsRepository.Find(x => x.Name == name)); ;
            return res;
        }

        public IEnumerable<CompletedTest> GetUserCompletedTests(string userName)
        {
            return Mapper.Map<IEnumerable<CompletedTest>>(database.UserProfilesRepository
                .Find(x => x.ApplicationUser.UserName == userName).FirstOrDefault().CompletedTests);
        }

        public void Dispose()
        {
            database.Dispose();
        }
    }
}
