using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

namespace Greens_To_SOG
{
   class clsExtractRBG
   {
      
      /// <summary>
      /// Extract spec gloss and occlusion from this green image
      /// </summary>
      /// <param name="o">path to the image</param>
      public static void ExtractThese(string o)
      {
         
         //This is to check for tiff only - removed to work on any image, mostly just tif and tiff, png don't work right but that is the file types faught I think
         /*try
         {
            var str = new SoapHexBinary(File.ReadAllBytes(o)).ToString();
            if (str.Substring(0, 4) != "4949")
            {
               NotAGreenMsg(o);
               return;
            }
         }
         catch
         {
            return;
         }*/
         Console.ForegroundColor = ConsoleColor.Cyan;
         Console.WriteLine("");
         Console.WriteLine("Opening:");
         Console.ForegroundColor = ConsoleColor.Gray;
         Console.WriteLine(o);

         if (LockBitsSetup(o, "_o", 1))
         {
            NotAGreenMsg(o);

            return;
         }
         //print out that the occlusion was written
         CheckAndPrint(o, "_o");
         LockBitsSetup(o, "_g");
         //print out that the gloss was written
         CheckAndPrint(o, "_g");
         LockBitsSetup(o, "", 2);
         try
         {
            
         }
         catch
         {
            //IO error
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("");
            Console.WriteLine("==================================  ERROR  ============================");
            Console.WriteLine("Error trying to extract images from " + Path.GetFileName(o));
            Console.WriteLine("Make sure you don't have it open, and that it was a valid bitmap image.");
            Console.WriteLine("=======================================================================");
            Console.WriteLine("");
         }
         //print out that the spec was written
         CheckAndPrint(o, "");
      }
      /// <summary>
      /// Message for if the image is not a green
      /// </summary>
      /// <param name="o"></param>
      private static void NotAGreenMsg(string o)
      {
         Console.ForegroundColor = ConsoleColor.Red;
         //Console.WriteLine("");
         //Console.WriteLine("==================================  ERROR  ============================");
         Console.WriteLine("NOT A GREEN");
         //Console.WriteLine();
         //Console.WriteLine("=======================================================================");
         //Console.WriteLine("");
         Console.ForegroundColor = ConsoleColor.Gray;
      }
      /// <summary>
      /// Move the orignal green to an "originals" sub folder and do work from there
      /// </summary>
      /// <param name="o">The original path to image</param>
      /// <returns></returns>
      private static string MoveOriginal(string o)
      {
         if (File.Exists(o))
         {
            ImageInfo imi = new ImageInfo(o);            

            if (!Directory.Exists(imi.dirsubfold))
            {
               Directory.CreateDirectory(imi.dirsubfold);
            }
            if (File.Exists(o))
            {
               if (File.Exists(Path.Combine(imi.dirsubfold, imi.name + imi.ext)))
               {
                  File.Delete(Path.Combine(imi.dirsubfold, imi.name + imi.ext));
               }
               File.Move(o, Path.Combine(imi.dirsubfold, imi.name + imi.ext));
               MainViewModel.Instance.ConvertImage = Path.Combine(imi.dirsubfold, imi.name + imi.ext);
            }
            return Path.Combine(imi.dirsubfold, imi.name + imi.ext);
         }
         return o;
      }
      /// <summary>
      /// Check if the image was written, and if so, print so
      /// </summary>
      /// <param name="o"></param>
      /// <param name="v"></param>
      private static void CheckAndPrint(string o, string v)
      {
         ImageInfo imi = new ImageInfo(o, v);
         if (File.Exists(imi.mname))
         {
            if (v == "_o")
            {
               Console.WriteLine("");
               Console.WriteLine("Wrote to " + Path.GetDirectoryName(o) + ":");
            }
            Console.WriteLine("\t" + imi.name+v+imi.ext);
         }
      }
      /// <summary>
      /// Prepare to run the byte analyzer in AnalyzeIfGreen
      /// </summary>
      /// <param name="img">image path</param>
      /// <param name="suffix">this images suffix</param>
      /// <param name="offset">byte offset from index 0</param>
      /// <returns></returns>
      private static bool LockBitsSetup(string img, string suffix = "", int offset = 0)
      {
         string npath = img;
         if (!File.Exists(img))
         {
            ImageInfo imi = new ImageInfo(img);

            if (File.Exists(imi.nname))
            {
               img = imi.nname;
            }
         }
         return AnalyzeIfGreen(npath, img, suffix, offset);

      }
      /// <summary>
      /// Read and return if is a green and save the file if img is a green
      /// </summary>
      /// <param name="npath">the new path for the original</param>
      /// <param name="img">the image path to analyze</param>
      /// <param name="suffix">the suffix for this image</param>
      /// <param name="offset">which byte we will be grabbing indexed from 0</param>
      /// <returns></returns>
      private static bool AnalyzeIfGreen(string npath, string img, string suffix = "", int offset = 0)
      {
         int red = 0;
         int blue = 0;
         int green = 0;
         string savefile;
         Rectangle rect;
         BitmapData bmpData;
         IntPtr ptr;
         using (var bmp = new Bitmap(img))
         {
            // Lock the bitmap's bits.  
            rect = new Rectangle(0, 0, bmp.Width, bmp.Height);
            bmpData =
                bmp.LockBits(rect, ImageLockMode.ReadWrite,
                bmp.PixelFormat);

            // Get the address of the first line.
            ptr = bmpData.Scan0;

            // Declare an array to hold the bytes of the bitmap.
            int bytes = Math.Abs(bmpData.Stride) * bmp.Height;
            byte[] rgbValues = new byte[bytes];

            // Copy the RGB values into the array.
            System.Runtime.InteropServices.Marshal.Copy(ptr, rgbValues, 0, bytes);

            // Set every third value to 255. A 24bpp bitmap will look red.  
            for (int counter = 0; counter < rgbValues.Length - 4; counter += 4)
            {
               if (suffix == "_o")
               {
                  blue += rgbValues[counter];
                  green += rgbValues[counter + 1];
                  red += rgbValues[counter + 2];
               }
               rgbValues[counter] = rgbValues[counter + offset];
               rgbValues[counter + 1] = rgbValues[counter + offset];
               rgbValues[counter + 2] = rgbValues[counter + offset];
            }

            // Copy the RGB values back to the bitmap
            System.Runtime.InteropServices.Marshal.Copy(rgbValues, 0, ptr, bytes);

            // Unlock the bits.
            bmp.UnlockBits(bmpData);
            if (suffix == "_o")
            {
               
               if (blue == red && red == green && blue == green)
               {
                  //this is one of the sogs
                  Console.WriteLine(" - This is one of the SOG already exported");
                  return true;
               }
               if ((green / rgbValues.Length) < 50 || red >= green || blue >= green)
               {
                  //not a green but give me more info please
                  if ((green / rgbValues.Length) < 50) Console.WriteLine(" - Not enough green in this image to qualify as a green image");
                  if (red >= green) Console.WriteLine(" - There is more red than green in this image");
                  if (blue >= green) Console.WriteLine(" - There is more blue than green in this image");
                  
                  return true;
               }
                  
            }

            // image processing
           
            savefile = Path.Combine(Path.GetDirectoryName(npath), Path.GetFileNameWithoutExtension(npath) + suffix + Path.GetExtension(npath));
            bmp.Save(savefile);
            if (suffix == "_o")
            {
               MainViewModel.Instance.OConvertImage = savefile;
            }
            if (suffix == "_g")
            {
               MainViewModel.Instance.GConvertImage = savefile;
            }
            if (suffix == "")
            {
               MainViewModel.Instance.SConvertImage = savefile;
            }
         }
         if (suffix == "_o")
         {
            MoveOriginal(img);
         }
         return false;
      }
   }
   class ImageInfo
   {
      public string name { get; set; }
      public string dirname { get; set; }
      public string main { get; set; }
      public string ext { get; set; }
      public string dirsubfold { get; set; }
      public string nname { get; set; }
      public string mname { get; set; }

      /// <summary>
      /// Factor all the different names and paths I need
      /// </summary>
      /// <param name="img">path to the iamge</param>
      /// <param name="v">suffic for this image</param>
      public ImageInfo(string img, string v="")
      {
         this.name = Path.GetFileNameWithoutExtension(img);
         this.dirname = Path.GetDirectoryName(img);
         this.main = Path.Combine(dirname, name);
         this.ext = Path.GetExtension(img);
         this.dirsubfold = Path.Combine(dirname, "originals");
         this.nname = Path.Combine(dirsubfold, name + ext);
         this.mname = Path.Combine(dirname, name + v + ext);
      }
   }
}
