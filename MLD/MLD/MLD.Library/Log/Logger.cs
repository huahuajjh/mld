using System;
using System.IO;
using System.Text;
using MLD.Library.Constant;
using MLD.Library.SerializeHelper;

namespace MLD.Library.Log
{
    /// <summary>
    /// 日志记录
    /// </summary>
    public static class Logger
    {
        private static readonly string Path = ConfigFileHelper.GetAppSettingValue(DiKey.LOGGER);
        private static FileStream _file;
        private static StreamWriter _sw;

        public static void Info(string position,string msg)
        {
            ReadOrCreateLogFile();
            var sb = new StringBuilder();
            sb.Append("[info]-[").Append(DateTime.Now+"]-[").Append(position+"]---").Append("[").Append(msg+"]");
            _sw.WriteLine(sb.ToString());
            _sw.Close();
            _file.Close();
            _sw = null;
            _file = null;
        }

        private static void ReadOrCreateLogFile()
        {
            string filePath = Path + "/" + "log-"+DateTime.Now.ToString("d");
            if (!Directory.Exists(Path))
            {
                Directory.CreateDirectory(Path);
            }
            //打开或者创建文件
            if (null == _file)
            {
                _file = new FileStream(filePath, FileMode.OpenOrCreate, FileAccess.ReadWrite);
            }
            
            if (null == _sw)
            {
                _sw = new StreamWriter(_file);
            }
        }
    }
}
