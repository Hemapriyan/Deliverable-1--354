using Mvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace Mvc.Controllers
{
    public class DiseaseController : Controller
    {
        // GET: Disease
        public ActionResult Index()
        {
            IEnumerable<mvcDiseaseModel> empList;
            HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync("Disease").Result;
            empList = response.Content. ReadAsAsync<IEnumerable<mvcDiseaseModel>>().Result;

            return View(empList);
        }

        public ActionResult AddOrEdit(int id = 0)
        {
            if (id == 0)
            return View(new mvcDiseaseModel());
            else
            {
                HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync("Disease/"+id.ToString()).Result;
                return View(response.Content.ReadAsAsync<mvcDiseaseModel>().Result);
            }
        }

        [HttpPost]

        public ActionResult AddOrEdit(mvcDiseaseModel emp)
        {
            if(emp.Disease_ID == 0)
            {
                HttpResponseMessage response = GlobalVariables.WebApiClient.PostAsJsonAsync("Disease", emp).Result;
                TempData["SuccessMessage"] = "Saved Successfully";
            }
            else
            {
                HttpResponseMessage response = GlobalVariables.WebApiClient.PutAsJsonAsync("Disease/"+ emp.Disease_ID, emp).Result;
                TempData["SuccessMessage"] = "Updated Successfully";
            }
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            HttpResponseMessage response = GlobalVariables.WebApiClient.DeleteAsync("Disease/" + id.ToString()).Result;
            TempData["SuccessMessage"] = "Deleted Successfully";
            return RedirectToAction("Index");
        }

    }
}