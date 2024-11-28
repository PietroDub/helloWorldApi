using Microsoft.AspNetCore.Identity;

namespace helloWorldApi.Models
{
    public class Appuser
    {
        public Guid AppuserId { get; set; }
        public int Level { get; set; }
        public IdentityUser? User { get; set; }
    }
}
