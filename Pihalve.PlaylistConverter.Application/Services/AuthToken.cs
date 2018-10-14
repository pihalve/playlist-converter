namespace Pihalve.PlaylistConverter.Application.Services
{
    public abstract class AuthToken
    {
        public virtual string Scheme { get; protected set; }
        public virtual string Credentials { get; protected set; }
    }
}
