using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Business;
using Core.Utilities.Helpers;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Business.Concrete
{
    public class CarImageManager : ICarImageService
    {
        ICarImageDal _carImageDal;
        IFileHelper _fileHelper;

        public CarImageManager(ICarImageDal carImageDal, IFileHelper fileHelper)
        {
            _carImageDal = carImageDal;
            _fileHelper = fileHelper;

        }

        public IResult Add(IFormFile formFile, CarImage carImage)
        {
            var ruleResult = BusinessRules.Run(CheckImageLimitExceeded(carImage.CarId));
            if (ruleResult != null)
            {
                return new ErrorResult(ruleResult.Message);
            }

            carImage.ImagePath = _fileHelper.Upload(formFile, PathConstants.ImagePath).ToString();
            carImage.Date = DateTime.Now;
            _carImageDal.Add(carImage);
            return new SuccessResult(Messages.CarImageAdded);
        }

        public IResult Delete(CarImage carImage)
        {
            var result = _fileHelper.Delete(PathConstants.ImagePath + carImage.ImagePath);
            if (!result.Success)
            {
                return result;
            }
            _carImageDal.Delete(carImage);
            return new SuccessResult(Messages.CarImageDeleted);
        }

        public IDataResult<List<CarImage>> GetAll()
        {
            return new SuccessDataResult<List<CarImage>>(Messages.CarImagesListed, _carImageDal.GetAll());
        }

        public IDataResult<List<CarImage>> GetByCarId(int carId)
        {
            var result = BusinessRules.Run(CheckIfCarImageExists(carId));

            if (result != null)
            {
                return new ErrorDataResult<List<CarImage>>(GetDefaultImage(carId).Data);
            }
            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll(c => c.CarId == carId));
        }

        public IDataResult<CarImage> GetByImageId(int imageId)
        {
            return new SuccessDataResult<CarImage>(_carImageDal.Get(c => c.CarId == imageId));
        }

        public IResult Update(IFormFile formFile, CarImage carImage)
        {
            var result = _fileHelper.Update(formFile, PathConstants.ImagePath + carImage.ImagePath, PathConstants.ImagePath);
            _carImageDal.Update(carImage);
            return new SuccessResult(Messages.CarImageUpdated);

        }

        private IResult CheckImageLimitExceeded(int carId)
        {
            var carImagesOfTheCar = _carImageDal.GetAll(p => p.CarId == carId);
            if (carImagesOfTheCar.Count >= 5)
            {
                return new ErrorResult(Messages.CarImageLimitExceeded);
            }
            return new SuccessResult();
        }

        private IResult CheckIfCarImageExists(int carId)
        {
            var result = _carImageDal.GetAll(c => c.CarId == carId).Count();

            if (result > 0)
            {
                return new SuccessResult();
            }
            return new ErrorResult();
        }
        private IDataResult<List<CarImage>> GetDefaultImage(int carId)
        {
            List<CarImage> carImages = new List<CarImage>();

            carImages.Add(new CarImage { CarId = carId, Date = DateTime.Now, ImagePath = "wwwroot\\images\\Default\\default.jpg}" });
            return new SuccessDataResult<List<CarImage>>(carImages);
        }
    }
}
