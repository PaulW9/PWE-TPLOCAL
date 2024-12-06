using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Sockets;
using TPLOCAL1.Models;

//Subject is find at the root of the project and the logo in the wwwroot/ressources folders of the solution
//--------------------------------------------------------------------------------------
//Careful, the MVC model is a so-called convention model instead of configuration,
//The controller must imperatively be name with "Controller" at the end !!!
namespace TPLOCAL1.Controllers
{
    public class HomeController : Controller
    {
        
        public ActionResult Index(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
               
                return View();
            else
            {
                
                switch (id)
                {
                    case "listReviews":
                       
                        return View(id);
                    case "Form":
                        
                        return View(id);
                    default:
                        
                        return View();
                }
            }
        }
        public IActionResult Validation(string Name, string Forename, string Gender, string Address, string ZipCode, string City, string Email, DateTime TrainingStartDate, string TrainingType, string TrainingReviewCOBOL, string TrainingReviewCsharp)
        {
            
            var model = new DataStored
            {
                Name = Name,
                Forename = Forename,
                Gender = Gender,
                Address = Address,
                ZipCode = ZipCode,
                City = City,
                Email = Email,
                TrainingStartDate = TrainingStartDate,
                TrainingType = TrainingType,
                TrainingReviewCOBOL = TrainingReviewCOBOL,
                TrainingReviewCsharp = TrainingReviewCsharp
            };

            
            return View(model);
        }
   
        public IActionResult AvisList()
        {        
            string filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "DataAvis.xml");
            
            if (!System.IO.File.Exists(filePath))
            {
                return NotFound("Le fichier des avis est introuvable. Chemin attendu :" + filePath);
            }
   
            var reviews = new Opinion().GetAvis(filePath);

            return View(reviews);
        }
    }
}