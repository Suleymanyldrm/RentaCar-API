using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RentaCar_API.Data;
using RentaCar_API.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RentaCar_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RentaCarController : ControllerBase
    {
        private readonly RentaCarContext _rentaCarContext;
        public RentaCarController(RentaCarContext rentaCarContext)
        {
            _rentaCarContext = rentaCarContext;
        }

        //Ofisleri getiriyor.
        [HttpGet]
        public async Task<List<Officies>> Get()
        {
            return await _rentaCarContext.Officies.ToListAsync();
        }

        //Araç tablosunda Seçtiğimiz ofise göre araçları listeliyor.
        [HttpGet("reservation")]
        public async Task<List<Car>> Get(string? location)  
        {
            return await _rentaCarContext.Cars.Where(o => o.Officies.Name == location)
                                        .Include(o => o.FuelType)
                                        .Include(o => o.TransmissionType)
                                        .Include(o => o.CarModal).ThenInclude(o => o.Brand)
                                        .Include(o => o.Officies)
                                        .Include(o => o.Classification)
                                        .Select(o => new Car()
                                        {
                                            Id = o.Id,
                                            Price = o.Price,
                                            CarModal = o.CarModal,
                                            Officies = o.Officies,
                                            FuelType = o.FuelType,
                                            TransmissionType = o.TransmissionType,
                                            Classification = o.Classification,
                                        }).ToListAsync();
        }

        //Araç tablosundaki Bütün araçları listeliyor.
        [HttpGet("Listcar")]
        public async Task<List<Car>> ListCar()
        {
            return await _rentaCarContext.Cars
                                        .Include(o => o.CarModal).ThenInclude(o => o.Brand)
                                        .Select(o => new Car()
                                        {
                                            Id = o.Id,
                                            Price = o.Price,
                                            Officies = o.Officies,
                                            CarModal = o.CarModal,
                                            FuelType = o.FuelType,
                                            TransmissionType = o.TransmissionType,
                                            Classification = o.Classification,
                                        }).ToListAsync();
                                        

        }

        //Filodaki araçların hepsinden birer tane gösteriyor.(Tekrar eden araçlar için)
        [HttpGet("ListOneCar")]
        public async Task<List<object>> ListOneCar()
        {
            //return await _rentaCarContext.Cars.Distinct().ToListAsync();
            var result = await _rentaCarContext.CarModals.Include(x => x.Brand).Include(cm => cm.Cars).ToListAsync();
            return null;
        }

        //Araç tablosunda Markaya göre araçları listeliyor.
        [HttpGet("VehicleForTheBrand")]
        public async Task<List<Car>> BrandCar(int? id)
        {
            return await _rentaCarContext.Cars.Where(o => o.CarModal.Brand.Id == id)
                                        .Include(o => o.CarModal).ThenInclude(o => o.Brand)
                                        .Select(o => new Car()
                                        {
                                            Id = o.Id,
                                            Price = o.Price,
                                            Officies = o.Officies,
                                            CarModal = o.CarModal,
                                            FuelType = o.FuelType,
                                            TransmissionType = o.TransmissionType,
                                            Classification = o.Classification,
                                        }).ToListAsync();

        }

        //Araç tablosunda araç model ID sine göre filtreleme yapıyoruz.
        [HttpGet("VehicleForTheCarModal")]
        public async Task<List<Car>> CarModalCar(int? id)
        {
            return await _rentaCarContext.Cars.Where(o => o.CarModal.Id == id)
                                        .Include(o => o.CarModal).ThenInclude(o => o.Brand)
                                        .Select(o => new Car()
                                        {
                                            Id = o.Id,
                                            Price = o.Price,
                                            Officies = o.Officies,
                                            CarModal = o.CarModal,
                                            FuelType = o.FuelType,
                                            TransmissionType = o.TransmissionType,
                                            Classification = o.Classification,
                                        }).ToListAsync();


        }

        //CarModal tablosunda isme göre filtreleme yapıyoruz.
        [HttpGet("NameCarModal")]
        public async Task<List<CarModal>> NameCarModal(string Name)
        {
            return await _rentaCarContext.CarModals.Where(o => o.Name == Name)
                                           .Include(o => o.Cars)
                                           .Select(o =>
                                            new CarModal()
                                            {
                                                Id = o.Id,
                                                Name = o.Name,
                                                Brand = o.Brand,
                                            }).ToListAsync();
        }

        //Araç ismi girdiğiniz zaman araç tablosundaki o isimde olan bütün araçları listeliyor.
        [HttpGet("VehicleNameFromVehicleTable")]
        public async Task<List<CarModal>> VehicleNameFromVehicleTable(string Name)
        {
            return await _rentaCarContext.CarModals.Where(o => o.Name.ToLower().Contains(Name.ToLower()))
                                            .Include(o => o.Cars)
                                            .Select(o => new CarModal()
                                            {
                                                Id = o.Id,
                                                Name = o.Name,  
                                                Cars = o.Cars
                                            }).ToListAsync();
        }

        [HttpDelete("DeleteCar")]
        public async Task<IActionResult> DeleteCar(int id)
        {
            var deleted = await _rentaCarContext.Cars.Where(d => d.Id == id).FirstOrDefaultAsync();
            _rentaCarContext.Remove(deleted);
            await _rentaCarContext.SaveChangesAsync();
            return Ok(deleted);
        }
    }
}
