using System;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_Responsive_Images.Helpers.ResponsiveImage
{
    /// <summary>
    /// Responsive Image with Density as Descriptor
    /// </summary>
    public class ResponsiveImageWithDensityDescriptor : BaseResponsiveImage, IResponsiveImage<ResponsiveImageWithDensityDescriptor>
    {
        #region constuctors

        public ResponsiveImageWithDensityDescriptor(string imageSrc, string imageAltText)
            : base(imageSrc,imageAltText)
        {}

        #endregion

        public ResponsiveImageWithDensityDescriptor AddImageToSrcset(string imagePath, int imageDescriptor)
        {
            ImageSrcset.Add(imageDescriptor, imagePath);
            return this;
        }

        public string ToHtmlString()
        {
            var imageTag = new TagBuilder("img");
            imageTag.MergeAttribute("src", VirtualPathUtility.ToAbsolute(ImageSrc));
            imageTag.MergeAttribute("alt", ImageAltText);

            if (ImageSrcset.Any())
            {
                AddSrcsetAttribute(imageTag);
            }

            return imageTag.ToString(TagRenderMode.SelfClosing);
        }

        #region private methods

        private void AddSrcsetAttribute(TagBuilder imageTag)
        {
            imageTag.MergeAttribute("srcset", string.Join(",", ImageSrcset.Select(c => VirtualPathUtility.ToAbsolute(c.Value) + " " + c.Key + "x")));
        }

        #endregion
    }
}
