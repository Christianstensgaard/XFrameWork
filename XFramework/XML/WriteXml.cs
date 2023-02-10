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

        public LinkedList<AXml<T>> Collection { get; set; }
        public XmlWriterSettings Settings { get; set; }
        public void Add(params T[] items)
        {
            foreach (var item in items)
                Collection.AddLast(item);
        }
        public bool Remove(T target)
        {
           return Collection.Remove(target);
        }
        public void SaveToFile(string path)
        {
            if (Write())
                File.WriteAllText($"{path}", stringWriter.ToString());
        }
        public string SaveToString()
        {
            if (Write())
                return stringWriter.ToString();
            else return string.Empty;
        }

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