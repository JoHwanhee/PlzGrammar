using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json.Linq;
using PlzGrammarCore.Model;

namespace PlzGrammarCore
{
    public class ProblemManager
    {
        #region Singleton
        private static readonly Lazy<ProblemManager> Lazy =
            new Lazy<ProblemManager>(() => new ProblemManager());

        public static ProblemManager Instance => Lazy.Value;
        #endregion

        private ProblemManager()
        {
            LoadProblems();
        }

        private void LoadProblems()
        {
            string jsonFile = @"./DataBase/problems.json";
            var jsonString = File.ReadAllText(jsonFile);
            JArray problemArray = JArray.Parse(jsonString);

            foreach (var problem in problemArray)
            {
                _problems.Add(Problem.Create(problem.ToString()));
            }
        }

        private readonly List<Problem> _problems = new List<Problem>();
        private readonly Dictionary<string, User> _userDictionary = new Dictionary<string, User>();
        private readonly Random _random = new Random();

        private List<string> ExtractAllProblemIds()
        {
            List<string> problemIds = new List<string>();
            foreach (var problem in _problems)
            {
                problemIds.Add(problem.Id);
            }

            return problemIds;
        }

        public Problem GetRandomProblemByDeviceId(string deviceId)
        {
            if (!_userDictionary.TryGetValue(deviceId, out _))
            {
                _userDictionary[deviceId] = new User(Guid.NewGuid().ToString(), deviceId, ExtractAllProblemIds());
            }

            var unSolvedList = _userDictionary[deviceId].UnSolvedProblemIdList;
            var problemCountMax = unSolvedList.Count;
            var problemIdToSolve = unSolvedList[_random.Next(0, problemCountMax)];

            return GetProblem(problemIdToSolve);
        }

        public bool SolveProblem(string deviceId, string problemId, string answerByUser)
        {
            var problem = _problems.Find(p =>
                p.Id == problemId
            );

            if (problem.Answer == answerByUser)
            {
                _userDictionary[deviceId].Correct(problemId);
                return true;
            }

            _userDictionary[deviceId].UnCorrect(problemId);
            return false;
        }

        public Problem GetProblem(int problemIndex)
        {
            if (_problems.Count < problemIndex)
            {
                return new DefaultProblem();
            }

            if (problemIndex < 0)
            {
                return new DefaultProblem();
            }

            return _problems[problemIndex];
        }

        public Problem GetProblem(string problemIndex)
        {
            if (!int.TryParse(problemIndex, out var index))
            {
                index = -1;
            }

            return GetProblem(index);
        }
    }
}