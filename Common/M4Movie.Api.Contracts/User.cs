using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace M4Movie.Api.Contracts
{
    [Serializable]
    public class User
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long UserId { get; set; }

        [DataType(DataType.Text), MaxLength(50), Required]
        public string UserName { get; set; }

        [DataType(DataType.ImageUrl), MaxLength(200), Required]
        public string UserImage { get; set; }

        [DataType(DataType.EmailAddress), MaxLength(50)]
        public string UserEmail { get; set; }
    }
}
