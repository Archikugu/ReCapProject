using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Business.Constants
{
    public static class Messages
    {
        public static string CarAdded = "Car Was Added";
        public static string CarDeleted = "Car Was Deleted";
        public static string CarsListed = "Cars Were Listed";
        public static string TheCarListed = "The Car Was Listed";
        public static string CarUpdated = "Car Was Updated";
        public static string CarNameInvalid = "Car Name Is Invalid";
        public static string DailyPriceInvalid = "Daily Price Is Invalid";
        public static string TheCarDoesNotExist = "The Car Does Not Exist!";

        public static string CarImageAdded = "CarImage Was Added";
        public static string CarImageDeleted = "CarImage Was Deleted";
        public static string CarImagesListed = "CarImages Were Listed";
        public static string TheCarImageListed = "The CarImage Was Listed";
        public static string CarImageUpdated = "CarImage Was Updated";
        public static string CarImageDoesNotFound = "The Given Car Image Does Not Found!";
        public static string CarImageLimitExceeded = "Car Image Limit Exceeded! You Can Not Upload More Than Five For A Car.";
        public static string TheCarImagesOfTheGivenCarListed = "The CarImages Of The Given Car Listed";

        public static string BrandAdded = "Brand Was Added";
        public static string BrandDeleted = "Brand Was Deleted";
        public static string BrandsListed = "Brands Were Listed";
        public static string TheBrandListed = "The Brand Was Listed";
        public static string BrandUpdated = "Brand Was Updated";

        public static string ColorAdded = "Color Was Added";
        public static string ColorDeleted = "Color Was Deleted";
        public static string ColorsListed = "Colors Were Listed";
        public static string TheColorListed = "The Color Was Listed";
        public static string ColorUpdated = "Color Was Updated";

        public static string UserAdded = "User Was Added";
        public static string UserDeleted = "User Was Deleted";
        public static string UsersListed = "Users Were Listed";
        public static string TheUserListed = "The User Was Listed";
        public static string UserUpdated = "User Was Updated";
        public static string UserClaimsListed = "Claims of the User Was Listed";
        public static string UserRegistered = "User Registered";
        public static string UserNotFound = "User Not Found";
        public static string PasswordError = "User's Password Is Wrong";
        public static string SuccessfulLogin = "User's Login Is Successful";
        public static string UserAlreadyExists = "User Is Already Exist";
        public static string AccessTokenCreated = "User's Access Token Was Created";

        public static string CustomerAdded = "Customer Was Added";
        public static string CustomerDeleted = "Customer Was Deleted";
        public static string CustomersListed = "Customers Were Listed";
        public static string TheCustomerListed = "The Customer Was Listed";
        public static string CustomerUpdated = "Customer Was Updated";
        public static string TheCustomerDoesNotExist = "The Customer Does Not Exist!";

        public static string RentalAdded = "Rental Was Added";
        public static string RentalDeleted = "Rental Was Deleted";
        public static string RentalsListed = "Rentals Were Listed";
        public static string TheRentalListed = "The Rental Was Listed";
        public static string RentalUpdated = "Rental Was Updated";
        public static string CarIsInAlreadyRental = "Car Is In Already Rental. You Can Not Rental This Car Again!";
        public static string RentalWasDelivered = "Rental Was Delivered";
        public static string RentalHasAlreadyDelivered = "Rental Has Already Delivered";
        public static string ThereIsNoRentalWhichHasTheGivenId = "There Is No Rental Which Has The Given Rental Id";

        public static string AuthorizationDenied = "Authorization Denied!";

    }
}
