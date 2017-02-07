using System.Web;
using System.Web.Mvc;
using MVC.Controllers;

namespace MVC.Areas.Admin.Controllers
{
    public class AddGroupCourseBookController : BaseController
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// 获取数据
        /// </summary>
        [HttpPost]
        public ActionResult Index(int iDisplayStart, int iDisplayLength, string sEcho)
        {
            int count;
            var data = base.BackCourse.Get(out count, iDisplayStart, iDisplayLength);
            return Json(new Models.TableAjaxOut()
            {
                aaData = data,
                iTotalDisplayRecords = count,
                iTotalRecords = count,
                sEcho = sEcho
            });
        }

        /// <summary>
        /// 新增文件
        /// </summary>
        [HttpPost]
        public ActionResult Add(MLD.Entity.TbGroupCourse course,HttpPostedFileBase img)
        {
            var stater = base.BackCourse.Add(course, img);
            return Content(stater.ToString());
        }

        /// <summary>
        /// 修改
        /// </summary>
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var model = base.BackCourse.Get(id);
            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(MLD.Entity.TbGroupCourse course, HttpPostedFileBase img)
        {
            var stater = base.BackCourse.Edit(course, img);
            return Content(stater.ToString());
        }

        [HttpPost]
        public void Delete(int id)
        {
            base.BackCourse.Delete(id);
        }
    }
}
