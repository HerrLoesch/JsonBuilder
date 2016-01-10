namespace JSonBuilder
{
    public class JsonValue : IJsonData
    {
        public object Value { get; private set; }

        public string Name { get; private set; }

        public string ToJson()
        {
            if (this.Name != null)
            {
                return $"\"{this.Name}\": \"{this.Value}\"";
            }
            else
            {
                return $"\"{this.Value}\"";
            }
        }

        public JsonValue(object value)
        {
            this.Value = value;
        }

        public JsonValue(string name, object value)
        {
            this.Name = name;
            this.Value = value;
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
    }
}