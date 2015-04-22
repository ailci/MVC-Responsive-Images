using System;
using System.Web.Mvc;

namespace MVC_Responsive_Images.Helpers.ResponsiveImage
{
    public static class ResponsiveImageHelper
    {
        public static T ResponsiveImage<T>(this HtmlHelper helper, string imageSrc, string imageAltText = "") where T : class
        {
            return (T) Activator.CreateInstance(typeof(T),imageSrc,imageAltText);
        }
    }
}