using Dapper;
using EFCoreDemo.Entity;
using Microsoft.Data.SqlClient;
using System.Collections.Generic;
using System.Data;

namespace EFCoreDemo
{
    public class DapperDemo
    {
        private static readonly string connectionString = "Server=47.107.107.33,8000;Database=RYAccountsDB;User ID = sa; Password=9emRFMgVJqX";
        public static DataTable querySingle()
        {
            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                DataTable tb = new DataTable("tb");
                string sql = "select * from  TestAccounts where gameid=2222227";
                var reader = connection.ExecuteReader(sql);
                tb.Load(reader);
                return tb;
            }
        }
        public static TestAccounts querySingle1()
        {
            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                string sql = "select * from  TestAccounts where gameid=@gameid";

                //var query = connection.Query<TestAccounts>(sql,
                //   new { GameID = 2222227 });
                // TestAccounts b= SqlMapper.Query<TestAccounts>(connection, sql, new { gameid = 2222227 }).AsList()[0];
                TestAccounts obj = GetModel<TestAccounts>("TestAccounts", "gameid", "2222227");
                //foreach (var item in query)
                //{
                //    Console.WriteLine(item.NickName );
                //}



                return obj;
            }
        }
        //查询单条
        public static T GetModel<T>(string table, string key, string kevalue)
        {
            string sql = "select * from " + table + " where " + key + "=" + kevalue;
            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                return SqlMapper.Query<T>(connection, sql).AsList<T>()[0];
            }
        }
        //所有
        public static List<TestAccounts> listAccounts()
        {
            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                return connection.Query<TestAccounts>("select * from TestAccounts").AsList();
            }
        }
        public static List<TestAccounts> listAccountsByGameID(int gameid)
        {
            string sql = "select * from TestAccounts where gameid=@gameid";
            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                return connection.Query<TestAccounts>(sql, new { gameid = gameid }).AsList();

            }
        }
        //返回多表
        public static void Multi()
        {
            string sql = "select * from TestAccounts where gameid=@gameid;select * from agent_user";
            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                var a = connection.QueryMultiple(sql, new { gameid = 999999 });
                TestAccounts b = a.Read<TestAccounts>().AsList<TestAccounts>()[0];
                List<Agent_User> c = a.Read<Agent_User>().AsList();
            }
        }
        //返回DataTable
        public static DataTable getTb()
        {
            string sql = "select * from TestAccounts";
            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                DataTable tb = new DataTable("tb");
                var red = connection.ExecuteReader(sql);
                tb.Load(red);
                return tb;
            }
        }
        //新增单条delete update同理
        public static int Insert(TestAccounts obj)
        {
            string sql = "INSERT INTO TestAccounts (GameID,nickname) Values (@gameid,@nname);";

            using (IDbConnection connection = new SqlConnection(connectionString))
            {

                return connection.Execute(sql, new { gameid = obj.Gameid, nname = obj.NickName });

            }
        }
        //新增多条delete update同理
        public static int InsertMany()
        {
            string sql = "INSERT INTO TestAccounts (GameID,nickname) Values (@gameid,@nname);";

            using (var connection = new SqlConnection(connectionString))
            {
                var rowscount = connection.Execute(sql,
                    new[]
                    {
                      new {gameid = 565656, nname = "北京"},
                      new {gameid =787878, nname = "上海"},
                      new {gameid = 434343, nname = "四川"}
                    }
                );

                return rowscount;
            }
        }
        
        //存储过程
        public static void ExeproSelect()
        {
           
            //带输出参数和select
            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                var p = new DynamicParameters();
                p.Add("userid", 999999);
                p.Add("mesg", "", dbType: DbType.String, direction: ParameterDirection.Output);
                var reader = connection.Query("test1",p,null,true,null,CommandType.StoredProcedure);
                string newID = p.Get<string>("mesg");
            }
            //带输出参数
            //using (IDbConnection connection = new SqlConnection(connectionString))
            //{
            //    var p = new DynamicParameters();
            //    p.Add("userid", 999999);
            //    p.Add("mesg", "", dbType: DbType.String, direction: ParameterDirection.Output);
            //    connection.Execute("test1", p, commandType: CommandType.StoredProcedure);
            //    string newID = p.Get<string>("mesg");
            //}
        }
    }
}
