namespace Samole.Model.Framework;

public class AplicationServiceResponse
{
    private readonly List<string> _errors = new();
    public bool IsSuccess => !Failur;
    public bool Failur => _errors.Any();

    public void AddError(string errorMessage)
    {
        _errors.Add(errorMessage);
    }

    public IReadOnlyList<string> Errors => _errors;
}

public class AplicationServiceResponse<TResult> : AplicationServiceResponse
{
    public TResult Result { get; set; }
}