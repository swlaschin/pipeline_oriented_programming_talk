open System
open Microsoft.AspNetCore.Builder
open Microsoft.AspNetCore.Hosting
open Microsoft.Extensions.Hosting
open Microsoft.Extensions.Logging
open Microsoft.Extensions.DependencyInjection
open Giraffe
open CustomerDb

// For more on Giraffe see
// https://github.com/giraffe-fsharp/Giraffe/

let base_dir = __SOURCE_DIRECTORY__


// Return some parameterized text
let goodbyeWithName name :HttpHandler =
    text ($"Goodbye {name}")

// Return some JSON
let jsonExample() =
    let myRecord = {| Name = "Scott"; Email="scott@example.com "|}
    json myRecord  // serialize to json

// Database query with error handling 
let customerHandler customerId :HttpHandler = 
    printfn "loading customer %i" customerId
    let customerOrError = CustomerDb.loadCustomerFromDb customerId
    match customerOrError with
    | Ok customer -> 
        json customer // OK, return serialized version
    | Error errorMsg -> 
        setStatusCode 400 >=> text errorMsg 

// return a non-200
let accessDenied = 
    setStatusCode 401 >=> text "Access Denied"

let pingPongHandler =
    choose [
        route "/ping" >=> text "pong"
        route "/pong" >=> text "ping"
        ]

let webApp =
    choose [
        GET >=> route "/hello"   >=> text "GET hello"
        POST >=> route "/hello"   >=> text "POST hello"
        GET >=> route "/goodbye"   >=>  text "GET goodbye (no name)"
        GET >=> routef "/goodbye/%s" goodbyeWithName
        GET >=> pingPongHandler 
        POST >=> route "/jsonExample" >=> jsonExample()
        GET >=> routef "/customer/%i" customerHandler
        POST >=> route "/denied" >=> accessDenied 
        // home page
        GET >=> route "/" >=> htmlFile (base_dir + "/pages/index.html") ]



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