using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.Models
{
    public class CatalogModel
    {
        #region DataProperies

        public int Id { set; get; }
        public string Name { set; get; }
        public string Producer { set; get; }
        public string Category { set; get; }
        public string SubCategory { set; get; }
        public int Volume { set; get; }
        public string VolMeasure { set; get; }
        public string Measure { set; get; }
        public decimal Price { set; get; }

        #endregion

        #region Ctor

        public CatalogModel(
                 int id
                , string name
                , string producer
                , string category
                , string subcategory
                , int volume
                , string volmeasure
                , string measure
                , decimal price
            )
        {
            Id = id;
            Name = name;
            Producer = producer;
            Category = category;
            SubCategory = subcategory;
            Volume = volume;
            VolMeasure = volmeasure;
            Measure = measure;
            Price = price;
        }

        #endregion

    }
}
