using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Cryptography;

namespace EnvironmentSimulator1
{
    class SQLCon
    {
        public static string connStr = "Data Source=HZY;Initial Catalog=1;Integrated Security=True";      // 数据库连接字符串
        public static SqlConnection conn;         // SqlConnection实例

        /// <summary>
        /// 连接数据库
        /// </summary>
        public static Boolean connectSql()
        {
            // 创建SqlConnection实例
            try
            {
                conn = new SqlConnection(connStr);
                // 打开数据库连接
                conn.Open();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("数据库连接失败！" + ex.Message);
                return false;
            }
        }

        /// <summary>
        /// 关闭数据库连接
        /// </summary>
        public static void close()
        {
            if (conn != null)
            {
                conn.Close();
            }
        }

        /// <summary>
        /// 通用查询方法
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public static DataSet select(string sql)
        {
            if (!connectSql())
            {
                return null;
            }
            try
            {
                // 执行语句
                SqlDataAdapter adapter = new SqlDataAdapter(sql, conn);
                // 将结果以DataTable的形式显示
                DataSet ds = new DataSet();
                adapter.Fill(ds, "StationTable");
                close();    // 关闭对象
                if (ds.Tables.Count > 0)
                {
                    return ds;

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("连接错误 ：" + ex.Message);
            }
            return null;
        }

        /// <summary>
        /// 新增sql方法
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public static int insert(string sql)
        {
            if (!connectSql())
            {
                return 0;
            }
            // 获取命令对象
            SqlCommand command = new SqlCommand(sql, conn);
            // 执行语句
            int result = command.ExecuteNonQuery();
            // 将结果以DataTable的形式显示
            conn.Close();
            return result;
        }

        /// <summary>
        /// 删除sql方法
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public static int delete(string sql)
        {
            if (!connectSql())
            {
                return 0;
            }
            // 获取命令对象
            SqlCommand command = new SqlCommand(sql, conn);
            // 执行语句
            int result = command.ExecuteNonQuery();
            // 将结果以DataTable的形式显示
            conn.Close();
            return result;
        }

        /// <summary>
        /// 更新sql语句
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public static int update(string sql)
        {
            if (!connectSql())
            {
                return 0;
            }
            // 获取命令对象
            SqlCommand command = new SqlCommand(sql, conn);
            // 执行语句
            int result = command.ExecuteNonQuery();
            // 将结果以DataTable的形式显示
            conn.Close();
            return result;
        }
        public static bool InsertDataTableToDB(DataTable dt, string Test2, Dictionary<string, string> colMapping)
        {
            try
            {
                string connStr = "Data Source=LAPTOP-7V9FNRK5;Initial Catalog=ATSData;Integrated Security=True";//连接字符串

                //使用SqlBulkCopy可省略SqlConnection，直接将连接字符串赋给它（当然也可以不省略），第二个参数表示打开事物（一步操作失败那么所有操作回滚）
                using (SqlBulkCopy bc = new SqlBulkCopy(connStr, SqlBulkCopyOptions.UseInternalTransaction))
                {
                    //添加DataTable每列与数据表每列的对应关系
                    foreach (var item in colMapping)
                    {
                        bc.ColumnMappings.Add(item.Key, item.Value);
                    }
                    bc.BatchSize = dt.Rows.Count;//设置每次插入的数据量
                    bc.DestinationTableName = Test2;//设置目标表（要插入到哪个数据库表）
                    bc.WriteToServer(dt);//执行插入
                    return true;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
