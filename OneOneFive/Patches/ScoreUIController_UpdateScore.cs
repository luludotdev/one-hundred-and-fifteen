using HarmonyLib;
using IPA.Utilities;
using TMPro;

namespace OneOneFive.Patches
{
    [HarmonyPatch(typeof(ScoreUIController))]
    [HarmonyPatch("UpdateScore")]
    internal class ScoreUIController_UpdateScore
    {
        private static FieldAccessor<ScoreUIController, ScoreUIController.InitData>.Accessor InitData = FieldAccessor<ScoreUIController, ScoreUIController.InitData>.GetAccessor("_initData");
        private static FieldAccessor<ScoreUIController, TextMeshProUGUI>.Accessor ScoreText = FieldAccessor<ScoreUIController, TextMeshProUGUI>.GetAccessor("_scoreText");

        internal static void Postfix(int multipliedScore, int modifiedScore, ScoreUIController __instance)
        {
            var _initData = InitData(ref __instance);
            var _scoreText = ScoreText(ref __instance);

            if (_initData is not null && _scoreText is not null)
            {
                int num = (_initData.scoreDisplayType == ScoreUIController.ScoreDisplayType.ModifiedScore) ? modifiedScore : multipliedScore;
                _scoreText.text = num.ToWords();
            }
        }
    }
}
