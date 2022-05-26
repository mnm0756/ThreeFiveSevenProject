using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using PickUpConsoleApp.View;
using PickUpConsoleApp.Model;

namespace PickUpConsoleApp.Controller
{

    /// <summary>
    /// 用户 Controller
    /// </summary>
    public class UserController
    {
        /// <summary>
        /// 根据UserName 取得User
        /// </summary>
        /// <param name="UserName">username 从EnumUser中选1</param>
        /// <returns>User</returns>
        public UserClass GetUser(EnumUserName UserName)
        {
            return UserListClass.GetUser(UserName);
        }
        /// <summary>
        /// 打印用户类的信息
        /// </summary>
        /// <param name="user">user</param>
        public void PrintUser(UserClass user)
        {
            UserView userView = new UserView();
            userView.PrintUser(user);
        }

        /// <summary>
        /// 用户拿火柴
        /// </summary>
        /// <param name="user">user</param>
        /// <param name="matchNoList">拿的火柴ID 列表</param>
        /// <returns></returns>
        public bool PickUpMatch(UserClass user,string matchNoList)
        {
            string sMessage = string.Format("用户:{0}   拿了火柴{1}", user.Name, matchNoList);
            SystemLog.Log(sMessage);

            //检查是否全是数字
            if (!CheckIsNumber(matchNoList))
            {
                return false;
            }

            //检查 MatchNo 是否属于同一行 和是否属于列表中
            if (!CheckMatchNoInRows(matchNoList))
            {
                return false;
            }

            //把火柴放入用户的火柴列表中
            string[] matchNoArray = matchNoList.Split(',');

            for (int i = 0; i < matchNoArray.Length; i++)
            {
                string matchNo = matchNoArray[i];
                int iMatchNO = int.Parse(matchNo);

                MatchesListClass.RomveMatch(iMatchNO);
                user.PickUpMatch(iMatchNO);
            }
            //检查用户是否已经获胜了
            CheckResult(user);
            return true;
        }

        /// <summary>
        /// 检查是否全是数字
        /// </summary>
        /// <param name="matchNoList">火柴ID 列表</param>
        /// <returns></returns>
        private bool CheckIsNumber(string matchNoList)
        {

            matchNoList = matchNoList.Replace(",", "").Trim();
            Regex regex = new System.Text.RegularExpressions.Regex(@"^[0-9]\d*$");
            bool result = regex.IsMatch(matchNoList);

            if (!result)
            {
                SystemLog.Error("火柴ID非数字！");
            }

            return result;
        }

        /// <summary>
        /// 检查 MatchNo 是否属于火柴列表中
        /// </summary>
        /// <param name="matchNoList">火柴ID 列表</param>
        /// <returns></returns>
        private bool CheckMatchNoInList(string matchNoList)
        {
            bool result = true;

            //取得所有的Match List
            List<int> allItems = new List<int>();
            foreach (var item in MatchesListClass.GetData())
            {
                List<int> rowItems = item.Value;
                allItems.AddRange(rowItems);
            }


            string [] matchNoArray = matchNoList.Split(',');
            for (int i = 0; i < matchNoArray.Length; i++)
            {
                if (!allItems.Contains(int.Parse(matchNoArray[i])))
                {
                    SystemLog.Error("火柴ID非法！");
                    return false;
                }
            }
            return result;
        }


        /// <summary>
        /// 检查 MatchNo 是否属于同一行 和是否属于列表中
        /// </summary>
        /// <param name="matchNoList">火柴ID 列表</param>
        /// <returns></returns>
        private bool CheckMatchNoInRows(string matchNoList)
        {
            bool result = true;

            //取得所有的Match List
           Dictionary<int, int> allItems = new Dictionary<int, int>();

            foreach (var item in MatchesListClass.GetData())
            {
                List<int> rowItems = item.Value;

                foreach (var row in rowItems)
                {
                    allItems.Add(row, item.Key);
                }
            }

            List<int> rowsList = new List<int>();

            string[] matchNoArray = matchNoList.Split(',');
            for (int i = 0; i < matchNoArray.Length; i++)
            {
                int rowNo = 0;
                if (!allItems.TryGetValue(int.Parse(matchNoArray[i]), out rowNo))
                {
                    SystemLog.Error("火柴ID非法！");
                    return false;
                }

                if (i==0)
                {
                    rowsList.Add(rowNo);
                }
                else
                {
                    if (!rowsList.Contains(rowNo))
                    {
                        SystemLog.Error("请选择同一行的火柴！");
                        return false;
                    }
                }
                
            }
            return result;
        }

        /// <summary>
        /// 检查用户是否已经获胜
        /// </summary>
        /// <param name="user">user</param>
        private void CheckResult(UserClass user)
        {
            List<int> allRowItems = new List<int>();

            foreach (var item in MatchesListClass.GetData())
            {
                int rowNo = item.Key;
                List<int> rowItems = item.Value;
                allRowItems.AddRange(rowItems);
            }

            if (allRowItems.Count == 1)
            {
                string sMessage = string.Format("-------------用户 {0} 获胜!---------------", user.Name.ToString());
                SystemLog.Log(sMessage);
            }

        }

        /// <summary>
        /// 检查火柴ID 是否在火柴列表中
        /// </summary>
        /// <param name="matchNo">火柴ID</param>
        /// <returns></returns>
        public bool CheckMatchList(int matchNo)
        {
            List<int> allItems = new List<int>();
            foreach (var item in MatchesListClass.GetData())
            {
                List<int> rowItems = item.Value;
                allItems.AddRange(rowItems);
            }

            if (allItems.Contains(matchNo))
            {
                return true;
            }
            else
            {
                return false;
            }

        }
    }
}
