using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfRentalDal : EfEntityRepositoryBase<Rental, RentalCarContext>, IRentalDal
    {
        public void Deliver(Rental rental)
        {
            using (RentalCarContext context = new())
            {
                var rentalToBeDelivered = context.Set<Rental>().SingleOrDefault(r => r.RentalId == rental.RentalId);
                rentalToBeDelivered.IsRentalCompleted = true;
                context.SaveChanges();
            }
        }

        public List<RentalDetailDto> GetRentalDetails()
        {
            using (RentalCarContext context = new())
            {
                var result = from rental in context.Rentals
                             join car in context.Cars on rental.CarId equals car.CarId
                             join customer in context.Customers on rental.CustomerId equals customer.CustomerId
                             join brand in context.Brands on car.BrandId equals brand.BrandId
                             join color in context.Colors on car.ColorId equals color.ColorId
                             join user in context.Users on customer.UserId equals user.UserId
                             select new RentalDetailDto
                             {
                                 CarName = car.CarName,
                                 BrandName = brand.BrandName,
                                 ColorName = color.ColorName,
                                 ModelYear = car.ModelYear,
                                 DailyPrice = car.DailyPrice,
                                 Description = car.Description,
                                 CustomerFirstName = user.FirstName,
                                 CustomerLastName = user.LastName,
                                 CustomerEmail = user.Email,
                                 CustomerCompanyName = customer.CompanyName,
                                 RentDate = rental.RentDate,
                                 ReturnDate = rental.ReturnDate,
                                 IsRentalCompleted = rental.IsRentalCompleted
                             };
                return result.ToList();
            }
        }
    }
}
