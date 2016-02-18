namespace JsonBuilder
{
    using System.Collections.Generic;
    using System.Text;

    public class JsonCollection : IJsonData
    {
        public string Name { get; }

        public JsonCollection(string name)
        {
            this.Name = name;
            this.Values = new List<IJsonData>();
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

        public List<IJsonData> Values { get; set; }

        private string FormatCollectionObject(string elementName, IEnumerable<object> values)
        {
            var stringBuilder = new StringBuilder();

            if (elementName != null)
            {
                stringBuilder.Append($"\"{elementName}\": ");
            }

            stringBuilder.AppendLine("[");
            var listedObjects = JsonBuilder.ListObjects(values);
            stringBuilder.Append(listedObjects);
            stringBuilder.AppendLine("]");

            return stringBuilder.ToString();
        }

        public JsonObject WithObject()
        {
            var jsonObject = new JsonObject();
            this.Values.Add(jsonObject);

            return jsonObject;
        }

        public JsonCollection WithObject(JsonObject jsonObject)
        {
            this.Values.Add(jsonObject);
            return this;
        }
    }
}