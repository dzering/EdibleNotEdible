using System;

namespace CodeBase.Data
{
    [Serializable]
    public class PlayerProgress
    {
        public Lives Lives;
        public Scores Scores;

        public PlayerProgress()
        {
            Lives = new Lives();
            Scores = new Scores();

        }
    }
}