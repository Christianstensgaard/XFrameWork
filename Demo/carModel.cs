using XFramework.Core.IO;
using Xframwork.Xml;

namespace Demo
{
    internal class carModel : AXml<carModel>
    {
        public override string ToString()
        {
            return $"name:{Name}, cylinders:{cylinders}, country:{Country}";
        }
        
        //- Model Properties 
        public string? Name { get; set; }
        public int cylinders { get; set; }
        public string? Country { get; set; }

        //-----------------------------------------------------------------------
        //- Part of the AXml class
        public override string ElementName => "car"; //- Element name.

        //- Running once when reading Xml
        protected override carModel OnRead(XInput xInput)
        {
            //- Link the diffrerent variables.
            Name = xInput.StringElement("name");
            cylinders = xInput.IntElement("cylinders");
            Country = xInput.StringElement("country");
            return this;
        }

        //- Running once when writing to xml. 
        protected override void OnWrite(XOutput xOutput)
        {
            //- Link the diffrerent variables.
            xOutput.Attribute("name", Name);
            xOutput.Element("cylinders", cylinders);
            xOutput.Element("country", Country);
        }
    }
}
