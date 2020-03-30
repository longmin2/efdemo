using EFCoreDemo.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.Internal;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace EFCoreDemo
{
    public class EFCoreDemo
    {
      
        //联合查询(join on)
        public static void listDetail(Context db)
        {
            // var nn = db._UserInfo.Join(db._Agent_User, bb => bb.Gameid, cc => cc.GameID, (bb, cc) => new { cc, bb.NickName }).ToList();

            //linq

            //所有
            // var result = (from userinfo in db._UserInfo
            //              join agent in db._Agent_User
            //              on userinfo.Gameid equals agent.GameID 
            //              select new { userinfo,agent}
            //              ).ToList();
            //指定字段
            var result = (from userinfo in db._UserInfo
                          join agent in db._Agent_User
                          on userinfo.Gameid equals agent.GameID
                          select new
                          {
                              nickname = userinfo.NickName,
                              ParentID = agent.ParaentGameID
                          }
                         ).ToList();
            //笛卡尔乘积
            //var result = from userinfo in db._UserInfo
            //             from agent in db._Agent_User
            //             select new { userinfo, agent };
            //链接条件查询 join on
            //var result = from userinfo in db._UserInfo
            //             from agent in db._Agent_User
            //             .Where(gg => gg.GameID == userinfo.Gameid)
            //             select new { userinfo, agent };
            //链接查询 left join
            //var result = from userinfo in db._UserInfo
            //             from agent in db._Agent_User
            //             .Where(gg => gg.GameID == userinfo.Gameid).DefaultIfEmpty()
            //             select new { userinfo, agent };
            //int resultcount = result.Count();
            //foreach (var bc in result)
            //{
            //    string nickname = bc.userinfo.NickName;
            //    int parentid = bc.agent.ParaentGameID;
            //}
            //foreach(var bc in result)
            //{
            //    string nickname = bc.nickname;
            //    int pareanm = bc.ParentID;

            //}
            //int count = result.Count;

        }

        //分组
        public static void GroupBy(Context db)
        {
            var sd = from userinfo in db._UserInfo
                     group userinfo by userinfo.Gameid into gg
                     select new { keys = gg.Key, cnt = gg.Count() };
          
           
            foreach (var re in sd)
            {
                string key = re.keys.ToString();
                int count = re.cnt;
            }
        }

        //(in) 
        public static List<TestAccounts> QueryBy_in(Context db)
        {
            int[] gameid = { 555555, 2222227 };
            string[] nickname = { "葡京殷商","测试一下2" };
            List<TestAccounts> df = db._UserInfo.Where(b => gameid.Contains(b.Gameid)&&nickname.Contains(b.NickName)).ToList();
            // var ya = db._UserInfo.Where(b => gameid.Contains(b.Gameid) && nickname.Contains(b.NickName)).ToList();
            //  string sd=  ya.ToString();
            // var sql = ((System.Data.Objects.ObjectQuery)query).ToTraceString();
         
            return df;
        }
        #region 用户表
        //按主键查找
        public static TestAccounts QuerySelect(Context db)
        {
            return db.Set<TestAccounts>().Find(89);

        }
        //按条件查询单条
        public static TestAccounts QuerySelectSinle(Context db, int GameID, int UserID)
        {
            //  return db.Set<TestAccounts>().FirstOrDefault(x => x.Gameid == GameID && x.UserID == UserID);
            return db._UserInfo.Single(x => x.Gameid == GameID && x.UserID == UserID);
        }
        //筛选(模糊查询)
        public static List<TestAccounts> QueryByWhere_Like(Context db, string nickname)
        {
            return db._UserInfo.AsEnumerable().Where(b => b.NickName.Contains(nickname)).ToList();
        }

        //查询所有
        public static List<TestAccounts> QueryAll(Context db)
        {

            return db._UserInfo.ToList();

        }
        //新增
        public static void Insert(Context db, TestAccounts OBJ)
        {
            if (db._UserInfo.Any(x => x.Gameid == OBJ.Gameid))
            {
                return;
            }
            db._UserInfo.Add(OBJ);
            //  db.Set<TestAccounts>().Add(OBJ);
            //   db.Add(OBJ);

            db.SaveChanges();
        }
        //修改
        //先查再改
        public static void Update(Context db, TestAccounts obj)
        {
            TestAccounts data = db._UserInfo.FirstOrDefault(b => b.UserID == obj.UserID) as TestAccounts;
            if (data != null)
            {
                data.Gameid = obj.Gameid;
                data.NickName = obj.NickName;

                db.SaveChanges();
            }

        }
        //按主键去修改，会把没有加的熟悉设置成NULL
        public static void update2(Context db)
        {
            TestAccounts u = new TestAccounts();
            u.NickName = "葡京殷商";
            u.UserID = 10;
            u.Gameid = 999999;
            db.Entry(u).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            db.SaveChanges();

        }
        //会把没写的熟悉设置为null
        public static void update3(Context db)
        {
            TestAccounts u = new TestAccounts();
            u.NickName = "葡京殷商";
            u.UserID = 10;
            u.Gameid = 999999;
            db._UserInfo.Update(u);
            db.Entry(u).State = Microsoft.EntityFrameworkCore.EntityState.Modified;

            db.SaveChanges();

        }
        //删除
        public static void Delete(Context db, int UsERid)
        {
            TestAccounts data = db._UserInfo.FirstOrDefault(b => b.UserID == UsERid) as TestAccounts;
            if (data != null)
            {
                //   db.Remove(data);
                //  db.Set<TestAccounts>().Remove(data);
                db._UserInfo.Remove(data);
                db.SaveChanges();
            }

        }
        #endregion
        #region Agent
        public static Agent_User QueryAgent(Context db, int GameID)
        {
            return db.Set<Agent_User>().FirstOrDefault(x => x.GameID == GameID);
        }
        //查询部分字段
        public static void queryAgentX(Context db)
        {
            //  List<Agent_User> list = new List<Agent_User>();

            //  db._Agent_User.Select(t => new { t.ID, t.ParaentGameID }).ToList();
            //重新定义返回结果字段名字
            var blogs = db._Agent_User
                      .OrderByDescending(blog => blog.ID)
                      .Select(blog => new
                      {
                          Id = blog.ID,
                          GameIDs = blog.GameID
                      }).ToList();
        }

        // 使用sql语句
        public static void queryBySql(Context db)
        {

            var blogs = db._UserInfo
              .FromSqlRaw("SELECT * FROM TestAccounts")
              .ToList();
            foreach (var v in blogs)
            {
                string nickname = v.NickName;
                string gameid = v.Gameid.ToString();
            }

        }
        #endregion

        //分页

        public static void page(Context db,int pageindex,int pagesize)
        {
            var list= db._UserInfo.ToList();
            var  list1= list.Where(c => c.UserID > 5).ToList();
            var b=list.Skip((pageindex - 1) * pagesize).Take(pagesize).ToList();
        }
      
    }

  
}
