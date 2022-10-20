using System.Diagnostics;
using System.IO;
using System.Reflection;

namespace BatteryNotification.Models
{
    /// <summary>
    /// 상수 필드 클래스.
    /// </summary>
    public class Paths
    {
        /// <summary>
        /// 억세스위 폴더 경로.
        /// </summary>
        public static string ACCESSWE_FOLDER_PATH = string.Format(@"{0}\Accesswe\", Directory.GetCurrentDirectory());
        /// <summary>
        /// 제품 경로.
        /// </summary>
        public static string BATTERY_NOTIFICATION_FOLDER_PATH => string.Format(@"{0}GCS\", ACCESSWE_FOLDER_PATH);

        /// <summary>
        /// 로그 파일 저장 경로.
        /// </summary>
        public static string LOG_FOLDER_PATH => string.Format(@"{0}logs\", BATTERY_NOTIFICATION_FOLDER_PATH);

        /// <summary>
        /// 설정 폴더 경로.
        /// </summary>
        public static string CONFIG_FOLDER_PATH => string.Format(@"{0}config\", BATTERY_NOTIFICATION_FOLDER_PATH);
    }
}
