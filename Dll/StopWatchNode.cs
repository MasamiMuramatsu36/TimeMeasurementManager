using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dll
{
    /// <summary>
    /// 計測器を表します
    /// </summary>
    public class StopWatchNode
    {
        /// <summary>
        /// 識別名
        /// </summary>
        private string IdentifyName { get; set; }

        /// <summary>
        /// 計測器
        /// </summary>
        private Stopwatch CurrentStopWatch { get; set; }

        /// <summary>
        /// 子として持つ計測器
        /// </summary>
        private Collection<StopWatchNode> ChildStopWatch { get; set; }

        #region コンストラクタ

        /// <summary>
        /// 計測器を作成します
        /// </summary>
        public StopWatchNode(string identifyName) : this(identifyName, new Stopwatch(), new Collection<StopWatchNode>())
        {
        }

        /// <summary>
        /// 計測器を作成します
        /// </summary>
        /// <param name="stopWatch"></param>
        public StopWatchNode(string identifyName, Stopwatch stopWatch) : this(identifyName, stopWatch, new Collection<StopWatchNode>()) 
        {
        }

        /// <summary>
        /// 計測器を作成します
        /// </summary>
        /// <param name="childStopWatch"></param>
        public StopWatchNode(string identifyName, Collection<StopWatchNode> childStopWatch) : this(identifyName, new Stopwatch(), childStopWatch)
        {
        }

        /// <summary>
        /// 計測器を作成します
        /// </summary>
        /// <param name="stopWatch"></param>
        /// <param name="ChildStopWatch"></param>
        public StopWatchNode(string identifyName, Stopwatch stopWatch, Collection<StopWatchNode> childStopWatch)
        {
            this.IdentifyName = identifyName;
            this.CurrentStopWatch = stopWatch;
            this.ChildStopWatch = childStopWatch;
        }

        #endregion // コンストラクタ

        public void StartStopWatch()
        {
            this.CurrentStopWatch = Stopwatch.StartNew();
        }

        public void StopStopWatch()
        {
            this.CurrentStopWatch.Stop();
        }

        /// <summary>
        /// 指定した計測器を子として追加します
        /// </summary>
        /// <param name="key"></param>
        /// <param name="stopwatch"></param>
        public void AddChildStopWatch(StopWatchNode stapWatchNode)
        {
            this.ChildStopWatch.Add(stapWatchNode);
        }

        /// <summary>
        /// 指定した名前の計測器に、指定した計測器を追加します
        /// </summary>
        /// <param name="name"></param>
        /// <param name="stopWatchNode"></param>
        /// <returns></returns>
        public bool TryAddStopWatch(string name, StopWatchNode stopWatchNode)
        {
            if (!this.HasStopWatch(name)) { return false; }

            if (this.IdentifyName == name)
            {
                this.AddChildStopWatch(stopWatchNode);
            }
            else
            {
                foreach (var csw in this.ChildStopWatch)
                {
                    csw.TryAddStopWatch(name, stopWatchNode);
                }
            }

            return true;
        }

        /// <summary>
        /// 指定した名前の計測器を持っているかを確かめます
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public bool HasStopWatch(string name)
        {
            return this.IdentifyName == name ||
                this.ChildStopWatch.Any(x => x.HasStopWatch(name));
        }

        /// <summary>
        /// 計測器の情報を取得します
        /// </summary>
        /// <returns></returns>
        public string GetCurrentStopWatchInfo()
        {
            return $"{this.IdentifyName} : {this.CurrentStopWatch.Elapsed}";
        }

        /// <summary>
        /// 子の計測器の情報を取得します
        /// </summary>
        /// <returns></returns>
        public string GetChilsStopWatchInfo()
        {
            return string.Join("\r\n", this.ChildStopWatch.Select(x => x.GetCurrentStopWatchInfo()).ToArray());
        }

        /// <summary>
        /// 子も含めたすべての計測器の情報を取得します
        /// </summary>
        /// <returns></returns>
        public string GetAllStopWatchInfo()
        {
            return $"{GetCurrentStopWatchInfo()}\r\n{GetChilsStopWatchInfo()}";
        }
    }
}
