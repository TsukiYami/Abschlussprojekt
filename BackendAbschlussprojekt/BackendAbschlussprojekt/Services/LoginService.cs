using BackendAbschlussprojekt.Caches;
using BackendAbschlussprojekt.DB;
using BackendAbschlussprojekt.Mapper;
using BackendAbschlussprojekt.Repository;
using Entity.DTOs.Post;
using Entity.Entities;

namespace BackendAbschlussprojekt.Services
{
    public class LoginService
    {
        private LoginRepository oRepository;
        private LoginMapper oMapper;
        
        public LoginService(AufraumaktionContext oContext)
        {
            oRepository = new LoginRepository(oContext);
            oMapper = new LoginMapper();
        }

        public bool Post(LoginPostDTO oDTO)
        {
            LoginEntity oEntity = oMapper.PostLoginDTOToEntity(oDTO);
            long nID = oRepository.Insert(oEntity);

            if (nID >= 0)
            {
                return true;
            }
            return false;
        }

        public bool DeleteByID(long nID)
        {
            if (oRepository.GetByID(nID) != null)
                oRepository.Delete(nID);
            return true;
        }

        public LoginEntity GetByID(long nID)
        {
            return oRepository.GetByID(nID);
        }

        public (bool, Guid?) LogIn(string sUsername, string sPassword)
        {
            LoginEntity oEntity = oRepository.GetByUsername(sUsername);

            if(oEntity.sPassword == sPassword)
            {
                Guid oGUID = Guid.NewGuid();
                if(UserCache.AddLoginToCache(oGUID, oEntity))
                {
                    return (true, oGUID);
                }
            }
            return (false, null);
        }
    }
}