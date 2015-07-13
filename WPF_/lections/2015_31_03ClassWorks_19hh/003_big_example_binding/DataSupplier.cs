using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace _003_big_example_binding
{
    public class DataSupplier
    {
        public static List<Employee> GetEmployee()
        { 
            //Thread.Sleep(4000);

            return new List<Employee> { 
                
                new Employee {Id = 101, Name="Bender Rodriguez", Department="IT", JobTitle="super user", Phone="(063) 110 - 10 -10",
                    //PhotoUri = new Uri( @"pack://application:,,,/photos/Bender_Rodriguez.png", UriKind.Absolute)
                    PhotoUri = new Uri( @"photos/Bender_Rodriguez.png", UriKind.Relative)
                }
                , new Employee {Id = 102, Name="Philip Fry", Department="IT", JobTitle="developer", Phone="(063) 110 - 10 -11",
                    PhotoUri = new Uri( @"photos/Philip_Fry.png", UriKind.Relative)
                }
            
                , new Employee {Id = 103, Name="Dr John Zoidberg", Department="IT", JobTitle="developer", Phone="(063) 110 - 10 -12",
                    PhotoUri = new Uri( @"photos/Dr_John_Zoidberg.png", UriKind.Relative)
                }
            
            };
        }

        public static ImageSource LoadPicture(Uri uri)
        {
            return new BitmapImage(uri);
        }
    }
}