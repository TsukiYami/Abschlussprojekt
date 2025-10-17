using Entity.DTOs.Delete;
using Entity.DTOs.Get;
using Entity.DTOs.Post;
using Entity.DTOs.Put;
using Entity.Entities;

namespace BackendAbschlussprojekt.Mapper
{
    public class VersionMapper
    {
        public VersionGetDTO VersionEntityToVersionGetDTO(VersionEntity oEntity)
        {
            VersionGetDTO oDTO = new VersionGetDTO(
                oEntity.nID,
                oEntity.sVersionPath,
                oEntity.bDeleteVersion);

            return oDTO;
        }

        public VersionEntity PutVersionDTOToEntity(VersionPutDTO oDTO)
        {
            VersionEntity oEntity = new VersionEntity(
                oDTO.nID,
                oDTO.sVersionPath,
                oDTO.bDeleteVersion);

            return oEntity;
        }

        public VersionGetDTO GetVersionDTOFromEntity(VersionEntity oEntity)
        {
            return new VersionGetDTO(oEntity.nID, oEntity.sVersionPath, oEntity.bDeleteVersion);
        }
    }
}
