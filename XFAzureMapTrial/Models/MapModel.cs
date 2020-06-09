namespace XFAzureMapTrial.Models
{
    using System.Collections.Generic;
    using Newtonsoft.Json;

    public partial class Temperatures
    {
        [JsonProperty("summary")]
        public Summary Summary { get; set; }

        [JsonProperty("results")]
        public List<Result> Results { get; set; }
    }

    public partial class Result
    {
        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("score")]
        public double Score { get; set; }

        [JsonProperty("address")]
        public Address Address { get; set; }

        [JsonProperty("position")]
        public Position Position { get; set; }

        [JsonProperty("viewport")]
        public Viewport Viewport { get; set; }

        [JsonProperty("entryPoints", NullValueHandling = NullValueHandling.Ignore)]
        public List<EntryPoint> EntryPoints { get; set; }
    }

    public partial class Address
    {
        [JsonProperty("streetNumber", NullValueHandling = NullValueHandling.Ignore)]
        public string StreetNumber { get; set; }

        [JsonProperty("streetName")]
        public string StreetName { get; set; }

        [JsonProperty("municipalitySubdivision")]
        public string MunicipalitySubdivision { get; set; }

        [JsonProperty("municipality")]
        public string Municipality { get; set; }

        [JsonProperty("countrySecondarySubdivision")]
        public string CountrySecondarySubdivision { get; set; }

        [JsonProperty("countrySubdivision")]
        public string CountrySubdivision { get; set; }

        [JsonProperty("countrySubdivisionName")]
        public string CountrySubdivisionName { get; set; }

        [JsonProperty("postalCode")]
        public string PostalCode { get; set; }

        [JsonProperty("extendedPostalCode", NullValueHandling = NullValueHandling.Ignore)]
        public string ExtendedPostalCode { get; set; }

        [JsonProperty("countryCode")]
        public string CountryCode { get; set; }

        [JsonProperty("country")]
        public string Country { get; set; }

        [JsonProperty("countryCodeISO3")]
        public string CountryCodeIso3 { get; set; }

        [JsonProperty("freeformAddress")]
        public string FreeformAddress { get; set; }

        [JsonProperty("localName")]
        public string LocalName { get; set; }
    }

    public partial class EntryPoint
    {
        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("position")]
        public Position Position { get; set; }
    }

    public partial class Position
    {
        [JsonProperty("lat")]
        public double Lat { get; set; }

        [JsonProperty("lon")]
        public double Lon { get; set; }
    }

    public partial class Viewport
    {
        [JsonProperty("topLeftPoint")]
        public Position TopLeftPoint { get; set; }

        [JsonProperty("btmRightPoint")]
        public Position BtmRightPoint { get; set; }
    }

    public partial class Summary
    {
        [JsonProperty("query")]
        public string Query { get; set; }

        [JsonProperty("queryType")]
        public string QueryType { get; set; }

        [JsonProperty("queryTime")]
        public long QueryTime { get; set; }

        [JsonProperty("numResults")]
        public long NumResults { get; set; }

        [JsonProperty("offset")]
        public long Offset { get; set; }

        [JsonProperty("totalResults")]
        public long TotalResults { get; set; }

        [JsonProperty("fuzzyLevel")]
        public long FuzzyLevel { get; set; }
    }
}
