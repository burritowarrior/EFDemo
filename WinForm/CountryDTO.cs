using System;

namespace WinForm
{
    public class CountryDTO
    {
        public int CountryId { get; set; }
        public string Country { get; set; }
        public DateTime LastUpdate { get; set; }
    }

    public class CountryOnlyDTO
    {
        public string Country { get; set; }
    }
}
