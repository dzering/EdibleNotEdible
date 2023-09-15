namespace CodeBase.Data
{
    public interface IGameData
    {
        Lives Lives { get; set; }
        Scores Score { get; set; }
        void IncreaseLive();
        void DecreaseLive();
        void IncreaseScore();
        void DecreaseScore();
    }
}