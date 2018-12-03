/******************************************************************
* 项目名称 ：Mir.Commons.Aliyun 
* 项目描述 ： 
* 类 名 称 ：AliyunOSS 
* 类 描 述 ： 
* CLR 版本 ：4.0.30319.42000 
* 版权所有 ：袁振峰
* 联系方式 ：http://www.ustuy.com/ 
******************************************************************/
using AspNetCore.Aliyun.OSS;
using System;
using System.IO;

namespace Mir.Commons.Aliyun
{
    /// <summary>
    /// 
    /// </summary>
    public class AliyunOSS
    {
        public string AccessKeyID { get; set; }
        public string AccessKeySecret { get; set; }
        public string BucketName { get; set; }
        public string EndPoint { get; set; }
        public AliyunOSS(string accessKeyID, string accessKeySecret, string bucketName, string endPoint)
        {
            AccessKeyID = accessKeyID;
            AccessKeySecret = accessKeySecret;
            BucketName = bucketName;
            EndPoint = endPoint;
        }

        /// <summary>
        /// 上传文件
        /// </summary>
        /// <param name="fileName">文件名：/images/demo.jpg</param>
        /// <param name="fileStream"></param>
        public void Upload(string fileName, Stream fileStream)
        {

            OssClient ossClient = new OssClient(EndPoint, AccessKeyID, AccessKeySecret);
            ObjectMetadata metadata = new ObjectMetadata
            {
                //根据文件名设置ContentType
                ContentType = GetContentType(fileName)
            };
            string key = "MerLogo/" + fileName;
            fileStream.Seek(0, SeekOrigin.Begin);
            PutObjectResult result = ossClient.PutObject(BucketName, key, fileStream, metadata);
        }


        /// <summary>
        /// 上传文件
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="fileStream"></param>
        /// <param name="dir"></param>
        /// <returns>返回存储后文件路径</returns>
        public string Upload(string fileName, Stream fileStream, string dir)
        {

            OssClient ossClient = new OssClient(EndPoint, AccessKeyID, AccessKeySecret);
            ObjectMetadata metadata = new ObjectMetadata
            {
                //根据文件名设置ContentType
                ContentType = GetContentType(fileName)
            };

            string fileext = fileName.Split('.')[1];
            fileName = Guid.NewGuid() + "." + fileext;

            string key = dir + fileName;
            fileStream.Seek(0, SeekOrigin.Begin);
            PutObjectResult result = ossClient.PutObject(BucketName, key, fileStream, metadata);
            return dir + fileName;
        }


        private string GetContentType(string fileName)
        {
            string[] fileNameArray = fileName.Split('.');
            string contentType = string.Empty;
            if (fileNameArray.Length >= 2)
            {
                switch (fileNameArray[1])
                {
                    case "gif":
                        contentType = "image/gif";
                        break;
                    case "png":
                        contentType = "image/png";
                        break;
                    case "jpg":
                        contentType = "image/jpg";
                        break;
                    case "rar":
                        contentType = "application/octet-stream";
                        break;
                    case "zip":
                        contentType = "application/zip";
                        break;
                    default:
                        break;
                }
            }
            return contentType;
        }
    }
}
