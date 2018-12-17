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
        LabUser GetUserByLogin(string login);
        [OperationContract]
        void AddUser(LabUser user);
        [OperationContract]
        void AddQuery(Query query);
        [OperationContract]
        void SaveQuery(Query query);
    }
}
