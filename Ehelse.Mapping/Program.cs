using System.Diagnostics;
using System.Globalization;
using CsvHelper;
using Ehelse.Mapping;
using Flurl;
using Flurl.Http;

Console.WriteLine("Fetching data from Norwegian Directorate of e-health");
Console.WriteLine("Download SNOMED CT concepts mapped to ICD-10");

using (var stream = File.Open("ehelse-icd10.csv", FileMode.Append))
using (var writer = new StreamWriter(stream))
using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
{
    csv.WriteHeader<Icd10CsvRecord>();
    csv.NextRecord();

    int pageNumber = 1;
    int totalPages = 3;
    do
    {
        Console.WriteLine($"Running request for page number {pageNumber}");

        Stopwatch stopwatch = new Stopwatch();
        stopwatch.Start();
        Icd10Response response = await "https://fat.terminologi.ehelse.no/api/diagnosis/hp/icd10"
            .SetQueryParam("customerCode", "hp")
            .SetQueryParam("pageSize", "100")
            .SetQueryParam("pageNumber", pageNumber)
            .GetJsonAsync<Icd10Response>();
        stopwatch.Stop();

        Console.WriteLine($"Request time: {stopwatch.ElapsedMilliseconds} ms");
        Console.WriteLine($"{response.Data.Count} items in response");
        Console.WriteLine(
            $"Page: {response.PageNumber} of {response.TotalPages} (page size: {response.PageSize}) with total of {response.TotalRecords} records.");

        totalPages = response.TotalPages;
        pageNumber++;

        List<Icd10CsvRecord> records = Icd10CsvRecord.CreateRecords(response.Data);
        
        csv.WriteRecords(records);
        csv.Flush();

    } while (pageNumber <= totalPages);
}
