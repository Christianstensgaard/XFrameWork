using System.Xml;
using Xframwork.Xml;

namespace Xframwork.XML
{
    public class ReadXml<T> where T : AXml<T>, new()
    {
        /// <summary>
        /// Creating an Instance of the ReadXML, 
        /// </summary>
        /// <param name="rootElement">Root element of the XML </param>
        /// <param name="path">File path</param>
        public ReadXml(string rootElement, string path)
        {
            this.startElement = rootElement;
            this.path = path;
            Collection = new();
            Settings = new();
        }
        public LinkedList<AXml<T>> Collection { get; private set; }
        public XmlReaderSettings Settings { get; set; }
        public bool ReadAll()
        {
            try
            {
                using (XmlReader reader = XmlReader.Create(path, Settings))
                {
                    reader.MoveToContent();
                    reader.ReadStartElement(startElement);
                    while (reader.IsStartElement())
                        Collection.AddLast(new T().FromXml(reader));
                }
                return true;
            }
            catch (Exception ex) { Console.WriteLine(ex); return false; }
        }
        #region Private
        string startElement;
        string path;
        #endregion
    }
}
