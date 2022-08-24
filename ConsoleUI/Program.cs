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
            //CarTest();
            //UserTest();
            //RentalTest();
            //CustomerTest();

            CarManager carManager = new CarManager(new EfCarDal());
            var result = carManager.GetCarDetails();
            if (result.Success == true)
            {
                foreach (var car in result.Data)
                {
                    Console.WriteLine(car.CarId + " / " + car.BrandName + " / " + car.ColorName );
                }
            }
            else
            {
                Console.WriteLine(result.Message);
            }





        }

        private static void CustomerTest()
        {
            CustomerManager customerManager = new CustomerManager(new EfCustomerDal());
            customerManager.Add(new Customer { UserId = 2, CompanyName = "Infinity" });

            var result = customerManager.GetAll();
            foreach (var customer in result.Data)
            {
                Console.WriteLine(customer.CustomerId + " / " + customer.UserId + " / " + customer.CompanyName);
            }
        }
        private static void RentalTest()
        {
            RentalManager rentalManager = new RentalManager(new EfRentalDal());
            var result = rentalManager.Add(new Rental { CarId = 3, CustomerId = 2, RentDate = new DateTime(2022, 08, 24) });
            Console.WriteLine(result.Success);
            Console.WriteLine(result.Message);
        }
        private static void UserTest()
        {

            UserManager userManager = new UserManager(new EfUserDal());
            //userManager.Add(new User { FirstName = "Sumeyye", LastName = "Buyukakyol", Email = "sumeyyebuyukakyol@gmail.com", Password = "12345" });

            var result = userManager.GetAll();
            foreach (var user in result.Data)
            {
                Console.WriteLine(user.UserId + " / " + user.FirstName + " / " + user.LastName + " / " + user.Email + " / " + user.Password);
            }
        }
        private static void CarTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());

            var result = carManager.GetAll();

            if (result.Success)
            {
                foreach (var car in result.Data)
                {
                    Console.WriteLine(car.Id + " / " + car.BrandId + " / " + car.ModelYear + " / " + car.DailyPrice + " / " + car.Descriptions);
                }
            }
            else
            {
                Console.WriteLine(result.Message);
            }
        }
    }
}
