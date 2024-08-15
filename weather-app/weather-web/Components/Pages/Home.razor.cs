using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Configuration;
using MudBlazor;
using System.Net.Http;
using System.Net.Http.Json;
using weather_web.Models;

namespace weather_web.Components.Pages;

public partial class Home
{
    private MudForm form;
    private string searchText;
    [Inject]
    public IHttpClientFactory _httpClientFactory { get; set; }

    [Inject]
    public IConfiguration _config { get; set; }

    protected override void OnInitialized()
    {
        
    }

    private async void Submit ()
    {
        form.Validate();
        if (form.IsValid)
        {
            using var _httpClient = _httpClientFactory.CreateClient();
            Console.WriteLine("submitted");

            string? apikey = _config.GetValue<string>("apikey");

            var request = new HttpRequestMessage();
            request.RequestUri = new Uri($"http://dataservice.accuweather.com/locations/v1/cities/US/search?q={searchText}&apikey={apikey}");
            request.Method = HttpMethod.Get;

            var response = await _httpClient.SendAsync(request);

            City[]? myDeserializedClass = await response.Content.ReadFromJsonAsync<City[]>();

            string? cityKey = myDeserializedClass[0].Key;


        }
        else
        {
            Console.WriteLine("not submitted");
        }
    }
}
