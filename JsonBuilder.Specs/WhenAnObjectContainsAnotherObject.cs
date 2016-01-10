namespace JSonBuilder.Specs
{
    using NUnit.Framework;

    public class WhenAnObjectContainsAnotherObject
         : JsonSpecificationBase
    {
        private string parentName = "parent";

        private string childName = "child";

        private string childValue = "childvalue";

        private string childValueName = "childValueName";


        public override void Given()
        {
            this.SUT.WithObject(this.parentName).ContainingObject(this.childName).WithValue(this.childValueName, this.childValue);
        }

        [Test]
        public void ThenTheParentNameExistsInTheResultJson()
        {
            StringAssert.Contains(this.parentName, this.result);
        }

        [Test]
        public void ThenTheChildNameExistsInTheResultJson()
        {
            StringAssert.Contains(this.childName, this.result);
        }

        [Test]
        public void ThenTheChildValudExistsInTehResultJson()
        {
            StringAssert.Contains(this.childValue, this.result);
        }
    }
}
