![http://iplab.googlecode.com/svn/wiki/Images/banner.gif](http://iplab.googlecode.com/svn/wiki/Images/banner.gif)


**[Image Processing Lab](http://www.aforgenet.com/projects/iplab/)** is an image processing application written in C#, which includes different filters and tools to analyze images available in [AForge.NET Framework](http://www.aforgenet.com/framework/).

![http://iplab.googlecode.com/svn/wiki/Images/iplab.jpg](http://iplab.googlecode.com/svn/wiki/Images/iplab.jpg)

The following filters are available in the IPLab application:
  * Color filters (grayscale, sepia, invert, rotate, channel extraction, channel replacing, channel filtering, color filtering, Euclidean color filtering);
  * HSL filters (linear correction, brightness, contrast, saturation, hue modifier, HSL filtering);
  * YCbCr filters (linear correction, YCbCr filtering, channel extraction/replacement);
  * Binarization filters (threshold, threshold with carry, ordered dithering, Bayer dithering, Floyd-Steinberg, Burkes, Jarvis-Judice-Ninke, Sierra, Stevenson-Arce, Stucki dithering methods);
  * Automatic binarization (simple image statistics);
  * Mathematical morphology filters (erosion, dilatation, opening, closing, hit & miss, thinning, thickening);
  * Convolution filters (mean, blur, sharpen, edges, Gaussian);
  * 2 Source filters (merge, intersect, add, subtract, difference, move towards, morph);
  * Edge detectors (homogeneity, difference, sobel, canny);
  * Blob counter, Connected components labeling;
  * Pixellate, Simple skeletonization, Jitter, Shrink, Oil painting;
  * Levels linear filter, gamma correction;
  * Median filter, Adaptive smoothing, Conservative smoothing;
  * Resize and Rotate;
  * Texture generators based on Perlin noise;
  * Texture filters (texturer, textured filtering, textured merging);
  * Fourier transformation (low-pass and hi-pass filters).

It is possible to create (save and load) your own convolution filters or filters based on standard mathematical morphology operators. Colorized grid makes it very convenient to work with custom convolution filters.

A preview window allows to view results of changing filters' parameters on the fly. It is possible to scroll an image using mouse in preview area. All filters are applied only to the portion of image currently viewed to speed up preview.

A Photo Shop like histogram allows to get information about mean, standard deviation, median, minimum and maximum values.

The application allows to copy to or paste from clipboard, save and print images.