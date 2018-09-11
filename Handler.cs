using Amazon.Lambda.APIGatewayEvents;
using Amazon.Lambda.Serialization.Json;
using Amazon.Lambda.Core;
using System;

[assembly:LambdaSerializer(typeof(Amazon.Lambda.Serialization.Json.JsonSerializer))]
//https://forum.serverless.com/t/c-function-can-be-invoked-but-not-called-through-get/4271/2
namespace AwsDotnetCsharp
{
    public class Handler
    {
      public APIGatewayProxyResponse Hello(APIGatewayProxyRequest request, ILambdaContext context) {
            context.Logger.LogLine("This is useful for debugging!");
            return new APIGatewayProxyResponse() {
                StatusCode = 200,
                Body = "Go Serverless v1.0! Your function executed successfully!",
            };
        }
        // public Response Hello(Request request)
        // {
        //     return new Response("Go Serverless v1.0! Your function executed successfully!", request);
        // }
    }

    // public class Response
    // {
    //   public string Message {get; set;}
    //   public Request Request {get; set;}
    //
    //   public Response(string message, Request request){
    //     Message = message;
    //     Request = request;
    //   }
    // }
    //
    // public class Request
    // {
    //   public string Key1 {get; set;}
    //   public string Key2 {get; set;}
    //   public string Key3 {get; set;}
    //
    //   public Request(string key1, string key2, string key3){
    //     Key1 = key1;
    //     Key2 = key2;
    //     Key3 = key3;
    //   }
    // }
}
