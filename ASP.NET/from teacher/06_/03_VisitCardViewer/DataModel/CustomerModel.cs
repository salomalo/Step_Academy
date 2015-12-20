using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel
{
    [Table("CustomerInfo")]
    public class CustomerInfo
    {
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        [MaxLength(25)]
        public string Name { get; set; }
        [Required]
        [MaxLength(25)]
        public string Surname { get; set; }
        [Required]
        [MaxLength(40)]
        public string Profession { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.PhoneNumber)]
        public string Phone { get; set; }
    }

    [Table("CustomerProfile")]
    public class CustomerProfile : CustomerInfo
    {
        public CustomerProfile()
        {
            SavedCards = new List<VisitCardModel>();
        }
        [Required]
        public DateTime Birthday { get; set; }
        [Required]
        public string Login { get; set; }
        [Required]
        [MaxLength(15)]
        [MinLength(6)]
        //[RegularExpression("pattern")]
        public string Password { get; set; }

        public /*!!!!*/ virtual List<VisitCardModel> SavedCards { get; set; }

        public VisitCardModel OwnCard
        {
            get
            {
                return (SavedCards.Count > 0) ? SavedCards.FirstOrDefault(c => c.Info.Id == this.Id) : null;
            }
        }
        public bool HasOwnCard { get { return OwnCard != null; } }
    }
    [Table("VisitCardModel")]
    public class VisitCardModel
    {
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public virtual CustomerInfo Info { get; set; }
        public string Url { get; set; }
        public virtual List<CustomerProfile> Profiles { get; set; }
    }
}
