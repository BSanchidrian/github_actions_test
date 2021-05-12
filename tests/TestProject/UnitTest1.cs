using github_actions_test;
using Xunit;

namespace TestProject
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            var result = Ruben.Mola(1, 2);
            Assert.Equal(3, result);
        }
    }
}