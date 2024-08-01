using System.Globalization;
using System.IdentityModel.Tokens.Jwt;
using System.Text.Json;
using Newtonsoft.Json;

namespace Cadastre.Utilities
{
    public static class JsonSerializerHelper
    {
        public static T? Deserialize<T>(string jsonDocument)
        {
            if (string.IsNullOrEmpty(jsonDocument))
            {
                throw new ArgumentException("Json document cannot be null or empty!");
            }

            return JsonConvert.DeserializeObject<T>(jsonDocument);
        }

        public static string Serialize<T>(T obj)
        {
            if (obj == null)
            {
                throw new ArgumentException("Cannot serialize null object reference!");
            }

            var settings = new JsonSerializerSettings
            {
                Formatting = Formatting.Indented,
                Culture = CultureInfo.InvariantCulture
            };

            return JsonConvert.SerializeObject(obj, settings).TrimEnd();
        }
    }
}
