using ShopLife.Application.InfraTool.Example;

namespace ShopLife.Infrastructure.Example;

/// <summary>
/// 範例Service
/// </summary>
public class ExampleService : IExampleService
{
    /// <summary>
    /// 建構子注入
    /// </summary>
    public ExampleService()
    {
    }

    /// <summary>
    /// Say
    /// </summary>
    /// <param name="vo">範例Vo</param>
    /// <returns></returns>
    public async Task Say(ExampleVo vo)
    {
        Console.WriteLine(vo.Text);
    }
}
