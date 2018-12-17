using DBModels.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tools;

namespace Managers
{
    public class SessionManager
    {
        #region Fields
        private static LabUser user;
        #endregion

        #region Properties
        public static LabUser User
        {
            get { return user; }
            set { user = value; }
        }
        #endregion

        public static void DeserializeLastUser()
        {
            try
            {
                User = SerializationManager.Deserialize<LabUser>(FileFolderHelper.LastUserFilePath);
            }
            catch (Exception ex)
            {
                Logger.Log("Failed to Deserialize last user", ex);
            }
        }

        public static void SerializeCurrentUser()
        {
            try
            {
                SerializationManager.Serialize<LabUser>(User, FileFolderHelper.LastUserFilePath);
                Logger.Log("User was serialized");
            }
            catch (Exception ex)
            {
                Logger.Log("Failed to serialize last user", ex);
            }
        }

        public static bool IsLastSessionActive()
        {
            return FileFolderHelper.LastUserFile.Exists;
        }

        public static void DestroyLastSession()
        {
            try
            {
                if (IsLastSessionActive())
                {
                    FileFolderHelper.LastUserFile.Delete();
                }
            }
            catch (IOException ex)
            {
                Logger.Log("Failed to delete last user autologin file", ex);
            }
        }
    }
}
