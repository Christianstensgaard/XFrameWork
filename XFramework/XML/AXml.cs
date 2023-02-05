using System.Xml;
using XFramework.Core.IO;
using XFramework.Core.Interface;

namespace Xframwork.Xml
{
    public abstract class AXml<T>:IXML<T>
    {
        public abstract string ElementName { get;}
        public void ToXml(XmlWriter writer)
        {
            XOutput xOutput = new XOutput();
            OnWrite(xOutput);

            writer.WriteStartElement(ElementName);
            //- Write the Attributes
            foreach (var item in xOutput.AttributeSet)
            {
                writer.WriteAttributeString(item.Key, item.Value);
            }

            //- Write the elements
            foreach (var item in xOutput.AttributeSet)
            {
                writer.WriteElementString(item.Key, item.Value);
            }

            writer.WriteEndElement();
        }
        public T FromXml(XmlReader reader)
        {
            Dictionary<string,string> keyValuePairs= new Dictionary<string,string>();

            //- If there are any attributes
            while (reader.MoveToNextAttribute())
            {
                keyValuePairs[reader.Name] = reader.Value;
            }

            reader.ReadStartElement(ElementName);
            while (reader.IsStartElement())
            {
                keyValuePairs[reader.Name] = reader.ReadElementContentAsString();
            }

            reader.ReadEndElement();
            return OnRead(new XInput(keyValuePairs));
        }
        protected abstract void OnWrite(XOutput xOutput);
        protected abstract T OnRead(XInput xInput);
    }
}
