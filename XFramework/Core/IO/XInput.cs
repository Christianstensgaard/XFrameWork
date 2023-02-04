namespace XFramework.Core.IO
{
    public class XInput
    {
        public XInput(Dictionary<string, string> elements)
        {
            elemenset = elements;
        }

        public bool HasElement { get; private set; }
        /// <summary>
        /// Get the Element Value
        /// </summary>
        /// <param name="key">Element name</param>
        /// <returns>Int Value</returns>
        public int IntElement(string key)
            => int.Parse(GetElement(key));
        /// <summary>
        /// Get the element value
        /// </summary>
        /// <param name="key">Element name</param>
        /// <returns>String value</returns>
        public string StringElement(string key)
            => GetElement(key);
        /// <summary>
        /// get the element value 
        /// </summary>
        /// <param name="key">Element name</param>
        /// <returns>Bool value</returns>
        public bool BoolElement(string key)
            => bool.Parse(GetElement(key));
        /// <summary>
        /// get the element value
        /// </summary>
        /// <param name="key">Element name</param>
        /// <returns>Double value</returns>
        public double DoubleElement(string key)
            => double.Parse(GetElement(key));
        /// <summary>
        /// Get the elemen value
        /// </summary>
        /// <param name="key">Element name</param>
        /// <returns>Float value</returns>
        public float FloatElement(string key)
            => float.Parse(GetElement(key));


        string GetElement(string key)
        {
            string value;
            HasElement = elemenset.TryGetValue(key, out value);
            return HasElement ? value! : string.Empty;
        }

        Dictionary<string, string> elemenset;
    }
}
