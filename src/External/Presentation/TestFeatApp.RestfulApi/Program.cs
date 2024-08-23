using System;
using System.Text;
using FastEndpoints;
using Microsoft.AspNetCore.Builder;
using TestFeatApp.BuildingBlocks.AppDependencyRegister;
using TestFeatApp.BuildingBlocks.AppDependencyRegister.Common;
using TestFeatApp.RestfulApi;

// Preset.
Console.OutputEncoding = Encoding.UTF8;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Core app services registration.
builder.Services.AddAppDependency();

// Webapi service registration.
builder.Services.AddWebApi();

var app = builder.Build();

// Build custom service resolver.
ServiceResolver.SetProvider(app.Services);

// Configure the HTTP request pipeline.
app.UseFastEndpoints();

await app.RunAsync();
