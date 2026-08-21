using System;
using System.ComponentModel.DataAnnotations;

namespace Eadent.Common.DataAccess.EntityFramework.Entities
{
    public class DatabaseVersionEntity
    {
        [Key]
        public int DatabaseVersionId { get; set; }

        public int Major { get; set; }

        public int Minor { get; set; }

        public int Patch { get; set; }

        public string Build { get; set; }

        public string Description { get; set; }

        public DateTime CreatedDateTimeUtc { get; set; }

        public DateTime? LastUpdatedDateTimeUtc { get; set; }
    }
}
