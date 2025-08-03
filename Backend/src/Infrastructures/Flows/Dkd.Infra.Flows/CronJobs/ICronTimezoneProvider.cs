namespace Dkd.Infra.Flows.CronJobs;

public interface ICronTimezoneProvider
{
    bool TryParse(string id, [MaybeNullWhen(false)] out TimeZoneInfo timezone);

    IReadOnlyList<string> GetAvailableIds();
}
