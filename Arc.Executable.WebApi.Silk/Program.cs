// See https://aka.ms/new-console-template for more information

using Sisk.Core.Http;
using Sisk.Core.Routing;

const string HttpLocalhost =
    "http://localhost:5000/";

var app =
    HttpServer
        .CreateBuilder(
            host =>
                host
                    .UseListeningPort(
                        HttpLocalhost
                    )
        );

app
    .Router
    .SetRoute(
        RouteMethod.Get,
        "/",
        _ =>
            new HttpResponse(
                    200
                )
                .WithContent(
                    "Hello, world!"
                )
    );

app.Start();