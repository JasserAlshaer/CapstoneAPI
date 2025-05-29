namespace CapstoneAPI.Entities
{
    public abstract class MainEntity
    {

        //Primary Key - Identity
        public int Id { get; set; }
        public string CreatedBy { get; set; } = "System";// nvarchar(max) not allowed to be null
        public string? UpdatedBy { get; set; } //nvarhcar(max) nullable
        public DateTime CreationDate { get; set; } = DateTime.Now; //DateTime not null
        public DateTime? UpdatedDate { get; set; }//DateTime nullable
        public bool IsActive { get; set; } = true; //bit not null  with default value of true 
    }
}
