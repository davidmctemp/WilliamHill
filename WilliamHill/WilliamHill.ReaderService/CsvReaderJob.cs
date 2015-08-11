using Quartz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WilliamHill.ReaderService
{
    public class CsvReaderJob : IJob
    {
        public CsvReaderJob()
        {
        }

        public void Execute(IJobExecutionContext context)
        {
            try
            {
                // read csv values
                Console.WriteLine("readong....");
            }
            catch (Exception ex)
            {
                
            }
        }       
    }
}