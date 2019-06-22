namespace PlzGrammarCore.Model
{
    class DefaultProblem : Problem
    {
        public DefaultProblem() : this(ProblemType.Multiple, "default")
        {
            
        }

        public DefaultProblem(ProblemType type, string id) : base(type, id)
        {
            Title = "기본 문제";
            Content = "기본 문제입니다.";
            Answers.Add("금새");
            Answers.Add("금세");
            CorrectAnswerIndex = 1;
        }
    }
}