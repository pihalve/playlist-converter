using System;
using Pihalve.PlaylistConverter.Application.Domain;

namespace Pihalve.PlaylistConverter.Application.Services
{
    public class TrackConvertionEventArgs : EventArgs
    {
        public PlaylistItem ConvertedTrack { get; private set; }
        public PlaylistItem OriginalTrack { get; private set; }

        public TrackConvertionEventArgs(PlaylistItem convertedTrack, PlaylistItem originalTrack)
        {
            OriginalTrack = originalTrack;
            ConvertedTrack = convertedTrack;
        }
    }
}
