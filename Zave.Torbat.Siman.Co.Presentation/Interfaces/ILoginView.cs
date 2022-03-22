namespace Zave.Torbat.Siman.Co.Presentation.Interfaces
{
    public interface ILoginView:IView<ILoginPresentation>
    {
        
        string UserName { get; set; }
        string Password { get; set; }
    }
}
