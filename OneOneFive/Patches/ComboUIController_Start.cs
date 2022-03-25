using HarmonyLib;
using IPA.Utilities;
using TMPro;

namespace OneOneFive.Patches
{
    [HarmonyPatch(typeof(ComboUIController))]
    [HarmonyPatch("Start")]
    internal class ComboUIController_Start
    {
        private static FieldAccessor<ComboUIController, TextMeshProUGUI>.Accessor ComboText = FieldAccessor<ComboUIController, TextMeshProUGUI>.GetAccessor("_comboText");

        internal static void Postfix(ComboUIController __instance)
        {
            var _comboText = ComboText(ref __instance);
            if (_comboText is not null)
            {
                _comboText.text = 0.ToWords();
            }
        }
    }
}
