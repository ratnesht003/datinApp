using API.Extensions;

namespace API.Entities
{
    public class AppUser
    {
        public int Id {  get; set; }
        public required string UserName { get; set; }
        public byte[] PasswordHash { get; set; } = [];
        public byte[] passwordSalt { get; set; } = [];
        public DateOnly DateofBirth { get; set; }
        public required string KnonAs { get; set; }
        public DateTime Created { get; set; } = DateTime.UtcNow;
        public DateTime LastActive { get; set; }=DateTime.UtcNow;
        public required string gender { get; set; }
        public string? Introduction {  get; set; }
        public string? Intrestes { get; set; }
        public string? LookingFor {  get; set; }
        public required string city { get; set; }
        public required string country { get; set; }
        public List<Photo> Photos { get; set;}

        //public int GetAge()
        //{
        //    return DateofBirth.CalculateAge();
        //}

    }
}
