using BackendAbschlussprojekt.DB;
using BackendAbschlussprojekt.Mapper;
using BackendAbschlussprojekt.Repository;
using Entity.DTOs.Get;
using Entity.DTOs.Put;
using Entity.Entities;

namespace BackendAbschlussprojekt.Services
{
    public class VersionService
    {
        private VersionRepository oRepository;
        private VersionMapper oMapper;

        public VersionService(AufraumaktionContext oContext)
        {
            oRepository = new VersionRepository(oContext);
            oMapper = new VersionMapper();
        }

        public List<VersionGetDTO> GetAll()
        {
            IEnumerable<VersionEntity> voEntity = oRepository.GetAll();
            List<VersionGetDTO> voDTOs = new List<VersionGetDTO>();

            foreach (VersionEntity oEntity in voEntity)
            {
                voDTOs.Add(oMapper.GetVersionDTOFromEntity(oEntity));
            }

            return voDTOs;
        }

        public VersionGetDTO GetByID(long nID)
        {
            return oMapper.GetVersionDTOFromEntity(oRepository.GetByID(nID));
        }

        public VersionGetDTO Update(VersionPutDTO oDTO)
        {
            VersionEntity oEntity = oMapper.PutVersionDTOToEntity(oDTO);
            oRepository.Update(oEntity);

            return oMapper.VersionEntityToVersionGetDTO(oRepository.GetByID(oEntity.nID));
        }
    }
}