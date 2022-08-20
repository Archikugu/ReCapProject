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

            carManager.Add(new Car {  BrandId = 1, ColorId = 2, ModelYear = 2020, DailyPrice = 450, Descriptions = "AUDI Q8 - White" });


            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine(car.Id +" / "+car.BrandId+" / "+car.ModelYear+" / "+car.DailyPrice+" / "+car.Descriptions);
            }
        }
    }
}
