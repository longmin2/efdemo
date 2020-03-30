using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebApi.Controllers
{
    public class ReturnData
    {
        /// <summary>
        /// 0：成功，>0失败
        /// </summary>
        public int status { get; set; }

        /// <summary>
        /// 提交信息
        /// </summary>
        public string message { get; set; }

        /// <summary>
        /// 数据
        /// </summary>

        public object data { get; set; } = "";

        public static ReturnData Success()
        {
            return new ReturnData()
            {
                status = 0,
                message = "操作成功"
            };
        }
        public static ReturnData Success(string msg, object _content)
        {
            return new ReturnData()
            {
                status = 0,
                data = _content,
                message = msg
            };
        }

        public static ReturnData SuccessDelete()
        {
            return new ReturnData()
            {
                status = 0,
                message = "删除成功"
            };
        }

        public static ReturnData Error(string msg)
        {
            return new ReturnData()
            {
                status = 1,
                message = msg
            };
        }

        public static ReturnData Error(int code, string msg)
        {
            return new ReturnData()
            {
                status = code,
                message = msg
            };
        }
        public static ReturnData Error(string msg, object _content)
        {
            return new ReturnData()
            {
                status = 1,
                data = _content,
                message = msg
            };
        }
        public static ReturnData Error(int code, string msg, object _content)
        {
            return new ReturnData()
            {
                status = code,
                data = _content,
                message = msg
            };
        }

        public static ReturnData Success(string msg)
        {
            return new ReturnData()
            {
                status = 0,
                message = msg
            };
        }
        public static ReturnData Success(object _content)
        {
            return new ReturnData()
            {
                status = 0,
                data = _content
            };
        }

    }
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
    public class ValuesController : ApiController
    {
        // GET api/values
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "到底", "cc" };
        //}

        [HttpGet]
        public IHttpActionResult ProductByID(int id)
        {
            List<Product> list = new List<Product>()
            {
            new Product { Id = 1, Name = "大哥",  },
            new Product { Id = 2, Name = "二哥" },
            new Product { Id = 3, Name = "三哥" }
            };
            var product = list.FirstOrDefault(b => b.Id == id);


           
            return Ok(list);
        }
        [HttpPost]
        public IHttpActionResult AddProduct([FromBody] Product pars)
        {
            string name = pars.Name;
            return Ok(name);
        }
        [HttpPost]
        public IHttpActionResult bazid(JObject pars)
        {
            //   string ID = pars["ID"].ToString();
            //  return Ok(ID);
            string id = pars["id"].ToString();
            string name = pars["name"].ToString();

            return Ok(name+":"+id);
        }

        [HttpPost]
        public ReturnData AddProduct_bx([FromBody] Product product)
        {
            return ReturnData.Success("获取成功", string.Format("获取到的值：id={0},name={1}", product.Id, product.Name));
        }
        [HttpPost]
        public ReturnData Test(JObject pars)
        {
            string id = pars["id"].ToString();
            string name = pars["name"].ToString();

            return ReturnData.Success("获取成功", string.Format("获取的参数值：id={0},name={1}", id, name));
        }

        // GET api/values/5
        //public string Getkk(int id)
        //{

        //    return "value";
        //}

        // POST api/values
        [HttpPost]
        public string Post([FromBody]string value)
        {
            return value;
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5

        public void Delete(int id)
        {
        }
    }

}
