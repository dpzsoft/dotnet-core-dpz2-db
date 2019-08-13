using System;
using System.Collections.Generic;
using System.Text;

namespace dpz2.db {

    /// <summary>
    /// 行数据操作器
    /// </summary>
    public abstract class RowOperator : dpz2.Object {

        /// <summary>
        /// 获取行数据对象
        /// </summary>
        protected Row Row { get; private set; }

        /// <summary>
        /// 对象实例化
        /// </summary>
        /// <param name="row"></param>
        public RowOperator(Row row) {
            this.Row = row;
        }

        /// <summary>
        /// 获取基础数据行对象
        /// </summary>
        /// <returns></returns>
        public Row GetRow() { return this.Row; }

        /// <summary>
        /// 释放资源
        /// </summary>
        protected override void OnDispose() {
            base.OnDispose();

            this.Row = null;
        }

    }
}
