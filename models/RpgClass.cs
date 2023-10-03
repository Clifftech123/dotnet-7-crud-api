using System.Text.Json.Serialization;

namespace dotenet7web_api_pratice.models
{



//  this convert this enum to string
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum RpgClass
    {
        
        Knight = 1,
        Mage = 2,
        Cleric = 3
    }
}