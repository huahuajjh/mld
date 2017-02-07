using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC.Areas.Admin.Models
{
    public class TableAjaxIn
    {
        public int iDisplayStart { get; set; }
        public int iDisplayLength { get; set; }
        public string sEcho { get; set; }
    }
}