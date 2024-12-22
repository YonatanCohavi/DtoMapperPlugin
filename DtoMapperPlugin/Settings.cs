namespace DtoMapperPlugin
{
    /// <summary>
    /// This class can help you to store settings for your plugin
    /// </summary>
    /// <remarks>
    /// This class must be XML serializable
    /// </remarks>
    public class Settings
    {
        public string LastUsedOrganizationWebappUrl { get; set; }
        public bool GenerateLabels { get; set; }
        public bool GenerateLabelsOneLine { get; set; }
        public bool OneLineAttributes { get; set; }
        public Settings Clone() => (Settings)MemberwiseClone();
    }
}