namespace PlzGrammarCore.Model
{
    public class DefaultProblem : Problem
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
            Commentary = @"‘지금 바로’의 뜻으로 쓰이는 부사 ‘금세’는 ‘금시에’가 줄어든 말입니다. 본말인 ‘금시에’의 형태를 염두에 두시면, ‘금세’의 형태를 기억하시는 데에 도움이 될 것입니다.";
            CorrectAnswerIndex = 1;
        }
    }
}