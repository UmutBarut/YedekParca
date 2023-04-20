using OtoYedekParca.Core.Utilities.Results;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OtoYedekParca.Core.Utilities.Helpers.File
{
    public interface IFileHelper
    {
        void RemoveOldFile(string directory);
        void CreateFile(string directory, IFormFile file);
        void CheckDirectoryExist(string directory);
        Results.IResult CheckFileTypeValid(string type);
        Results.IResult CheckFileExist(IFormFile file);
        Results.IResult Upload(IFormFile file,string folderName);
        Results.IResult Update(IFormFile file, string imagePath,string folderName);
        Results.IResult Remove(string path,string folderName);
    }
}
