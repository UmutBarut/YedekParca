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
        private readonly IModelService _modelService;
        private readonly UserManager<User> _userManager;

        public FileManager(IMarkaService markaService, IFileHelper fileHelper,IUrunService urunService, IModelService modelService,UserManager<User> userManager)
        {
            _markaService = markaService;
            _fileHelper = fileHelper;
            _urunService = urunService;
            _modelService = modelService;
            _userManager = userManager;
        }

        public async Task<OtoYedekParca.Core.Utilities.Results.IResult> Add(IFormFile file, User user)
        {
            string folderName = "avatars";
            if (!string.IsNullOrEmpty(user.ImagePath))
            {
                _fileHelper.Remove(user.ImagePath,folderName);
            }
            var imageResult = _fileHelper.Upload(file,folderName);
            if (!imageResult.Success)
            {
                return new ErrorResult("Resim Yüklenemedi.");
            }

            user.ImagePath = imageResult.Message;
            await _userManager.UpdateAsync(user);
            return new SuccessResult("Resim Başarıyla Yüklendi");
        }

        public async Task<OtoYedekParca.Core.Utilities.Results.IResult> AddForUrun(IFormFile file, Urun urun)
        {
            string folderName ="urunler";
             if (!string.IsNullOrEmpty(urun.ImagePath))
            {
                _fileHelper.Remove(urun.ImagePath,folderName);
            }
            var imageResult = _fileHelper.Upload(file,folderName);
            if (!imageResult.Success)
            {
                return new ErrorResult("Resim Yüklenemedi.");
            }

            urun.ImagePath = imageResult.Message;
            _urunService.Update(urun);
            return new SuccessResult("Resim Başarıyla Yüklendi");
        }

        public async Task<OtoYedekParca.Core.Utilities.Results.IResult> AddForMarka(IFormFile file,Marka marka)
        {
           string folderName ="markalar";
             if (!string.IsNullOrEmpty(marka.ImagePath))
            {
                _fileHelper.Remove(marka.ImagePath,folderName);
            }
            var imageResult = _fileHelper.Upload(file,folderName);
            if (!imageResult.Success)
            {
                return new ErrorResult("Resim Yüklenemedi.");
            }

            marka.ImagePath = imageResult.Message;
            _markaService.Update(marka);
            return new SuccessResult("Resim Başarıyla Yüklendi");
        }

        public async Task<OtoYedekParca.Core.Utilities.Results.IResult> AddForModel(IFormFile file,Model model)
        {
            string folderName ="modeller";
             if (!string.IsNullOrEmpty(model.ImagePath))
            {
                _fileHelper.Remove(model.ImagePath,folderName);
            }
            var imageResult = _fileHelper.Upload(file,folderName);
            if (!imageResult.Success)
            {
                return new ErrorResult("Resim Yüklenemedi.");
            }

            model.ImagePath = imageResult.Message;
            _modelService.Update(model);
            return new SuccessResult("Resim Başarıyla Yüklendi");
        }
    }
}