

using webCrawler;

try
{
    Console.ForegroundColor = ConsoleColor.Yellow;
    Console.WriteLine("Enter the URL of the desired website page :");
    Console.WriteLine();

    Console.ForegroundColor = ConsoleColor.Cyan;
    string url = Console.ReadLine();
    Console.WriteLine();

    SendHttpRequest sendHttpRequest = new SendHttpRequest(url);
    string html = await sendHttpRequest.FetchHtmlAsync(url);

    HTMLAnalysis analysis = new HTMLAnalysis(html);

    analysis.ExtractPageTitle();
    analysis.ExtractAllLinks();

    Console.ForegroundColor = ConsoleColor.Green;
    Console.WriteLine();
    Console.WriteLine("Finish");

}
catch(Exception ex)
{
    Console.WriteLine($"An error occurred: {ex.Message}");
}








