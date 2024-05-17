using HttpClientTest.Domain.Entity;

namespace HttpClientTest.Services.Interfaces
{
    public interface ICatPostTestService
    {
        public Task<LoginDTO?> PostTest(LoginDTO request);
    }
}
