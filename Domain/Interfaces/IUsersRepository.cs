namespace Domain.Interfaces
{
    public interface IUsersRepository
    {
        Models.Users.User Get(string identityName);
    }
}
