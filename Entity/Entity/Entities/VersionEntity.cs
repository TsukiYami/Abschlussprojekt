using System.ComponentModel.DataAnnotations.Schema;

namespace Entity.Entities
{
    public class VersionEntity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long nID { get; private set; }

        public string sVersionPath { get; private set; }

        public bool bDeleteVersion { get; set; }
    }
}