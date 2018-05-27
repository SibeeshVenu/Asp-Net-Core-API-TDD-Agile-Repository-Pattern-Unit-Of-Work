using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace M4Movie.Api.Contracts
{
    [Serializable]
    public class Movie
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long MovieId { get; set; }

        [DataType(DataType.Text), MaxLength(50), Required]
        public string MovieName { get; set; }

        [DataType(DataType.Text), MaxLength(750)]
        public string MovieDescription { get; set; }

        [DataType(DataType.ImageUrl), MaxLength(500), Required]
        public string MovieImage { get; set; }

        [DataType(DataType.Text), MaxLength(20)]
        public string MoviRating { get; set; }
    }
}
