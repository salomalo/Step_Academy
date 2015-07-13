using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BS.Presentation.Models
{
    public class CatalogModel
    {
        #region Dataproperties

        public int Id { set; get; }
        public string Name { set; get; }
        public string Producer { set; get; }
        public string Category { set; get; }
        public string SubCategory { set; get; }
        public decimal Volume { set; get; }
        public string VolMeasure { set; get; }
        public string Measure { set; get; }
        public decimal Price { set; get; }

        #endregion

        // Ctor - constructor
        #region Ctor  

        public CatalogModel(
                 int id
                ,string name
                ,string producer
                ,string category
                ,string subCategory
                ,decimal volume
                ,string volMeasure
                ,string measure
                ,decimal price
            )
        {
            Id = id;
            Name = name;
            Producer = producer;
            Category = category;
            SubCategory = subCategory;
            Volume = volume;
            VolMeasure = volMeasure;
            Measure = measure;
            Price = price;
        }

        #endregion
    }
}
