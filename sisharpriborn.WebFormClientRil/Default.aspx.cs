using sisharpriborn.WebFormClientRil.Models;
using sisharpriborn.WebFormClientRil.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace sisharpriborn.WebFormClientRil
{
    public partial class _Default : Page
    {
        private CarsServices _carsService = new CarsServices();

        private async Task FillForms(int carId)
        {
            var car = await _carsService.GetCar(carId);
            if (car != null)
            {
                txtCarId.Text = car.CarId;
                txtVIN.Text = car.VIN;
                txtModelType.Text = car.ModelType;
                txtFuelType.Text = car.FuelType;
                txtBasePrice.Text = car.BasePrice.HasValue ? car.BasePrice.Value.ToString("N0") : string.Empty;
            }
        }

        private void ClearForms()
        {
            txtCarId.Text = string.Empty;
            txtVIN.Text = string.Empty;
            txtModelType.Text = string.Empty;
            txtFuelType.Text = string.Empty;
            txtBasePrice.Text = string.Empty;

            btnAdd.Enabled = false;
        }

        private async Task FillGridView()
        {
            gvCars.DataSource = await _carsService.GetCars();
            gvCars.DataBind();
        }

        protected async void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var carId = Request.QueryString["CarId"];
                if (!string.IsNullOrEmpty(carId))
                {
                    await FillForms(int.Parse(carId));
                }

                await FillGridView();
            }
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            ClearForms();
        }

        protected async void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                //add car
                if (!btnAdd.Enabled && txtModel.Text == string.Empty)
                {
                    var newCar = new CarInsert
                    {
                        Model = txtModel.Text,
                        Type = txtType.Text,
                        BasePrice = Convert.ToDouble(txtBasePrice.Text),
                        Color = txtColor.Text,
                        Stock = Convert.ToInt32(txtStock.Text)
                    };
                    var result = await _carsService.AddCar(newCar);
                    btnAdd.Enabled = true;
                    ClearForms();
                    ltMessage.Text = $"<span class='alert alert-success'>Add Car {result.Model} success !</span>";
                }
                else //update car
                {
                    var updateCar = new CarUpdate
                    {
                        CarId = int.Parse(hfCarId.Value),
                        Model = txtModel.Text,
                        Type = txtType.Text,
                        BasePrice = Convert.ToDouble(txtBasePrice.Text),
                        Color = txtColor.Text,
                        Stock = Convert.ToInt32(txtStock.Text)
                    };
                    var result = await _carsService.UpdateCar(updateCar);
                    ltMessage.Text = $"<span class='alert alert-success'>Update Car {result.Model} success !</span>";
                }
            }
            catch (Exception ex)
            {
                ltMessage.Text = $"<span class='alert alert-danger'>Error: {ex.Message}</span>";
            }
            finally
            {
                await FillGridView();
            }

        }

        protected async void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                var carId = int.Parse(hfCarId.Value);
                await _carsService.DeleteCar(carId);
                ltMessage.Text = $"<span class='alert alert-success'>Delete Car {carId} success !</span>";

                await FillGridView();
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}