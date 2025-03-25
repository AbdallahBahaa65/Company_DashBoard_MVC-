namespace Demo.DataAccess.Models.Shared.Classes
{
    public class BaseEntity
    {
        public int Id { get; set; } // PK 
        public int CreatedBy { get; set; } //User Id    

        public int LastModifiedBy { get; set; } // User Id 

        public DateTime? CreatedOn { get; set; }
        public DateTime? LastModifiedOn { get; set; }

        public bool IsDeleted { get; set; } // Soft  Delete 
    }
}
