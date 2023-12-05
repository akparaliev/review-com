namespace ReviewCom.Services
{
    public interface ILoggingService
    {
        void LogDebug(string message);
        void LogInformation(string message);
        void LogWarning(string message);
        void LogError(string message);
        void LogError(string message, Exception exception);
        void LogFatal(string message, Exception exception);
    }
}