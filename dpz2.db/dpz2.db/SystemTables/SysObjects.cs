using System;
using System.Collections.Generic;
using System.Text;

namespace dpz2.db.SystemTables {

    /// <summary>
    /// Sql Server专用系统对象表
    /// </summary>
    public class SysObjects : SqlUnits.Table {

        /// <summary>
        /// 获取Id字段
        /// </summary>
        public SqlUnits.TableField Id { get; private set; }

        /// <summary>
        /// 获取Name字段
        /// </summary>
        public SqlUnits.TableField Name { get; private set; }

        /// <summary>
        /// 获取Type字段
        /// </summary>
        public SqlUnits.TableField Type { get; private set; }

        /// <summary>
        /// 对象实例化
        /// </summary>
        public SysObjects() : base("SysObjects") {
            this.Id = new SqlUnits.TableField(this, "Id");
            this.Name = new SqlUnits.TableField(this, "Name");
            this.Type = new SqlUnits.TableField(this, "Type");
        }

    }
}
