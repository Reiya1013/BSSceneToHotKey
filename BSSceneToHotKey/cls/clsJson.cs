using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSSceneToHotKey
{
    public class clsJsonEventObject
    {
        public string Event { get; set; }
        public Int64 time { get; set; }
        public clsJsonStatusObject status { get; set; }
        public clsJsonBeatmapEventObject beatmapEvent { get; set; }
    }
    public class clsJsonBeatmapEventObject
    {
        public int type { get; set; }
        public int value { get; set; }
    }

    public class clsJsonStatusObject
    {
        public clsJsonGameObject game { get; set; } = new clsJsonGameObject();
        public clsJsonBeatmapObject beatmap { get; set; } = new clsJsonBeatmapObject();
        public clsJsonPerformanceObject performance { get; set; } = new clsJsonPerformanceObject();
        public clsJsonModObject mod { get; set; } = new clsJsonModObject();
        public clsJsonPlayerSettingsObject playerSettings { get; set; } = new clsJsonPlayerSettingsObject();
    }

    public class clsJsonGameObject
    {
        public string pluginVersion { get; set; }
        public string gameVersion { get; set; }
        public string scene { get; set; }
        public string mode { get; set; }
    }
    public class clsJsonBeatmapObject
    {
        //曲名
        public string songName { get; set; }
        //曲のサブ名
        public string songSubName { get; set; }
        //曲の作成者名
        public string songAuthorName { get; set; }
        //ビートマップの作成者名
        public string levelAuthorName { get; set; }
        //曲のカバー
        public string songCover { get; set; }
        //一意のビートマップ識別子。すべての困難について同じです。levelIdから抽出され、OSTおよびWIPの曲に対してnullを返します。
        public string songHash { get; set; }
        //曲の生のlevelId。すべての困難について同じです。
        public string levelId { get; set; }
        //曲の1分
        public int songBPM { get; set; }
        //曲の音符のジャンプ移動速度、音符がプレーヤーに向かって移動する速度。
        public int noteJumpSpeed { get; set; }
        //曲のどこからビートマップが開始するかをミリ単位で表した時間。曲の速度乗数に合わせて調整。
        public int songTimeOffset { get; set; }
        //マップが開始されたときのミリ秒単位のUNIXタイムスタンプ。ゲームが再開されると変化します。練習の設定により変更される場合があります。
        public int start { get; set; }
        public int paused { get; set; }
        public int length { get; set; }
        public string difficulty { get; set; }
        public int notesCount { get; set; }
        public int bombsCount { get; set; }
        public int obstaclesCount { get; set; }
        public int maxScore { get; set; }
        public string maxRank { get; set; }
        public string environmentName { get; set; }
    }

    public class clsJsonPerformanceObject
    {
        public int score { get; set; }
        public int currentMaxScore { get; set; }
        public string rank { get; set; }
        public int passedNotes { get; set; }
        public int hitNotes { get; set; }
        public int missedNotes { get; set; }
        public int passedBombs { get; set; }
        public int hitBombs { get; set; }
        public int combo { get; set; }
        public int maxCombo { get; set; }
        public int multiplier { get; set; }
        public int multiplierProgress { get; set; }
        public int batteryEnergy { get; set; }
    }
    public class clsJsonModObject
    {
        public int multiplier { get; set; }
        public string obstacles { get; set; }
        public bool instaFail { get; set; }
        public bool noFail { get; set; }
        public bool batteryEnergy { get; set; }
        public int batteryLives { get; set; }
        public bool disappearingArrows { get; set; }
        public bool noBombs { get; set; }
        public string songSpeed { get; set; }
        public int songSpeedMultiplier { get; set; }
        public bool noArrows { get; set; }
        public bool ghostNotes { get; set; }
        public bool failOnSaberClash { get; set; }
        public bool strictAngles { get; set; }
        public bool fastNotes { get; set; }
        public bool smallNotes { get; set; }
        public bool proMode { get; set; }
        public bool zenMode { get; set; }
    }

    public class clsJsonPlayerSettingsObject
    {
        public bool staticLights { get; set; }
        public bool leftHanded { get; set; }
        public int playerHeight { get; set; }
        public int sfxVolume { get; set; }
        public bool reduceDebris { get; set; }
        public bool noHUD { get; set; }
        public bool advancedHUD { get; set; }
        public bool autoRestart { get; set; }
        public bool saberTrailIntensity { get; set; }
        public bool environmentEffects { get; set; }
        public bool hideNoteSpawningEffect { get; set; }
    }
}
