using System.ComponentModel.DataAnnotations.Schema;

namespace Entity.Entities
{
    public class LoginEntity
    {
        public LoginEntity(long nID, string sUsername, string sPassword)
        {
            this.nID = nID;
            this.sUsername = sUsername;
            this.sPassword = sPassword;
        }

        public LoginEntity(string sUsername, string sPassword)
        {
            this.sUsername = sUsername;
            this.sPassword = sPassword;
        }


        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long nID { get; private set; }
        public string sUsername { get; private set; }
        public string sPassword { get; private set; }
    }
}