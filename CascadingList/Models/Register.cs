namespace CascadingList.Models
{
    public class Register
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Country { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public int Mobile { get; set; }
        public string Address { get; set; }
        public bool? Isactive { get; set; }
        public string Createdby { get; set; }
        public DateTime CreatedDate { get; set; }
        public string Updatedby { get; set; }
        public DateTime UpdatedDate { get; set; }

    }
}
