using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;

namespace InvestNetwork.Core
{
    public static class ImageHelper
    {
        public static void LoadImages(HttpFileCollectionBase files, int adId)
        {
            
        }

        public static void UploadImage(HttpPostedFileBase projectImg)
        {

        }

        public static Bitmap Resize(Bitmap sourceImage, int newWidth, int newHeight)
        {
            //меняем размеры логотипа с помощью графики
            var newLogo = new Bitmap(newWidth, newHeight);
            var graph = Graphics.FromImage(newLogo);
            graph.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.Bicubic;

            if (sourceImage.Height > sourceImage.Width)
            {
                graph.DrawImage(sourceImage, new Rectangle(0, 0, newWidth, sourceImage.Height * newWidth / sourceImage.Width));
            }
            else
            {
                graph.DrawImage(sourceImage, new Rectangle(0, 0, sourceImage.Width * newHeight / sourceImage.Height, newHeight));
            }

            graph.DrawImageUnscaledAndClipped(newLogo, new Rectangle(0, 0, newWidth, newHeight));

            return newLogo;
        }
    }
}
