namespace JsonBuilder.Tests
{
    using System;

    using DynamicSpecs.NUnit;

    using NUnit.Framework;

    public class WhenAnEmptyObjectIsCreated : Specifies<JsonBuilder>
    {
        private string elementName = "MyObject";

        public override void Given()
        {
            this.SUT.WithObject(this.elementName);
        }

        [Test]
        public void ThenAExceptionMustBethrown()
        {
            Assert.Throws<InvalidOperationException>(() => this.SUT.Create());
        }
    }
}
