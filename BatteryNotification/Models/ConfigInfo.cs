using BatteryNotification.Tools;
using Newtonsoft.Json;
using System.IO;

namespace BatteryNotification.Models
{
    [JsonObject(MemberSerialization.OptOut)]
    public class ConfigInfo
    {
        #region Fields

        public static readonly string FILE_NAME = "config.json";
        public static readonly string FULL_PATH = string.Format("{0}{1}", Paths.CONFIG_FOLDER_PATH, FILE_NAME);

        #endregion

        #region Constructors

        public ConfigInfo()
        {

        }

        #endregion

        #region Properties

        /// <summary>
        /// 알림 기능 사용 여부.
        /// </summary>
        public bool IsUseNotice
        {
            get;
            set;
        } = true;

        #endregion

        /// <summary>
        /// 마지막 목표 고도.
        /// </summary>
        public int MinPercent
        {
            get;
            set;
        } = 70;

        #region Public methods

        public static ConfigInfo Load()
        {
            ConfigInfo config = JsonTool<ConfigInfo>.Import(FULL_PATH);
            config ??= new ConfigInfo();

            return config;
        }

        public void Save()
        {
            if (Directory.Exists(Paths.CONFIG_FOLDER_PATH) == false)
            {
                _ = Directory.CreateDirectory(Paths.CONFIG_FOLDER_PATH);
            }

            JsonTool<ConfigInfo>.Export(FULL_PATH, this);
        }

        #endregion
    }
}
