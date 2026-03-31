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

                        if (w == 4096 && h == 2048)
                        {
                            int halfWidth = w / 2;
                            int height = 2048;

                            var encoder = new PngEncoder
                            {
                                CompressionLevel = PngCompressionLevel.Level6
                            };

                            string nameOnly = Path.GetFileNameWithoutExtension(sourceFileName);

                            // left side
                            using (Image leftPart = image.Clone(ctx => ctx.Crop(new Rectangle(0, 0, halfWidth, height))))
                            {
                                leftPart.Save(nameOnly + "_1001.png", encoder);
                            }

                            // right side
                            using (Image rightPart = image.Clone(ctx => ctx.Crop(new Rectangle(halfWidth, 0, halfWidth, height))))
                            {
                                rightPart.Save(nameOnly + "_1002.png", encoder);
                            }

                            Console.WriteLine("Done! Two 2048x2048 images created.");

                        }
                        else
                        {
                            Console.WriteLine("Error: Found image: " + w + "x" + h + ". required 4096x2048 size!");
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
                Console.WriteLine($"Required image file name");
            }
        }
    }
}