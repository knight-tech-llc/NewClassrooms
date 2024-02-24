// -----------------------------------------------------------------------
// <copyright file="Program.cs" company="Knight Technologies LLC">
// Author: Shawn W Knight
// Copyright (c) Knight Technologies LLC All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace NewClassrooms.Host
{
    using System.Reflection;
    using Microsoft.OpenApi.Models;
    using NewClassrooms.Host.Extension;

    /// <summary>
    /// Provides an entry point for the application.
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Provides the main entry point for the application.
        /// </summary>
        /// <param name="args">A value that represents an arry of string arguments.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddServices();
            builder.Services.AddPorts();
            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "New Classrooms Take-Home Assignment",
                    Version = "v1",
                    Description = "New Classrooms Take-Home Assignment API.",
                });

                var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                c.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
            });

            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.UseAuthorization();
            app.MapControllers();
            await app.RunAsync();
        }
    }
}