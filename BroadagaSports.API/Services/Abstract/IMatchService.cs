using BroadagaSports.API.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BroadagaSports.API.Services.Abstract
{
    public interface IMatchService
    {
        Task<MatchDTO> AddMatchAsync(MatchDTO matchDTO);
        Task<List<MatchDTO>> AddRangeMatchAsync(List<MatchDTO> matchDTOs);
        Task<List<MatchDTO>> GetAllMatchAsync();
        Task<MatchDTO> GetByIdProductAsync(int matchId);
        Task<MatchDTO> UpdateMatchAsync(MatchDTO matchDTO);
        Task<List<MatchDTO>> UpdateRangeMatchAsync(List<MatchDTO> matchDTOs);
    }
}
