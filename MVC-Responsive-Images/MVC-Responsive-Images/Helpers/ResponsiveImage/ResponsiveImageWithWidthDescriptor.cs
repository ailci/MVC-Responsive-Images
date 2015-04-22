using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_Responsive_Images.Helpers.ResponsiveImage
{
    /// <summary>
    /// Responsive Image with Width as Descriptor
    /// </summary>
    public class ResponsiveImageWithWidthDescriptor : BaseResponsiveImage, IResponsiveImage<ResponsiveImageWithWidthDescriptor>
    {
        #region members/variables

        //Default Viewport Width
        private readonly IList<ResponsiveSizesAttribute> _sizes;

        #endregion

        #region constructors

        public ResponsiveImageWithWidthDescriptor(string imageSrc, string imageAltText)
            : base(imageSrc, imageAltText)
        {
            _sizes = new List<ResponsiveSizesAttribute>();
        }

        #endregion

        public ResponsiveImageWithWidthDescriptor AddSizes(ResponsiveSizesAttribute size)
        {
            _sizes.Add(size);
            return this;
        }

        public ResponsiveImageWithWidthDescriptor AddImageToSrcset(string imagePath, int imageDescriptor)
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
                
                if(_sizes.Any())
                    AddSizesAttribute(imageTag);
            }

            return imageTag.ToString(TagRenderMode.SelfClosing);
        }

        #region private methods

        private void AddSrcsetAttribute(TagBuilder imageTag)
        {
            imageTag.MergeAttribute("srcset", string.Join(",", ImageSrcset.Select(c => VirtualPathUtility.ToAbsolute(c.Value) + " " + c.Key + "w")));
        }

        private void AddSizesAttribute(TagBuilder imageTag)
        {
            var sizesWithMediaQuery = _sizes.Where(c => c.Width.HasValue) // Werte nehmen,die eine Width haben
                .Select(c => "(" + c.MediaQueryWidthType.ToString().ToLower() + "-width: " + 
                c.Width + c.MediaQueryWidthUnit.ToString().ToLower() + ") " + 
                c.ViewPortWidth + "vw");

            var sizesWithoutMediaQuery = _sizes.Where(c => c.Width.HasValue == false)
                        .Select(c => c.ViewPortWidth + "vw");

            imageTag.MergeAttribute("sizes",string.Join(",",sizesWithMediaQuery.Concat(sizesWithoutMediaQuery)));
        }

        #endregion
    }
}