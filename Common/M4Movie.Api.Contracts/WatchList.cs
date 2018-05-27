using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace M4Movie.Api.Contracts
{
    [Serializable]
    public class WatchList
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long WatchListId { get; set; }

        public long UserId { get; set; }

        public long MovieId { get; set; }

        public Movie Movie { get; set; }
    }
}
