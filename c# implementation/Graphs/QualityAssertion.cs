using System;
using System.Collections.Generic;
using System.Drawing;

namespace Graphs
{
    public class QualityAssertion
    {
        public struct AssertionResults
        {
            public int CorrectObjectPixelsToTotalPixels;
            public int CorrectBackgroundPixelsToTotalPixels;
            public int AllCorrectPixelsToTotalPixels;
            public int JaccardMetric;
        }
        
        private readonly Bitmap subject;
        private readonly Bitmap ideal;
        private int correctObjectPixelsCount = 0;
        private int correctBackgroundPixelsCount = 0;
        private int totalObjectPixelsCount = 0;

        public QualityAssertion(Bitmap subject, Bitmap ideal)
        {
            this.subject = subject;
            this.ideal = ideal;
        }

        public AssertionResults GetQualityMetrics()
        {
            if (subject.Width != ideal.Width || subject.Height != ideal.Height)
            {
                throw new Exception("Bitmaps sizes are not equal.");
            }

            for (var i = 0; i < subject.Width; i++)
            {
                for (var j = 0; j < subject.Height; j++)
                {
                    var intensity = (int)(subject.GetPixel(i, j).GetBrightness() * 255);
                    var qualityIntensity = (int)(ideal.GetPixel(i, j).GetBrightness() * 255);

                    if (intensity > 0 && qualityIntensity > 0)
                    {
                        correctObjectPixelsCount += 1;
                    }

                    if (intensity > 0 || qualityIntensity > 0)
                    {
                        totalObjectPixelsCount += 1;
                    }

                    if (intensity == 0 && qualityIntensity == 0)
                    {
                        correctBackgroundPixelsCount += 1;
                    }
                }
            }

            var firstObjectMetric = GetObjectFirstMetric();
            var firstBackgroundMetric = GetBackgroundFirstMetric();
            var firstMetric = GetFirstMetric();
            var jaccardMetric = GetJaccardMetric();

            return new AssertionResults
            { 
                CorrectObjectPixelsToTotalPixels = (int)(firstObjectMetric * 100),
                CorrectBackgroundPixelsToTotalPixels = (int)(firstBackgroundMetric * 100),
                AllCorrectPixelsToTotalPixels = (int)(firstMetric * 100),
                JaccardMetric = (int)(jaccardMetric * 100),
            };
        }

        private double GetObjectFirstMetric()
        {
            return (double)correctObjectPixelsCount / (subject.Width * subject.Height);
        }

        private double GetBackgroundFirstMetric()
        {
            return (double)correctBackgroundPixelsCount / (subject.Width * subject.Height);
        }

        private double GetFirstMetric()
        {
            return (double)(correctObjectPixelsCount + correctBackgroundPixelsCount) / (subject.Width * subject.Height);
        }

        private double GetJaccardMetric()
        {
            return (double)correctObjectPixelsCount / totalObjectPixelsCount;
        }
    }
}
