using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dll
{
    /// <summary>
    /// 計測器を管理します
    /// </summary>
    public static class StopWatchManager
    {
        /// <summary>
        /// 最上位の計測器
        /// </summary>
        private static StopWatchNode RootStopWatch { get; set; }
        
        /// <summary>
        /// 最上位の計測器を設定します
        /// </summary>
        /// <param name="rootStopWatch"></param>
        public static void SetRootStopWatch(StopWatchNode rootStopWatch)
        {
            RootStopWatch = rootStopWatch;
        }

        /// <summary>
        /// 指定した計測器を子として追加します
        /// </summary>
        /// <param name="stopWatchNode"></param>
        public static void AddChildStopWatch(StopWatchNode stopWatchNode)
        {
            RootStopWatch.AddChildStopWatch(stopWatchNode);
        }

        /// <summary>
        /// 指定した名前の計測器に、指定した計測器を追加します
        /// </summary>
        /// <param name="name"></param>
        /// <param name="stopWatchNode"></param>
        /// <returns></returns>
        public static bool TryAddStopWatch(string name, StopWatchNode stopWatchNode)
        {
            if (!RootStopWatch.HasStopWatch(name)) { return false; }


        }

        /// <summary>
        /// 自身の計測器の情報を取得します
        /// </summary>
        /// <returns></returns>
        public static string GetRootStopWatchInfo()
        {
            return $"{RootStopWatch.GetCurrentStopWatchInfo()}";
        }

        /// <summary>
        /// 所有する計測器の情報を取得します
        /// </summary>
        /// <returns></returns>
        public static string GetChilsStopWatchInfo()
        {
            return RootStopWatch.GetChilsStopWatchInfo();
        }

        /// <summary>
        /// 自身も含めた所有するすべての計測器の情報を取得します
        /// </summary>
        /// <returns></returns>
        public static string GetAllStopWatchInfo()
        {
            return RootStopWatch.GetAllStopWatchInfo();
        }
    }
}
