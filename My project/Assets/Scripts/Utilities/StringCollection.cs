
public class StringCollection
{
    #region --------------------------------- EVENTS --------------------------------------


    public const string EVENT_STAR_CLICK                    = "OnStarClick";
    public const string EVENT_ROPE_CONNECTION_COMPLETED     = "OnAllRopeConnected";

    public const string EVENT_JOINT_CLICK                   = "OnJointClick";
    public const string EVENT_JOINT_RELEASE                 = "OnJointRelease";

    public const string EVENT_TIME_STOP_START               = "OnTimeStopStarted";
    public const string EVENT_TIME_STOP_COMPLETE            = "OnTimeStopCompleted";
    public const string EVENT_TIME_CONTINUE_START           = "OnTimeContinueStarted";
    public const string EVENT_TIME_CONTINUE_COMPLETE        = "OnTimeContinueCompleted";

    public const string EVENT_LEVEL_COMPLETE                = "OnLevelComplete";
    public const string EVENT_LEVEL_FAILED                  = "OnLevelFailed";

    public const string EVENT_ITEM_BUTTON_CLICK             = "OnItemsButtonClick";

    public const string EVENT_CHANGE_SKIN                   = "OnSkinChange";
    public const string EVENT_CHANGE_BACKGROUND             = "OnBackgroundChange";
    public const string EVENT_COIN_CHANGE                   = "OnCoinChange";

    public const string EVENT_SKIP_EVENT                    = "OnSkipEvent";

    public const string EVENT_REFRESH_RANDOM_BUTTON         = "OnRefreshRandomButton";
    public const string EVENT_CLAIM_ITEM                    = "OnItemClaim";
    public const string EVENT_CLAIM_ROPE_ITEM               = "OnRopeItemClaim";

    #endregion ----------------------------------------------------------------------------

    #region ---------------------------------- DATA ---------------------------------------

    public const string DATA_IS_INITIALIZED                 = "DataIsInitialized";
    public const string DATA_IS_RATED                       = "DataIsRated";
    public const string DATA_IS_FIRST_INSTALLED             = "DataIsFirstInstall";

    public const string DATA_CURRENT_COIN                   = "DataCurrentCoin";
    public const string DATA_CURRENT_LEVEL                  = "DataCurrentLevel";

    public const string DATA_SETTINGS_SOUND                 = "DataSettingsSound";
    public const string DATA_SETTINGS_MUSIC                 = "DataSettingsMusic";
    public const string DATA_SETTINGS_VIBRATE               = "DataSettingsVibrate";

    public const string DATA_CURRENT_SKIN_SET               = "DataCurrentSkinSet";
    public const string DATA_CURRENT_ROPE_SET               = "DataCurrentRopeSet";

    #endregion ----------------------------------------------------------------------------
}

public enum Tag
{
    Untagged,
    Respawn,
    Finish,
    EditorOnly,
    MainCamera,
    Player,
    GameController,
    Link,
    FxTemporaire,
    Friendly,
    Enemy,
    IgnoreTNT,
    Wood,
    Wall,
    TNT,
    SpikeBall,
    Spike,
    BlackHole
}

public enum Sound
{
    dispose,
    help,
    hit,
    yell,

    blackHole,
    explode,
    rope,
    spike,
    spikeBall,
    wood,

    gravity_down,
    gravity_up,

    button_click,
    camera_shot,

    lose,
    win
}

public enum WinLoseType
{
    loseChar,
    loseEnemy,
    loseCharEnemy,
    winChar,
    winEnemy,
    winCharEnemy
}

public enum ItemType
{
    theme,
    rope
}

public enum UnlockType
{
    ads,
    level
}

public enum SkinType
{
    Enemy,
    FirstCharacter,
    SecondCharacter
}

public enum ClaimType
{
    normal,
    ads
}
