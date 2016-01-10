namespace JSonBuilder
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class JsonBuilder
    {
        private List<JsonObject> objects = new List<JsonObject>();

        public string Create()
        {
            if (!this.objects.Any())
            {
                throw new InvalidOperationException($"No value provided!");
            }

            var stringBuilder = new StringBuilder();
            foreach (var jsonObject in this.objects)
            {
                stringBuilder.AppendLine(jsonObject.ToJson() + ", ");
            }

            var formatedElements = stringBuilder.ToString();
            formatedElements = formatedElements.Remove(formatedElements.Length - 4, 4);

            return WrapInBraces(formatedElements);
        }

        public JsonObject WithObject(string elementName)
        {
            var newElement = new JsonObject(elementName);

            this.objects.Add(newElement);

            return newElement;
        }

        internal static string GetFormatedElementName(string name)
        {
            var elementName = $"\"{name}\":";
            return elementName;
        }

        internal static string WrapInBraces(string element)
        {
            var stringBuilder = new StringBuilder();
            stringBuilder.AppendLine("{ ");
            stringBuilder.AppendLine(element);
            stringBuilder.AppendLine("}");

            return stringBuilder.ToString();
        }

        internal static string ListObjects(IEnumerable<object> values)
        {
            var stringBuilder = new StringBuilder();

            foreach (var value in values)
            {
                if (value is IJSonData)
                {
                    var wrapedData = value.ToString();
                    stringBuilder.AppendLine(wrapedData + ", ");
                }
                else
                {
                    stringBuilder.AppendLine("\"" + value + "\", ");
                }
            }

            var formatedObject = stringBuilder.ToString();
            var trimmedResult = formatedObject.Remove(formatedObject.Length - 4, 4);

            return trimmedResult;
        }
    }
}