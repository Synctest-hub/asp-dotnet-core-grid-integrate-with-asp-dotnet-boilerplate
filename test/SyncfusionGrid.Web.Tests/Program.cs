using Microsoft.AspNetCore.Builder;
using SyncfusionGrid;
using Volo.Abp.AspNetCore.TestBase;

var builder = WebApplication.CreateBuilder();
await builder.RunAbpModuleAsync<SyncfusionGridWebTestModule>();

public partial class Program
{
}
