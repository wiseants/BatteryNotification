using Newtonsoft.Json;
using System;
using System.IO;

namespace BatteryNotification.Tools
{
    /// <summary>
    /// json 파일로 가져오기/내보내기 도구.
    /// </summary>
    /// <typeparam name="T">변환 타입.</typeparam>
	public class JsonTool<T>
    {
        /// <summary>
        /// 파일로 내보내기.
        /// </summary>
        /// <param name="fileFullpath">파일 전체 경로.</param>
        /// <param name="target">내보내기 할 오브젝트.</param>
		public static void Export(string fileFullpath, object target, JsonSerializerSettings settings = null)
        {
            string folderPath = Directory.GetParent(fileFullpath).FullName;
            if (Directory.Exists(folderPath) == false)
            {
                _ = Directory.CreateDirectory(folderPath);
            }

            string writeString = JsonConvert.SerializeObject(target, settings);
            if (string.IsNullOrEmpty(writeString) == false)
            {
                File.WriteAllText(fileFullpath, writeString);
            }
        }

        /// <summary>
        /// 파일 내용을 가져오기.
        /// </summary>
        /// <param name="fileName">파일 전체 경로.</param>
        /// <param name="settings">json 직렬화 옵션.</param>
        /// <returns>가져오기 한 오브젝트.</returns>
		public static T Import(string fileName, JsonSerializerSettings settings = null)
        {
            _ = TryImport(fileName, out T result, settings);

            return result;
        }

        /// <summary>
        /// 파일 내용을 가져오기.
        /// </summary>
        /// <param name="fileName">파일 전체 경로.</param>
        /// <param name="result">결과 객체.</param>
        /// <param name="settings">json 직렬화 옵션.</param>
        /// <returns></returns>
        public static bool TryImport(string fileName, out T result, JsonSerializerSettings settings = null)
        {
            result = default;

            bool isResult = false;
            if (File.Exists(fileName) == false)
            {
                return isResult;
            }

            try
            {
                string readString = File.ReadAllText(fileName);
                if (string.IsNullOrEmpty(readString) == false)
                {
                    result = JsonConvert.DeserializeObject<T>(readString, settings);
                    isResult = default(T) == null ? false : default(T).Equals(result) == false;
                }
            }
            catch (IOException ex)
            {
            }
            catch (Exception ex)
            {
            }

            return isResult;
        }
    }
}
