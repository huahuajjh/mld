using System.Collections.Generic;
using System.Web.Mvc;
using MLD.Library.Constant;
using MVC.Controllers;

namespace MVC.Areas.Admin.Controllers
{
    public class UserController : BaseController
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(Models.TableAjaxIn inAjax,string sreahTel)
        {
            int count;
            var data = base.BackUser.Get(out count,inAjax.iDisplayStart,inAjax.iDisplayLength,sreahTel);
            return Json(new Models.TableAjaxOut()
            {
                aaData = data,
                iTotalDisplayRecords = count,
                iTotalRecords = count,
                sEcho = inAjax.sEcho
            });
        }

        [HttpPost]
        public ActionResult Add(MLD.Entity.TbUser user)
        {
            var list = new List<MLD.Entity.TbUser>();
            list.Add(user);
            var state = base.BackUser.Add(list);
            return Content(state.ToString());
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var model = base.BackUser.Get(id);
            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(MLD.Entity.TbUser user)
        {
            var state = base.BackUser.Edit(user);
            return Content(state.ToString());
        }

        [HttpPost]
        public void Delete(int id)
        {
            base.BackUser.Delete(id);
        }

    }
}
