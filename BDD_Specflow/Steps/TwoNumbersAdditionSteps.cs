using NUnit.Framework;
using TechTalk.SpecFlow;

namespace _111ProjectStructure.Steps
{
    [Binding]
    public class TwoNumbersAdditionSteps
    {
        private int _number1;
        private int _number2;
        private int _result;

        [Given("number 1 as 10")]
        public void UserHasNumber1As10()
        {
            _number1 = 10;
        }

        [Given("number 2 as 20")]
        public void UserHasNumber2As20()
        {
            _number2 = 20;
        }

        [When("user adds number 1 & number 2")]
        public void UserAddsNumber1AndNumber2()
        {
            _result = _number1 + _number2;
        }

        [Then("result is 30")]
        public void ResultIs30()
        {
            Assert.That(_result, Is.EqualTo(30));
        }
    }
}
