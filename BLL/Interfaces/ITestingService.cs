using System;
using System.Collections.Generic;
using BLL.Models;

namespace BLL.Interfaces
{
    public interface ITestingService : IDisposable
    {
        IEnumerable<Test> GetTestsByName(string name);
        IEnumerable<Test> GetTestsByDiscipline(string subject);
        IEnumerable<CompletedTest> GetUserCompletedTests(string userName);
        bool DeleteTest(Test test);
        bool CreateCompletedTest(int time, int grade, User user, CompletedTest completedTest);
        bool CreateNewTest(Test test);
    }
}
