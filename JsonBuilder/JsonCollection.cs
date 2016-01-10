namespace JSonBuilder
{
    using System.Collections.Generic;
    using System.Text;

    public class JsonCollection : IJsonData
    {
        public string Name { get; }

        public JsonCollection(string name)
        {
            this.Name = name;
            this.Values = new List<JsonValue>();
        }

        public string ToJson()
        {
            return this.FormatCollectionObject(this.Name, this.Values);
        }

        public JsonCollection WithValue(object value)
        {
            var jsonValue = new JsonValue(value);
            this.Values.Add(jsonValue);

            return this;
        }

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

        public List<JsonValue> Values { get; set; }

        protected virtual string FormatCollectionObject(string elementName, IEnumerable<object> values)
        {
            var stringBuilder = new StringBuilder($"\"{elementName}\": [");

            var listedObjects = JsonBuilder.ListObjects(values);
            stringBuilder.Append(listedObjects);
            stringBuilder.AppendLine(" ]");

            return stringBuilder.ToString();
        }
    }
}