namespace BS.Presentation.Models
{
    public class CatalogModel
    {
        #region DataProperies

        public int      Id           { set; get; }
        public string   Name         { set; get; }
        public string   Producer     { set; get; }
        public string   Category     { set; get; }
        public string   SubCategory  { set; get; }
        public decimal  Volume       { set; get; }
        public string   VolMeasure   { set; get; }
        public string   Measure      { set; get; }
        public decimal  Price        { set; get; }

        #endregion

        #region Ctor

        public CatalogModel(
                 int        id               
                ,string     name          
                ,string     producer      
                ,string     category      
                ,string     subcategory   
                ,decimal    volume       
                ,string     volmeasure    
                ,string     measure       
                ,decimal    price        
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
