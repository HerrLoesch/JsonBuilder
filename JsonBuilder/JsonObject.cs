namespace JSonBuilder
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class JsonObject: IJsonData
    {
        private readonly List<IJsonData> values = new List<IJsonData>();
        public JsonObject(string elementName)
        {
            this.Name = elementName;
        }

        public IEnumerable<IJsonData> Values => this.values;

        public string Name { get; set; }

        /// <summary>
        /// Returns a string that represents the current object.
        /// </summary>
        /// <returns>
        /// A string that represents the current object.
        /// </returns>
        public override string ToString()
        {
            return this.ToJson();
        }

        public string ToJson()
        {
            if (!this.values.Any())
            {
                throw new InvalidOperationException($"No values provided for object {this.Name}!");
            }
            
            var elementName = JsonBuilder.GetFormatedElementName(this.Name);
            string content;

            if (this.values.Count == 1)
            {
                var value = this.values.First();
                content = value.ToJson();
            }
            else
            {
                content = JsonBuilder.ListObjects(this.values);
            }

            var formatedObject = elementName + JsonBuilder.WrapInBraces(content);
            return formatedObject;
        }
        
        public JsonObject WithValue(string name, object value)
        {
            var jsonValue = new JsonValue(name, value);
            this.values.Add(jsonValue);

            return this;
        }

        public JsonObject ContainingObject(string childName, bool wrapObjectInBraces = true)
        {
            var jsonObject = new JsonObject(childName);
            this.values.Add(jsonObject);

            return jsonObject;
        }

        public JsonCollection WithCollection(string collectionName)
        {
            var collection = new JsonCollection(collectionName);

            this.values.Add(collection);

            return collection;
        }
    }
}