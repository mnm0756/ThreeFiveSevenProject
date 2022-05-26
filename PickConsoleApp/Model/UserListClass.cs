
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PickUpConsoleApp.Model
{

    /// <summary>
    /// 用户 集合类
    /// </summary>
    public class UserListClass
    {
        /// <summary>
        /// 用户集合
        /// </summary>
        static Dictionary<EnumUserName, User>   userList = new Dictionary<EnumUserName, User>();

        /// <summary>
        /// 根据UserName 取得用户
        /// </summary>
        /// <param name="UserName">用户名</param>
        /// <returns></returns>
        public static User GetUser(EnumUserName UserName)
        {
            User item = null;
            if (UserName == EnumUserName.userA)
            {
          

                if (userList.TryGetValue(UserName, out item))
                {
                    return item;
                }
                else
                {
                    item = new User(EnumUserName.userA);
                    userList.Add(EnumUserName.userA, item);
                    return item;
                }
            }
            else if (UserName == EnumUserName.userB)
            {


                if (userList.TryGetValue(UserName, out item))
                {
                    return item;
                }
                else
                {
                    item = new User(EnumUserName.userB);
                    userList.Add(EnumUserName.userB, item);
                    return item;
                }
            }
            return item;
        }

        /// <summary>
        /// 当前用户
        /// </summary>
        private static User currentUser =null;

       /// <summary>
       /// 取得下一个用户
       /// </summary>
       /// <returns></returns>
        public static User NextUser()
        {
            foreach (var item in userList)
            {
                if (currentUser == null)
                {
                    currentUser = item.Value;
                    return currentUser;
                }
                else if(item.Value != currentUser)
                    {
                    currentUser = item.Value;
                    return currentUser;
                }
            }

            return currentUser;
        }

  
         
    }
}
