namespace Entity.DTOs.Delete
{
    public class LoginDeleteDTO
    {
        public LoginDeleteDTO(long nID, string sUsername, string sPassword)
        {
            this.nID = nID;
            this.sUsername = sUsername;
            this.sPassword = sPassword;
        }

        public long nID { get; set; }
        public string sUsername { get; set; }
        public string sPassword { get; set; }
    }
}