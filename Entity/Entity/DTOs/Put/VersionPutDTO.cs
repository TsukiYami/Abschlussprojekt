using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.DTOs.Put
{
    public class VersionPutDTO
    {
        public VersionPutDTO(long nID, string sVersionPath, bool bDeleteVersion)
        {
            this.nID = nID;
            this.sVersionPath = sVersionPath;
            this.bDeleteVersion = bDeleteVersion;
        }

        public long nID { get; private set; }

        public string sVersionPath { get; private set; }

        public bool bDeleteVersion { get; set; }
    }
}
