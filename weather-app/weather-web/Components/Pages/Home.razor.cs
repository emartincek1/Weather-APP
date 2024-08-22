using Microsoft.AspNetCore.Components;
using MudBlazor;
using weather_web.Models;

namespace weather_web.Components.Pages;

public partial class Home
{
    private MudForm form;
    private string searchText;
    private string apikey;
    private string? localName;
    private string? state;
    private float temp;
    [Inject]
    public IHttpClientFactory _httpClientFactory { get; set; }

    [Inject]
    public IConfiguration _config { get; set; }

    protected override void OnInitialized()
    {
         apikey = _config.GetValue<string>("apikey");
    }

    private async void Submit ()
    {
        form.Validate();
        if (form.IsValid)
        {
            using var _httpClient = _httpClientFactory.CreateClient();

            string? apikey = _config.GetValue<string>("apikey");

            var request = new HttpRequestMessage();
            request.RequestUri = new Uri($"http://dataservice.accuweather.com/locations/v1/cities/US/search?q={searchText}&apikey={apikey}");
            request.Method = HttpMethod.Get;

            var response = await _httpClient.SendAsync(request);

            City[]? myDeserializedClass = await response.Content.ReadFromJsonAsync<City[]>();

            string? cityKey = myDeserializedClass[0].Key;
            localName = myDeserializedClass[0].LocalizedName;
            state = myDeserializedClass[0].AdministrativeArea.LocalizedName;
            await Task.Delay(500);
            CurrentConditions(cityKey);
        }
        else
        {
            Console.WriteLine("not submitted");
        }
    }

    private async void CurrentConditions(string CityKey)
    {
        using var _httpClient = _httpClientFactory.CreateClient();

        var request = new HttpRequestMessage();
        request.RequestUri = new Uri($"http://dataservice.accuweather.com/currentconditions/v1/{CityKey}?apikey={apikey}");
        request.Method = HttpMethod.Get;

        var response = await _httpClient.SendAsync(request);

        CurrentConditions[]? deserializedConditions = await response.Content.ReadFromJsonAsync<CurrentConditions[]>();

        temp = deserializedConditions[0].Temperature.Imperial.Value;
        StateHasChanged();
    }
}
