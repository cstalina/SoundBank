using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProiectDAW
{
    public partial class Recognize : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int[] array = {1,2,4,8,16,32,64,128,256,512,1024,2048,4096,8192,16384,65536,131072,262144,524288,1048576,2097152};
               

            double[] data;
            string path = @"C:\Users\Alina\Documents\Visual Studio 2012\Projects\ProiectDAW\ProiectDAW\DoubleArrays\myfile.txt";
            //   data =  File.ReadAllLines(path).Select(s => double.Parse(s).ToArray());
            data = File.ReadAllText(path)
                           .Split(new[] { " ", "\r\n", "\n" }, StringSplitOptions.RemoveEmptyEntries)
                           .Select(s => double.Parse(s, CultureInfo.GetCultureInfo("en-US"))).ToArray();
             int length = data.Length;
             if ((length & (length - 1)) != 0)
             {
                 length = array.OrderBy(x =>  length - (long)x ).First();
                 Array.Resize(ref data, length);
             }
            FFTClass wow = new FFTClass();
            wow.FFT(data, true);

        }


        protected void prepare(object sender, EventArgs e)
        {
           
            Double[] data;
            byte[] sR = new byte[4];
            using (BinaryReader br = new BinaryReader(FileUpload1.PostedFile.InputStream))
            {
                byte[] bytes = br.ReadBytes((int)FileUpload1.PostedFile.InputStream.Length);
                data = new Double[(bytes.Length - 44) / 4];//shifting the headers out of the PCM data;
                /***********Converting and PCM accounting***************/
                for (int i = 0; i < data.Length - i * 4; i++)
                {
                    data[i] = (BitConverter.ToInt32(bytes, (1 + i) * 4)) / 65536.0;
                    //65536.0.0=2^n,       n=bits per sample;
                }
                /**************assigning sample rate**********************/
                for (int i = 24; i < 28; i++)
                {
                    sR[i - 24] = bytes[i];
                }
                File.WriteAllLines(@"C:\Users\Alina\Documents\Visual Studio 2012\Projects\ProiectDAW\ProiectDAW\DoubleArrays\sample.txt", data.Select(d => d.ToString()).ToArray());
            }
        }


        protected void RecognizeSong(object sender, EventArgs e)
        {
         double[] data;
         string path = @"C:\Users\Alina\Documents\Visual Studio 2012\Projects\ProiectDAW\ProiectDAW\DoubleArrays\sample.txt";
       //   data =  File.ReadAllLines(path).Select(s => double.Parse(s).ToArray());
         data = File.ReadAllText(path)
                        .Split(new[] { " ", "\r\n", "\n" }, StringSplitOptions.RemoveEmptyEntries)
                        .Select(s => double.Parse(s, CultureInfo.GetCultureInfo("en-US"))).ToArray();
         FFTClass wow = new FFTClass();
         wow.FFT(data, true);
        }
    }
}