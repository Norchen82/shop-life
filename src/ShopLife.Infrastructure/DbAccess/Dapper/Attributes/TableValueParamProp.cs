namespace ShopLife.Infrastructure.DbAccess.Dapper.Attributes;

/// <summary>
/// Vo To DynamicParameters(使用者定義資料表類型)
/// </summary>
public class TableValueParamProp : AbstractDapperParamProp
{
    /// <summary>
    /// 參數名稱
    /// </summary>
    public string ParamName { get; } = null!;

    /// <summary>
    /// 使用者定義資料表類型名稱
    /// </summary>
    public string UserDefinedTypeName { get; } = null!;

    /// <summary>
    /// 建構子
    /// </summary>
    /// <param name="paramName">參數名稱</param>
    /// <param name="userDefinedTypeName">使用者定義資料表類型名稱</param>
    public TableValueParamProp(string paramName, string userDefinedTypeName)
    {
        this.ParamName = paramName;
        this.UserDefinedTypeName = userDefinedTypeName;
    }
}
