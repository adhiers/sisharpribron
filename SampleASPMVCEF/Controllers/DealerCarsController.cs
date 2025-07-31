using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using SampleASPMVCEF.DAL;
using SampleASPMVCEF.Models;
using SampleASPMVCEF.ViewModels;
using Microsoft.AspNetCore.Mvc.Rendering;
// Add the correct namespace if DealerCarViewModel is in a different namespace, for example:
// using SampleASPMVCEF.ViewModels;

namespace SampleASPMVCEF.Controllers
{
    public class DealerCarsController : Controller
    {
        private readonly IDealerCar _dealerCar;
        private readonly ICar _car;
        private readonly IDealer _dealer;
        public DealerCarsController(IDealerCar dealerCar, ICar car, IDealer dealer)
        {
            _dealerCar = dealerCar;
            _car = car;
            _dealer = dealer;
        }
        // GET: DealerCarsController
        public ActionResult Index()
        {
            if (TempData["Message"] != null)    
            {
                ViewBag.Message = TempData["Message"];
            }
            var dealerCars = _dealerCar.GetAll().ToList();
            // var dealerCarViewModel = dealerCars.Select(dc => new DealerCarViewModel
            // {
            //     DealerCarId = dc.DealerCarId,
            //     CarId = dc.CarId,
            //     DealerId = dc.DealerId,
            //     Stock = dc.Stock ?? 0,
            //     DealerCarPrice = (decimal)dc.DealerCarPrice,
            //     CarModel = dc.Car.ModelType
            // }).ToList();
            var dealerCarViewModel = new List<DealerCarViewModel>();
            foreach (var dc in dealerCars)
            {
                dealerCarViewModel.Add(new DealerCarViewModel
                {
                    DealerCarId = dc.DealerCarId,
                    CarId = dc.CarId,
                    DealerId = dc.DealerId,
                    Stock = dc.Stock ?? 0,
                    DealerCarPrice = (decimal)dc.DealerCarPrice,
                    ModelType = _car.GetById(dc.CarId).ModelType,
                    DealerName = _dealer.GetById(dc.DealerId).DealerName
                });
            }
            return View(dealerCarViewModel);
            // return View(dealerCars);
        }

        public ActionResult Details(string id)
        {
            return View();
        }

        // [HttpGet]
        public ActionResult Create()
        {
            ViewBag.Cars = _car.GetAll().Select(c => new SelectListItem
            {
                Value = c.CarId,
                Text = c.ModelType
            }).ToList();

            ViewBag.Dealers = _dealer.GetAll().Select(d => new SelectListItem
            {
                Value = d.DealerId,
                Text = d.DealerName
            }).ToList();

            return View();

        }

        [HttpPost]
        public ActionResult Create(DealerCarInsertViewModel dealerCarInsertViewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var dealerCar = new DealerCarList
                    {
                        DealerCarId = dealerCarInsertViewModel.DealerCarId,
                        CarId = dealerCarInsertViewModel.CarId,
                        DealerId = dealerCarInsertViewModel.DealerId,
                        Stock = dealerCarInsertViewModel.Stock,
                        DealerCarPrice = (double)dealerCarInsertViewModel.DealerCarPrice
                        
                    };
                    _dealerCar.Create(dealerCar);
                    TempData["Message"] = "<br/><span class='alert alert-success'>Dealer car added successfully!</span><br/><br/>";
                    return RedirectToAction(nameof(Index));
                }
                // If ModelState is invalid, re-display the form with validation errors
                return View(dealerCarInsertViewModel);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", $"Error: {ex.Message}");
                return View(dealerCarInsertViewModel);
            }
        }

        public ActionResult Edit(string id)
        {
            var dealerCar = _dealerCar.GetById(id);
            if (dealerCar == null)
            {
                TempData["Message"] = "<br/><span class='alert alert-danger'>Dealer car not found!</span><br/><br/>";
                return RedirectToAction(nameof(Index));
            }

            var model = new DealerCarUpdateViewModel
            {
                DealerCarId = dealerCar.DealerCarId,
                CarId = dealerCar.CarId,
                DealerId = dealerCar.DealerId,
                Stock = dealerCar.Stock ?? 0,
                DealerCarPrice = (double)dealerCar.DealerCarPrice
            };
            ViewBag.Cars = _car.GetAll().Select(c => new SelectListItem
            {
                Value = c.CarId,
                Text = c.ModelType
            }).ToList();
            ViewBag.Dealers = _dealer.GetAll().Select(d => new SelectListItem
            {
                Value = d.DealerId,
                Text = d.DealerName
            }).ToList();
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(string id, DealerCarUpdateViewModel dealerCarUpdateViewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var UpdatedDealerCar = _dealerCar.GetById(id);
                    if (UpdatedDealerCar == null)
                    {
                        TempData["Message"] = "<br/><span class='alert alert-danger'>Dealer car not found!</span><br/><br/>";
                        return RedirectToAction(nameof(Index));
                    }
                    UpdatedDealerCar.CarId = dealerCarUpdateViewModel.CarId;
                    UpdatedDealerCar.DealerId = dealerCarUpdateViewModel.DealerId;
                    UpdatedDealerCar.Stock = dealerCarUpdateViewModel.Stock;
                    UpdatedDealerCar.DealerCarPrice = dealerCarUpdateViewModel.DealerCarPrice;
                    _dealerCar.Update(UpdatedDealerCar);
                    TempData["Message"] = "<br/><span class='alert alert-success'>Dealer car updated successfully!</span><br/><br/>";
                    return RedirectToAction(nameof(Index));
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", $"Error: {ex.Message}");
                ViewBag.Cars = _car.GetAll().Select(c => new SelectListItem
                {
                    Value = c.CarId,
                    Text = c.ModelType
                }).ToList();
                ViewBag.Dealers = _dealer.GetAll().Select(d => new SelectListItem
                {
                    Value = d.DealerId,
                    Text = d.DealerName
                }).ToList();

            }
                return View(dealerCarUpdateViewModel);
        }

        public ActionResult Delete(string id)
        {
            var dealerCar = _dealerCar.GetById(id);
            if (dealerCar == null)
            {
                TempData["Message"] = "<br/><span class='alert alert-danger'>Dealer car not found!</span><br/><br/>";
                return RedirectToAction(nameof(Index));
            }
            return View(dealerCar);

            // Create a view model to pass to the view
        }

        [HttpPost]
        [ActionName("Delete")]
        public ActionResult Delete(string id, IFormCollection collection)
        {
            try
            {
                var dealerCar = _dealerCar.GetById(id);
                if (dealerCar == null)
                {
                    TempData["Message"] = "<br/><span class='alert alert-danger'>Dealer car not found!</span><br/><br/>";
                    return RedirectToAction(nameof(Index));
                }
                _dealerCar.Delete(id);
                TempData["Message"] = "<br/><span class='alert alert-success'>Dealer car deleted successfully!</span><br/><br/>";
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
         
    }
}
