using BroadagaSports.API.CronJob.CronJobConfig.Abstract;
using System;

namespace BroadagaSports.API.CronJob.CronJobConfig.Concrate
{
    public class ScheduleConfig<T> : IScheduleConfig<T>
    {
        public string CronExpression { get; set; }
        public TimeZoneInfo TimeZoneInfo { get; set; }
    }
}
