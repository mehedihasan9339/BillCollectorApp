using BillCollectorApp.Services.Interfaces;

namespace BillCollectorApp.Services
{
    public class SmsService: ISms
    {
        private readonly HttpClient _httpClient;

        public SmsService()
        {
            _httpClient = new HttpClient();
        }

        public async Task SendSmsAsync(string destination, string message)
        {
            var username = "OpusBDENT";
            var password = "Opus@25!";
            var type = "0";
            var dlr = "1";
            var source = "8809617611359";

            var url = $"http://apibd.rmlconnect.net/bulksms/personalizedbulksms?username={username}&password={password}&type={type}&dlr={dlr}&source={source}&destination={destination}&message={message}";

            try
            {
                HttpResponseMessage response = await _httpClient.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    Console.WriteLine("SMS sent successfully.");
                }
                else
                {
                    Console.WriteLine($"Failed to send SMS. Status code: {response.StatusCode}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while sending SMS: {ex.Message}");
            }
        }
    }
}
