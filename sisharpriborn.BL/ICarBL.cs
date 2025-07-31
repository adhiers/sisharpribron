using System;
using sisharpriborn.BL.DTO;
using sisharpriborn.BO;

namespace sisharpriborn.BL;

public interface ICarBL
{
    IEnumerable<CarDTO> GetCars();
    CarDTO GetById(string carId);
    CarDTO AddCar(CarInsertDTO carInsertDto);
    CarDTO UpdateCar(CarUpdateDTO carUpdateDto);
    void DeleteCar(string carId);
    IEnumerable<CarDTO> GetCarsBySearch(string dealerId);
}
