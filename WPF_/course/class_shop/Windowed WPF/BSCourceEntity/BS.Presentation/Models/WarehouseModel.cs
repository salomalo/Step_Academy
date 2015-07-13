using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BS.Presentation.Models
{
    public class WarehouseModel
    {

        #region DataProperty

        public int    Id            { get; set; }
        public string Name          { get; set; }
        public string Producer      { get; set; }
        public decimal Volume       { get; set; }
        public string Adress        { get; set; }


        #endregion

        #region Ctor

        public WarehouseModel(
             int id
            , string name
            , string producer
            , decimal volume
            , string adress
        )
        {
            Id = id;
            Name = name;
            Producer = producer;
            Volume = volume;
            Adress = adress;
        }

        #endregion

    }
}
