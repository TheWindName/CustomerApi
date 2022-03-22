using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TWN.CustomerApi.Entities.Country;
using TWN.CustomerApi.Infrastructure.Repository;

namespace TWN.CustomerApi.Service.Controllers
{
    /// <summary>
    /// Country Controller
    /// </summary>
    [ApiVersionNeutral]
    [ApiController]
    [Route("api/[controller]")]
    public class CountryController : ControllerBase
    {

        private readonly ICountryRepository _countryRepository;

        private readonly IMapper _mapper;

        /// <summary>
        /// Principal Constructor
        /// </summary>
        public CountryController(ICountryRepository countryRepository,
                                   IMapper mapper)
        {
            this._countryRepository = countryRepository;
            this._mapper = mapper;
        }

        /// <summary>
        /// Get Method which returns all Country Entities in DataBase.
        /// </summary>
        /// <returns>Action Result with CustomerEntity list</returns>
        [HttpGet]
        public ActionResult<List<CountryEntity>> GetAll()
        {
            var countrylist = this._countryRepository.GetAllCountry();

            var result = this._mapper.Map<List<CountryEntity>>(countrylist);

            return result;
        }

        /// <summary>
        /// Get Method which returns a concrete Country Entities in DataBase.
        /// </summary>
        /// <returns>Action Result with CustomerEntity</returns>
        [HttpGet("{countryId}")]
        public ActionResult<CountryEntity> GetById(int countryId)
        {
            var countryModel = this._countryRepository.GetCountryById(countryId);

            var result = this._mapper.Map<CountryEntity>(countryModel);

            return result;
        }

        /// <summary>
        /// Post Method which insert a new Country into DataBase.
        /// </summary>
        /// <param name="countryEntity">Country Entity Parameter</param>
        /// <returns>Country Entity stored in DataBase</returns>
        [HttpPost]
        public ActionResult<CountryEntity> Create(CountryEntity countryEntity)
        {
            var countryModel = this._countryRepository.AddCountry(countryEntity);

            var result = this._mapper.Map<CountryEntity>(countryModel);

            return result;
        }

        /// <summary>
        /// Put Method which update an already created stored Country into DataBase.
        /// </summary>
        /// <param name="countryId">CountryId of the Entity we want to modify</param>
        /// <param name="countryEntity">Country Entity Parameter</param>
        /// <returns>Customer Entity stored in DataBase with the changes</returns>
        [HttpPut("{countryId}")]
        public ActionResult<CountryEntity> Update(int countryId, CountryEntity countryEntity)
        {
            var result = new CountryEntity { CountryId = 1, CountryName = "Test Full Name" };

            return result;
        }

        /// <summary>
        /// Delete Method which insert an already created Country into DataBase.
        /// </summary>
        /// <param name="countryId">Country Entity Parameter</param>
        /// <returns>Customer Entity stored in DataBase</returns>
        [HttpDelete("{countryId}")]
        public async Task<IActionResult> Delete(int countryId)
        {
            var result = NoContent();

            return result;
        }
    }
}
