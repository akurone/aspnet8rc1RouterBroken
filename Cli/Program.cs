using System;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Test.Cli;

try {
  var builder = WebAssemblyHostBuilder.CreateDefault(args);
  builder.RootComponents.Add<App>("#app");

  var app = builder.Build();
  await app.RunAsync();
}
catch (Exception ex) {
  Console.WriteLine(ex.ToString());
  throw;
}

