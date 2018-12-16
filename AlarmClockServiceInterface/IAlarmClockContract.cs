using DBModels.Models;
using System.ServiceModel;

namespace AlarmClockServiceInterface
{
    [ServiceContract]
    public interface IAlarmClockContract
    {
        [OperationContract]
        bool UserExists(string login);
        [OperationContract]
        User GetUserByLogin(string login);
        [OperationContract]
        void AddUser(User user);
        [OperationContract]
        void AddQuery(Query query);
        [OperationContract]
        void SaveQuery(Query query);
    }
}
