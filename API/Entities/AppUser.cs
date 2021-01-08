namespace API.Entities
{
    public class AppUser
    {
        public int Id { get; set; } //Primary Key Using the word 'Id' is the convention to use with entity framework
    
        public string UserName { get; set; }

        public byte[] PasswordHash{ get; set; }

        public byte[] PasswordSalt{ get; set; }
    } 

}