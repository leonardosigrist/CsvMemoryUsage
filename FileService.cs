using System.Collections.Generic;
using System.Globalization;
using System.IO;
using CsvHelper;

namespace MemorySizer
{
    public class FileService
    {
        public void CreateNewCsv()
        {
            var totalFiles = 1_500_000;
            var paList = new List<PreApprovedLimit>(totalFiles);

            for (var i = 0; i < totalFiles; i++)
            {
                paList.Add(new PreApprovedLimit
                {
                    CpfCnpj = "39055903876",
                    PaLimit = 3000
                });
            }

            using (var writer = new StreamWriter("files/pa-file.csv"))
            using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
            {
                csv.WriteRecords(paList);
            }
        }

        public IEnumerable<PreApprovedLimit> GetCsvCollection()
        {
            using (var reader = new StreamReader("files/pa-file.csv"))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                csv.Read();
                csv.ReadHeader();
                while (csv.Read())
                {
                    yield return csv.GetRecord<PreApprovedLimit>();
                }
            }
        }
    }
}