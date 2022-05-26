using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PickUpConsoleApp
{
    /// <summary>
    /// 系统日志类
    /// </summary>
    public class SystemLog
    {

        /// <summary>
        /// 记录日志，并显示
        /// </summary>
        /// <param name="message"></param>
        public static void Log(string message)
        {
            Console.WriteLine(message);

        }

        /// <summary>
        /// 记录错误，并显示
        /// </summary>
        /// <param name="message"></param>
        public static void Error(string message)
        {
            Console.WriteLine(message);

        }
    }
}
