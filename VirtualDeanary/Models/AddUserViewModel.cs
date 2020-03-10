using VirtualDeanery.Data.Models;

namespace VirtualDeanary.Models
{
    public class AddUserViewModel
    {
        public string Password { get; set; }

        public string Email { get; set; }
        public int Year { get; set; }
        public string Name { get; set; }
        public string Lastname { get; set; }
    }
}
