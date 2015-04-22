using System.Web;

namespace MVC_Responsive_Images.Helpers.ResponsiveImage
{
    public interface IResponsiveImage<T> : IHtmlString where T : class
    {
        T AddImageToSrcset(string imagePath, int imageDescriptor);
    }
}
