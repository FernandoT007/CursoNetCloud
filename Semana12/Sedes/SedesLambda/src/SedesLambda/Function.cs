using Newtonsoft.Json;
using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.Model;
using Amazon.Lambda.Core;
using Amazon.Lambda.APIGatewayEvents;

// Assembly attribute to enable the Lambda function's JSON input to be converted into a .NET class.
[assembly: LambdaSerializer(typeof(Amazon.Lambda.Serialization.SystemTextJson.DefaultLambdaJsonSerializer))]

namespace SedesLambda;

public class Function
{
    private readonly IAmazonDynamoDB _dynamoDbClient;

        public Function()
        {
            _dynamoDbClient = new AmazonDynamoDBClient();
        }

        public async Task<APIGatewayProxyResponse> FunctionHandler(APIGatewayProxyRequest request, ILambdaContext context)
        {
            var inputData = JsonConvert.DeserializeObject<Sede>(request.Body);

            // Construir el objeto para insertar en DynamoDB
            var requestDynamoDb = new PutItemRequest
            {
                TableName = "Sedes",
                Item = new Dictionary<string, AttributeValue>
                {
                    { "Id", new AttributeValue { S = inputData!.Id } },
                    { "Name", new AttributeValue { S = inputData.Name } }
                }
            };

            await _dynamoDbClient.PutItemAsync(requestDynamoDb);

              return new APIGatewayProxyResponse
            {
                StatusCode = 200,
                Body = "Success",
                Headers = new Dictionary<string, string> { { "Content-Type", "application/json" } }
            };
        }

    public class Sede
    {
        public required string Id { get; set; }
        public required string Name { get; set; }
    }
}