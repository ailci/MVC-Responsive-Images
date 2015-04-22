using System.Collections.Generic;

namespace MVC_Responsive_Images.Helpers.ResponsiveImage
{
    public abstract class BaseResponsiveImage
    {
        #region members/variables

        protected string ImageSrc { get; set; }
        protected string ImageAltText { get; set; }
        protected IDictionary<int,string> ImageSrcset { get; set; }

        #endregion

        protected BaseResponsiveImage(string imageSrc, string imageAltText)
        {
            ImageSrc = imageSrc;
            ImageAltText = imageAltText; 
            ImageSrcset = new Dictionary<int, string>();
        }
    }
}