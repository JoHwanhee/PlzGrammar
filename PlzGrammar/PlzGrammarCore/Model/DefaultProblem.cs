namespace PlzGrammarCore.Model
{
    class DefaultProblem : Problem
    {
        public DefaultProblem() : this(ProblemType.Multiple, "default")
        {
            SetAnswer();
        }

        public DefaultProblem(ProblemType type, string id) : base(type, id)
        {
            Title = "기본 문제";
            Content = "(   ) 날이 저물었다.";
            Answers.Add("금새");
            Answers.Add("금세");
            IconName = "ios-home";
            CorrectAnswerIndex = 1;
        }
    }
}