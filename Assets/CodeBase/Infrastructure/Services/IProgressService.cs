using CodeBase.Data;

namespace CodeBase.Infrastructure.Services
{
    public interface IProgressService : IService
    {
        PlayerProgress PlayerProgress { get; set; }
    }
}