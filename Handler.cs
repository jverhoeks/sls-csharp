using Amazon.Lambda.APIGatewayEvents;
using Amazon.Lambda.Serialization.Json;
using Amazon.Lambda.Core;
using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.DocumentModel;
using Amazon.Runtime;
//using Amazon.RegionEndpoint;

using System;

[assembly: LambdaSerializer(typeof(Amazon.Lambda.Serialization.Json.JsonSerializer))]
//https://forum.serverless.com/t/c-function-can-be-invoked-but-not-called-through-get/4271/2
namespace AwsDotnetCsharp
{
  public class Handler
  {
     private readonly string _accessKey;
     private readonly string _secretKey;
     private readonly string _serviceUrl;
     private readonly string _tableName;

      public Handler()
      {
          _accessKey = Environment.GetEnvironmentVariable("AccessKey");
          _secretKey = Environment.GetEnvironmentVariable("SecretKey");
          _serviceUrl = Environment.GetEnvironmentVariable("ServiceURL");
          _tableName =  Environment.GetEnvironmentVariable("DYNAMODB_TABLE");
      }

    public APIGatewayProxyResponse Create(APIGatewayProxyRequest request, ILambdaContext context) {
      context.Logger.LogLine("Create: "+_tableName);

      var dynamoDbClient = new AmazonDynamoDBClient(
          new BasicAWSCredentials(_accessKey, _secretKey),
          new AmazonDynamoDBConfig { ServiceURL = _serviceUrl,
              RegionEndpoint  = Amazon.RegionEndpoint.EUWest1});

       return new APIGatewayProxyResponse() {
                           StatusCode = 200,
                           Body = "{ 'message': 'Create' }",
            };
    }

    public APIGatewayProxyResponse List(APIGatewayProxyRequest request, ILambdaContext context) {
            context.Logger.LogLine("List");
            return new APIGatewayProxyResponse() {
                           StatusCode = 200,
                           Body = "{ 'message': 'List' }",
            };
    }


    public APIGatewayProxyResponse View(APIGatewayProxyRequest request, ILambdaContext context) {
            context.Logger.LogLine("View");
            return new APIGatewayProxyResponse() {
                           StatusCode = 200,
                           Body =  "{ 'message': 'View' }",
            };
    }


    public APIGatewayProxyResponse Remove(APIGatewayProxyRequest request, ILambdaContext context) {
            context.Logger.LogLine("Remove");
            return new APIGatewayProxyResponse() {
                           StatusCode = 200,
                           Body =  "{ 'message': 'Remove' }",
            };
    }
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
