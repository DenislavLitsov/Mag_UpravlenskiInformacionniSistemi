namespace UpravlenskiInformacionniSistemi.Web.ViewModels.Common.Abstractions
{
    public interface IError
    {
        string ErrorTitle { get; set; }
        
        string ErrorDescription { get; set; }
        
        bool IsError { get; }
    }
}