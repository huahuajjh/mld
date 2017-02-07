using Newtonsoft.Json;

namespace MLD.Library.SerializeHelper
{
    /// <summary>
    /// 该类服务序列化操作
    /// </summary>
    public class SerializeHelper
    {

        /// <summary>
        /// 将对象序列化为Json格式数据
        /// </summary>
        /// <param name="serObj">要被序列化的对象</param>
        /// <returns>序列化后的字符串</returns>
        public static string Serialize(object serObj)
        {
            return JsonConvert.SerializeObject(serObj);
        }

        /// <summary>
        /// 将json字符串反序列化为对象
        /// </summary>
        /// <typeparam name="T">被反序列化之后的对象</typeparam>
        /// <param name="jsonString">要被反序列化的json字符串</param>
        /// <returns>返回的DeJson泛型对象</returns>
        public static T DeSerialize<T>(string jsonString)
        {
            return JsonConvert.DeserializeObject<T>(jsonString);
        }
    }
}
