namespace Entity.DTOs.Post
{
    public class LoginPostDTO
    {
        public LoginPostDTO(long nID, string sUsername, string sPassword)
        {
            this.nID = nID;
            this.sUsername = sUsername;
            this.sPassword = sPassword;
        }

        public long nID { get; private set; }
        public string sUsername { get; set; }
        public string sPassword { get; set; }
    }
}
