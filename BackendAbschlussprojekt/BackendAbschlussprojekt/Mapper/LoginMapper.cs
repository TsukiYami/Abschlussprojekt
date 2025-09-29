using Entity.DTOs.Delete;
using Entity.DTOs.Get;
using Entity.DTOs.Post;
using Entity.Entities;

namespace BackendAbschlussprojekt.Mapper
{
    public class LoginMapper
    {
        public LoginEntity PostLoginDTOToEntity(LoginPostDTO oDTO)
        {
            return new LoginEntity(oDTO.sUsername, oDTO.sPassword);
        }

        public LoginGetDTO GetLoginDTOFromEntity(LoginEntity oEntity)
        {
            return new LoginGetDTO(oEntity.nID, oEntity.sUsername, oEntity.sPassword);
        }

        public LoginEntity DeleteLoginDTOToEntity(LoginDeleteDTO oDTO)
        {
            return new LoginEntity(oDTO.nID, oDTO.sUsername, oDTO.sPassword);
        }
    }
}