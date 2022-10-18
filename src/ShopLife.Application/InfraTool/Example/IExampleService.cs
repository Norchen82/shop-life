namespace ShopLife.Application.InfraTool.Example;

/// <summary>
/// 範例Service 介面
/// </summary>
public interface IExampleService
{
    /// <summary>
    /// Say
    /// </summary>
    /// <param name="vo">範例Vo</param>
    /// <returns></returns>
    Task Say(ExampleVo vo);
}