open System
open Microsoft.AspNetCore.Builder
open Microsoft.AspNetCore.Hosting
open Microsoft.Extensions.Hosting
open Microsoft.Extensions.Logging
open Microsoft.Extensions.DependencyInjection
open Giraffe

// For more on Giraffe see
// https://github.com/giraffe-fsharp/Giraffe/

let base_dir = __SOURCE_DIRECTORY__

let goodbyeHandler name :HttpHandler =
    fun next ctx ->
        ($"Goodbye {name}" |> text) next ctx

let myRecord = {| Name = "Scott"; Email="scott@example.com "|}

let accessDenied = setStatusCode 401 >=> text "Access Denied"

let webApp =
    choose [
        GET >=> route "/ping"   >=> text "pong"
        GET >=> route "/hello"   >=> text "GET hello"
        GET >=> route "/goodbye"   >=>  text "GET goodbye"
        GET >=> routef "/goodbye/%s" goodbyeHandler
        POST >=> route "/hello"   >=> json myRecord
        POST >=> route "/goodbye" >=> accessDenied 
        route "/" >=> htmlFile (base_dir + "/pages/index.html") ]



// ===================================
// Code needed for ASP.NET 
// ===================================

type Startup() =
    member __.ConfigureServices (services : IServiceCollection) =
        // Register default Giraffe dependencies
        services.AddGiraffe() |> ignore

    member __.Configure (app : IApplicationBuilder)
                        (env : IHostEnvironment)
                        (loggerFactory : ILoggerFactory) =
        // Add Giraffe to the ASP.NET Core pipeline
        app.UseGiraffe webApp

[<EntryPoint>]
let main _ =
    Host.CreateDefaultBuilder()
        .ConfigureWebHostDefaults(
            fun webHostBuilder ->
                webHostBuilder
                    .UseStartup<Startup>()
                    |> ignore)
        .Build()
        .Run()
    0