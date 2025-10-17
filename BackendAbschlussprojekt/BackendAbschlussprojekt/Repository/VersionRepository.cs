using BackendAbschlussprojekt.DB;
using BackendAbschlussprojekt.Repository.IRepository;
using Entity.Entities;

namespace BackendAbschlussprojekt.Repository
{
    public class VersionRepository : IRepository<VersionEntity>
    {
        protected readonly AufraumaktionContext oContext;
        private bool bDisposed = false;

        public VersionRepository(AufraumaktionContext oContext)
        {
            this.oContext = oContext;
        }

        ~VersionRepository() { Dispose(); }

        protected virtual void Disposed(bool bDisposing)
        {
            if (!this.bDisposed)
            {
                if (bDisposing)
                {
                    oContext.Dispose();
                }
            }
            this.bDisposed = true;
        }

        public void Dispose()
        {
            Disposed(true);
            GC.SuppressFinalize(this);
        }

        public void Delete(long nID)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<VersionEntity> GetAll()
        {
            return oContext.oVersion;
        }

        public VersionEntity GetByID(long nID)
        {
            return oContext.oVersion.Find(nID);
        }

        public VersionEntity GetByVersionName(string sVersion)
        {
            return oContext.oVersion.Find(sVersion);
        }

        public long Insert(VersionEntity oEntity)
        {
            throw new NotImplementedException();
        }

        public void Update(VersionEntity oEntity)
        {
            VersionEntity oVersion = oContext.oVersion.Where(e => e.nID == oEntity.nID).FirstOrDefault();
            oVersion = oEntity;
            oContext.Update(oVersion);
            oContext.SaveChanges();
        }
    }
}