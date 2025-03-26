using Newtonsoft.Json;
using Model.University;

namespace Service.University;
public class UniversityService
{
    private readonly HttpClient client = new HttpClient();

    public async Task<IEnumerable<UniversityClass>> GetUniversities()
    {
        var response = await client.GetAsync("http://universities.hipolabs.com/search?country=portugal");
        var content = await response.Content.ReadAsStringAsync();
        var universities = JsonConvert.DeserializeObject<IEnumerable<UniversityClass>>(content) ?? Enumerable.Empty<UniversityClass>();
        return universities;
    }
}
