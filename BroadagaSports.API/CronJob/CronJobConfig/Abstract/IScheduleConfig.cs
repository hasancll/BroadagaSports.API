using System;

namespace BroadagaSports.API.CronJob.CronJobConfig.Abstract
{
    public interface IScheduleConfig<T>
    {
        string CronExpression { get; set; }
        TimeZoneInfo TimeZoneInfo { get; set; }
    }
}
