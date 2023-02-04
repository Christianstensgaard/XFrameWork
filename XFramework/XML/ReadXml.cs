using System.Xml;
using Xframwork.Xml;

namespace Xframwork.XML
{
    public class ReadXml<T> where T : AXml<T>, new() //- This makes it possible to create a instance of T if it has a Default constructor. 
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

        public LinkedList<AXml<T>> Collection { get; private set; } //- Using linkedList<> because i don't Need the sorting or other. 
        public XmlReaderSettings Settings { get; set; } //- Settings
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
        }//- Reading all Elements<T> from the xml-file. This class don't know anything about the files information, but used the IXML<T> interface to do the job. 

        #region Private
        string startElement;
        string path;
        #endregion
    }
}
