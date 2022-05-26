using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PickUpConsoleApp.Model
{

    /// <summary>
    /// 火柴集合类
    /// </summary>
    public class MatchesListClass
    {
        /// <summary>
        /// 火柴集合
        /// </summary>
        private static Dictionary<int, List<int>> dicMatch = new Dictionary<int, List<int>>();

        /// <summary>
        /// 初始化数据
        /// </summary>
        private  static void InitData()
        {
            if (dicMatch.Count == 0)
            {
                dicMatch.Clear();
                dicMatch.Add(1, new List<int>() { 1, 2, 3 });
                dicMatch.Add(2, new List<int>() { 4, 5, 6, 7, 8 });
                dicMatch.Add(3, new List<int>() { 9, 10, 11, 12, 13, 14, 15 });
            }

        }

        /// <summary>
        /// 取得所有火柴的数据
        /// </summary>
        /// <returns></returns>
        public  static Dictionary<int, List<int>> GetData()
        {
            InitData();
            return dicMatch;
        }

        /// <summary>
        /// 显示所有的火柴列表
        /// </summary>
        public  static void ShowList()
        {
            SystemLog.Log("------------显示 所有火柴列表------------------");

            foreach (var item in dicMatch)
            {
                int rowNo = item.Key;
                List<int> rowItems = item.Value;
                string strRowItems = string.Join(",", rowItems);

                string sMessage =  string.Format("第:{0} 行  剩余火柴{1}", rowNo, strRowItems);
                SystemLog.Log(sMessage);
            }

            SystemLog.Log("----------------------------------------------");
        }


        /// <summary>
        /// 火柴拿走
        /// </summary>
        /// <param name="matchNo">火柴ID</param>
        public static  void RomveMatch(int matchNo)
        {
            foreach (var item in dicMatch)
            {
                int rowNo = item.Key;
                List<int> rowItems = item.Value;
                rowItems.Remove(matchNo);
            }
        }






    }
}
