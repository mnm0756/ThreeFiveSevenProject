using Microsoft.VisualStudio.TestTools.UnitTesting;
using PickUpConsoleApp;
using PickUpConsoleApp.Controller;
using PickUpConsoleApp.Model;

namespace PickUpTestProject
{

    /// <summary>
    /// UserController 测试类
    /// </summary>
    [TestClass]
    public class UserControllerTestClass
    {

        /// <summary>
        /// 测试GetUser
        /// </summary>
        [TestMethod()]
        public void GetUser_Test()
        {
            UserController userController = new UserController();
            Assert.AreEqual(userController.GetUser(EnumUserName.userA).Name.ToString(), EnumUserName.userA.ToString());
        }


        /// <summary>
        /// 测试火柴ID非正常情况
        /// 1. 非法字符
        /// 2. id超出范围
        /// 3. 选的id 不是同一行
        /// </summary>
        [TestMethod()]
        [DataRow("1,2,14")]
        [DataRow("1,2,3")]
        [DataRow("1,2,A")]
        [DataRow("1,2,$")]
        public void PickUpMatch_Test(string userAPickUp)
        {
            UserController userController = new UserController();
            UserClass user = userController.GetUser(EnumUserName.userA);

            bool result = userController.PickUpMatch(user, userAPickUp);
            Assert.AreEqual(result,true);

        }


    }
}