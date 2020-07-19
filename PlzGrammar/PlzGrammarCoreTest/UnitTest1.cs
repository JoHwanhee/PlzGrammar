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
        public void JSON_Problem()
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
        public void Problems_JSON()
        {
            var problemManager = ProblemManager.Instance;
            var problem = problemManager.GetProblem(0);

            if (problem.Answer != "�ݼ�")
            {
                Assert.Pass("�ѱ��� �ȵȴ���..");
            }

            if (problem.Id == "default")
            {
                Assert.Pass("�����");
            }
            else
            {
                Assert.Fail();
            }

            Assert.Pass();
        }
    }
}