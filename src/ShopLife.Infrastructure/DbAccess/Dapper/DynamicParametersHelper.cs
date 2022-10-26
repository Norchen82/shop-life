using Dapper;
using ShopLife.Infrastructure.DbAccess.Dapper.Attributes;
using ShopLife.Infrastructure.DbAccess.Dapper.Factory;
using System.Reflection;

namespace ShopLife.Infrastructure.DbAccess.Dapper;

/// <summary>
/// Class轉型DynamicParameters
/// </summary>
internal class DynamicParametersHelper
{
    /// <summary>
    /// Vo To DynamicParameters
    /// </summary>
    internal static DynamicParameters GetDynamicParams<T>(T vo)
    {
        DynamicParameters parameters = new();
        IEnumerable<PropertyInfo> props = vo.GetType()
                                            .GetProperties()
                                            .Where(x => x.GetCustomAttributes<AbstractDapperParamProp>().Any());
        parameters = SetProp<T>(props, vo);
        return parameters;
    }

    /// <summary>
    /// 設定Prop於DynamicParameters中
    /// </summary>
    private static DynamicParameters SetProp<T>(IEnumerable<PropertyInfo> props, T vo)
    {
        DynamicParametersFactory parametersFactory = new();
        foreach (PropertyInfo prop in props)
        {
            object valueParameter = prop.GetValue(vo);
            parametersFactory.Add(prop, valueParameter);
        }
        return parametersFactory.Parameters;
    }
}
