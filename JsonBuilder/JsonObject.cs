namespace JSonBuilder
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class JsonObject: IJSonData
    {
        private readonly List<IJSonData> values = new List<IJSonData>();

        public JsonObject(string elementName)
        {
            this.Name = elementName;
        }

        public JsonObject() { }

        public IEnumerable<IJSonData> Values => this.values;

        /// <summary>
        /// Adds the given object as child and returns reference of this instance.
        /// </summary>
        /// <param name="jsonObject">The json object which is part of this instance.</param>
        /// <returns>Reference of this object, not of the added child!</returns>
        public JsonObject ContainingObject(JsonObject jsonObject)
        {
            this.values.Add(jsonObject);
            return this;
        }

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

        public JsonObject ContainingObject(string childName)
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