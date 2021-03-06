namespace JsonBuilder.Tests
{
    using DynamicSpecs.NUnit;

    using Newtonsoft.Json.Linq;

    using NUnit.Framework;

    public abstract class JsonSpecificationBase : Specifies<JsonBuilder>
    {
        protected string result;

        public override void When()
        {
            this.result = this.SUT.Create();
        }

        [Test]
        public void ThenTheCreatedJsonMustBeValid()
        {
            JToken.Parse(this.result);
        }
    }
}