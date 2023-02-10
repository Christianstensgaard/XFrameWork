namespace XFramework.Core.IO
{
    public class XOutput
    {
        
        public void Element(string key, object value)
            => AddElement(key, value.ToString()!);
        public void Attribute(string key, object value)
            => AddAttribute(key, value.ToString()!);

        internal XOutput()
        {
            ElementSet = new Dictionary<string, string>();
            AttributeSet = new Dictionary<string, string>();
        } 
        internal Dictionary<string, string> ElementSet { get; set; }
        internal Dictionary<string, string> AttributeSet { get; set; }
        void AddElement(string key, string value)
        {
            ElementSet[key] = value;
        }

        void AddAttribute(string key, string value)
        {
            AttributeSet[key] = value;
        }
    }
}
