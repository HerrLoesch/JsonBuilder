namespace FluentJsonBuilder.Tests
{
    using System.Linq;

    using DynamicSpecs.NUnit;

    using NUnit.Framework;

    public class WhenAnObjectIsAddedAsValueForAnObject : JsonSpecificationBase
    {
        private JsonObject jsonObject;

        public override void Given()
        {
            this.jsonObject = new JsonObject("my object");
            this.jsonObject.WithValue("value", "value");

            this.SUT.WithObject("parent").ContainingObject(this.jsonObject);
        }

        [Test]
        public void ThenTheNameOfTheObjectIsAvailable()
        {
            StringAssert.Contains(this.jsonObject.Name, this.result);
        }

        [Test]
        public void ThenTheValueOfTheObjectIsAvailable()
        {
            StringAssert.Contains(this.jsonObject.Values.First().ToJson(), this.result);
        }

    }
}
