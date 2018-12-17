using DBModels.Models;
using System.ServiceModel;


namespace AlarmClockServiceInterface
{
    public class AlarmClockServiceWrapper
    {
        public static bool UserExists(string login)
        {
            using (var myChannelFactory = new ChannelFactory<IAlarmClockContract>("Server"))
            {
                IAlarmClockContract client = myChannelFactory.CreateChannel();
                return client.UserExists(login);
            }
        }

        public static LabUser GetUserByLogin(string login)
        {
            using (var myChannelFactory = new ChannelFactory<IAlarmClockContract>("Server"))
            {
                IAlarmClockContract client = myChannelFactory.CreateChannel();
                return client.GetUserByLogin(login);
            }
        }

        public static void AddUser(LabUser user)
        {
            using (var myChannelFactory = new ChannelFactory<IAlarmClockContract>("Server"))
            {
                IAlarmClockContract client = myChannelFactory.CreateChannel();
                client.AddUser(user);
            }
        }

        public static void AddQuery(Query query)
        {
            using (var myChannelFactory = new ChannelFactory<IAlarmClockContract>("Server"))
            {
                IAlarmClockContract client = myChannelFactory.CreateChannel();
                client.AddQuery(query);
            }
        }

        public static void SaveQuery(Query query)
        {
            using (var myChannelFactory = new ChannelFactory<IAlarmClockContract>("Server"))
            {
                IAlarmClockContract client = myChannelFactory.CreateChannel();
                client.SaveQuery(query);
            }
        }
    }
}
