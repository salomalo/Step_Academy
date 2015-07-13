using BS.Business.Managers.Abstract;
using BS.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace BS.Business.Managers.XML
{
    public class XMLMeasureManager : IMeasureManager
    {
        string path = "XMLs/Measures.xml";

        public IEnumerable<Measure> GetAll()
        {
            try
            {
                XDocument xmlFile = XDocument.Load(path);
                List<Measure> measureList = new List<Measure>();

                var res =
                    from m in xmlFile.Descendants("Measure")
                    select new
                    {
                        Id = m.Element("Id").Value,
                        SmallName = m.Element("SmallName").Value,
                        Name = m.Element("Name").Value
                    };

                foreach (var m in res)
                {
                    Measure newMeasure = new Measure
                    {
                        Id = Convert.ToInt32(m.Id),
                        SmallName = m.SmallName,
                        Name = m.Name
                    };

                    measureList.Add(newMeasure);
                }

                return measureList;
            }
            catch (Exception ex) { throw ex; }
        }
    }
}
