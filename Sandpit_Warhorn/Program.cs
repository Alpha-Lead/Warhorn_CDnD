
using GraphQL;
using static System.Net.WebRequestMethods;

Console.WriteLine(
@" _    _            _                       ___  ___                                  " + "\r\n" +
@"| |  | |          | |                      |  \/  |                                  " + "\r\n" +
@"| |  | | __ _ _ __| |__   ___  _ __ _ __   | .  . | __ _ _ __   __ _  __ _  ___ _ __ " + "\r\n" +
@"| |/\| |/ _` | '__| '_ \ / _ \| '__| '_ \  | |\/| |/ _` | '_ \ / _` |/ _` |/ _ \ '__|" + "\r\n" +
@"\  /\  / (_| | |  | | | | (_) | |  | | | | | |  | | (_| | | | | (_| | (_| |  __/ |   " + "\r\n" +
@" \/  \/ \__,_|_|  |_| |_|\___/|_|  |_| |_| \_|  |_/\__,_|_| |_|\__,_|\__, |\___|_|   " + "\r\n" +
@"                                                                      __/ |          " + "\r\n" +
@"                                                                     |___/           "
);

//https://warhorn.net/developers/docs/guides/app-registration
//https://warhorn.net/developers/apps
//https://warhorn.net/developers/apps/w6buDsCRftLTm68u89xc8yLi
string ClientId = "";
//https://warhorn.net/developers/docs/guides/access-tokens
string AppToken = "";
HttpClient client = new HttpClient();

/*************************************
 * Try to get the initial connection *
 *************************************/
String requestUrl = "https://warhorn.net/graphql";
Dictionary<string, string> postValues = new Dictionary<string, string>();
postValues.Add("client_id", ClientId);
postValues.Add("client_secret", AppToken);
postValues.Add("grant_type", "client_credentials");
HttpContent httpContent = new FormUrlEncodedContent(postValues);
HttpResponseMessage response = await client.PostAsync(requestUrl, httpContent);
//HttpResponseMessage response = await Http.PostAsync(requestUrl, httpContent);

if (response.IsSuccessStatusCode)
{
    string message = response.Content.ToString() ?? "";
    Console.WriteLine("Auth POST response: {0}", message);
}
else
{
    Console.WriteLine("HTTP POST Auth request threw exception: {0}", response.Content.ToString());
}

//DevNote: Works, now need to get GraphQL queries working

/********************************************
 * Try and get a list of the upcoming games *
 ********************************************/
//DevNote: Added "GraphQL" package
//DevNote: There is documentation!!!, need to be logged in then: https://warhorn.net/developers/docs/products/graphql-api/overview
/*DevNote:
 * Such a useful tool!
 * https://warhorn.net/developers/tools/explorer
 * name:type
 * 
 * event = "TheLostDice"
 * "session" is what we are looking at, data wise
 * "email" will be NULL as I am not an admin
 */

GraphQL.Types.Schema schema = GraphQL.Types.Schema.For(
@"
    type Query {
        hello: String
    }
"); //GQL
var root = new { Hello = "Hello World" };
var json = await schema.ExecuteAsync(_ =>
{
    _.Query = "{ hello }";
    _Root = root;
});
Console.WriteLine(json.ToString());


Console.WriteLine("==END==");