namespace XFramework.Core.IO
{
    public class XOutput
    {
        //------------------------------------------------
        //- Store as Element
        /// <summary>
        /// Write Element
        /// </summary>
        /// <param name="key">Element name</param>
        /// <param name="value">element Value</param>
        public void Element(string key, int value)
            => Add(key, value.ToString(), false);
        /// <summary>
        /// Write Element
        /// </summary>
        /// <param name="key">Element name</param>
        /// <param name="value">element Value</param>
        public void Element(string key, string value)
            => Add(key, value.ToString(), false);
        /// <summary>
        /// Write Element
        /// </summary>
        /// <param name="key">Element name</param>
        /// <param name="value">element Value</param>
        public void Element(string key, bool value)
            => Add(key, value.ToString(), false);
        /// <summary>
        /// Write Element
        /// </summary>
        /// <param name="key">Element name</param>
        /// <param name="value">element Value</param>
        public void Element(string key, double value)
            => Add(key, value.ToString(), false);
        /// <summary>
        /// Write Element
        /// </summary>
        /// <param name="key">Element name</param>
        /// <param name="value">element Value</param>
        public void Element(string key, float value)
            => Add(key, value.ToString(), false);



        //------------------------------------------------
        //- Store as Attribute
        /// <summary>
        /// Write Attribute
        /// </summary>
        /// <param name="key">Attribute name</param>
        /// <param name="value">Attribute Value</param>
        public void Attribute(string key, int value)
            => Add(key, value.ToString(), true);
        /// <summary>
        /// Write Attribute
        /// </summary>
        /// <param name="key">Attribute name</param>
        /// <param name="value">Attribute Value</param>
        public void Attribute(string key, string value)
            => Add(key, value.ToString(), true);
        /// <summary>
        /// Write Attribute
        /// </summary>
        /// <param name="key">Attribute name</param>
        /// <param name="value">Attribute Value</param>
        public void Attribute(string key, bool value)
            => Add(key, value.ToString(), true);
        /// <summary>
        /// Write Attribute
        /// </summary>
        /// <param name="key">Attribute name</param>
        /// <param name="value">Attribute Value</param>
        public void Attribute(string key, double value)
            => Add(key, value.ToString(), true);
        /// <summary>
        /// Write Attribute
        /// </summary>
        /// <param name="key">Attribute name</param>
        /// <param name="value">Attribute Value</param>
        public void Attribute(string key, float value)
            => Add(key, value.ToString(), true);


        internal XOutput()
        {
            ElementSet = new Dictionary<string, string>();
            AttributeSet = new Dictionary<string, string>();
        }
        internal Dictionary<string, string> ElementSet { get; set; }
        internal Dictionary<string, string> AttributeSet { get; set; }

        void Add(string key, string value, bool isAttribute)
        {
            switch (isAttribute)
            {
                case true:
                    AttributeSet[key] = value;
                    break;
                case false:
                    ElementSet[key] = value;
                    break;
            }
        }
    }
}
