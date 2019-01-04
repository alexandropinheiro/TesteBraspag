using log4net;
using System.Reflection;

namespace Api
{
    public enum TipoLog
    {
        Info,
        Error,
        Warn
    }

    public class RegisterLog
    {
        private static readonly ILog log = LogManager.GetLogger
            (MethodBase.GetCurrentMethod().DeclaringType);

        public static void Log(TipoLog tipoLog, string message)
        {
            switch (tipoLog) {
                case TipoLog.Info:
                    log.Info(message);
                    break;

                case TipoLog.Warn:
                    log.Warn(message);
                    break;

                case TipoLog.Error:
                    log.Error(message);
                    break;
            }
        }
    }
}
