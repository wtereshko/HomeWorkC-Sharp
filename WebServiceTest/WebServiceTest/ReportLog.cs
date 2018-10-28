using System;
using System.IO;

namespace WebServiceTest
{
    public class ReportLog
    {
        #region Fields

        private static StreamWriter streamWriter;
        private static FileStream fileStream;
        private static string directory;

        #endregion

        #region Public Methods

        public static void Dispose()
        {
            if (streamWriter != null)
            {
                streamWriter.Close();
            }
        }

        /// <summary>
        /// Initialization logging
        /// </summary>
        public static void InitializationLogging(string fileName)
        {
            directory = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);

            DirectoryInfo lDirectoryInfo = new DirectoryInfo(string.Format("{0}\\TestsLog\\", directory));
            if (!lDirectoryInfo.Exists)
            {
                lDirectoryInfo.Create();
            }

            fileStream =
                File.Open(
                    string.Format("{0}\\TestsLog\\{1}.{2}.txt", directory, fileName, DateTime.Now.ToString("MM/dd/yyyy")),
                    FileMode.Append,
                    FileAccess.Write,
                    FileShare.Read);
            streamWriter = new StreamWriter(fileStream);
        }

        /// <summary>
        /// Write log
        /// </summary>
        /// <param name="exception"></param>
        /// <param name="message"></param>
        public static void WritingLogging(Exception exception, string message = "Message empty")
        {
            if (exception != null)
            {
                streamWriter.WriteLine("{0}: {1}",DateTime.Now, string.Format($"{exception.Message} \n stack trace:\n {exception.StackTrace}"));
            }
            else
            {
                streamWriter.WriteLine("{0}; {1}", DateTime.Now, message);
            }
                
                streamWriter.Flush();
            }
        
        #endregion
    }
}
