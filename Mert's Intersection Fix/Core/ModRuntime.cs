using Colossal.Logging;

namespace MertsIntersectionFix.Core
{
    internal static class ModRuntime
    {
        public static ILog log = LogManager.GetLogger("MertsIntersectionFix").SetShowsErrorsInUI(false);

        public static void Log(string message)
        {
            log.Info(message);
        }
        public static void Warn(string message)
        {
            log.Warn(message);
        }
        public static void Error(string message)
        {
            log.Error(message);
        }
    }
}