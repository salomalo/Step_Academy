using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BS.Presentation.Models
{
    class AddPakageModel
    {
              #region DataProperty

        public string Category      { get; set; }
        public string SubCategory   { get; set; }
        public string Producer      { get; set; }
        public string Name          { get; set; }
        public decimal Volume       { get; set; }
        public string Measure       { get; set; }
        public string VolMeasure    { get; set; }
        public decimal? Price       { get; set; }

        #endregion

        #region Ctor

        public AddPakageModel(
          
              string category   
            , string subcategory
            , string producer   
            , string name       
            , decimal volume    
            , string measure    
            , string volmeasure 
            , decimal? price    
        )
        {
            Name = name;
            Category = category;
            SubCategory = subcategory;
            Producer = producer;
            Measure = measure;
            Volume = volume;
            VolMeasure = volmeasure;
            Price = price;
        }

        #endregion
    }
}

