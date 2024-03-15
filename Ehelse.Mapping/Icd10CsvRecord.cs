namespace Ehelse.Mapping;

public class Icd10CsvRecord
{
    public string ConceptId { get; set; }
    public string Fsn { get; set; }
    public string? PreferredTermNorwegian { get; set; }
    public string? PreferredTermEnglish { get; set; }
    public string Icd10Code { get; set; }
    public string Icd10Term { get; set; }

    public static List<Icd10CsvRecord> CreateRecords(List<Icd10Concept> data)
    {
        var list = new List<Icd10CsvRecord>();
        foreach (var item in data)
        {
            list.AddRange(CreateRecords(item));
        }
        return list;
    }

    private static List<Icd10CsvRecord> CreateRecords(Icd10Concept item)
    {
        var list = new List<Icd10CsvRecord>();
        foreach (var mapping in item.Mapping)
        {
            list.Add(new Icd10CsvRecord()
            {
                ConceptId = item.ConceptId,
                Fsn = item.Fsn,
                PreferredTermNorwegian = item.TermNorwegianSCT?.Value,
                PreferredTermEnglish = item.TermEnglishSCT?.Value,
                Icd10Code = mapping.Icd10Code,
                Icd10Term = mapping.Icd10Term
            });
        }
        return list;
    }
}