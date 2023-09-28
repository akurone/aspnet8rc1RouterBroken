using System;
using System.Globalization;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

try {
  CultureInfo.CurrentCulture = CultureInfo.InvariantCulture;
  var app = ConfigureDependenciesAndBuildApp(args);
  return await ConfigurePipelineAndRun(app);
}
catch (Exception ex) {
  Console.Error.Write(ex);
  return 1;
}

static WebApplication ConfigureDependenciesAndBuildApp(string[] args) {
  var builder = WebApplication.CreateBuilder(args);
  ///StaticWebAssetsLoader.UseStaticWebAssets(builder.Environment, builder.Configuration);  
  _ = builder.Services.AddControllers();
  return builder.Build();
}

static WebApplication MapBlazorApp(WebApplication app) {
  _ = app //backend
    .Map("/subpath", x => x
      .UseRouting()
      .UseEndpoints(static y => _ = y.MapControllers()));

  _ = app //frontend
    .UseStaticFiles()
    .UseBlazorFrameworkFiles()
    .UseRouting()
    .UseEndpoints(static y => _ = y.MapFallbackToFile("index.html"));

  return app;
}

static async Task<int> ConfigurePipelineAndRun(WebApplication app) {
  app.UseWebAssemblyDebugging();//since this is a repro
  await MapBlazorApp(app).RunAsync();
  return 0;
}

