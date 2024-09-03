namespace WebAPI;

public abstract class BaseParameter
{
    public int Page { get; set; } = 1;
    public int PageSize { get; set; } = 10;

    public string? Filter { get; set; }
    public string? Sort { get; set; }

}
