namespace JsonBuilder.Tests
{
    using NUnit.Framework;

    public class WhenAnObjectContainsTwoObjects : JsonSpecificationBase
    {
        private string parentName = "parent";

        private string firstChildName = "firstChildName";

        private string secondChildName = "secondChildName";

        public override void Given()
        {
            var rootObject = this.SUT.WithObject(this.parentName);
            rootObject.ContainingObject(this.firstChildName).WithValue("firstChildValue", "actualValue");
            rootObject.ContainingObject(this.secondChildName).WithValue("firstChildValue", "actualValue");
        }

        [Test]
        public void ThenTheNameOfTheFirstChildMustExistInTheResultJson()
        {
            StringAssert.Contains(this.firstChildName, this.result);
        }

        [Test]
        public void ThenTheNameOfTheSecondChildMustExistInTheResultJson()
        {
            StringAssert.Contains(this.secondChildName, this.result);
        }

        [Test]
        public void ThenTheObjectsMustNotBeListedAsACollection()
        {
            StringAssert.DoesNotContain("[", this.result);
            StringAssert.DoesNotContain("]", this.result);
        }
    }
}
