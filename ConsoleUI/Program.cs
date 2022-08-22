using Business.Concrete;
using DataAccess.Concrete.InMemory;
using DataAccess.Concrete.EntityFramework;
using System;
using Entities.Concrete;

namespace ConsoleUI
{
    internal class Program
    {
        static void Main(string[] args)
        {
            CarManager carManager = new CarManager(new EfCarDal());

            //carManager.Add(new Car {  BrandId = 1, ColorId = 2, ModelYear = 2022, DailyPrice = 750, Descriptions = "AUDI Q8 - Brown" });
            //carManager.Update(new Car { Id = 1025, BrandId = 1, ColorId = 6, ModelYear = 2020, DailyPrice = 450, Descriptions = "AUDI Q8 - Brown" });
            //carManager.Delete(new Car { Id = 1025, BrandId = 1, ColorId = 6, ModelYear = 2020, DailyPrice = 450, Descriptions = "AUDI Q8 - Brown" });



            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine(car.Id +" / "+car.BrandId+" / "+car.ModelYear+" / "+car.DailyPrice+" / "+car.Descriptions);
            }
            Console.WriteLine();
            foreach (var car in carManager.GetCarDetails())
            {
                Console.WriteLine(car.CarId+" / "+car.BrandName);
            }
        }
    }
}
