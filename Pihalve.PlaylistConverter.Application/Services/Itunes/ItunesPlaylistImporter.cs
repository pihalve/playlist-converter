using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using Pihalve.PlaylistConverter.Application.Domain;
using Pihalve.PlaylistConverter.Application.Exceptions;

namespace Pihalve.PlaylistConverter.Application.Services.Itunes
{
    public class ItunesPlaylistImporter : IPlaylistImporter
    {
        public IEnumerable<PlaylistItem> Import(string filePath)
        {
            var playlist = new List<PlaylistItem>();

            var playlistDoc = XDocument.Load(filePath);
            IEnumerable<XElement> tracks = ReadTrackElements(playlistDoc);
            foreach (XElement track in tracks)
            {
                var id = GetValue<string>("Track ID", track);
                var trackName = GetValue<string>("Name", track);
                var artist = GetValue<string>("Artist", track);
                var album = GetValue<string>("Album", track);
                var year = GetValue<int?>("Year", track);

                playlist.Add(PlaylistItem.Create(id, artist, album, year, trackName, null, null));
            }

            return playlist;
        }

        private static IEnumerable<XElement> ReadTrackElements(XDocument playlistDocument)
        {
            try
            {
                return playlistDocument
                    .Descendants("plist")
                        .Descendants("dict")
                            .Descendants("key").First(x => x.Value == "Tracks")
                            .ElementsAfterSelf("dict").First()
                                .Descendants("dict");
            }
            catch
            {
                throw new InvalidPlaylistFormatException("iTunes");
            }
        }

        private static T GetValue<T>(string name, XElement trackElement)
        {
            var trackChildElement = trackElement.Descendants("key").SingleOrDefault(x => x.Value == name);
            if (trackChildElement != null)
            {
                string value = trackChildElement.ElementsAfterSelf().First().Value;
                if (!string.IsNullOrEmpty(value))
                {
                    Type targetType = typeof(T);
                    Type nullableType = Nullable.GetUnderlyingType(targetType);
                    if (nullableType != null)
                    {
                        targetType = nullableType;
                    }
                    return (T)Convert.ChangeType(value, targetType);
                }
            }
            return default(T);
        }
    }
}