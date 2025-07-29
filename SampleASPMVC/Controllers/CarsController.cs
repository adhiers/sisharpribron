using System.Runtime.CompilerServices;
using Microsoft.AspNetCore.Mvc;
using SampleASPMVC.Models;
using SampleASPMVC.Services;

namespace SampleASPMVC.Controllers
{
    public class CarsController : Controller
    {
        // GET: CarsController
        private readonly ICar _carService;
        public CarsController(ICar carService)
        {
            _carService = carService;
        }

        [HttpGet]
        public IActionResult Index(string? search="")
        {
            List<Car> models = new List<Car>();
            if (TempData["Message"] != null)
            {
                ViewBag.Message = TempData["Message"];
            }
            if(!string.IsNullOrEmpty(search))
            {
                models = _carService.GetByModel(search).ToList();
            }
            else
            {
                models = _carService.GetAll().ToList();
            }
            return View(models);
        }

        public IActionResult Insert()
        {
            return View();
        }

        [HttpPost]
        [ActionName("Insert")]
        public IActionResult InsertPost(Car car)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _carService.Create(car);
                    TempData["Message"] = "<br/><span class='alert alert-success'>Car added successfully!</span><br/><br/>";
                    return RedirectToAction("Index");
                }
                return View(car);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", $"Error: {ex.Message}");
            }
            return View(car);
        }


        public IActionResult Update(string id)
        {
            var car = _carService.Read(id);
            if (car == null)
            {
                return NotFound();
            }
            return View(car);
        }

        [HttpPost]
        [ActionName("Update")]
        public IActionResult UpdatePost(string id, Car car)
        {
            var existingCar = _carService.Read(id);
            if (existingCar == null)
            {
                return NotFound();
            }

            if (id != car.CarId)
            {
                return BadRequest("Car ID mismatch.");
            }

            try
            {
                if (ModelState.IsValid)
                {
                    _carService.Update(car);
                    TempData["Message"] = "<br/><span class='alert alert-success'>Car updated successfully!</span><br/><br/>";
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", $"Error: {ex.Message}");
            }
            return View(car);
        }
        public IActionResult Delete(string id)
        {
            var car = _carService.Read(id);
            if (car == null)
            {
                return NotFound();
            }
            return View(car);
        }
        [HttpPost]
        [ActionName("Delete")]
        public IActionResult DeletePost(string id)
        {
            try
            {
                _carService.Delete(id);
                TempData["Message"] = "<br/><span class='alert alert-success'>Car deleted successfully!</span><br/><br/>";
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", $"Error: {ex.Message}");
            }
            return View();
        }
    }
}
