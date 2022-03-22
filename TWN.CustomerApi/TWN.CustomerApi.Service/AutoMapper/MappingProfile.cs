using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TWN.CustomerApi.Entities.Country;
using TWN.CustomerApi.Infrastructure.Models;

namespace TWN.CustomerApi.Service.AutoMapper
{
    /// <summary>
    /// Class MappingProfile which allows us to map models to another differents models
    /// </summary>
    public class MappingProfile : Profile
    {
        /// <summary>
        /// Mapping Profile Constructor
        /// </summary>
        public MappingProfile()
        {
            CreateMap<Country, CountryEntity>();
            CreateMap<CountryEntity, Country>();
            CreateMap<Country, List<CountryEntity>>();
        }
    }
}
