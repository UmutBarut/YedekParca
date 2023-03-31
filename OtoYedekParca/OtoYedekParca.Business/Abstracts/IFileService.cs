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
       Task<IResult> AddForMarka(IFormFile dosya, Marka marka);
       Task<IResult> AddForUrun(IFormFile dosya, Urun urun);
        Task<IResult> AddForModel(IFormFile dosya, Model model);
    }
}