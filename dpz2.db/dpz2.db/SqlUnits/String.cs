using System;
using System.Collections.Generic;
using System.Text;

namespace dpz2.db.SqlUnits {

    /// <summary>
    /// 数字单元
    /// </summary>
    public class String : dpz2.Object, ISqlStringable {

        // 值
        private string _value;

        /// <summary>
        /// 对象实例化
        /// </summary>
        /// <param name="value"></param>
        public String(string value) {
            _value = value;
        }

        /// <summary>
        /// 获取是否为复杂对象
        /// </summary>
        public bool IsComplicated { get { return false; } set { } }

        /// <summary>
        /// 获取标准SQL字符串
        /// </summary>
        /// <param name="tp"></param>
        /// <param name="multiTable"></param>
        /// <returns></returns>
        public string ToSqlString(DatabaseTypes tp, bool multiTable = false) {
            if (_value == null) return "NULL";
            return $"'{_value}'";
        }
    }
}
