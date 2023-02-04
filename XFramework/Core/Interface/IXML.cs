using System.Xml;

namespace XFramework.Core.Interface
{
    internal interface IXML<T>
    {
        public void ToXml(XmlWriter writer);
        public T FromXml(XmlReader reader);
    }
}