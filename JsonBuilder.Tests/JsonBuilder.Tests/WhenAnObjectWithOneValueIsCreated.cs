namespace JsonBuilder.Tests
{
    using NUnit.Framework;

    public class WhenAnObjectWithOneValueIsCreated : JsonSpecificationBase
    {
        private string elementName = "MyObject";

        private string value = "value";

        public override void Given()
        {
            this.SUT.WithObject(this.elementName).WithValue("valueName", this.value);
        }

        [Test]
        public void ThenTheResultMustContainAName()
        {
            StringAssert.Contains(this.elementName, this.result);
        }

        [Test]
        public void ThenTheValueMustBePartOfTheJSon()
        {
            StringAssert.Contains(this.value, this.result);
        }
    }
}
