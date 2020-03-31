using EFCoreDemo.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace EFCoreDemo
{
    public class TestAccounts
    {
        public int UserID { get; set; }
        public string NickName { get; set; }
        public int Gameid { get; set; }
        public string RegisterDate { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            //Dapper

            // DataTable obj = DapperDemo.querySingle();
            // TestAccounts obj = DapperDemo.querySingle1();
            //  List<TestAccounts> list = DapperDemo.listAccounts();
            //DapperDemo.Multi();
            // DapperDemo.getTb();
            //List<TestAccounts> listwhere = DapperDemo.listAccountsByGameID(111111);
            //////////////////////



            //using (var context = new Enitity.Context())
            //{
            //    context.Database.();//如果数据库不存在时则创建
            //}

            //using (var db = new Entity.Context())
            //{
            //    //  TestAccounts obj=  QuerySelect(db);
            //    //   TestAccounts obj = QuerySelectSinle(db, 222222,10);
            //    // List<TestAccounts> list = QueryByWhere_Like(db, "2");
            //    // Console.WriteLine("昵称是：" + obj.NickName);
            //    // List<TestAccounts> list = QueryAll(db);
            //    //  Insert(db, new TestAccounts { Gameid = 22222, NickName = "普京" });
            //    //  Update(db, new TestAccounts { UserID =11, NickName = "香梨网络" ,Gameid= 2222227 });
            //    // update2(db);
            //    update3(db);
            //    // Delete(db, 7);

            //}
            ////代理
            using (var db = new Context())
            {
                //  Agent_User ag = QueryAgent(db, 222888);
                //   queryAgentX(db);
                // listDetail(db);
                //  GroupBy(db);
                //   EFCoreDemo.queryBySql(db);
                //  EFCoreDemo.QueryBy_in(db);
                //EFCoreDemo.listDetail(db);
                //  EFCoreDemo.GroupBy(db);
                // EFCoreDemo.page(db,1,2);
               // EFCoreDemo.listDetail(db);
            }

            //  buniessBll.getSingle();
            //  buniessBll.list();
            // buniessBll.UpdateUser();
            // buniessBll.Insert(new TestAccounts { Gameid = 888888, NickName = "安安金库" });
            // buniessBll.Dlete(888888);
            // List<TestAccounts> list = new List<TestAccounts>
            //{
            //    new TestAccounts{Gameid=777777,NickName="一起玩"},
            //    new TestAccounts{Gameid=212121,NickName="2舅棋牌"}
            //};
            // buniessBll.InsertMany(list);
            // buniessBll.DleteWhere(2222227);

            // DapperDemo.Insert(new TestAccounts { Gameid = 44444, NickName = "误了有" });
            DapperDemo.InsertMany();
            Console.WriteLine("处理完成");
            Console.Read();
        }
       
    }
}
