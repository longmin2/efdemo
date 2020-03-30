using EFCoreDemo.Entity;
using EFCoreDemo.face;
using EFCoreDemo.service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EFCoreDemo
{

    public class buniessBll
    {
        private static IRepository<TestAccounts> res = new RepositoryService<TestAccounts>(new Context());
        public static TestAccounts getSingle()
        {
            var u = res.GetById(11) as TestAccounts;
            return u;
        }
        public static void list()
        {
            var list = res.TableNoTracking;

        }
        public static void UpdateUser()
        {
            var u = res.GetById(11);
            if (u == null)
            {
                // return Ok(new Return(ResultCode.Fail, "玩家不存在"));
            }

            u.NickName = "香梨金币";
            res.Update(u);

            // _backendUnitOfWork.Save();
        }
        public static void Insert(TestAccounts obj)
        {
            //这是以case then的方式去检查是否存在 1是0 否(True 和false)
            var get = res.TableNoTracking.Any(x => x.Gameid == obj.Gameid);
            if (!get)
            {
                res.Insert(obj);
            }
        }
        public static void InsertMany(List<TestAccounts> obj)
        {
            res.InsertMany(obj);
        }
        public static void Dlete(int gameid)
        {
            var u = res.TableNoTracking.FirstOrDefault(x => x.Gameid == gameid);
            if (u != null)
            {
                res.Delete(u);
            }
        }
        public static void DleteMany(int gameid)
        {
          
           // res.DeleteWhere(x => x.Gameid == gameid);
        }
        public static void DleteWhere(int gameid)
        {

          int result=  res.DeleteWhere(x => x.Gameid == gameid);
        }
    }
}
