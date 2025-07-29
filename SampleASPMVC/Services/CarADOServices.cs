using Microsoft.Data.SqlClient;
using Dapper;
using System.Drawing;
using System.Collections.Generic;
using SampleASPMVC.Models;

namespace SampleASPMVC.Services;

public class CarADOServices : ICar
{
    private readonly IConfiguration _config;
    
    public CarADOServices(IConfiguration config)
    {
        _config = config;
    }

    private string GetConnStr()
    {
        return _config.GetConnectionString("FinalProjectConnectionString");
    }

    public Car Create(Car item)
    {
        using (SqlConnection conn = new SqlConnection(GetConnStr()))
        {
            conn.Open();
            using (SqlCommand cmd = new SqlCommand("INSERT INTO Car (CarId, VIN, ModelType, FuelType, BasePrice) VALUES (@CarId, @VIN, @ModelType, @FuelType, @BasePrice)", conn))
            {
                cmd.Parameters.AddWithValue("@CarId", item.CarId);
                cmd.Parameters.AddWithValue("@VIN", item.VIN);
                cmd.Parameters.AddWithValue("@ModelType", item.ModelType);
                cmd.Parameters.AddWithValue("@FuelType", item.FuelType);
                cmd.Parameters.AddWithValue("@BasePrice", item.BasePrice);
                
                int rowsAffected = cmd.ExecuteNonQuery();
                if (rowsAffected > 0)
                {
                    return item; // Return the created car object
                }
                else
                {
                    throw new Exception("Error inserting car record.");
                }
            }
        }
    }

    public Car Read(string carId)
    {
        using (SqlConnection conn = new SqlConnection(GetConnStr()))
        {
            conn.Open();
            using(SqlCommand cmd = new SqlCommand("GetCarById", conn))
            {
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@CarId", carId);
                using(SqlDataReader reader = cmd.ExecuteReader())
                {
                    if(reader.Read())
                    {
                        return new Car
                        {
                            CarId = reader["CarId"].ToString(),
                            VIN = reader["VIN"].ToString(),
                            ModelType = reader["ModelType"].ToString(),
                            FuelType = reader["FuelType"].ToString(),
                            BasePrice = Convert.ToDouble(reader["BasePrice"])
                        };
                    }
                    else
                    {
                        throw new KeyNotFoundException($"Car with ID {carId} not found.");
                    }
                }
            }
        }
    }

    public Car Update(Car item)
    {
        using (SqlConnection conn = new SqlConnection(GetConnStr()))
        {
            conn.Open();
            using (SqlCommand cmd = new SqlCommand("UpdateCarById", conn))
            {
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@CarId", item.CarId);
                cmd.Parameters.AddWithValue("@VIN", item.VIN);
                cmd.Parameters.AddWithValue("@ModelType", item.ModelType);
                cmd.Parameters.AddWithValue("@FuelType", item.FuelType);
                cmd.Parameters.AddWithValue("@BasePrice", item.BasePrice);

                int rowsAffected = cmd.ExecuteNonQuery();
                if (rowsAffected > 0)
                {
                    return item; // Return the updated car object
                }
                else
                {
                    throw new Exception("Error updating car record.");
                }
            }
        }
    }

    public void Delete(string carId)
    {
        using (SqlConnection conn = new SqlConnection(GetConnStr()))
        {
            conn.Open();
            using (SqlCommand cmd = new SqlCommand("DeleteCarById", conn))
            {
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@CarId", carId);
                int rowsAffected = cmd.ExecuteNonQuery();
                if (rowsAffected == 0)
                {
                    throw new KeyNotFoundException($"Car with ID {carId} not found.");
                }
            }
        }
    }

    public IEnumerable<Car> GetAll()
    {
        // Implementation for retrieving all car records from the database
        using (SqlConnection conn = new SqlConnection(GetConnStr()))
        {
            var cars = conn.Query<Car>("GetAllCars", commandType: System.Data.CommandType.StoredProcedure).ToList();
            return cars;
            // conn.Open();
            // using(SqlCommand cmd = new SqlCommand("GetAllCars", conn))
            // {
            //     cmd.CommandType = System.Data.CommandType.StoredProcedure;
            //     using (SqlDataReader reader = cmd.ExecuteReader())
            //     {
            //         List<Car> cars = new List<Car>();
            //         while (reader.Read())
            //         {
            //             Car car = new Car
            //             {
            //                 CarId = reader["CarId"].ToString(),
            //                 VIN = reader["VIN"].ToString(),
            //                 ModelType = reader["ModelType"].ToString(),
            //                 FuelType = reader["FuelType"].ToString(),
            //                 BasePrice = Convert.ToDouble(reader["BasePrice"])
            //             };
            //             cars.Add(car);
            //         }
            //         return cars;
            //     }
            // }
        }
    }

    public IEnumerable<Car> GetByModel(string modelType)
    {
        using (SqlConnection conn = new SqlConnection(GetConnStr()))
        {
            var cars = conn.Query<Car>("GetCarsByModelOrFuel", new { ModelType = "%" + modelType + "%", FuelType = "%" + modelType + "%" }, commandType: System.Data.CommandType.StoredProcedure).ToList();
            return cars;
            // conn.Open();
            // using (SqlCommand cmd = new SqlCommand("GetCarsByModelOrFuel", conn))
            // {
            //     cmd.CommandType = System.Data.CommandType.StoredProcedure;
            //     cmd.Parameters.AddWithValue("@ModelType", "%" + modelType + "%");
            //     cmd.Parameters.AddWithValue("@FuelType", "%" + modelType + "%");
            //     using (SqlDataReader reader = cmd.ExecuteReader())
            //     {
            //         List<Car> cars = new List<Car>();
            //         while (reader.Read())
            //         {
            //             Car car = new Car
            //             {
            //                 CarId = reader["CarId"].ToString(),
            //                 VIN = reader["VIN"].ToString(),
            //                 ModelType = reader["ModelType"].ToString(),
            //                 FuelType = reader["FuelType"].ToString(),
            //                 BasePrice = Convert.ToDouble(reader["BasePrice"])
            //             };
            //             cars.Add(car);
            //         }
            //         return cars;
            //     }
            // }
        }
    }
}
