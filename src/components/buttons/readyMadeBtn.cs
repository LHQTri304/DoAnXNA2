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
            PlayButton = new Button(game1, Textures.Play_BTN, Textures.Play_BTN_Active, () =>
            {
                game1.SetChoosingLevels();
            });

            SettingsButton = new Button(game1, Textures.Settings_BTN, Textures.Settings_BTN_Active, () =>
            {
                game1.SetSetting();
            });

            BackwardButton = new Button(game1, Textures.Backward_BTN, Textures.Backward_BTN_Active, () =>
            {
                game1.SetStateBackward();
            });

            CloseButton = new Button(game1, Textures.Close_BTN, Textures.Close_BTN_Active, () =>
            {
                // Logic khi nhấn CloseButton
            });

            ReplayButton = new Button(game1, Textures.Replay_BTN, Textures.Replay_BTN_Active, () =>
            {
                // Logic khi nhấn ReplayButton
            });

            FacebookButton = new Button(game1, Textures.Facebook_BTN, Textures.Facebook_BTN_Active, () =>
            {
                // Logic khi nhấn FacebookButton
            });

            ShopButton = new Button(game1, Textures.Shop_BTN, Textures.Shop_BTN_Active, () =>
            {
                // Logic khi nhấn ShopButton
            });

            FAQButton = new Button(game1, Textures.FAQ_BTN, Textures.FAQ_BTN_Active, () =>
            {
                // Logic khi nhấn FAQButton
            });

            ForwardButton = new Button(game1, Textures.Forward_BTN, Textures.Forward_BTN_Active, () =>
            {
                // Logic khi nhấn ForwardButton
            });

            SoundButton = new Button(game1, Textures.Sound_BTN, Textures.Sound_BTN_Active, () =>
            {
                // Logic khi nhấn SoundButton
            });

            TwitterButton = new Button(game1, Textures.Twitter_BTN, Textures.Twitter_BTN_Active, () =>
            {
                // Logic khi nhấn TwitterButton
            });

            GoogleButton = new Button(game1, Textures.Google_BTN, Textures.Google_BTN_Active, () =>
            {
                // Logic khi nhấn GoogleButton
            });

            UpgradeButton = new Button(game1, Textures.Upgrade_BTN, Textures.Upgrade_BTN_Active, () =>
            {
                // Logic khi nhấn UpgradeButton
            });

            VibrationButton = new Button(game1, Textures.Vibration_BTN, Textures.Vibration_BTN_Active, () =>
            {
                // Logic khi nhấn VibrationButton
            });

            VKButton = new Button(game1, Textures.VK_BTN, Textures.VK_BTN_Active, () =>
            {
                // Logic khi nhấn VKButton
            });

            HangarButton = new Button(game1, Textures.Hangar_BTN, Textures.Hangar_BTN_Active, () =>
            {
                // Logic khi nhấn HangarButton
            });

            InfoButton = new Button(game1, Textures.Info_BTN, Textures.Info_BTN_Active, () =>
            {
                // Logic khi nhấn InfoButton
            });

            MenuButton = new Button(game1, Textures.Menu_BTN, Textures.Menu_BTN_Active, () =>
            {
                // Logic khi nhấn MenuButton
            });

            MoreGamesButton = new Button(game1, Textures.More_Games_BTN, Textures.More_Games_BTN_Active, () =>
            {
                // Logic khi nhấn MoreGamesButton
            });

            MusicButton = new Button(game1, Textures.Music_BTN, Textures.Music_BTN_Active, () =>
            {
                // Logic khi nhấn MusicButton
            });

            NotificationsButton = new Button(game1, Textures.Notifications_BTN, Textures.Notifications_BTN_Active, () =>
            {
                // Logic khi nhấn NotificationsButton
            });

            OkButton = new Button(game1, Textures.Ok_BTN, Textures.Ok_BTN_Active, () =>
            {
                // Logic khi nhấn OkButton
            });

            PauseButton = new Button(game1, Textures.Pause_BTN, Textures.Pause_BTN_Active, () =>
            {
                // Logic khi nhấn PauseButton
            });

            RatingButton = new Button(game1, Textures.Rating_BTN, Textures.Rating_BTN_Active, () =>
            {
                // Logic khi nhấn RatingButton
            });
        }
    }
}

