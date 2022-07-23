using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Security.Cryptography;

namespace Sorting_Algo_Visualizer
{
    public partial class FormMain : Form
    {

        Graphics g1;
        List<int> array1;
        List<int> arrayCopy;
        Bitmap bmpsave1;

        int middleSpacer;
        int leftSpacer;
        int rightSpacer;
        int bottomSpacer;
        int topSpacer;

        Thread thread1;

        static Random rng = new Random();
        public FormMain()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            cbAlgo.SelectedIndex = cbAlgo.Items.IndexOf("Bubble Sort");
            tbSamples.Value = 100;
            cbArr.SelectedIndex = cbArr.Items.IndexOf("Random Sample");
        }

        public void Shuffle<T>(IList<T> list)
        {
            int n = list.Count;
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                T value = list[k];
                list[k] = list[n];
                list[n] = value;
                //MessageBox.Show("Shuffle Successful");
            }
        }

        private void PrepareForSort()
        {
            bmpsave1 = new Bitmap(pbSort.Width, pbSort.Height);
            g1 = Graphics.FromImage(bmpsave1);

            pbSort.Image = bmpsave1;

            array1 = new List<int>(tbSamples.Value);

            for (int i = 0; i < array1.Capacity; i++)
            {
                int y = (int)((double)(i + 1) / array1.Capacity * pbSort.Height);
                array1.Add(y);
            }
        }

        private void bSort_Click(object sender, EventArgs e)
        {

            if (thread1 != null)
            {
                thread1.Abort();
                thread1.Join();
            }

            PrepareForSort();

            if (cbArr.SelectedItem.ToString() == "Random Sample")
            {
                Shuffle(array1);
            }
            else {
                array1.Reverse();
            }
            arrayCopy = array1;

            int sortSpeed = 1;
            for (int i = 0; i < tbSpeed.Value; i++)
            {
                sortSpeed *= 2;
            }

            string algo = "";

            if (cbAlgo.SelectedItem != null)
                algo = cbAlgo.SelectedItem.ToString();

            SortBot sa = new SortBot(array1, pbSort, sortSpeed);

            ThreadStart thread = delegate ()
            {
                switch (algo)
                {
                    case "Bubble Sort":
                        sa.BubbleSort(array1);
                        break;
                    case "Merge Sort":
                        sa.MergeSort(array1, 0, array1.Count - 1);
                        break;
                    case "QuickSort":
                        sa.QuickSort(array1, 0, array1.Count - 1);
                        break;
                    case "Selection Sort":
                        sa.SelectionSort(array1);
                        break;
                }


                sa.finishDrawing();

                if (!isSorted(array1))
                    MessageBox.Show("Sort Failed!");

            };

            if (algo != "")
            {
                thread1 = new Thread(thread);
                thread1.Start();
            }
        }

        private bool isSorted(List<int> list)
        {
            for (int i = 0; i < list.Count - 1; i++)
            {
                if (array1[i] != arrayCopy[i])
                    return false;
            }
            return true;
        }

        private void tbSamples_Scroll(object sender, EventArgs e)
        {
            label1.Text = "# of Samples: " + tbSamples.Value.ToString("n0");
        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            Environment.Exit(0);
        }
    }
}
