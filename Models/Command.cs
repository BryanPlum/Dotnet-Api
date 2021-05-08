using System.ComponentModel.DataAnnotations;

namespace CmdiApi.Models
{
    public class Command
    {
        [Key]
        public int Id { get; set; }
        public string HowTo { get; set; }
        public string Plataform { get; set; }
        public string CommandLine { get; set; }
    }
}

