using System;

namespace Catalogo.Api.Configuration;

public static class ApiConfiguration
{
    public static WebApplication SwaggerDocumentation(this WebApplication app)
    {
        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.MapOpenApi();
        }

        return app;
    }
}
