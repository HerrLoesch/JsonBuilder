namespace JsonBuilder.Tests
{
    using NUnit.Framework;

    public class WhenTwoObjectsOnRootLevelAreCreated : JsonSpecificationBase
    {
        private string firstElementName = "firstName";

        private string secondElementName = "secondName";

        public override void Given()
        {
            this.SUT.WithObject(this.firstElementName).WithValue("firstValue", "firstValue");
            this.SUT.WithObject(this.secondElementName).WithValue("secondValue", "secondValue");
        }

        [Test]
        public void ThenNameOfFirstElementCanBeFound()
        {
            StringAssert.Contains(this.firstElementName, this.result);
        }

        [Test]
        public void ThenNameOfSecondElementCanBeFound()
        {
            StringAssert.Contains(this.secondElementName, this.result);
        }
    }
}
