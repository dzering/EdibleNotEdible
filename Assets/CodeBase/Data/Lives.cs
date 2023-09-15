using System;

namespace CodeBase.Data
{
    [Serializable]
    public class Lives
    {
        public int CurrentLives;
        public int MaxLives;

        public void ResetLives() => CurrentLives = MaxLives;
    }
}