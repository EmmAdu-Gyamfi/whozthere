using System.ComponentModel.DataAnnotations;

namespace whozthere_blazor
{
    public class SyncData
    {

        [Key]
        public int Id { get; set; }

        public string query { get; set; }

        public DateTime CreatedAt { get; set; }
    }
}
