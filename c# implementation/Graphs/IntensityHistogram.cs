using System;
using System.Drawing;
using System.Linq;

namespace Graphs
{
    class IntensityHistogram
    {
        private int[] histogram;
        private int totalPixelsCount;

        public int AverageIntensity { get; private set; }

        public int AverageBackgroundIntensity { get; private set; }

        public int AverageObjectIntensity { get; private set; }

        public IntensityHistogram(Bitmap bitmap)
        {
            totalPixelsCount = bitmap.Width * bitmap.Height;
            histogram = new int[256];

            int totalIntensity = 0;

            for (var i = 0; i < bitmap.Width; i++)
            {
                for (var j = 0; j < bitmap.Height; j++)
                {
                    var intensity = bitmap.GetPixel(i, j).GetBrightness();
                    int normalizedIntensity = (int)(intensity * 255);

                    totalIntensity += normalizedIntensity;

                    histogram[normalizedIntensity] += 1;
                }
            }

            AverageIntensity = (int)Math.Round((double)totalIntensity / totalPixelsCount);

            GetDefaultSeedsValues();
        }

        public IntensityHistogram(double[] intensities)
        {
            totalPixelsCount = intensities.Length;

            histogram = new int[256];

            var totalIntensity = 0;

            for (var i = 0; i < intensities.Length; i++)
            {
                var intensity = (int)(intensities[i] * 255);

                totalIntensity += intensity;

                histogram[intensity] += 1;
            }

            AverageIntensity = (int)Math.Round((double)totalIntensity / totalPixelsCount);
        }

        public double GetIntensityProbability(int intensity)
        {
            return (double)histogram[intensity] / totalPixelsCount;
        }

        public override string ToString()
        {
            var str = "";

            for (var i = 0; i < histogram.Length; i++)
            {
                str += i + ":" + histogram[i] + " ";
            }

            return str;
        }

        private void GetDefaultSeedsValues()
        {
            AverageBackgroundIntensity = 0;
            AverageObjectIntensity = 0;
            
            int[] backwardIndexMap = new int[256];

            for (var i = 0; i < 256; i++)
            {
                backwardIndexMap[i] = i;
            }

            var sortedHistogram = QuickSort(histogram.ToArray(), backwardIndexMap);

            int maxDiff = 0;
            int maxDiffIndex = -1;

            for (var i = 0; i < 255; i++)
            {
                var diff = sortedHistogram[i + 1] - sortedHistogram[i];

                if (maxDiff < diff)
                {
                    maxDiff = diff;
                    maxDiffIndex = i;
                }
            }

            int backgroundIntensityPartitionLength = 0;
            int objectIntensityPartitionLength = 0;
            bool isLeftPartitionSmaller = maxDiffIndex < 127;

            for (var i = 0; i < 256; i++)
            {
                if (histogram[backwardIndexMap[i]] > 0)
                {
                    if (isLeftPartitionSmaller)
                    {
                        if (i < maxDiffIndex)
                        {
                            AverageBackgroundIntensity += backwardIndexMap[i];
                            backgroundIntensityPartitionLength += 1;
                        }
                        else
                        {
                            AverageObjectIntensity += backwardIndexMap[i];
                            objectIntensityPartitionLength += 1;
                        }
                    }
                    else
                    {
                        if (i < maxDiffIndex)
                        {
                            AverageObjectIntensity += backwardIndexMap[i];
                            objectIntensityPartitionLength += 1;
                        }
                        else
                        {
                            AverageBackgroundIntensity += backwardIndexMap[i];
                            backgroundIntensityPartitionLength += 1;
                        }
                    }
                }
            }

            AverageBackgroundIntensity = (int)Math.Round((double)(AverageBackgroundIntensity / backgroundIntensityPartitionLength));
            AverageObjectIntensity = (int)Math.Round((double)(AverageObjectIntensity / objectIntensityPartitionLength));
        }

        private static void Swap(ref int x, ref int y)
        {
            var t = x;
            x = y;
            y = t;
        }

        private static int Partition(int[] array, int minIndex, int maxIndex, int[] indexMap)
        {
            var pivot = minIndex - 1;
            for (var i = minIndex; i < maxIndex; i++)
            {
                if (array[i] < array[maxIndex])
                {
                    pivot++;
                    Swap(ref indexMap[pivot], ref indexMap[i]);
                    Swap(ref array[pivot], ref array[i]);
                }
            }

            pivot++;
            Swap(ref indexMap[pivot], ref indexMap[maxIndex]);
            Swap(ref array[pivot], ref array[maxIndex]);
            return pivot;
        }

        private static int[] QuickSort(int[] array, int minIndex, int maxIndex, int[] indexMap)
        {
            if (minIndex >= maxIndex)
            {
                return array;
            }

            var pivotIndex = Partition(array, minIndex, maxIndex, indexMap);
            QuickSort(array, minIndex, pivotIndex - 1, indexMap);
            QuickSort(array, pivotIndex + 1, maxIndex, indexMap);

            return array;
        }

        private static int[] QuickSort(int[] array, int[] indexMap)
        {
            return QuickSort(array, 0, array.Length - 1, indexMap);
        }
    }
}
