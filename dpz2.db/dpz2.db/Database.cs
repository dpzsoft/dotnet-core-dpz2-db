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
