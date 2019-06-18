using System;
using System.Collections.Generic;
using System.Text;

namespace PlzGrammarCore.Model
{
    class Problem
    {
        public ProblemType Type { get; }
        public string Id { get; }
        public string Title { get; set; }
        public List<string> Answers { get; set; }
        public int CorrectAnswerIndex { get; set; }

        public Problem(ProblemType type, string id)
        {
            Type = type;
            Id = id;
        }
    }
}
