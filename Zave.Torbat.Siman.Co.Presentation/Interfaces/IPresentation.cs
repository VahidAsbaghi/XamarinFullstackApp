namespace Zave.Torbat.Siman.Co.Presentation.Interfaces
{
    public interface IPresentation<TView>
    {
        TView View { get; set; }
        IApplicationController ApplicationController { get; }
    }
}
