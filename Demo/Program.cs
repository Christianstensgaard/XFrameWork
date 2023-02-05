using Demo;
using Xframwork.XML;


//- Reading From XML
ReadXml<carModel> readXml = new ReadXml<carModel>("cars", "http://www.fkj.dk/cars.xml");
readXml.Settings = new System.Xml.XmlReaderSettings
{
    IgnoreWhitespace = true,
    IgnoreComments = true,
};


if(readXml.ReadAll())
    foreach (carModel car in readXml.Collection)
        Console.WriteLine(car.ToString());


//- Reading the Xml file. 

//- Printing To Console, (Models) 

//- Writing to XML
WriteXml<carModel> writeXml = new WriteXml<carModel>("cars", readXml.Collection);
//- Write To Console
Console.WriteLine(writeXml.SaveToString());
//- Write to file
writeXml.SaveToFile($"{Directory.GetCurrentDirectory()}/XmlFile.xml");
