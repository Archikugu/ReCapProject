using Core.Utilities.Business;
using Core.Utilities.Results;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Helpers
{
    public class FileHelperManager : IFileHelper
    {

        public IResult Delete(string filePath)
        {
            //Böyle bir dosya var mı yok mu diye kontrol edildi.
            var result = CheckIfFileExists(filePath);
            if (!result.Success)
            {
                return result;
            }
            File.Delete(filePath);
            return new SuccessResult();
        }

        public IResult Update(IFormFile fromFile, string filePath, string root)
        {
            var resultOfDelete = Delete(filePath);
            if (!resultOfDelete.Success)
            {
                return resultOfDelete;
            }

            var resultOfUpload = Upload(fromFile, root);
            if (!resultOfUpload.Success)
            {
                return resultOfUpload;
            }

            return new SuccessResult(resultOfUpload.Message);
        }

        public IResult Upload(IFormFile fromFile, string root)
        {
            var result = BusinessRules.Run(CheckIfFileEnter(fromFile),
                CheckIfFileExtensionValid(Path.GetExtension(fromFile.FileName)));

            if (result != null)
            {
                return result;
            }

            //Guid ile benzersiz bir isim oluşturup dosyanın uzantısı ile birleştirilir.
            string fileName = Guid.NewGuid().ToString() + Path.GetExtension(fromFile.FileName);

            //Dosyayı koyacağımız klasör yolu var mı yok mu diye kontrol edilidi yok ise oluşturuldu
            CheckIfDirectoryExists(root);

            CreateFile(root + fileName, fromFile);

            return new SuccessResult(fileName);
        }


        //Business Code
        private IResult CheckIfFileExists(string filePath)
        {
            if (File.Exists(filePath))
            {
                return new SuccessResult();
            }
            return new ErrorResult("Böyle bir dosya mevcut değil");
        }

        private IResult CheckIfFileEnter(IFormFile fromFile)
        {
            if (fromFile.Length < 0)
            {
                return new ErrorResult("Dosya girilmemiş");
            }
            return new SuccessResult();
        }

        private IResult CheckIfFileExtensionValid(string extension)
        {
            if (extension == ".jpg" || extension == ".png" || extension == ".jpeg" || extension == ".webp")
            {
                return new SuccessResult();
            }
            return new ErrorResult("Dosya uzantısı geçerli değil");
        }

        private void CheckIfDirectoryExists(string root)
        {
            if (!Directory.Exists(root))
            {
                Directory.CreateDirectory(root);
            }
        }

        private void CreateFile(string directory, IFormFile fromFile)
        {
            //Yeni bir dosya oluşturulur ve eğer aynı isimde bir dosya bulunuyorsa üzerine yazılır.
            using (FileStream fileStream = File.Create(directory))
            {
                fromFile.CopyTo(fileStream); //Oluşturduğumuz dosyanın içine resmi kopyaladık.
                fileStream.Flush(); //Tampondaki bilgilerin boşaltılmasını ve stream dosyasının güncellenmesini sağlar.
            }
        }


    }
}
