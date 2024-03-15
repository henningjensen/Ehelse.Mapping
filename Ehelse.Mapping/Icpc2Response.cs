namespace Ehelse.Mapping;

public class Icpc2Response
{
    public List<Icpc2Mapping> Data { get; set; } = new List<Icpc2Mapping>();
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
    public int TotalPages { get; set; }
    public int TotalRecords { get; set; }
}

public class Icpc2Mapping
{
    public string ConceptId { get; set; }
    public string Fsn { get; set; }
    public Term TermNorwegianSCT { get; set; }
    public Term TermEnglishSCT { get; set; }
    public bool Released { get; set; }
    public string ReleasedEffectiveTime { get; set; }
    public string Icpc2Code { get; set; }
    public string Icpc2Term { get; set; }
    public string MapGroup { get; set; }
    public string MapPriority { get; set; }
}

public class Term
{
    public string Value { get; set; }
    public string CaseSignificance { get; set; }
}