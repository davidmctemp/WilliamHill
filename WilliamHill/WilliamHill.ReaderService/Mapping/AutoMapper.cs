using AutoMapper;
using WilliamHill.Data.Models;
using WilliamHill.FileParser;

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
