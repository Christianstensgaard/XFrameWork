using XFramework.Core.IO;
using Xframwork.Xml;

namespace Demo
{
    internal class carModel : AXml<carModel>
    {
        //- Model Properties 
        public string? Name { get; set; }
        public int cylinders { get; set; }
        public string? Country { get; set; }



        public override string ToString()
        {
            return $"name:{Name}, cylinders:{cylinders}, country:{Country}";
        }

        //-----------------------------------------------------------------------
        //- Part of the AXml class
        public override string ElementName => "car";

        protected override carModel OnRead(XInput xInput)
        {
            //- The FromXml, Here we link the different Outputs. 
            // Target - Type - ElementName;
            Name = xInput.StringElement("name");
            cylinders = xInput.IntElement("cylinders");
            Country = xInput.StringElement("country");
            return this;
        }

        protected override void OnWrite(XOutput xOutput)
        {
            xOutput.Attribute("name", Name);
            xOutput.Element("cylinders", cylinders);
            xOutput.Element("country", Country);
        }
    }
}
