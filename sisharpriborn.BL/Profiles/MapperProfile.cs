using System;
using AutoMapper;
using sisharpriborn.BL.DTO;
using sisharpriborn.BO;

namespace sisharpriborn.BL.Profiles;

public class MapperProfile : Profile
{
    public MapperProfile()
    {

        CreateMap<Car, CarDTO>();
        CreateMap<CarInsertDTO, Car>();
        CreateMap<CarUpdateDTO, Car>();

        CreateMap<Dealer, DealerDTO>();
        CreateMap<DealerInsertDTO, Dealer>();
        CreateMap<DealerUpdateDTO, Dealer>();

        CreateMap<DealerCarList, DealerCarDTO>();
        CreateMap<DealerCarInsertDTO, DealerCarList>();
        CreateMap<DealerCarUpdateDTO, DealerCarList>(); 
    }
}
