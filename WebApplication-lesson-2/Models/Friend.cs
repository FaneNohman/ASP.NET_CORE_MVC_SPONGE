using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication_lesson_2.Models
{
    public class Friend
    {
        public Guid FriendId { get; set; }

        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        public string? Job { get; set; }

        public string? JobPlace { get; set; }

        public string? SkinColor { get; set; }

        [ForeignKey("HomeId")]
        public Home? Home{ get; set; }

    }
}
