using System.Threading.Tasks;

namespace Pokespeare.Api.Services
{
    public interface IApiService
    {
        Task<string> GetPokemonDescription(string name);
        Task<string> GetShakespeareTranslation(string description);
    }
}