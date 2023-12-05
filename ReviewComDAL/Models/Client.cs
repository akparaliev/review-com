using System.ComponentModel.DataAnnotations;

namespace ReviewComDAL.Models {
    public class Client: IEntity
    {
        public int Id { get; set; }

        [Required, StringLength(100)]
        public string Name { get; set; }

        [EmailAddress]
        public string Email {get;set;}

        public virtual ICollection<Review> Reviews {get;set;}
    }
}