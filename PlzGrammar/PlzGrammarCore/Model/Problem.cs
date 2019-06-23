using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json.Linq;

namespace PlzGrammarCore.Model
{
    class Problem
    {
        public ProblemType Type { get; }
        public string Id { get; }
        public string Title { get; set; }
        public string Content { get; set; }
        public List<string> Answers { get; set; } = new List<string>();
        public int CorrectAnswerIndex { get; set; }
        public string IconName { get; set; }
        public string Answer { get; private set; }

        public Problem(ProblemType type, string id)
        {
            Type = type;
            Id = id;
        }

        protected void SetAnswer()
        {
            if (Answers.Count > 0 && Answers.Count > CorrectAnswerIndex)
            {
                Answer = Answers[CorrectAnswerIndex];
            }
        }

        public JObject ToJson()
        {
            JObject json = new JObject();
            json["type"] = Type.ToString();
            json["id"] = Id;
            json["title"] = Title;
            json["content"] = Content;

            JArray answers = new JArray();
            foreach (var answer in Answers)
            {
                answers.Add(answer);
            }

            json["answers"] = answers;
            json["correctAnswerIndex"] = CorrectAnswerIndex;
            json["answer"] = Answer;
            json["iconName"] = IconName;

            return json;
        }
    }
}
