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
        public static Button MainMenuButton;

        public static void InitAndLoad()
        {
            PlayButton = new Button(Textures.Play_BTN, Textures.Play_BTN_Active, () =>
            {
                MainRes.GSM.SetChoosingLevels();
            });

            SettingsButton = new Button(Textures.Settings_BTN, Textures.Settings_BTN_Active, () =>
            {
                MainRes.GSM.SetSetting();
            });

            BackwardButton = new Button(Textures.Backward_BTN, Textures.Backward_BTN_Active, () =>
            {
                MainRes.GSM.SetStateBackward();
            });

            CloseButton = new Button(Textures.Close_BTN, Textures.Close_BTN_Active, () =>
            {
                // Logic khi nhấn CloseButton
            });

            ReplayButton = new Button(Textures.Replay_BTN, Textures.Replay_BTN_Active, () =>
            {
                // Logic khi nhấn ReplayButton
            });

            FacebookButton = new Button(Textures.Facebook_BTN, Textures.Facebook_BTN_Active, () =>
            {
                // Logic khi nhấn FacebookButton
            });

            ShopButton = new Button(Textures.Shop_BTN, Textures.Shop_BTN_Active, () =>
            {
                // Logic khi nhấn ShopButton
            });

            FAQButton = new Button(Textures.FAQ_BTN, Textures.FAQ_BTN_Active, () =>
            {
                // Logic khi nhấn FAQButton
            });

            ForwardButton = new Button(Textures.Forward_BTN, Textures.Forward_BTN_Active, () =>
            {
                // Logic khi nhấn ForwardButton
            });

            SoundButton = new Button(Textures.Sound_BTN, Textures.Sound_BTN_Active, () =>
            {
                // Logic khi nhấn SoundButton
            });

            TwitterButton = new Button(Textures.Twitter_BTN, Textures.Twitter_BTN_Active, () =>
            {
                // Logic khi nhấn TwitterButton
            });

            GoogleButton = new Button(Textures.Google_BTN, Textures.Google_BTN_Active, () =>
            {
                // Logic khi nhấn GoogleButton
            });

            UpgradeButton = new Button(Textures.Upgrade_BTN, Textures.Upgrade_BTN_Active, () =>
            {
                // Logic khi nhấn UpgradeButton
            });

            VibrationButton = new Button(Textures.Vibration_BTN, Textures.Vibration_BTN_Active, () =>
            {
                // Logic khi nhấn VibrationButton
            });

            VKButton = new Button(Textures.VK_BTN, Textures.VK_BTN_Active, () =>
            {
                // Logic khi nhấn VKButton
            });

            HangarButton = new Button(Textures.Hangar_BTN, Textures.Hangar_BTN_Active, () =>
            {
                // Logic khi nhấn HangarButton
            });

            InfoButton = new Button(Textures.Info_BTN, Textures.Info_BTN_Active, () =>
            {
                // Logic khi nhấn InfoButton
            });

            MenuButton = new Button(Textures.Menu_BTN, Textures.Menu_BTN_Active, () =>
            {
                // Logic khi nhấn MenuButton
            });

            MoreGamesButton = new Button(Textures.More_Games_BTN, Textures.More_Games_BTN_Active, () =>
            {
                // Logic khi nhấn MoreGamesButton
            });

            MusicButton = new Button(Textures.Music_BTN, Textures.Music_BTN_Active, () =>
            {
                // Logic khi nhấn MusicButton
            });

            NotificationsButton = new Button(Textures.Notifications_BTN, Textures.Notifications_BTN_Active, () =>
            {
                // Logic khi nhấn NotificationsButton
            });

            OkButton = new Button(Textures.Ok_BTN, Textures.Ok_BTN_Active, () =>
            {
                // Logic khi nhấn OkButton
            });

            PauseButton = new Button(Textures.Pause_BTN, Textures.Pause_BTN_Active, () =>
            {
                // Logic khi nhấn PauseButton
            });

            RatingButton = new Button(Textures.Rating_BTN, Textures.Rating_BTN_Active, () =>
            {
                // Logic khi nhấn RatingButton
            });

            MainMenuButton = new Button(Textures.Backward_BTN, Textures.Backward_BTN_Active, () =>
            {
                MainRes.GSM.SetMainMenu();
            });
        }
    }
}

