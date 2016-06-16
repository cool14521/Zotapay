using System;
using System.IO;
using System.Threading.Tasks;

namespace ZotapayTest.Tools
{
    public class Logger
    {
        private readonly string m_logsFolder;

        public Logger(string logsFolder)
        {
            m_logsFolder = logsFolder;
        }

        public async Task LogAsync(string template, params object[] args)
        {
            var logRecord = string.Format(template, args);
            if (!Directory.Exists(m_logsFolder))
            {
                Directory.CreateDirectory(m_logsFolder);
            }

            var fileName = DateTime.Now.ToString("yyyyMMdd_HHmmss");
            var filePath = Path.Combine(m_logsFolder, fileName);
            using (var stream = new StreamWriter(filePath))
            {
                await stream.WriteLineAsync(logRecord);
            }
        }
    }
}