﻿using BroadageSports.Data.Repository.Abstract;
using BroadageSports.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BroadageSports.Data.Repository.Concrete
{
    public class StageRepository:BaseRepository<Stage>,IStageRepository
    {
        public StageRepository(BroadageSportsContext broadageSportsContext):base(broadageSportsContext)
        {

        }
    }
}
