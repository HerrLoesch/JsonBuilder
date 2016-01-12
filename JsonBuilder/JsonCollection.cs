namespace JSonBuilder
{
    using System.Collections.Generic;
    using System.Text;

    public class JsonCollection : IJSonData
    {
        public string Name { get; }

        public JsonCollection(string name)
        {
            this.Name = name;
            this.Values = new List<IJSonData>();
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

        public List<IJSonData> Values { get; set; }

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
    }
}