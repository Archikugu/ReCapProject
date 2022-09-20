using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Business.Constants
{
    public class Messages
    {
        public static string CarAdded = "Car Added";
        public static string CarDeleted = "Car Deleted";
        public static string CarUpdated = "Car Updated";
        public static string CarListed = "Cars Are Listed";
        public static string CustomerAdded = "Customer Added";
        public static string CarDescriptionsInvalid = "The car description is invalid";
        public static string MaintenanceTime = "The System Is In Maintenance";
        public static string CarAlreadyRented = "The car rental process failed, the selected car was rented";
        public static string RentalSuccesful = "The Car rental process is successful";
        public static string CouldNotCarAdded = "Could Not Car Added ";
        public static string CarImageCountExceeded = "Car Image Count Exceeded ";


        public static string ErrorMessage="Error !";
        public static string ImageAdded="Image Added";
        public static string ImageNotFound= "Image Not Found";
        public static string ImageError= "Image Error";
        public static string ImageUpdated= "Image Updated";
        public static string ImageDeleted= "Image Deleted";

        public static string AuthorizationDenied = "You are not authorized";

        public static string AccessTokenCreated = "AccessTokenCreated";
        public static string UserNotFound = "UserNotFound";
        public static string PasswordError = "PasswordError";
        public static string SuccessfulLogin = "SuccessfulLogin";
        public static string UserRegistered = "UserRegistered";
        public static string UserAlreadyExists = "UserAlreadyExists";
    }
}
