namespace SAR_API.Repositories;

public interface IUserRepository
{
    public Task<string> FindUserIdByEmail(string userEmail);
}