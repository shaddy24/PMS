using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PMS_BLL;
using PMS_Entities;
using PMS_Utilities;
using System.Web.Script.Serialization;
using System.Text.RegularExpressions;
using System.IO;
using System.Text;


namespace PMS.Areas.Administration.Controllers
{

 
    public class EmployeeController : Controller
    {

        private EmployeeInfoBLL _employeeInfoBLL = null;

        // GET: Administration/Employee
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult EmployeeInfo()
        {
            return View();
        }


        [HttpPost]
        [ActionName("EmployeeInfo")]
        public JsonResult GetEmployeeInfolist(string sidx = "", string sord = "desc", int page = 1, int rows = 10
           , bool _search = false)

        {
            
            IEnumerable<EmployeeInfoTableViewFilterEntity> objPersonInfoViews = null;
            EmployeeInfoTableViewFilterEntity objPersonInfoViewFilter = null;

            int totalRecords = 0;
            int noOfPages = 1;
            int rowStart = 1;


            try
            {
                rowStart = page > 1 ? page * rows - rows + 1 : rowStart;

                objPersonInfoViewFilter = new EmployeeInfoTableViewFilterEntity
                {
                    RowStart = rowStart,
                    NoOfRecord = rows,
                    SortColumn = sidx == "" ? 0 : Convert.ToInt32(sidx),
                    SortDirection = sord
                };

                var serializer = new JavaScriptSerializer();

               //_personInfoBLL = new PersonInfoBLL(_objSystemUser);
                objPersonInfoViews = _employeeInfoBLL.GetFiltered(objPersonInfoViewFilter).ToList();

                if (objPersonInfoViews != null && objPersonInfoViews.Count() > 0)
                {
                    totalRecords = objPersonInfoViews.FirstOrDefault().TotalNoOfRecords;
                    noOfPages = (int)Math.Ceiling((float)totalRecords / (float)rows);


                }
            }
            catch (Exception ex)
            {
                
            }


            return Json(JsonRequestBehavior.AllowGet);
        }


    }
}