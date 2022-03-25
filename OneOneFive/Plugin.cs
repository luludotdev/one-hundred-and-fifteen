using System.Reflection;
using HarmonyLib;
using IPA;
using IPA.Logging;

namespace OneOneFive
{
    [Plugin(RuntimeOptions.DynamicInit)]
    public class Plugin
    {
        internal static Logger Logger { get; private set; } = null!;
        private static readonly Harmony harmony = new("dev.lulu.oneonefive");

        [Init]
        public void Init(Logger logger)
        {
            Logger = logger;
        }

        [OnEnable]
        public void OnEnable()
        {
            harmony.PatchAll(Assembly.GetExecutingAssembly());
            Logger.Debug("Patched!");
        }

        [OnDisable]
        public void OnDisable()
        {
            harmony.UnpatchSelf();
            Logger.Debug("Unpatched!");
        }
    }
}
