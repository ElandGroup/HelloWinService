using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace HelloWinService.data.Service
{
    public class SimpleService
    {
        public static void TestCode()
        {
            string path = @"c:\good.txt";
            if (!File.Exists(path))
                File.Create(path);
            File.AppendAllText(path, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "hello windows service Quartz" + "\r\n");
        }
        public static void TestCode(string fileName)
        {
            string path = @"c:\test.txt";
            if (!File.Exists(path))
                File.Create(path);
            File.AppendAllText(path, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + fileName + "\r\n");
        }
    }
}
