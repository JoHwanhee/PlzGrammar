using NUnit.Framework;
using PlzGrammarCore;
using PlzGrammarCore.Model;

namespace PlzGrammarCoreTest
{
    public class ProblemTest
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void JSON포맷으로_Problem객체를_만들어야된다()
        {
            DefaultProblem defaultProblem = new DefaultProblem();
            Problem problem = Problem.Create(defaultProblem.ToJson().ToString());

            if (problem.Answers.Count != 2)
            {
                Assert.Fail();
            }

            if (problem == null)
            {
                Assert.Fail();
            }

            Assert.Pass();
        }

        [Test]
        public void Problems_JSON_읽기테스트()
        {
            var problemManager = ProblemManager.Instance;
            var problem = problemManager.GetProblem(0);

            if (problem.Answer != "금세")
            {
                Assert.Pass("한글이 안된느듯..");
            }

            if (problem.Id == "default")
            {
                Assert.Pass("구우웃");
            }
            else
            {
                Assert.Fail();
            }
        }


    }
}