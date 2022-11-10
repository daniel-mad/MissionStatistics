using AutoMapper;
using MissionStatistics.Application.Models;
using MissionStatistics.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MissionStatistics.Application.Profiles
{
    public class MissionProfile : Profile
    {
        public MissionProfile()
        {
            CreateMap<CreateMissionDto, Mission>();
            CreateMap<Mission, MissionDto>();
        }
    }
}
