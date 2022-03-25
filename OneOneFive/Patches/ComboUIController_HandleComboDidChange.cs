using HarmonyLib;
using IPA.Utilities;
using TMPro;

namespace OneOneFive.Patches
{
    [HarmonyPatch(typeof(ComboUIController))]
    [HarmonyPatch("HandleComboDidChange")]
    internal class ComboUIController_HandleComboDidChange
    {
        private static FieldAccessor<ComboUIController, TextMeshProUGUI>.Accessor ComboText = FieldAccessor<ComboUIController, TextMeshProUGUI>.GetAccessor("_comboText");

        internal static void Postfix(int combo, ComboUIController __instance)
        {
            var _comboText = ComboText(ref __instance);
            if (_comboText is not null)
            {
                _comboText.text = combo.ToWords();
            }
        }
    }
}
