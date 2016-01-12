namespace FluentJsonBuilder.Tests
{
    using DynamicSpecs.NUnit;

    using NUnit.Framework;

    public class WhenAnObjectWithAPropertyIsCreated : JsonSpecificationBase
    {
        private string propertyName = "child";

        private string propertyValue = "childData";

        public override void Given()
        {
            this.SUT.WithObject("parent").WithValue(this.propertyName, this.propertyValue);
        }

        [Test]
        public void TheNameOfThePropertyIsAvailable()
        {
            StringAssert.Contains(this.propertyName, this.result);
        }

        [Test]
        public void TheValueOfThePropertyIsAvailable()
        {
            StringAssert.Contains(this.propertyValue, this.result);
        }
    }
}
