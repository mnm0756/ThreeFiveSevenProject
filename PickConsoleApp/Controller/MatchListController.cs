using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PickUpConsoleApp.View;
using PickUpConsoleApp.Model;

namespace PickUpConsoleApp.Controller
{

    /// <summary>
    /// 火柴列表 Controller
    /// </summary>
    public class MatchListController
    {

        /// <summary>
        /// 取得所有的火柴集合数据
        /// </summary>
        /// <returns></returns>
        public Dictionary<int, List<int>> GetList()
        {
            return MatchesListClass.GetData();
        }
            

        /// <summary>
        /// 打印火柴列表
        /// </summary>
        public void PrintList()
        {
            Dictionary<int, List<int>> dicMatch = GetList();
            MatchListView matchListView = new MatchListView();
            matchListView.PrintList(dicMatch);
        }

    }
}
