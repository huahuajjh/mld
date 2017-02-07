using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Web;
using MLD.Library.Constant;
using MLD.Library.SerializeHelper;

namespace MLD.Library.FileHelper
{
    /// <summary>
    /// 文件处理帮助类
    /// </summary>
    public static class FileHelper
    {
        /// <summary>
        /// 保存处理后的图像
        /// </summary>
        /// <param name="file">文件对象</param>
        /// <param name="width">欲生成的缩略图高度</param>
        /// <param name="height">欲生成的缩略图宽度</param>
        /// <returns>文件地址</returns>
        public static string SaveFile(HttpPostedFileBase file, int width, int height)
        {
            return SaveFile(file.InputStream,width,height);
        }

        /// <summary>
        /// 保存处理后的图像
        /// </summary>
        /// <param name="file">文件对象</param>
        /// <param name="width">欲生成的缩略图高度</param>
        /// <param name="height">欲生成的缩略图宽度</param>
        /// <returns>文件地址</returns>
        public static string SaveFile(Stream file, int width, int height)
        {
            //获取配置文件中的图片文件夹
            string dir = ConfigFileHelper.GetAppSettingValue(DiKey.IMGDIR);
            dir = HttpContext.Current.Server.MapPath("/") + dir;
            //如果文件夹不存在，则创建
            if (!Directory.Exists(dir))
            {
                Directory.CreateDirectory(dir);
            }

            //图片
            Image img = Image.FromStream(file);

            //源图的宽高
            int oldWidth = img.Width;
            int oldHeight = img.Height;


            //生成缩略图实际宽高
            int thombWidth = width;
            int thombHeight = height;

            //生成缩略图的位置
            int x = 0;
            int y = 0;

            //根据源图以及欲生成的缩略图尺寸，计算出缩略图的实际尺寸及其在画布上的位置
            if (thombHeight * oldWidth > thombWidth * oldHeight)
            {
                thombHeight = oldHeight * width / oldWidth;
                y = (height - thombHeight) / 2;
            }
            else
            {
                thombWidth = oldWidth * height / oldHeight;
                x = (width - thombWidth) / 2;
            }

            //创建画布
            var bmp = new Bitmap(width, height);

            //画笔
            Graphics g = Graphics.FromImage(bmp);
            //bg
            g.Clear(Color.White);
            // 指定高质量的双三次插值法。执行预筛选以确保高质量的收缩。此模式可产生质量最高的转换图像。 
            g.InterpolationMode = InterpolationMode.HighQualityBicubic;
            // 指定高质量、低速度呈现。 
            g.SmoothingMode = SmoothingMode.HighQuality;
            //绘制
            g.DrawImage(img, new Rectangle(x, y, thombWidth, thombHeight), new Rectangle(0, 0, oldWidth, oldHeight), GraphicsUnit.Pixel);

            //生成文件名
            string name;
            string fileName = Guid.NewGuid() + ".jpg";
            try
            {
                name = dir + "/" + fileName;
                bmp.Save(name, ImageFormat.Jpeg);
            }
            catch (Exception e)
            {
                return e.InnerException.Message;
            }
            finally
            {
                //释放资源
                bmp.Dispose();
                img.Dispose();
                g.Dispose();
            }

            return fileName;
        }


    }
}
