using Entity.Entities;

namespace BackendAbschlussprojekt.Caches
{
    public class UserCache
    {
        private static Dictionary<Guid, LoginEntity> mooLogin = new Dictionary<Guid, LoginEntity>();

        public static LoginEntity GetLoginFromGUID(Guid oGUID)
        {
            return mooLogin[oGUID];
        }

        public static bool AddLoginToCache(Guid oGUID, LoginEntity oEntity)
        {
            if (mooLogin[oGUID] != null)
            {
                return false;
            }

            mooLogin.Add(oGUID, oEntity);
            return true;
        }

        public static bool RemoveLoginFromCache(Guid oGUID)
        {
            return mooLogin.Remove(oGUID);
        }
    }
}
