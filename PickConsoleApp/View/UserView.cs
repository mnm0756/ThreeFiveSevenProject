using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PickUpConsoleApp.Model;

namespace PickUpConsoleApp.View
{

    public class UserView
    {
        public void PrintUser(User user)
        {
            string strRowItems = string.Join(",", user.MatchList);

            string sMessage = string.Format("用户:{0}   已拿火柴{1}", user.Name.ToString(), strRowItems);
            SystemLog.Log(sMessage);
        }

    }

}
