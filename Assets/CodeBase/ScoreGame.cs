using TMPro;

namespace CodeBase
{
    public class ScoreGame : PlayerScoreBase
    {
        public TextMeshProUGUI _scoreText;
        private int _score;
        
        public override void Increase()
        {
            _score++;
            _scoreText.text = _score.ToString();
        }

        public override void Decrease()
        {
            _score--;
            _scoreText.text = _score.ToString();
        }
    }
}