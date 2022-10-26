using Dapper;
using ShopLife.Infrastructure.DbAccess.Dapper.Attributes;
using System.Data;
using System.Reflection;

namespace ShopLife.Infrastructure.DbAccess.Dapper.Factory;

/// <summary>
/// DynamicParameters工廠
/// </summary>
internal class DynamicParametersFactory
{
    /// <summary>
    /// A bag of parameters that can be passed to the Dapper Query and Execute methods
    /// </summary>
    internal DynamicParameters Parameters { get; private set; } = null!;

    /// <summary>
    /// 建構子
    /// </summary>
    internal DynamicParametersFactory()
    {
        this.Parameters = new DynamicParameters();
    }

    /// <summary>
    /// Add a parameter to this dynamic parameters list.
    /// </summary>
    /// <param name="prop">The name of the parameter.</param>
    /// <param name="valueParameter">The value of the parameter.</param>
    /// <exception cref="AggregateException"></exception>
    internal void Add(PropertyInfo prop, object valueParameter)
    {
        TableValueParamProp? tvpAttr = prop.GetCustomAttribute<TableValueParamProp>();
        if (tvpAttr != null && typeof(IEnumerable<object>).IsAssignableFrom(prop.PropertyType))
        {
            IEnumerable<object> list = valueParameter as IEnumerable<object>;
            var table = this.AsTableValuedParameter(list, tvpAttr.UserDefinedTypeName);
            this.Parameters.Add(tvpAttr.ParamName, table);
            return;
        }
        else
        {
            DynamicParamProp? attr = prop.GetCustomAttribute<DynamicParamProp>();
            this.Parameters.Add(attr.ParamName, valueParameter, attr.DbType, attr.ParamDirection, attr.Length);
            return;
        }
        throw new AggregateException($"{prop.Name}未實作{nameof(AbstractDapperParamProp)}");
    }

    /// <summary>
    /// 轉換為Dapper TVP
    /// </summary>
    /// <typeparam name="T">type of enumerable</typeparam>
    /// <param name="enumerable">list of values</param>
    /// <param name="typeName">database type name</param>
    /// <param name="orderedColumnNames">if more than one column in a TVP, columns order must match order of columns in TVP</param>
    /// <returns>a custom query parameter</returns>
    private SqlMapper.ICustomQueryParameter AsTableValuedParameter<T>(IEnumerable<T> enumerable, string typeName, IEnumerable<string>? orderedColumnNames = null)
    {
        DataTable dataTable = new();
        if (typeof(T).IsValueType || typeof(T).FullName.Equals($"{nameof(System)}.{nameof(System.String)}"))
        {
            dataTable.Columns.Add(orderedColumnNames == null ? "NONAME" : orderedColumnNames.First(), typeof(T));
            foreach (T obj in enumerable)
            {
                dataTable.Rows.Add(obj);
            }
        }
        else
        {
            PropertyInfo[] properties = enumerable.GetType().GetGenericArguments().First().GetProperties(BindingFlags.Public | BindingFlags.Instance);
            IEnumerable<PropertyInfo> readableProperties = properties.Where(x => x.CanRead);

            IEnumerable<string> columnNames = orderedColumnNames ?? readableProperties.Select(x => x.Name);
            foreach (string name in columnNames)
            {
                dataTable.Columns.Add(name, readableProperties.Single(x => x.Name.Equals(name)).PropertyType);
            }

            foreach (T obj in enumerable)
            {
                dataTable.Rows.Add(columnNames.Select(x => readableProperties.Single(y => y.Name.Equals(x)).GetValue(obj)));
            }
        }
        return dataTable.AsTableValuedParameter(typeName);
    }
}
