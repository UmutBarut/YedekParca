using OtoYedekParca.Business.Abstracts;
using OtoYedekParca.Core.Utilities.Helpers.File;
using OtoYedekParca.Core.Utilities.Results;
using OtoYedekParca.Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OtoYedekParca.Business.Concrete
{
    public class FileManager : IFileService
    {
        private readonly IMarkaService _markaService;
        private readonly IUrunService _urunService;
        private readonly IFileHelper _fileHelper;

        public FileManager(IMarkaService markaService, IFileHelper fileHelper,IUrunService urunService)
        {
            _markaService = markaService;
            _fileHelper = fileHelper;
            _urunService = urunService;
        }

        public async Task<IResult> AddForMarka(IFormFile file,Marka marka)
        {
            if(!string.IsNullOrEmpty(marka.ImagePath))
            {
                _fileHelper.Remove(marka.ImagePath);
            }
            var imageresult = _fileHelper.Upload(file);
            if(!imageresult.Success)
            {
                return new ErrorResult("Resim Yüklenemedi...");
            }

            marka.ImagePath = imageresult.Message;
            _markaService.Update(marka);
            return new SuccessResult("Resim Yüklendi");
        }

        public async Task<IResult> AddForUrun(IFormFile file,Urun urun)
        {
            if(!string.IsNullOrEmpty(urun.ImagePath))
            {
                _fileHelper.Remove(urun.ImagePath);
            }
            var imageresult = _fileHelper.Upload(file);
            if(!imageresult.Success)
            {
                return new ErrorResult("Resim Yüklenemedi...");
            }

            urun.ImagePath = imageresult.Message;
            _urunService.Update(urun);
            return new SuccessResult("Resim Yüklendi");
        }
    }
}