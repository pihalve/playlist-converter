using System;
using System.Collections.Generic;
using System.Linq;

namespace Pihalve.PlaylistConverter.Application.Domain
{
    public class Album : ICloneable
    {
        private IEnumerable<Country> _countries;

        public Album(string name, int? year, IEnumerable<Country> countries)
        {
            Name = name;
            Year = year;
            Countries = countries;
        }

        public string Name { get; set; }
        public int? Year { get; set; }
        public IEnumerable<Country> Countries
        {
            get { return _countries ?? (_countries = new HashSet<Country>()); }
            set { _countries = value; }
        }

        public override string ToString()
        {
            return string.Format("{0}, {1}, [{2}]", Name, Year, string.Join(", ", Countries));
        }

        public object Clone()
        {
            return new Album(Name, Year, Countries.Select(x => (Country)x.Clone()));
        }
    }
}
