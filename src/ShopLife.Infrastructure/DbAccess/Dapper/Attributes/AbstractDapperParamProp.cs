namespace ShopLife.Infrastructure.DbAccess.Dapper.Attributes;

/// <summary>
/// Vo To DynamicParameters 基底
/// </summary>
[AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
public abstract class AbstractDapperParamProp : Attribute
{
}
