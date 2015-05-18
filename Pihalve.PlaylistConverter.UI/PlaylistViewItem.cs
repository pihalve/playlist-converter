using System.Globalization;
using System.Windows.Forms;
using Pihalve.PlaylistConverter.Application.Domain;

namespace Pihalve.PlaylistConverter.UI
{
    public class PlaylistViewItem : ListViewItem
    {
        public PlaylistViewItem(PlaylistItem playlistItem)
        {
            SubItems.Add(new ListViewSubItem { Name = "Artist" });
            SubItems.Add(new ListViewSubItem { Name = "Track" });
            SubItems.Add(new ListViewSubItem { Name = "Album" });
            SubItems.Add(new ListViewSubItem { Name = "Year" });

            SubItems.Add(new ListViewSubItem { Name = "ArtistDst" });
            SubItems.Add(new ListViewSubItem { Name = "TrackDst" });
            SubItems.Add(new ListViewSubItem { Name = "AlbumDst" });
            SubItems.Add(new ListViewSubItem { Name = "YearDst" });

            Name = playlistItem.Id;
            ImageIndex = 0;
            SubItems["Artist"].Text = playlistItem.Artist.Name;
            SubItems["Track"].Text = playlistItem.Track.Name;
            SubItems["Album"].Text = playlistItem.Album.Name;
            SubItems["Year"].Text = GetYear(playlistItem.Album.Year);
        }

        public string ArtistDst
        {
            set { SubItems["ArtistDst"].Text = value; }
        }

        public string TrackDst
        {
            set { SubItems["TrackDst"].Text = value; }
        }

        public string AlbumDst
        {
            set { SubItems["AlbumDst"].Text = value; }
        }

        public int? YearDst
        {
            set { SubItems["YearDst"].Text = GetYear(value); }
        }

        private static string GetYear(int? year)
        {
            return year.HasValue ? year.Value.ToString(CultureInfo.InvariantCulture) : string.Empty;
        }
    }
}
