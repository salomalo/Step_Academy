using System.Configuration;
using System.Windows.Forms;

namespace _003_SqlBulkCopy_notifyAfter
{
    public partial class Form1 : Form
    {
        private static string _cs = ConfigurationManager.ConnectionStrings["CS"].ConnectionString;

        public Form1()
        {
            InitializeComponent();
        }
    }
}
