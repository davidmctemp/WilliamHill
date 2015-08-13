using AutoMapper;
using Quartz;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WilliamHill.Data.Models;
using WilliamHill.Data.Repository;
using WilliamHill.FileParser;

namespace WilliamHill.ReaderService
{
    public class CsvReaderJob : IJob
    {
        private readonly IFileReader _fileReader;
        private readonly ISettledRepository _settledRepository;
        private readonly IUnSettledRepository _unSettledRepository;

        public CsvReaderJob(IFileReader fileReader, ISettledRepository settledRepository, IUnSettledRepository unSettledRepository)
        {
            _fileReader = fileReader;
            _settledRepository = settledRepository;
            _unSettledRepository = unSettledRepository;
        }

        public void Execute(IJobExecutionContext context)
        {
            Console.WriteLine("\n-----------------------------------------------------------------------------\n");
            try
            {
                var csvFileDirectory = ConfigurationManager.AppSettings["CsvFileLocation"];
                if (csvFileDirectory == null)
                {
                    Console.WriteLine("Csv File path has not been set in app.config");
                    return;
                }

                ProcessUnSettledBets(csvFileDirectory);

                ProcessSettledBets(csvFileDirectory);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.WriteLine("\n-----------------------------------------------------------------------------\n");
        }

        private void ProcessSettledBets(string csvFileDirectory)
        {
            var fileName = string.Concat(csvFileDirectory, "Settled.csv");
            if (File.Exists(fileName))
            {
                var settled = _fileReader.LoadAll(fileName);

                Console.WriteLine("Loaded {0} Settled bets from CSV", settled.Count);

                settled.ForEach(a => _settledRepository.Add(Mapper.Map<Settled>(a)));

                _settledRepository.Save();

                File.Delete(fileName);
            }
            else
                Console.WriteLine("No Settled files exist");
        }

        private void ProcessUnSettledBets(string csvFileDirectory)
        {
            var fileName = string.Concat(csvFileDirectory, "Unsettled.csv");
            if (File.Exists(fileName))
            {
                var unSettled = _fileReader.LoadAll(fileName);
                Console.WriteLine("Loaded {0} UnSettled bets from CSV", unSettled.Count);
                unSettled.ForEach(a => _unSettledRepository.Add(Mapper.Map<UnSettled>(a)));

                _unSettledRepository.Save();

                File.Delete(fileName);
            }
            else
                Console.WriteLine("No Unsettled files exist");
        }
    }
}