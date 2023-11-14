namespace DtoMapperPlugin.Controllers
{
    public class FilteredListItem
    {
        public FilteredListItem(string text) : this(text, text)
        {
        }
        public FilteredListItem(string text, string key)
        {
            Text = text;
            Key = key;
        }

        public string Key { get; set; }
        public string Text { get; set; }
        public bool Bold { get; set; }
        public string Type { get; set; }
        public bool Disabled { get; set; }
    }
}
