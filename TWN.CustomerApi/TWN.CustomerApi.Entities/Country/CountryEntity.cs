using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace TWN.CustomerApi.Entities.Country
{
    /// <summary>
    /// Class CountryEntity
    /// </summary>
    public class CountryEntity
    {
        public int CountryId { get; set; }

        public string CountryName { get; set; }
    }
}
