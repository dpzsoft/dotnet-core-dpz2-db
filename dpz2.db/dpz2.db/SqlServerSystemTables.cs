using System;
using System.Collections.Generic;
using System.Text;

namespace dpz2.db {

    /// <summary>
    /// SqlServer系统专用表
    /// </summary>
    public class SqlServerSystemTables : dpz2.Object {

        // SysObjects表对象缓存
        private SystemTables.SysObjects _sysObjects = null;

        /// <summary>
        /// SysObjects表
        /// </summary>
        public SystemTables.SysObjects SysObjects {
            get {
                if (_sysObjects == null) _sysObjects = new SystemTables.SysObjects();
                return _sysObjects;
            }
        }

        // SysObjects表对象缓存
        private SystemTables.SysColumns _sysColumns = null;

        /// <summary>
        /// SysObjects表
        /// </summary>
        public SystemTables.SysColumns SysColumns {
            get {
                if (_sysColumns == null) _sysColumns = new SystemTables.SysColumns();
                return _sysColumns;
            }
        }

        /// <summary>
        /// 释放资源
        /// </summary>
        protected override void OnDispose() {
            base.OnDispose();

            if (_sysObjects != null) {
                _sysObjects.Dispose();
                _sysObjects = null;
            }

            if (_sysColumns != null) {
                _sysColumns.Dispose();
                _sysColumns = null;
            }
        }

    }
}
