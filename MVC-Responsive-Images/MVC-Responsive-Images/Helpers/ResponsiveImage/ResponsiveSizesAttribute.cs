using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC_Responsive_Images.Helpers.ResponsiveImage
{
    public class ResponsiveSizesAttribute
    {
        public ResponsiveImageEnums.MediaQueryWidthType MediaQueryWidthType { get; set; }
        public int? Width { get; set; }
        public int ViewPortWidth { get; set; }
        public ResponsiveImageEnums.MediaQueryWidthUnit MediaQueryWidthUnit { get; set; }
    }
}