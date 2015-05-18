using System.Collections.Generic;
using Pihalve.PlaylistConverter.Application.Domain;

namespace Pihalve.PlaylistConverter.Application.Services
{
    public interface IPlaylistImporter
    {
        IEnumerable<PlaylistItem> Import(string filePath);
    }
}
