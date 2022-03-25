using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using CsvHelper;
using Presentation.Application.Common.Models.StructuralMetadata.Interfaces;

namespace Presentation.Application.Common.Utils
{
    public static class CSVRecordReader<C> where C : IRecordCsv
    {
        public static IEnumerable<C> Read(string csv) 
        {
            TextReader reader = new StringReader(csv);
            using (var csvReader = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                return csvReader.GetRecords<C>();
            }
        }

         public static IEnumerable<C> ReadLevel(string csv, int levelNumber) 
        {
            TextReader reader = new StringReader(csv);
            using (var csvReader = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                if(levelNumber > 0)
                {
                    return csvReader.GetRecords<C>().Where(r => r.LevelNumber == levelNumber);
                }
                else
                {
                    return Read(csv);
                }
            }
        }
    }
}
