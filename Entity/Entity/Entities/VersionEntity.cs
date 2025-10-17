using System.ComponentModel.DataAnnotations.Schema;

namespace Entity.Entities
{
    public class VersionEntity
    {
        public VersionEntity(long nID, string sVersionPath, bool bDeleteVersion) {
            this.nID = nID;
            this.sVersionPath = sVersionPath;
            this.bDeleteVersion = bDeleteVersion;
        }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long nID { get; private set; }

        public string sVersionPath { get; private set; }

        public bool bDeleteVersion { get; set; }
    }
}