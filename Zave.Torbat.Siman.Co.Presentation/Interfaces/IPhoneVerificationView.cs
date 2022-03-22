namespace Zave.Torbat.Siman.Co.Presentation.Interfaces
{
    public interface IPhoneVerificationView:IView<IPhoneVerificationPresenter>
    {
        void SendSmsSuccessful(int timeoutSeconds);
        void SendSmsFailed(string resultDescription);
        void AuthenticateFailed();
        void RetrySendToken();
        void RetryReceiveToken();

        void DownTimeCounterTask(int timeoutSeconds);
        void VerificationDone();
    }
}
