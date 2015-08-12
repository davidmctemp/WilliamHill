using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WilliamHill.Data.Models;

namespace WilliamHill.ReaderService.Mapping
{
    public static class AutoMapper
    {
        public static void CreateMappings()
        {
            Mapper.CreateMap<UnSettled, BetItem>();
            Mapper.CreateMap<Settled, BetItem>();

            Mapper.CreateMap<BetItem, Settled>();
            Mapper.CreateMap<BetItem, UnSettled>();
        }
    }
}
