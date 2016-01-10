namespace JSonBuilder.Specs
{
    using NUnit.Framework;

    public class WhenAnObjectWithACollectionOfTwoValuesIsCreated : JsonSpecificationBase
    {
        private string elementName = "MyObject";

        private string firstValue = "firstValue";

        private string secondValue = "secondValue";

        private string collectionName = "collection";

        public override void Given()
        {
            this.SUT.WithObject(this.elementName)
                .WithCollection(this.collectionName)
                .WithValue(this.firstValue)
                .WithValue(this.secondValue);
        }

        [Test]
        public void ThenTheResultMustContainAName()
        {
            StringAssert.Contains(this.elementName, this.result);
        }

        [Test]
        public void ThenTheFirstValueMustBeAvailable()
        {
            StringAssert.Contains(this.firstValue, this.result);
        }

        [Test]
        public void ThenTheValuesMustBeAddedAsACollection()
        {
            StringAssert.Contains("[", this.result);
            StringAssert.Contains("]", this.result);
        }

        [Test]
        public void ThenTheSecondValueMustBeAvailable()
        {
            StringAssert.Contains(this.secondValue, this.result);
        }
    }
}
