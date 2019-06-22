using System;
using System.Collections.Generic;
using PlzGrammarCore.Model;

namespace PlzGrammarCore
{
    class ProblemManager
    {
        private readonly List<Problem> _problems = new List<Problem>();

        private static readonly Lazy<ProblemManager> Lazy =
            new Lazy<ProblemManager>(() => new ProblemManager());

        public static ProblemManager Instance => Lazy.Value;
        private ProblemManager() { }

        public Problem GetRandomProblem()
        {
            Random random = new Random();
            var problemCountMax = _problems.Count;
            return GetProblem(random.Next(0, problemCountMax - 1));
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
    }
}