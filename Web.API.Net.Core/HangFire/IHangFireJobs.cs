namespace Api.HangFire
{
    public interface IHangFireJobs
    {
        Task DisableAbsentUsers();
    }
}
