using System;
using System.Collections.Generic;
using System.Text;

namespace dpz2.db {

    /// <summary>
    /// 数据库定义操作静态类
    /// </summary>
    public static class Database {

        /// <summary>
        /// 从配置文件中加载数据库定义
        /// </summary>
        /// <param name="path"></param>
        /// <param name="group"></param>
        /// <returns></returns>
        public static dpz2.Database LoadFromConf(string path, string group = "default") {

            // 当文件不存在时，执行初始化创建
            if (!System.IO.File.Exists(path)) {
                using (dpz2.Conf.File file = new Conf.File(path)) {

                    // 建立Sqlserver示例
                    var sqlserverGroup = file["SqlServer"];
                    sqlserverGroup["Type"] = "SqlServer";
                    sqlserverGroup["Address"] = "127.0.0.1";
                    sqlserverGroup["Port"] = "1433";
                    sqlserverGroup["Name"] = "master";
                    sqlserverGroup["User"] = "sa";
                    sqlserverGroup["Password"] = "123456";

                    // 建立mysql示例
                    var mysqlGroup = file["MySql"];
                    mysqlGroup["Type"] = "MySql";
                    mysqlGroup["Address"] = "127.0.0.1";
                    mysqlGroup["Port"] = "3306";
                    mysqlGroup["Name"] = "mysql";
                    mysqlGroup["User"] = "root";
                    mysqlGroup["Password"] = "123456";

                    // 建立sqlite示例
                    var sqliteGroup = file["Sqlite"];
                    sqliteGroup["Type"] = "Sqlite";
                    sqliteGroup["Path"] = "/db/sqlite.db";

                    //文件保存
                    file.Save();
                }
            }

            using (dpz2.Conf.File file = new Conf.File(path)) {
                var confGroup = file[group];
                string dbType = confGroup["Type"];

                switch (dbType.ToLower()) {
                    case "sqlserver":
                        return new Databases.MicrosoftSqlServer() {
                            Address = confGroup["Address"],
                            Port = confGroup["Port"].ToInteger(),
                            Name = confGroup["Name"],
                            User = confGroup["User"],
                            Password = confGroup["Password"]
                        };
                    case "mysql":
                        return new Databases.MySql() {
                            Address = confGroup["Address"],
                            Port = confGroup["Port"].ToInteger(),
                            Name = confGroup["Name"],
                            User = confGroup["User"],
                            Password = confGroup["Password"]
                        };
                    case "sqlite":
                        return new Databases.Sqlite() {
                            Path = confGroup["Path"]
                        };
                    default:
                        throw new Exception($"不支持的数据库类型:{dbType}");
                }

            }
        }

    }
}
