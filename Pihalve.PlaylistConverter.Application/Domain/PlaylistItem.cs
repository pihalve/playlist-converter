using System;
using System.Collections.Generic;
using System.Linq;

namespace Pihalve.PlaylistConverter.Application.Domain
{
    public class PlaylistItem : ICloneable
    {
        public PlaylistItem(string id, Artist artist, Album album, Track track, string uri)
        {
            Id = id;
            Artist = artist;
            Album = album;
            Track = track;
            Uri = uri;
        }

        public string Id { get; set; }
        public Artist Artist { get; set; }
        public Track Track { get; set; }
        public Album Album { get; set; }
        public string Uri { get; set; }

        public static PlaylistItem Create(string id, string artist, string album, int? year, string trackName, IEnumerable<string> countryCodes, string uri)
        {
            var countries = new HashSet<Country>();
            if (countryCodes != null)
            {
                foreach (string countryCode in countryCodes)
                {
                    Country country = Country.Countries.SingleOrDefault(x => x.TwoLetterIsoLanguageName == countryCode);
                    countries.Add(new Country(countryCode, country != null ? country.Name : null));
                }
            }

            return new PlaylistItem(id, new Artist(artist), new Album(album, year, countries), new Track(trackName), uri);
        }

        public override string ToString()
        {
            return string.Format("{0}, {1}, {2}, {3}, {4}", Id, Artist, Track, Album, Uri);
        }

        public object Clone()
        {
            return new PlaylistItem(Id, (Artist)Artist.Clone(), (Album)Album.Clone(), (Track)Track.Clone(), Uri);
        }
    }
}
