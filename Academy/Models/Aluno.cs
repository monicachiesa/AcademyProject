namespace Academy.Models;

public class Aluno
{
    public long Id { get; set; }
    public string? Nome { get; set; }
    public bool IsComplete { get; set; }
    public string? DataExclusao { get; set; }
}