namespace Connect.Shared
{
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    [JsonConverter(typeof(StringEnumConverter))]
    public enum ReportItemStatus
    {
        Ok,
        CheckDue,
        Expired,
        Unknown
    }
}