namespace DoAnXNA2
{
    public class GameStateManager
    {
        private readonly MainMenu _mainMenu;
        private readonly Setting _setting;
        private readonly ChoosingLevels _choosingLevels;
        private readonly GameDisplay _gameDisplay;
        private readonly GameOver _gameOver;
        private readonly Victory _victory;
        private readonly ComingSoon _comingSoon;

        public GameStateManager()
        {
            _mainMenu = new();
            _setting = new();
            _choosingLevels = new();
            _gameDisplay = new();
            _gameOver = new();
            _victory = new();
            _comingSoon = new();
        }

        public void SetMainMenu()
        {
            MainRes.PreviousState = MainRes.CurrentState;
            AudioManager.Play(Soundtrack.TitleTheme);
            MainRes.CurrentState = _mainMenu;
        }
        public void SetSetting()
        {
            MainRes.PreviousState = MainRes.CurrentState;
            AudioManager.Play(Soundtrack.TitleTheme);
            MainRes.CurrentState = _setting;
        }
        public void SetChoosingLevels()
        {
            MainRes.PreviousState = MainRes.CurrentState;
            AudioManager.Play(Soundtrack.TitleTheme);
            _choosingLevels.StartLoading();
            MainRes.CurrentState = _choosingLevels;
        }
        public void SetGameDisplay(int level)
        {
            MainRes.PreviousState = MainRes.CurrentState;
            AudioManager.Play(AudioManager.GetRandomCombatTheme());
            MainRes.ResetData();
            _gameDisplay.RenewListLevels();
            _gameDisplay.CurrentLevel = level;
            MainRes.CurrentState = _gameDisplay;
        }
        public void SetGameOver()
        {
            MainRes.PreviousState = MainRes.CurrentState;
            AudioManager.Play(Soundtrack.GameOver);
            MainRes.CurrentState = _gameOver;
        }
        public void SetVictory()
        {
            MainRes.PreviousState = MainRes.CurrentState;
            AudioManager.Play(Soundtrack.StageClear);
            MainRes.CurrentState = _victory;
        }
        public void SetComingSoon()
        {
            MainRes.PreviousState = MainRes.CurrentState;
            AudioManager.Play(Soundtrack.TitleTheme);
            MainRes.CurrentState = _comingSoon;
        }
        public void SetStateBackward()
        {
            MainRes.CurrentState = MainRes.PreviousState;
        }
    }
}
