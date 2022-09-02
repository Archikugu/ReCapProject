using Core.Utilities.Results;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Helpers
{
    public interface IFileHelper
    {
        IResult Upload(IFormFile fromFile, string root);
        IResult Delete(string filePath);
        IResult Update(IFormFile formFile, string filePath, string root);
    }
}
