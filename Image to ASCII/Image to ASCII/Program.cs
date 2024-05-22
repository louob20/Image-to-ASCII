using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Image_to_ASCII
{
    class Program
    {
        static void Main(string[] args)
        {
            const int OUTPUT_WIDTH = 30;
            const int OUTPUT_HEIGHT = 15;
            const string chars = "@%#*+=-:. ";
            //const string chars = "$@B%8&WM#*oahkbdpqwmZO0QLCJUYXzcvunxrjft/\\|()1{}[]?-_+~<>i!lI;:,\"^`'. ";
            string filename = @"C:\Users\louie\Documents\Pictures\RR6M9JRr_400x400.jpg";
            //string filename = @"C:\Users\louie\Documents\Pictures\finger.jfif";
            Bitmap image = new Bitmap(filename);
            int groupWidth = image.Width / OUTPUT_WIDTH;
            int groupHeight = image.Height/ OUTPUT_HEIGHT;

            for (int y = 0; y < OUTPUT_HEIGHT; y++) // for every output character
            {
                for (int x = 0; x < OUTPUT_WIDTH; x++)
                {
                    double sum = 0;
                    int pixelY = y * groupHeight;
                    int endPixelY = pixelY + groupHeight;
                    for (pixelY = pixelY; pixelY < endPixelY && pixelY < image.Height; pixelY++) // for every pixel group
                    {
                        int pixelX = x * groupWidth;
                        int endPixelX = pixelX + groupWidth;
                        for (pixelX = pixelX; pixelX < endPixelX && pixelX < image.Width; pixelX++)
                        {
                            Color color = image.GetPixel(pixelX, pixelY);
                            sum += color.GetBrightness(); // so that 0 is completely black
                            //sum += (color.R + color.G + color.B) / (3*255); // get grayscale value
                        }
                    }
                    double averageBrightness = sum / (groupHeight * groupWidth);
                    char output = chars[(int)Math.Round((chars.Length - 1) * (averageBrightness))];
                    //Console.Write(averageBrightness + " ");
                    Console.Write(output.ToString().PadRight(1));
                }
                Console.WriteLine();
            }
            Console.ReadLine();
        }
    }
}
