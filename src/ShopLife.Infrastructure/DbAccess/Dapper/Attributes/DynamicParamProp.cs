using System.Data;

namespace ShopLife.Infrastructure.DbAccess.Dapper.Attributes;

/// <summary>
/// Vo To DynamicParameters
/// </summary>
public class DynamicParamProp : AbstractDapperParamProp
{
    /// <summary>
    /// 參數名稱
    /// </summary>
    public string ParamName { get; } = null!;

    /// <summary>
    /// 參數於Db的Type
    /// </summary>
    public DbType? DbType { get; }

    /// <summary>
    /// 實作的方法(Input/Output/Return)
    /// </summary>
    public ParameterDirection ParamDirection { get; }

    /// <summary>
    /// 參數長度
    /// </summary>
    public int? Length { get; }

    /// <summary>
    /// 建構子
    /// </summary>
    /// <param name="paramName">參數名稱</param>
    /// <param name="dbType">參數於Db的Type</param>
    /// <param name="paramDirection">實作的方法(Input/Output/Return)</param>
    /// <param name="length">參數長度</param>
    public DynamicParamProp(string paramName, DbType? dbType, ParameterDirection paramDirection = ParameterDirection.Input, int length = 0)
    {
        this.ParamName = paramName;
        this.DbType = dbType;
        this.ParamDirection = paramDirection;
        this.Length = length;
    }
}
