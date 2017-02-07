using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MLD.Library.Constant
{
    public static class StringExtended
    {
        /// <summary>
        /// 把Json字符串转成对象
        /// </summary>
        /// <typeparam name="T">转换的类型</typeparam>
        /// <param name="json">需要转换的数据</param>
        /// <returns>转换成功对象</returns>
        public static T ToObj<T>(this string json)
        {
            var script =
                new System.Web.Script.Serialization.JavaScriptSerializer();
            return script.Deserialize<T>(json);
        }
    }
}
