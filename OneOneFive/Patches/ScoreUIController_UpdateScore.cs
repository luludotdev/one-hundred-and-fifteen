using HarmonyLib;
using IPA.Utilities;
using TMPro;

namespace OneOneFive.Patches
{
    [HarmonyPatch(typeof(ScoreUIController))]
    [HarmonyPatch("UpdateScore")]
    internal class ScoreUIController_UpdateScore
    {
        private static readonly FieldAccessor<ScoreUIController, ScoreUIController.InitData>.Accessor InitData = FieldAccessor<ScoreUIController, ScoreUIController.InitData>.GetAccessor("_initData");
        private static readonly FieldAccessor<ScoreUIController, TextMeshProUGUI>.Accessor ScoreText = FieldAccessor<ScoreUIController, TextMeshProUGUI>.GetAccessor("_scoreText");

        internal static void Postfix(int multipliedScore, int modifiedScore, ScoreUIController __instance)
        {
            var _initData = InitData(ref __instance);
            if (_initData is null)
            {
                Plugin.Logger.Error($"{nameof(_initData)} is null!");
                return;
            }

            var _scoreText = ScoreText(ref __instance);
            if (_scoreText is null)
            {
                Plugin.Logger.Error($"{nameof(_scoreText)} is null!");
                return;
            }

            if (_scoreText.enableWordWrapping)
            {
                _scoreText.enableWordWrapping = false;
            }

            if (_scoreText.overflowMode != TextOverflowModes.Overflow)
            {
                _scoreText.overflowMode = TextOverflowModes.Overflow;
            }

            int num = (_initData.scoreDisplayType == ScoreUIController.ScoreDisplayType.ModifiedScore) ? modifiedScore : multipliedScore;
            _scoreText.text = num.ToWords();
        }
    }
}
