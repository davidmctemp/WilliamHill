using Quartz;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WilliamHill.ReaderService.Interfaces;

namespace WilliamHill.ReaderService
{
    public class CsvReaderJob : IJob
    {
        private readonly IFileReader _fileReader;

        public CsvReaderJob(IFileReader fileReader)
        {
            _fileReader = fileReader;
        }

        public void Execute(IJobExecutionContext context)
        {
            try
            {
                var csvFileDirectory = ConfigurationManager.AppSettings["CsvFileLocation"];
                if (csvFileDirectory == null)
                    throw new Exception("Csv File path has not been set in app.config");

                var unSettled = _fileReader.LoadAll(string.Concat(csvFileDirectory, "Unsettled.csv"));

                var settled = _fileReader.LoadAll(string.Concat(csvFileDirectory, "Settled.csv"));



                _fileReader.GetBetItem("");
                // if file exists. else - return.
                // parse all records. 
                // save to database. 
                // move file, or rename.
                Console.WriteLine("reading....");
            }
            catch (Exception ex)
            {
                
            }
        }       
    }
}