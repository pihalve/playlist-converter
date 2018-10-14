using System;
using System.Collections.Generic;
using Pihalve.PlaylistConverter.Application.Domain;
using Pihalve.PlaylistConverter.Application.Domain.Rules;

namespace Pihalve.PlaylistConverter.Application.Services
{
    public interface ITrackConverter
    {
        event EventHandler<TrackConvertionEventArgs> TrackConvertedEvent;
        event EventHandler TracksConvertedEvent;
        void ConvertAsync(IEnumerable<PlaylistItem> playlistItems, HashSet<BaseRule> rules, List<FallbackItem> fallbackSequence);
    }
}
