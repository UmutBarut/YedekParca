using OtoYedekParca.Core.Utilities.Results;
using OtoYedekParca.Entity;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace OtoYedekParca.Business.Abstracts
{
    public interface IFileService
    {
        Task<OtoYedekParca.Core.Utilities.Results.IResult> Add(IFormFile file, User user);
       Task<OtoYedekParca.Core.Utilities.Results.IResult> AddForMarka(IFormFile dosya, Marka marka);
       Task<OtoYedekParca.Core.Utilities.Results.IResult> AddForUrun(IFormFile dosya, Urun urun);
        Task<OtoYedekParca.Core.Utilities.Results.IResult> AddForModel(IFormFile dosya, Model model);
    }
}