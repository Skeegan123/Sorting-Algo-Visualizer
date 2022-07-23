using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace Sorting_Algo_Visualizer
{
    internal class SortBot
    {
        List<int> arrayToSort;
        Graphics g;
        Bitmap bmpsave;
        PictureBox pnlSamples;
        int imgCount;

        int operationsPerFrame; // operations per frame
        int frameMS; // time between frames (aim for 40 ms = 25 fps)
        int operationCount;
        Dictionary<int, bool> highlightedIndexes = new Dictionary<int, bool>(); // highlight all of these indexes in the frame
        DateTime nextFrameTime;
        int originalPanelHeight;

        static Random rand = new Random();

        public SortBot(List<int> list, PictureBox pic, int s)
        {
            imgCount = 0;
            arrayToSort = list;
            pnlSamples = pic;

            operationCount = 0;
            operationsPerFrame = s;
            frameMS = 1000; // so now operationsPerFrame is operations per second

            // reduce the frame wait for better visuals (increased frame rate)
            while (frameMS >= 40 && operationsPerFrame > 1)
            {
                operationsPerFrame = operationsPerFrame / 2;
                frameMS = frameMS / 2;
            }

            bmpsave = new Bitmap(pnlSamples.Width, pnlSamples.Height);
            g = Graphics.FromImage(bmpsave);
            originalPanelHeight = pnlSamples.Height;
            pnlSamples.Image = bmpsave;
            nextFrameTime = DateTime.UtcNow;

            CheckForFrame();
        }

        public IList<int> BubbleSort(IList<int> arr) {
            int size = arr.Count();
            bool swapMade = false;

            for (int i = 0; i < size - 1; i++) {
                swapMade = false;
                for (int j = 0; j < (size - i - 1); j++) {
                    if (CompareItems(arr, j, j + 1) > 0) {
                        SwapItems(arr, j, j + 1);
                        swapMade = true;
                    }
                }
                if (!swapMade) {
                    break;
                }
            }
            return arr;
        }

        public IList<int> SelectionSort(IList<int> arr)
        {
            int size = arr.Count;
            int minIndex;

            for (int i = 0; i < size; i++)
            {
                minIndex = i;
                for (int j = i + 1; j < size; j++)
                {
                    if (CompareItems(arr, j, minIndex) < 0)
                    {
                        minIndex = j;
                    }
                }
                if (minIndex > i)
                {
                    SwapItems(arr, i, minIndex);
                }
            }
            return arr;
        }

        public IList<int> MergeSort(IList<int> arr, int left, int right)
        {
            if (left >= right) {
                return arr;
            }

            int mid = left + (right - left) / 2;
            arr = MergeSort(arr, left, mid);
            arr = MergeSort(arr, mid + 1, right);

            int arr1Len = mid - left + 1;
            int arr2Len = right - mid;

            List<int> lArr = new List<int>();
            List<int> rArr = new List<int>();

            for (int i = 0; i < arr1Len; i++)
            {
                lArr.Add(arr[left + i]);
            }
            for (int j = 0; j < arr2Len; j++)
            {
                rArr.Add(arr[mid + 1 + j]);
            }

            int lIndex = 0;
            int rIndex = 0;
            int mergedIndex = left;

            while (lIndex < arr1Len && rIndex < arr2Len)
            {
                if (GetItem(lArr, lIndex) <= GetItem(rArr, rIndex))
                {
                    arr = SetItem(arr, mergedIndex, GetItem(lArr, lIndex));
                    lIndex++;
                }
                else
                {
                    arr = SetItem(arr, mergedIndex, GetItem(rArr, rIndex));
                    rIndex++;
                }
                mergedIndex++;
            }

            while (lIndex < arr1Len)
            {
                arr = SetItem(arr, mergedIndex, GetItem(lArr, lIndex));
                lIndex++;
                mergedIndex++;
            }

            while (rIndex < arr2Len)
            {
                arr = SetItem(arr, mergedIndex, GetItem(rArr, rIndex));
                rIndex++;
                mergedIndex++;
            }

            rArr.Clear();
            lArr.Clear();

            return arr;
        }
        
        public IList<int> QuickSort(IList<int> arr, int left, int right)
        {
            if (left < right)
            {
                int pIndex = Partition(ref arr, left, right);

                arr = QuickSort(arr, left, pIndex - 1);
                arr = QuickSort(arr, pIndex + 1, right);
            }
            return arr;            
        }

        //Partition function for quickSort
        public int Partition(ref IList<int> arr, int left, int right)
        {
            int pivot = GetItem(arr, right);
            int i = left - 1;
            for (int j = left; j < right; j++)
            {
                if (GetItem(arr, j) <= pivot)
                {
                    i++;
                    SwapItems(arr, i, j);
                }
            }
            SwapItems(arr, i + 1, right);
            return i + 1;
        }

        public int GetItem(IList<int> arr, int index) {

            if (!highlightedIndexes.ContainsKey(index))
                highlightedIndexes.Add(index, false);

            operationCount++;
            CheckForFrame();

            return arr[index];
        }

        public IList<int> SetItem(IList<int> arr, int toIndex, int val) { 

            arr[toIndex] = val;

            if (!highlightedIndexes.ContainsKey(toIndex))
                highlightedIndexes.Add(toIndex, false);
            
            operationCount++;
            CheckForFrame();

            return arr;
        }

        public int CompareItems(IList<int> arr, int i, int j) {
            if (!highlightedIndexes.ContainsKey(i))
                highlightedIndexes.Add(i, false);
            if (!highlightedIndexes.ContainsKey(j))
                highlightedIndexes.Add(j, false);

            operationCount++;
            CheckForFrame();

            return arr[i].CompareTo(arr[j]);
        }

        private void SwapItems(IList<int> arrayToSort, int index1, int index2)
        {
            int temp = arrayToSort[index1];
            arrayToSort[index1] = arrayToSort[index2];
            arrayToSort[index2] = temp;

            if (!highlightedIndexes.ContainsKey(index1))
                highlightedIndexes.Add(index1, false);
            if (!highlightedIndexes.ContainsKey(index2))
                highlightedIndexes.Add(index2, false);

            operationCount += 2;
            CheckForFrame();
        }

        delegate void SetControlValueCallback(Control pnlSort);

        private void RefreshPanel(Control pnlSort)
        {
            if (pnlSort.InvokeRequired)
            {
                SetControlValueCallback d = new SetControlValueCallback(RefreshPanel);
                try
                {
                    pnlSort.Invoke(d, new object[] { pnlSort });
                }
                catch { 
                    Exception e;
                    Environment.Exit(0);
                }
            }
            else
            {
                pnlSort.Refresh();
            }
        }

        public void DrawSamples()
        {
            // might need to grow or shrink if size is different from original (can't change array!)
            double multiplyHeight = 1;

            // check if need to change size
            if (bmpsave.Width != pnlSamples.Width || bmpsave.Height != pnlSamples.Height)
            {
                bmpsave = new Bitmap(pnlSamples.Width, pnlSamples.Height);
                g = Graphics.FromImage(bmpsave);
                pnlSamples.Image = bmpsave;
            }

            if (pnlSamples.Height != originalPanelHeight)
            {
                multiplyHeight = (double)(pnlSamples.Height) / (double)(originalPanelHeight);
            }

            // start with white background
            g.Clear(Color.White);

            // use black sometimes
            Pen pen = new Pen(Color.Black);
            SolidBrush b = new SolidBrush(Color.Black);

            // use red sometimes
            Pen redPen = new Pen(Color.Red);
            SolidBrush redBrush = new SolidBrush(Color.Red);

            // draw a nice width based on number of elements
            int w = (pnlSamples.Width / arrayToSort.Count) - 1;

            for (int i = 0; i < this.arrayToSort.Count; i++)
            {
                int x = (int)(((double)pnlSamples.Width / arrayToSort.Count) * i);

                int itemHeight = (int)Math.Round(Convert.ToDouble(arrayToSort[i]) * multiplyHeight);

                // draw highlighed versions
                if (highlightedIndexes.ContainsKey(i))
                {
                    if (w <= 1)
                    {
                        g.DrawLine(redPen, new Point(x, pnlSamples.Height), new Point(x, (int)(pnlSamples.Height - itemHeight)));
                    }
                    else
                    {
                        g.FillRectangle(redBrush, x, pnlSamples.Height - itemHeight, w, pnlSamples.Height);
                    }
                }
                else // draw normal versions
                {
                    if (w <= 1)
                    {
                        g.DrawLine(pen, new Point(x, pnlSamples.Height), new Point(x, (int)(pnlSamples.Height - itemHeight)));
                    }
                    else
                    {
                        g.FillRectangle(b, x, pnlSamples.Height - itemHeight, w, pnlSamples.Height);
                    }
                }
            }
        }

        private void CheckForFrame()
        {
            if (operationCount >= operationsPerFrame || nextFrameTime <= DateTime.UtcNow)
            {
                // time to draw a new frame and wait
                DrawSamples();
                RefreshPanel(pnlSamples);

                // prepare for next frame
                highlightedIndexes.Clear();
                operationCount -= operationsPerFrame; // if there were more operations than needed, don't just forget those

                if (DateTime.UtcNow < nextFrameTime)
                {
                    Thread.Sleep((int)((nextFrameTime - DateTime.UtcNow).TotalMilliseconds));
                }
                nextFrameTime = nextFrameTime.AddMilliseconds(frameMS);
            }
        }

        public void finishDrawing()
        {
            if (highlightedIndexes.Count > 0)
            {
                // put one last frame in before the end
                nextFrameTime = DateTime.UtcNow;
                CheckForFrame();
            }

            // draw the last frame
            nextFrameTime = DateTime.UtcNow;
            CheckForFrame();
        }
    }
}
