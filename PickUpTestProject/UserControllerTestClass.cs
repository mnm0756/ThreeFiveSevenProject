using Microsoft.VisualStudio.TestTools.UnitTesting;
using PickUpConsoleApp;
using PickUpConsoleApp.Controller;
using PickUpConsoleApp.Model;

namespace PickUpTestProject
{

    /// <summary>
    /// UserController ������
    /// </summary>
    [TestClass]
    public class UserControllerTestClass
    {

        /// <summary>
        /// ����GetUser
        /// </summary>
        [TestMethod()]
        public void GetUser_Test()
        {
            UserController userController = new UserController();
            Assert.AreEqual(userController.GetUser(EnumUserName.userA).Name.ToString(), EnumUserName.userA.ToString());
        }


        /// <summary>
        /// ���Ի��ID���������
        /// 1. �Ƿ��ַ�
        /// 2. id������Χ
        /// 3. ѡ��id ����ͬһ��
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