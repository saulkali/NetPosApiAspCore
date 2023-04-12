using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PyPosApi.common.database.schemes
{
    public class UserScheme:BaseScheme
    {
        [Required]
        [MaxLength(30)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(30)]
        public string LastName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [RegularExpression("")]
        [MinLength(4)]
        public string Password { get; set; }
        public Guid IdUserRolScheme { get; set; }
        [Required]
        public string RFC { get; set; }
        [Required]

        public string Address { get; set; }
        [Required]

        public string City { get; set; }
        [Required]

        public int CodePostal { get; set; }
 

        [Phone]
        public string Phone { get; set; }

        [ForeignKey("IdUserRolScheme")]
        public virtual UserRolScheme? UserRolScheme { get; set; }
    }
}
