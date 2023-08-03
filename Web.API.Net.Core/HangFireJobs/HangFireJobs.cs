using Services.Admin;

namespace Api.HangFireJobs
{
    public class HangFireJobs : IHangFireJobs
    {
        private readonly IUserService _userService;
        public HangFireJobs(IUserService userService)
        {
            _userService = userService;
        }

        public async Task DisableAbsentUsers()
        {
            await _userService.DisableAbsentUsers();
        }
    }
}
