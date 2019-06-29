using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json.Linq;
using PlzGrammarCore.Common;

namespace PlzGrammarCore.Model
{
    public class Problem
    {
        public ProblemType Type { get; }
        public string Id { get; }
        public string Title { get; set; }
        public string Content { get; set; }
        public List<string> Answers { get; set; } = new List<string>();
        public int CorrectAnswerIndex { get; set; }
        public string IconName { get; set; }
        public string Answer { get; private set; }
        public string Commentary { get; set; }

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

        private static bool CheckProperties(JObject json)
        {
            if (json["id"] == null)
            {
                return false;
            }
            if (json["title"] == null)
            {
                return false;
            }
            if (json["content"] == null)
            {
                return false;
            }
            if (json["answers"] == null)
            {
                return false;
            }
            if (json["correctAnswerIndex"] == null)
            {
                return false;
            }
            if (json["iconName"] == null)
            {
                return false;
            }
            if (json["answer"] == null)
            {
                return false;
            }
            if (json["commentary"] == null)
            {
                return false;
            }

            return true;
        }

        public static Problem Create(string jsonString)
        {
            if (!JsonUtils.TryParse(jsonString, out var json))
            {
                return null;
            }

            if (!CheckProperties(json))
            {
                return null;
            }

            var typeString = json.Value<string>("type");
            ProblemType type = (ProblemType)Enum.Parse(typeof(ProblemType), typeString);

            var id = json.Value<string>("id");
            var content = json.Value<string>("content");
            var title = json.Value<string>("title");

            var answers = json.Value<JArray>("answers");
            var answerList = new List<string>();
            foreach (var jToken in answers)
            {
                answerList.Add(jToken.ToString());
            }

            var correctAnswerIndex = json.Value<int>("correctAnswerIndex");
            var answer = json.Value<string>("answer");
            var iconName = json.Value<string>("iconName");
            var commentary = json.Value<string>("commentary");

            Problem problem = new Problem(type, id);
            problem.Title = content;
            problem.Title = title;
            problem.Answers = answerList;
            problem.CorrectAnswerIndex = correctAnswerIndex;
            problem.Answer = answer;
            problem.IconName = iconName;
            problem.Commentary = commentary;
            problem.SetAnswer();
            return problem;
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
            json["commentary"] = Commentary;

            return json;
        }
    }
}
