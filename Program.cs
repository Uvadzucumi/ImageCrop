using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Formats.Png;
using SixLabors.ImageSharp.Processing;

namespace ImageCrop
{
    class Program
    {
        static void Main(string[] args)
        {

            if (args.Length > 0)
            {
                String sourceFileName = args[0];
                Console.WriteLine($"image_file: {sourceFileName}");

                try
                {
                    using (Image image = Image.Load(sourceFileName))
                    {

                        // check width & height
                        int w = image.Width;
                        int h = image.Height;

                        if (w == h)
                        {
                            Console.WriteLine("not required crop image: " + sourceFileName + " (" + w + "x" + h + ")");
                            return;
                        }

                        if (w < h)
                        {
                            Console.WriteLine("ERROR: Only if image width > image height");
                            return;
                        }

                        if(w % h!=0)
                        {
                            Console.WriteLine("ERROR:" + sourceFileName + " Not virtual texture image!");
                            return;
                        }

                        int images_count = w / h;
                        var encoder = new PngEncoder
                        {
                            CompressionLevel = PngCompressionLevel.Level6
                        };
                        string nameOnly = Path.GetFileNameWithoutExtension(sourceFileName);

                        for (int idx = 0; idx < images_count; idx++){
                            using (Image currentImage = image.Clone(ctx => ctx.Crop(new Rectangle(idx*h, 0, h, h))))
                            {
                                currentImage.Save(nameOnly + "_1"+(idx+1).ToString("D3")+".png", encoder);
                            }
                        }

                    }

                }
                catch (Exception ex)
                {
                    Console.WriteLine($"An unexpected error occurred: {ex.Message}");
                }
            }
            else
            {
                Console.WriteLine("Required image file name");
            }
        }
    }
}