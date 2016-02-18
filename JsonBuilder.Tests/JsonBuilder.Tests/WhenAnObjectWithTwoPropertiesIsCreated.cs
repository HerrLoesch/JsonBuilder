namespace JsonBuilder.Tests
{
    using NUnit.Framework;

    public class WhenAnObjectWithTwoPropertiesIsCreated : JsonSpecificationBase
    {
        private string firstPropertyName = "firstChild";

        private string firstPropertyValue = "firstChildData";

        private string secondPropertyName = "secondChild";

        private string secondPropertyValue = "secondChildData";

        public override void Given()
        {
            this.SUT.WithObject("parent")
                .WithValue(this.firstPropertyName, this.firstPropertyValue)
                .WithValue(this.secondPropertyName, this.secondPropertyValue);
        }

        [Test]
        public void TheNameOfTheFirstPropertyIsAvailable()
        {
            StringAssert.Contains(this.firstPropertyName, this.result);
        }

        [Test]
        public void TheValueOfTheFirstPropertyIsAvailable()
        {
            StringAssert.Contains(this.firstPropertyValue, this.result);
        }

        [Test]
        public void TheNameOfTheSecondPropertyIsAvailable()
        {
            StringAssert.Contains(this.secondPropertyName, this.result);
        }

        [Test]
        public void TheValueOfTheSecondPropertyIsAvailable()
        {
            StringAssert.Contains(this.secondPropertyValue, this.result);
        }

        [Test]
        public void PropertiesAreNotShownAsACollection()
        {
            StringAssert.DoesNotContain("[", this.result);
            StringAssert.DoesNotContain("]", this.result);
        }
    }
}