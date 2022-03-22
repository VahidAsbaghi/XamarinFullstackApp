namespace Zave.Torbat.Siman.Co.Presentation.Interfaces
{
    public interface IView<TPresentation>
    {
        TPresentation Presenter { get; set; }
        object ViewContext { get; set; }
    }
}
