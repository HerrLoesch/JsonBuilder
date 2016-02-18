namespace JsonBuilder
{
    /// <summary>
    /// This class helps to handle empty data. If you have no data for a specific
    /// part of your Json, don't use null. Just return this empty object.
    /// </summary>
    public class JsonEmptyData : IJsonData
    {
        public string ToJson()
        {
            return string.Empty;
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