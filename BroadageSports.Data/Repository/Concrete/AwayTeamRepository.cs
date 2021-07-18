﻿using BroadageSports.Data.Repository.Abstract;
using BroadageSports.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BroadageSports.Data.Repository.Concrete
{
    public class AwayTeamRepository : BaseRepository<AwayTeam>, IAwayTeamRepository
    {
        public AwayTeamRepository(BroadageSportsContext broadageSportsContext) : base(broadageSportsContext)
        {
        }
    }
}
