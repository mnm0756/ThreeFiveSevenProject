using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PickUpConsoleApp.Controller;
using PickUpConsoleApp.Model;
using PickUpConsoleApp.View;


namespace PickUpConsoleApp
{
    public class DemoClass
    {
      

        /// <summary>
        /// 正常的路径
        /// </summary>
        public static void RunDemo()
        {

            //初始化 userA 和userB
            UserController userController = new UserController();

            User userA = userController.GetUser(EnumUserName.userA);
            User userB = userController.GetUser(EnumUserName.userB);

            //初始化火柴列表
            MatchListController matchListController = new MatchListController();

            matchListController.PrintList();


            //1 round===================
            int round = 1;
            RoundClass.SetRoundNo(round);
            RoundClass.BeginRound();
            string userAPickUp = "1";
            string userBPickUp = "2";

            userController.PickUpMatch(UserListClass.NextUser(), userAPickUp);
            userController.PickUpMatch(UserListClass.NextUser(), userBPickUp);

    
            matchListController.PrintList();
            userController.PrintUser(userA);
            userController.PrintUser(userB);

            RoundClass.EndRound();

            //2 round===============
            round = round + 1;
            RoundClass.SetRoundNo(round);
            RoundClass.BeginRound();

            userAPickUp = "3";
            userBPickUp = "4";

            userController.PickUpMatch(UserListClass.NextUser(), userAPickUp);
            userController.PickUpMatch(UserListClass.NextUser(),  userBPickUp);


            userController.PrintUser(userA);
            userController.PrintUser(userB);
            matchListController.PrintList();

            RoundClass.EndRound();

            //3 round====================
            round = round + 1;
            RoundClass.SetRoundNo(round);
            RoundClass.BeginRound();

            userAPickUp = "5,6,7,8";
            userBPickUp = "9,10,11,12";

            userController.PickUpMatch(UserListClass.NextUser(), userAPickUp);
            userController.PickUpMatch(UserListClass.NextUser(),  userBPickUp);

            matchListController.PrintList();
            userController.PrintUser(userA);
            userController.PrintUser(userB);


            RoundClass.EndRound();


            //4 round===============
            round = round + 1;
            RoundClass.SetRoundNo(round);
            RoundClass.BeginRound();

            userAPickUp = "13";
            userBPickUp = "14";


            userController.PickUpMatch(UserListClass.NextUser(),  userAPickUp);
            userController.PickUpMatch(UserListClass.NextUser(),  userBPickUp);
   
            matchListController.PrintList();
            userController.PrintUser(userA);
            userController.PrintUser(userB);

            RoundClass.EndRound();
 
        }


    }



    public class RoundClass
    {

         static int roundNumber = 0;


        public static void SetRoundNo(int roundNo)
        {
            roundNumber = roundNo;
        }

        public static void BeginRound()
        {
            SystemLog.Log("");
            SystemLog.Log(String.Format("============开始 第{0}轮=================", roundNumber.ToString()));

        }

        public static void EndRound()
        {
            SystemLog.Log(String.Format("============结束 第{0}轮=================", roundNumber.ToString()));
        }
    }
}
