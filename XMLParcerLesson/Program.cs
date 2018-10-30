using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace XMLParcerLesson
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Person> people = new List<Person> {
                new Person
                {
                    FullName="Админ Админович Админов",
                    BirthDay=DateTime.Now
                },
                new Person
                {
                    FullName="Админ2 Админович Админов",
                    BirthDay=DateTime.Now
                },
                new Person
                {
                    FullName="Админ3 Админович Админов",
                    BirthDay=DateTime.Now
                },
                new Person
                {
                    FullName="Админ4 Админович Админов",
                    BirthDay=DateTime.Now
                }
            };
            XmlDocument xml = new XmlDocument();
            XmlNode rootElement = xml.CreateElement("People");
            foreach(var person in people)
            {
                var personElement = xml.CreateElement("person");
                personElement.SetAttribute("FullName", person.FullName);
                personElement.SetAttribute("age", person.Age.ToString());
                personElement.SetAttribute("birthDay", person.BirthDay.ToString());
                rootElement.AppendChild(personElement);
            }
            xml.AppendChild(rootElement);
            xml.Save("data.xml");

            xml = new XmlDocument();
            xml.Load("data.xml");

            var root = xml.DocumentElement;
            List<Person> loadedPeople = new List<Person>();

            foreach( XmlNode element in root.ChildNodes)
            {
                Person person = null;
                DateTime birthDate;

              if(DateTime.TryParse(element.Attributes["birthDay"].Value,out birthDate))
                {
                    person = new Person
                    {
                        FullName = element.Attributes["FullName"].Value,
                        BirthDay = birthDate
                    };
                }
                else
                {
                    continue;
                }
                loadedPeople.Add(person);
            }



//
//            XmlWriterSettings settings = new XmlWriterSettings();
//            settings.Encoding = Encoding.UTF8;
//            XmlWriter xmlWriter = XmlWriter.Create("data.xml", settings);
        }
    }
}
