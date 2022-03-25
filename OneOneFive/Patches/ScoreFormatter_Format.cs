using HarmonyLib;

namespace OneOneFive.Patches
{
    [HarmonyPatch(typeof(ScoreFormatter))]
    [HarmonyPatch("Format")]
    internal class ScoreFormatter_Format
    {
        internal static void Postfix(int score, ref string? __result)
        {
            if (__result is not null)
            {
                __result = score.ToWords();
            }
        }
    }
}
