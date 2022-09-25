using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryDal : ICarDal
    {
        List<Car> _cars;

        public InMemoryDal()
        {
            _cars = new List<Car>
            {
                new Car{CarId=1,BrandId=1,ColorId=1,DailyPrice=785,Description="Beyaz Fiat Egea",ModelYear=2021},
                new Car{CarId=2,BrandId=2,ColorId=1,DailyPrice=875,Description="Beyaz Renault Megane",ModelYear=2020},
                new Car{CarId=3,BrandId=3,ColorId=2,DailyPrice=1100,Description="Lacivert Bmw X5",ModelYear=2018},
                new Car{CarId=4,BrandId=4,ColorId=3,DailyPrice=650,Description="Kırmızı Dacia Duster",ModelYear=2017},
                new Car{CarId=5,BrandId=5,ColorId=1,DailyPrice=1000,Description="Beyaz Mercedes Cla-180",ModelYear=2019},
            };
        }

        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Delete(Car car)
        {
            Car carToDelete = _cars.SingleOrDefault(c => c.CarId == car.CarId);
            _cars.Remove(carToDelete);
        }
        public void Update(Car car)
        {
            Car carToUpdate =_cars.SingleOrDefault(c => c.CarId== car.CarId);
            carToUpdate.BrandId = car.BrandId;
            carToUpdate.ColorId = car.ColorId;
            carToUpdate.DailyPrice = car.DailyPrice;
            carToUpdate.Description = car.Description;
            carToUpdate.ModelYear = car.ModelYear;
        }
        public List<Car> GetAll()
        {
            return _cars;
        }

        public List<Car> GetById(int carId)
        {
            return _cars.Where(c=>c.CarId==carId).ToList();
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<CarDetailDto> GetCarDetails()
        {
            throw new NotImplementedException();
        }
    }
}
