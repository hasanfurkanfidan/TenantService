using Core.Utilities.Results;

namespace Core.Utilities.Business
{
    #region Static Methods
    public static IResult Run(params IResult[] logics)
    {
        foreach (var result in logics)
        {
            if (!result.Success)
                return result;
        }

        return null;
    }
    #endregion
}
