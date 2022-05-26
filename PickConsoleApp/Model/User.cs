using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PickUpConsoleApp.Model
{
 
    /// <summary>
    /// 用户类
    /// </summary>
    public  class UserClass
    {
        /// <summary>
        /// 用户名
        /// </summary>
        public EnumUserName Name { get; set; }

        /// <summary>
        ///属于该用户的 火柴IDList 
        /// </summary>
        public List<int> MatchList { get; set; }=new List<int>();

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="enumUser"></param>
        public UserClass(EnumUserName enumUser)
        {
            Name = enumUser;
        }

        /// <summary>
        /// 用户拿火柴
        /// </summary>
        /// <param name="matchNo">火柴ID</param>
        /// <returns></returns>
        public bool PickUpMatch(int matchNo)
        {
            if ((matchNo > 0) && (matchNo < 16))
            {
                MatchList.Add(matchNo);
            }
            //string sMessage = string.Format("用户:{0}   拿了火柴{1}", Name.ToString(), matchNo);
            //SystemLog.Log(sMessage);

            return true;
        }




    }


}
