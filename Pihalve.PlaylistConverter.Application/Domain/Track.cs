using System;

namespace Pihalve.PlaylistConverter.Application.Domain
{
    public class Track : ICloneable
    {
        public Track(string name)
        {
            Name = name;
        }

        public string Name { get; set; }

        public override string ToString()
        {
            return string.Format("{0}", Name);
        }

        public object Clone()
        {
            return new Track(Name);
        }
    }
}
