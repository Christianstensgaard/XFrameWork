using System.Xml;
using Xframwork.Xml;

namespace Xframwork.XML
{
    public class WriteXml<T> where T : AXml<T>
    {
        public WriteXml(string startElement, LinkedList<AXml<T>> collection)
        {
            this.startElement = startElement;
            Collection = collection;
            Settings = new XmlWriterSettings
            {
                Indent = true,
            };
        }

        public LinkedList<AXml<T>> Collection { get; set; } //-Collection of Instance of IXML<T> 
        public XmlWriterSettings Settings { get; set; } //-Writer settings. 
        public void Add(params T[] items)
        {
            foreach (var item in items)
                Collection.AddLast(item);
        }//- Add a instance of T to be writen to the xml
        public bool Remove(T target)
        {
           return Collection.Remove(target);
        }//- Remove a instance of T object
        public void SaveToFile(string path)
        {
            if (Write())
                File.WriteAllText($"{path}", stringWriter.ToString());
        }//- Writing the xml-format to the file. 
        public string SaveToString()
        {
            if (Write())
                return stringWriter.ToString();
            else return string.Empty;
        }//- Returning the Xml-Format as a string

        #region Private
        string startElement;
        StringWriter? stringWriter;
        bool Write()
        {
            using (stringWriter = new())
            {
                using (XmlWriter writer = XmlWriter.Create(stringWriter, Settings))
                {
                    writer.WriteStartDocument();
                    writer.WriteStartElement(startElement);
                    foreach (var T in Collection)
                        T.ToXml(writer);
                    writer.WriteEndElement();
                    writer.WriteEndDocument();
                }
            }
            return true;
        }
        #endregion
    }
}