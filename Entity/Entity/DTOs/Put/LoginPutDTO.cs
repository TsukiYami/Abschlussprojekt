namespace Entity.DTOs.Put
{
    public class LoginPutDTO
    {
        public LoginPutDTO(long nID, string sUsername, string sPassword)
        {
            this.nID = nID;
            this.sUsername = sUsername;
            this.sPassword = sPassword;
        }

        public long nID { get; private set; }
        public string sUsername { get; private set; }
        public string sPassword { get; private set; }
    }
}
