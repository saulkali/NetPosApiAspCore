using System.ComponentModel.DataAnnotations;

namespace PyPosApi.common.entities
{
    public class UserEntity
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }
        public Guid IdUserRolScheme { get; set; }
        public string Phone { get; set; }

    }
}
