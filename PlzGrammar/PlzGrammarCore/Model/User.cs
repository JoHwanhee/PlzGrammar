using System;
using System.Collections.Generic;
using System.Text;

namespace PlzGrammarCore.Model
{
    class User
    {
        public string UserId { get; }
        public string DeviceId { get; }
        public List<string> UnSolvedProblemIdList { get; } = null;

        public List<string> SolvedProblemIdList { get; } = new List<string>();
        public List<string> WorngProblemIdList { get; } = new List<string>();

        public User(string userId, string deviceId, List<string> problemIdList)
        {
            UserId = userId;
            DeviceId = deviceId;
            UnSolvedProblemIdList = problemIdList;
        }

        public void Correct(string problemId)
        {
            SolvedProblemIdList.Add(problemId);
            UnSolvedProblemIdList.Remove(problemId);
        }

        public void UnCorrect(string problemId)
        {
            WorngProblemIdList.Add(problemId);
            UnSolvedProblemIdList.Remove(problemId);
        }
    }
}
