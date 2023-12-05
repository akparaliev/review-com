using System.ComponentModel.DataAnnotations;

namespace ReviewComDAL.Models {
    public class Review: IEntity
    {
        public int Id { get; set; }
       
        [Required, StringLength(100)]
        public string Text { get; set; }
        
        [Required]
        public int Performance {get;set;}
        
        public Client Client {get; set;}
        
        public Company Company {get; set;}
    }
}