namespace DoAnXNA2
{
    public static class ReadyMadeBtn
    {
        // Các button sẵn có với chức năng cố định
        public static Button PlayButton;
        public static Button SettingsButton;
        public static Button BackwardButton;
        public static Button CloseButton;
        public static Button ReplayButton;
        public static Button FacebookButton;
        public static Button ShopButton;
        public static Button FAQButton;
        public static Button ForwardButton;
        public static Button SoundButton;
        public static Button TwitterButton;
        public static Button GoogleButton;
        public static Button UpgradeButton;
        public static Button VibrationButton;
        public static Button VKButton;
        public static Button HangarButton;
        public static Button InfoButton;
        public static Button MenuButton;
        public static Button MoreGamesButton;
        public static Button MusicButton;
        public static Button NotificationsButton;
        public static Button OkButton;
        public static Button PauseButton;
        public static Button RatingButton;

        public static void InitAndLoad(Game1 game1)
        {
            PlayButton = new Button(game1, Textures.Play_BTN, () =>
            {
                game1.SetChoosingLevels();
            });

            SettingsButton = new Button(game1, Textures.Settings_BTN, () =>
            {
                game1.SetSetting();
            });

            BackwardButton = new Button(game1, Textures.Backward_BTN, () =>
            {
                game1.SetStateBackward();
            });

            CloseButton = new Button(game1, Textures.Close_BTN, () =>
            {
                // Logic khi nhấn CloseButton
            });

            ReplayButton = new Button(game1, Textures.Replay_BTN, () =>
            {
                // Logic khi nhấn ReplayButton
            });

            FacebookButton = new Button(game1, Textures.Facebook_BTN, () =>
            {
                // Logic khi nhấn FacebookButton
            });

            ShopButton = new Button(game1, Textures.Shop_BTN, () =>
            {
                // Logic khi nhấn ShopButton
            });

            FAQButton = new Button(game1, Textures.FAQ_BTN, () =>
            {
                // Logic khi nhấn FAQButton
            });

            ForwardButton = new Button(game1, Textures.Forward_BTN, () =>
            {
                // Logic khi nhấn ForwardButton
            });

            SoundButton = new Button(game1, Textures.Sound_BTN, () =>
            {
                // Logic khi nhấn SoundButton
            });

            TwitterButton = new Button(game1, Textures.Twitter_BTN, () =>
            {
                // Logic khi nhấn TwitterButton
            });

            GoogleButton = new Button(game1, Textures.Google_BTN, () =>
            {
                // Logic khi nhấn GoogleButton
            });

            UpgradeButton = new Button(game1, Textures.Upgrade_BTN, () =>
            {
                // Logic khi nhấn UpgradeButton
            });

            VibrationButton = new Button(game1, Textures.Vibration_BTN, () =>
            {
                // Logic khi nhấn VibrationButton
            });

            VKButton = new Button(game1, Textures.VK_BTN, () =>
            {
                // Logic khi nhấn VKButton
            });

            HangarButton = new Button(game1, Textures.Hangar_BTN, () =>
            {
                // Logic khi nhấn HangarButton
            });

            InfoButton = new Button(game1, Textures.Info_BTN, () =>
            {
                // Logic khi nhấn InfoButton
            });

            MenuButton = new Button(game1, Textures.Menu_BTN, () =>
            {
                // Logic khi nhấn MenuButton
            });

            MoreGamesButton = new Button(game1, Textures.More_Games_BTN, () =>
            {
                // Logic khi nhấn MoreGamesButton
            });

            MusicButton = new Button(game1, Textures.Music_BTN, () =>
            {
                // Logic khi nhấn MusicButton
            });

            NotificationsButton = new Button(game1, Textures.Notifications_BTN, () =>
            {
                // Logic khi nhấn NotificationsButton
            });

            OkButton = new Button(game1, Textures.Ok_BTN, () =>
            {
                // Logic khi nhấn OkButton
            });

            PauseButton = new Button(game1, Textures.Pause_BTN, () =>
            {
                // Logic khi nhấn PauseButton
            });

            RatingButton = new Button(game1, Textures.Rating_BTN, () =>
            {
                // Logic khi nhấn RatingButton
            });
        }
    }
}

