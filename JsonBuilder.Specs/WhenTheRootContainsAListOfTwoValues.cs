namespace FluentJsonBuilder.Tests
{
    using DynamicSpecs.NUnit;

    using NUnit.Framework;

    public class WhenTheRootContainsAListOfTwoValues : JsonSpecificationBase
    {
        private string firstvalue = "first value";

        private string secondvalue = "second value";

        private string collectionName = "collection";

        public override void Given()
        {
            this.SUT.WithCollection(this.collectionName)
                .WithValue(this.firstvalue)
                .WithValue(this.secondvalue);
        }

        [Test]
        public void ThenTheCollectionNameMustBeProvided()
        {
            StringAssert.Contains(this.firstvalue, this.result);
        }

        [Test]
        public void ThenTheFirstValueIsAvailable()
        {
            StringAssert.Contains(this.firstvalue, this.result);
        }

        [Test]
        public void ThenTheSecondValueIsAvailable()
        {
            StringAssert.Contains(this.secondvalue, this.result);
        }

        [Test]
        public void ThenTheCollectionMustBeAvailable()
        {
            StringAssert.Contains("[", this.result);
            StringAssert.Contains("]", this.result);
        }
    }
}
