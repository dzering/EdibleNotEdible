using CodeBase.Data;

namespace CodeBase.Infrastructure.Services
{
    public sealed class ProgressService : IProgressService
    {
        public PlayerProgress PlayerProgress { get; set; }
    }
}