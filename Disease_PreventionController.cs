using Mvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace Mvc.Controllers
{
    public class Disease_PreventionController : Controller
    {
        // GET: Disease_Prevention
        public ActionResult Index()
        {

            IEnumerable<mvcDisease_PreventionModel> empList;
            HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync("Disease_Prevention").Result;
            empList = response.Content.ReadAsAsync<IEnumerable<mvcDisease_PreventionModel>>().Result;

            return View(empList);

        }

        public ActionResult AddOrEdit(int id = 0)
        {
            if (id == 0)
                return View(new mvcDisease_PreventionModel());
            else
            {
                HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync("Disease_Prevention/" + id.ToString()).Result;
                return View(response.Content.ReadAsAsync<mvcDisease_PreventionModel>().Result);
            }
        }

        [HttpPost]

        public ActionResult AddOrEdit(mvcDisease_PreventionModel emp)
        {
            if (emp.Prevention_ID == 0)
            {
                emp.Disease_ID = 1;
                HttpResponseMessage response = GlobalVariables.WebApiClient.PostAsJsonAsync("Disease_Prevention", emp).Result;
                
                TempData["SuccessMessage"] = "Saved Successfully";
            }
            else
            {
                emp.Disease_ID = 1;
                HttpResponseMessage response = GlobalVariables.WebApiClient.PutAsJsonAsync("Disease_Prevention/" + emp.Prevention_ID, emp).Result;
                TempData["SuccessMessage"] = "Updated Successfully";
            }
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            HttpResponseMessage response = GlobalVariables.WebApiClient.DeleteAsync("Disease_Prevention/" + id.ToString()).Result;
            TempData["SuccessMessage"] = "Deleted Successfully";
            return RedirectToAction("Index");
        }
    }
}