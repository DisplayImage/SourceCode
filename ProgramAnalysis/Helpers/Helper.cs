using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProgramAnalysis.Helpers
{
	public class Helper
	{
	}
    public class Location
    {
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public double Distance { get; set; }
    }
    public class ImageInfoMark
    {
        public bool IsImgReal { get; set; }
        public int Result { get; set; }
        public double Rate { get; set; }
        public double RunningTime { get; set; }
        public string ErrorDesc { get; set; }

        public ImageInfoMark()
        {
            this.IsImgReal = false;
            this.ErrorDesc = string.Empty;
        }

    }
    public class MatLabConfig
    {
        public MLApp.MLApp MatlabObj = new MLApp.MLApp();
        public string matlabFuncPath { get; set; }
        public string matlabDataPath { get; set; }
        private string BagPath { get; set; }
        private string MeanMhistRGBPath { get; set; }
        private string RealSamplePath { get; set; }
        private string VLFeatLibPath { get; set; }
        private string ProductImagePath { get; set; }

        public MatLabConfig()
        {
            this.matlabFuncPath = Utility.pathMatlab + "AutoEvaluationFunction";
            this.matlabDataPath = Utility.pathMatlab + "AutoEvaluationData";
            this.BagPath = matlabDataPath + "\\Bag.mat";
            this.MeanMhistRGBPath = matlabDataPath + "\\MeanMhistRGB.mat";
            this.RealSamplePath = matlabDataPath + "\\RealImage_Sample.jpg";
            this.VLFeatLibPath = matlabDataPath + "\\VLFeat_Lib\\toolbox\\vl_setup.m";
            this.ProductImagePath = matlabDataPath + "\\SuaHop_Sample.jpg";
            //this.ProductImagePath = matlabDataPath + "\\sanpham1.jpg";

            this.MatlabObj.Execute("clc; clear");
            this.MatlabObj.Execute("cd " + matlabFuncPath);

        }

        public ImageInfoMark ImageReal(string ImagePath)
        {
            ImageInfoMark info = new ImageInfoMark();
            object output;
            object[] result;
            MatlabObj.Feval("CheckRealImage", 4, out output, ImagePath, BagPath, MeanMhistRGBPath, RealSamplePath);
            result = output as object[];

            info.Result = Convert.ToInt16(result[0]);
            if (info.Result == 1)
            {
                info.IsImgReal = true;
            }
            info.Rate = Convert.ToDouble(result[1]);
            info.RunningTime = Convert.ToDouble(result[2]);
            info.ErrorDesc = Convert.ToString(result[3]);
            //Console.WriteLine("CheckRealImage: \n\t Ket Qua That Gia : " + Result + "\n\t Thoi Gian Chay :" + RunningTime + "\n\t Trang Thai Loi : " + ErrorDesc);
            return info;
        }
        public ImageInfoMark ItemExistImage(string ImagePath, string ItemInImage = "")
        {
            ImageInfoMark info = new ImageInfoMark();
            object output;
            object[] result;
            MatlabObj.Feval("CheckProductImage", 4, out output, ImagePath, ProductImagePath);
            result = output as object[];

            info.Result = Convert.ToInt16(result[0]);
            if (info.Result == 1)
            {
                info.IsImgReal = true;
            }
            info.Rate = Convert.ToDouble(result[1]);
            info.RunningTime = Convert.ToDouble(result[2]);
            info.ErrorDesc = Convert.ToString(result[3]);
            //Console.WriteLine("CheckRealImage: \n\t Ket Qua That Gia : " + Result + "\n\t Thoi Gian Chay :" + RunningTime + "\n\t Trang Thai Loi : " + ErrorDesc);
            return info;
        }
    }
}