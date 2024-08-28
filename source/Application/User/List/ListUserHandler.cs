using static System.Net.HttpStatusCode;

namespace Architecture.Application;

public sealed record ListUserHandler(IUserRepository userRepository) : IHandler<ListUserRequest, IEnumerable<UserModel>>
{
    public async Task<Result<IEnumerable<UserModel>>> HandleAsync(ListUserRequest request)
    {
        var users = await userRepository.ListModelAsync();

        return new Result<IEnumerable<UserModel>>(users is null ? NotFound : OK, users);
    }
}
