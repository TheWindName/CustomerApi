using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TWN.CustomerApi.Entities.Country;
using TWN.CustomerApi.Infrastructure.Models;
using TWN.CustomerApi.Infrastructure.ObjectDataContext;

namespace TWN.CustomerApi.Infrastructure.Repository
{
    /// <summary>
    /// Class Country Repository to access to DB
    /// </summary>
    public class CountryRepository : ICountryRepository
    {

        private readonly TestDb _contextDb;

        private readonly IMapper _mapper;

        #region Constructors
        public CountryRepository(IMapper mapper, TestDb contextDb)
        {
            this._mapper = mapper;
            this._contextDb = contextDb;
        }
        #endregion Constructors


        #region Public Methods

        /// <summary>
        /// Get a Country by CountryId
        /// </summary>
        /// <param name="country">Country Parameter which allows us search into DataBase</param>
        /// <returns></returns>
        public Country GetCountryById(int countryId)
        {
            Country result = _contextDb.Country.Where(c => c.CountryId == countryId).FirstOrDefault();

            return result;
        }

        /// <summary>
        /// Get All Countries stored into DataBase
        /// </summary>
        /// <returns></returns>
        public List<Country> GetAllCountry()
        {
            List<Country> result = _contextDb.Country.Select(x => x).ToList();

            return result;
        }

        /// <summary>
        /// Method to Insert a new Country
        /// </summary>
        /// <param name="country">New Country to insert into DataBase</param>
        public Country AddCountry(CountryEntity country)
        {
            Country result;
            try
            {
                result = _mapper.Map<Country>(country);

                _contextDb.Country.Add(new Country { CountryName = result.CountryName });

                _contextDb.SaveChanges();
            }
            catch (Exception ex)
            {
                result = new Country { CountryId = 0, CountryName = "" };
            }

            return result;
            
        }

        #endregion Public Methods
    }
}
