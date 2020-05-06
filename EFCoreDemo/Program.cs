using EFCoreDemo.Entity;
using EFCoreDemo.service;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;

namespace EFCoreDemo
{
    public class TestAccounts
    {
        public int UserID { get; set; }
        public string NickName { get; set; }
        public int Gameid { get; set; }
        public string RegisterDate { get; set; }
    }
    public class te
    {
        public int id { get; set; }
        public string names { get; set; }
        public te() { }
        public te (int id,string names)
        {
            this.id = id;
            this.names = names;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            //  te dfd = new te(3, "我草");
            // Console.WriteLine(dfd.id + ":" + dfd.names);
            Console.Write(PhoneTypeCode.xxx);
            Console.WriteLine(PhoneTypeCode.BindPhone+":"+(int) PhoneTypeCode.BindPhone);
            Console.ReadLine();
           
            //TestAccounts TS = new TestAccounts()
            //{
            //    UserID=2333,
            //    NickName="测试一下",
            //    Gameid=99999,
            //    RegisterDate="2019-5-6"
            //};
            //PropertyInfo _findedPropertyInfo = TS.GetType().GetProperty("GAMEID", BindingFlags.Public | BindingFlags.Instance | BindingFlags.IgnoreCase);

            //if (_findedPropertyInfo != null)
            //{
            //   object sfsd=  _findedPropertyInfo.GetValue(TS);
            //    _findedPropertyInfo.SetValue (TS, 555);

            //    string sf = TS.Gameid.ToString();
            //}

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
            //using (var db = new Context())
            //{
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
            //EFCoreDemo.ExePro(db);
            // EFCoreDemo.TestList(db);
            //Agent_User obj = new Agent_User()
            //{
            //    UserID=8787,
            //    GameID=6868,
            //    ParaentGameID=9889
            //};
            //EFCoreDemo.insertAgent(db, obj);
            // }

            //  buniessBll.getSingle();
            // new buniessBll(new RepositoryService<TestAccounts>(new Context()));
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
            //DapperDemo.InsertMany();
            // DapperDemo.ExeproSelect();
            //Dictionary<string, string> dic = new Dictionary<string, string>();
            //dic.Add("A", "a");
            //dic.Add("B", "b");
            //var result = dic.Where(x => x.Key == "A").Select(p => new { name = p.Key, value = p.Value });

            //foreach (var v in result)
            //{
            //    string xx = v.name;
            //    string dfd = v.value;

            //}

            //var result = BankDic.Select(x => new
            //{
            //    Name = x.Key,
            //    Value = x.Value
            //});

            //测试

            //KeyValue[] arry = new KeyValue[] {
            //new KeyValue{Key="userName",Value="你骂吧" },
            // new KeyValue{Key="regPassword",Value="123456" },
            //};


            //for (int i = 0; i < 4; i++)
            //{
            // TestAsync();
            // }
            TestAsync();

            Console.WriteLine("执行结束");
            Console.Read();
        }
        public static string testTbu()
        {
            Console.WriteLine("同步执行结束");
            return "这是同步的";
        }

        #region 开始
        static async Task TestAsync()
        {
            Console.WriteLine("Test()开始, Thread Id: {0}\r\n", Thread.CurrentThread.ManagedThreadId);
            var name = GetNameAsync(); //我们这里没有用 await,所以下面的代码可以继续执行
                                       // 但是如果上面是 await GetNameAsync()，下面的代码就不会立即执行，输出结果就不一样了。            

            Console.WriteLine("继续执行其他");
            XS();
            var res = await name;
            //  var name1 = GetNameAsync();
            //  await Task.WhenAll(name,name1);


            Console.WriteLine("await GetName1: {0},得到结果进行其它操作", res);
            Console.WriteLine("Test()结束.\r\n");
        }
        static void XS()
        {
            Console.WriteLine("无关重要");
        }
        static Task<string> xxx()
        {
            return Task<string>.Run(() =>
            {
                Console.WriteLine("个屁了");
                return "xx";
            });

        }
        static async Task<string> GetNameAsync()
        {
            // 这里还是主线程
            Console.WriteLine("GetName()开始， thread Id is: {0}", Thread.CurrentThread.ManagedThreadId);
            return await Task.Run(() =>
            {
                Thread.Sleep(3000);
                Console.WriteLine("'GetName' Thread Id: {0}", Thread.CurrentThread.ManagedThreadId);
                return "Jesse";
            });

        }
        #endregion 结束
        #region 开始
        static async Task<int> GetStrLengthAsync()
        {
            Console.WriteLine("GetStrLengthAsync方法开始执行");
            //此处返回的<string>中的字符串类型，而不是Task<string>
            string str = await GetString();
            // string str = "尼玛币d";
            Console.WriteLine("str：" + str);

            Thread.Sleep(3000);
            Console.WriteLine("GetStrLengthAsync方法执行结束");
            return str.Length;
        }
        //这不是一个异步方法
        static Task<string> GetString()
        {
            Console.WriteLine("GetString方法开始执行");
            return Task<string>.Run(() =>
            {
                Thread.Sleep(3000);
                Console.WriteLine("GetString方法结束执行");
                return "GetString的返回值";
            });
        }
        #endregion 结束
        #region 开始
        public static async Task<int> cc()
        {
            int a = await aa();
            int b = await bb();
            Console.WriteLine("来没");
            return 2;
        }
        public static async Task ccc()
        {
            int a = await aa();
            int b = await bb();
            Console.WriteLine("来没");
        }
        public static async Task<int> aa()
        {
            await Task.Delay(5000);
            Console.WriteLine("aa执行完");
            return 10;
        }
        public static async Task<int> bb()
        {
            await Task.Delay(5000);
            Console.WriteLine("bb执行完");
            return 15;
        }
        #endregion 结束
        #region 开始
        public static async Task<string> testYibu()
        {
            // fanh();
            string yiburesult = await RerunString();

            return yiburesult;
        }
        private static async Task<string> RerunString()
        {
            await Task.Run(() =>
            {
                Console.WriteLine("执行异步方法");
                Thread.Sleep(5000);
                Console.WriteLine("异步方法执行完毕");

            });
            return "异步执行完了";
        }
        private static async void fanh()
        {
            await Task.Run(() =>
           {
               Console.WriteLine("执行异步方法");
               Thread.Sleep(5000);
               Console.WriteLine("异步方法执行完毕");

           });
        }

        #endregion 结束
        #region 开始
        static async void test()
        {
            //最先输出,还没有进入task
            log("test: await之前");
            // await后的内容会被加在目标doo的Task的后面，然后test马上返回,而doo则是进入了另一个任务执行了
            log("doo的Task的结果: " + await doo());
            // 会等到上面await执行的任务完成后才会执行当前代码
            log("test: await之后");
        }
        //返回Task的async方法, 一个标准的带返回值的异步task任务方法
        static async Task<int> doo()
        {
            // 简单的说, async中使用await就是异步中以同步方式执行Task任务的方法,task任务一个接一个执行.
            var res1 = await Task.Run(() => { Thread.Sleep(1000); log("Awaited Task1 执行"); return 1; });
            var res2 = await Task.Run(() => { Thread.Sleep(1000); log("Awaited Task2 执行"); return 2; });
            var res3 = await Task.Run(() => { Thread.Sleep(1000); log("Awaited Task3 执行"); return 3; });

            //不使用await：线程池多线程, 当前task不会等这个执行完,因为不是await,只是又开启了一个线程
            ThreadPool.QueueUserWorkItem(_ =>
            {
                Thread.Sleep(1000);
                log("ThreadPool.QueueUserWorkItem: 线程池多线程执行");
            });

            //不使用await：Task多线程, 当前task不会等这个执行完,因为不是await,只是又开启了一个任务
            Task.Run(() =>
            {
                Thread.Sleep(1000);
                log("Task.Run: Task多线程执行");

            });

            return res1 + res2 + res3;
        }
        //输出方法：显示当前线程号和输出信息
        static void log(string msg)
        {
            Console.WriteLine("线程{0}: {1}", Thread.CurrentThread.ManagedThreadId, msg);
        }
        #endregion
    }
    public class regiser
    {
        public string username { get; set; }
        public string account { get; set; }
    }
    public enum PhoneTypeCode
    {
        xxx,
        日你妈,
        /// <summary>
        /// 绑定手机
        /// </summary>
        BindPhone = 35345,
        /// <summary>
        /// 找回账号
        /// </summary>
        FindAccount = 2,
        /// <summary>
        /// 找回密码
        /// </summary>
        FindPassword = 3,
        /// <summary>
        /// 手机登录
        /// </summary>
        LoginPhone = 4,
        /// <summary>
        /// 手机注册
        /// </summary>
        RegisterPhone = 5,
    }
}
