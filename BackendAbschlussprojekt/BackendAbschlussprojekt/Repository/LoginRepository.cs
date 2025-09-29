using BackendAbschlussprojekt.DB;
using BackendAbschlussprojekt.Repository.IRepository;
using Entity.Entities;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace BackendAbschlussprojekt.Repository
{
    public class LoginRepository : IRepository<LoginEntity>
    {
        protected readonly AufraumaktionContext oContext;
        private bool bDisposed = false;

        public LoginRepository(AufraumaktionContext oContext)
        {
            this.oContext = oContext;
        }

        ~LoginRepository() { Dispose(); }

        protected virtual void Disposed(bool bDisposing)
        {
            if(!this.bDisposed)
            {
                if(bDisposing)
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

        public LoginEntity GetByID(long nID)
        {
            return oContext.Login.Where(e => e.nID == nID).FirstOrDefault();
        }

        public LoginEntity GetByUsername(string sUsername)
        {
            return oContext.Login.Find(sUsername);
        }

        public IEnumerable<LoginEntity> GetAll()
        {
            throw new NotImplementedException();
        }

        public long Insert(LoginEntity oEntity)
        {
            EntityEntry<LoginEntity> oEntry = oContext.Login.Add(oEntity);
            oContext.SaveChanges();
            return oEntry.Entity.nID;
        }

        public void Update(LoginEntity oEntity)
        {
            LoginEntity oLogin = oContext.Login.Where(e => e.nID == oEntity.nID).FirstOrDefault();
            oLogin = oEntity;
            oContext.Update(oLogin);
            oContext.SaveChanges();
        }

        public void Delete(long nID)
        {
            LoginEntity oLogin = oContext.Login.Where(e => e.nID == nID).FirstOrDefault();
            oContext.Login.Remove(oLogin);
            oContext.SaveChanges();
        }
    }
}
