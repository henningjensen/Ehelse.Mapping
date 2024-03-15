namespace Ehelse.Mapping;

public class Icd10Response
{
    public List<Icd10Concept> Data { get; set; } = new List<Icd10Concept>();
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
    public int TotalPages { get; set; }
    public int TotalRecords { get; set; }
}

public class Icd10Concept
{
    public string ConceptId { get; set; }
    public string Fsn { get; set; }
    public Term? TermNorwegianSCT { get; set; }
    public Term? TermEnglishSCT { get; set; }
    public bool Released { get; set; }
    public string ReleasedEffectiveTime { get; set; }
    public List<Icd10Mapping> Mapping { get; set; } = new List<Icd10Mapping>();
}

public class Icd10Mapping
{
    public string Icd10Code { get; set; }
    public string Icd10Term { get; set; }
}