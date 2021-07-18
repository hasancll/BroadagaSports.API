using BroadagaSports.API.CronJob.CronJobConfig.Abstract;
using BroadagaSports.API.Helper;
using BroadagaSports.API.Logging.Abstract;
using BroadagaSports.API.Services.Abstract;
using BroadageSports.Data.Repository.Abstract;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace BroadagaSports.API.CronJob
{
    public class CronJobForIIS : CronJobService
    {
        private readonly IMatchRepository _matchRepository;
        private readonly IMatchService _matchService;

        public CronJobForIIS(IScheduleConfig<CronJobForIIS> config, IApplicationBuilder applicationBuilder) : base(config.CronExpression, config.TimeZoneInfo)
        {
            _matchRepository = applicationBuilder.ApplicationServices.CreateScope().ServiceProvider.GetRequiredService<IMatchRepository>();
            _matchService = applicationBuilder.ApplicationServices.CreateScope().ServiceProvider.GetRequiredService<IMatchService>();

        }

        public override Task StartAsync(CancellationToken cancellationToken)
        {
            return base.StartAsync(cancellationToken);
        }

        public override async Task DoWork(CancellationToken cancellationToken)
        {
            var dateControl = DateTime.Now.Date;
            var date = dateControl.Day + "/" + dateControl.Month + "/" + dateControl.Year;

            var request = RequestHelper.HttpRequestMessage(HttpMethod.Get, "https://s0-sports-data-api.broadage.com/soccer/match/list?date=" + date);
            var response = RequestHelper.GetHttpResponseSingleAsync<List<DTOs.MatchDTO>>(request).GetAwaiter().GetResult();

            var matches = await _matchRepository.GetAllAsync(p => p.Date.Date == Convert.ToDateTime(date).Date).ConfigureAwait(false);

            var isAdded = !matches.IsNullOrEmpty();

            
            if (isAdded)
            {
                await _matchService.UpdateRangeMatchAsync(response);
            }
            
            else
            {
                await _matchService.AddRangeMatchAsync(response);
            }



        }

        public override Task StopAsync(CancellationToken cancellationToken)
        {
            return base.StopAsync(cancellationToken);
        }
    }
}
