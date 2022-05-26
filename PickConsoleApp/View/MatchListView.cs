using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PickUpConsoleApp.View
{

    /// <summary>
    /// 火柴列表 View
    /// </summary>
    public class MatchListView
    {

        /// <summary>
        /// 显示所有火柴列表
        /// </summary>
        /// <param name="dicMatch"></param>
        public void PrintList(Dictionary<int, List<int>> dicMatch)
        {
            SystemLog.Log("------------显示 所有火柴列表------------------");
            foreach (var item in dicMatch)
            {
                int rowNo = item.Key;
                List<int> rowItems = item.Value;
                string strRowItems = string.Join(",", rowItems);

                string sMessage = string.Format("第:{0} 行  剩余火柴{1}", rowNo, strRowItems);
                SystemLog.Log(sMessage);
            }

            SystemLog.Log("----------------------------------------------");
        }

    }
}
