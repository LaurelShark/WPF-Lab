using DBAdapter;
using DBModels.Models;

namespace AlarmClockService
{
    class AlarmClockService : AlarmClockServiceInterface.IAlarmClockContract
    {
        public bool UserExists(string login)
        {
            return EntityWrapper.UserExists(login);
        }

        public LabUser GetUserByLogin(string login)
        {
            return EntityWrapper.GetUserByLogin(login);
        }

        public void AddUser(LabUser user)
        {
            EntityWrapper.AddUser(user);
        }

        public void AddQuery(Query query)
        {
            EntityWrapper.AddQuery(query);
        }

        public void SaveQuery(Query query)
        {
            EntityWrapper.SaveQuery(query);
        }
    }
}
