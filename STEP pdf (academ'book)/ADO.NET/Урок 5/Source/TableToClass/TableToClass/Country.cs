using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data.Linq;
using Microsoft.SqlServer.Types;
using System.Data.Linq.Mapping;

namespace TableToClass
{
    [Table()]
    public sealed class Country
    {
     [Column(AutoSync = AutoSync.OnInsert, DbType = "int", 
         IsPrimaryKey = true, IsDbGenerated = true, UpdateCheck = UpdateCheck.Never)]
      public int Id;
    [Column(DbType = "nvarchar(40)", CanBeNull = true, Name="Name")]
       public string CountryName;
	    [Column(DbType = "float",  CanBeNull = true)]
	    public float Square;
	 }

    
    public class ExampleDatabase: DataContext
	 {
	    public Table<Country> Country;
	    public ExampleDatabase(string connectionString)
	     : base(connectionString)
	    {
	 
	    }
	 }

}
