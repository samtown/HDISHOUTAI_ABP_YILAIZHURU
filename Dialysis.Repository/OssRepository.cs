using Cuiliang.AliyunOssSdk;
using Cuiliang.AliyunOssSdk.Entites;
using Cuiliang.AliyunOssSdk.Request;
using Dialysis.Common;
using Dialysis.Domain;
using Microsoft.Extensions.Options;
using System;
using System.IO;
using System.Threading.Tasks;

namespace Dialysis.Repository
{
    public class OssRepository
    {
        private readonly MyOptions _optionsAccessor;
        private readonly OssClient _client;

        public OssRepository(IOptions<MyOptions> optionsAccessor)
        {
            _optionsAccessor = optionsAccessor.Value;
            _client = new OssClient(new OssCredential
            {
                AccessKeyId = CommConstant.OssAccessKeyId,
                AccessKeySecret = CommConstant.OssAccessKeySecret
            });
        }

        /// <summary>
        /// 上传患者头像
        /// </summary>
        /// <param name="id">患者Id</param>
        /// <param name="buffer">头像</param>
        /// <returns></returns>
        public async Task<string> UploadPatientAvatar(long id, byte[] buffer)
        {
            var fileName = string.Format("{0}-{1}.{2}", id.ToString(), DateTime.Now.ToString(CommConstant.FullTimeFormatString), "jpg");
            var key = _optionsAccessor.OssPatientDir + CommConstant.OssAvatarDir + fileName;
            var mimeType = GetContentTypeBySuffix(Path.GetExtension(fileName));
            using (var stream = new MemoryStream(buffer))
            {
                return await PutObject(stream, key, mimeType);
            }
        }

        /// <summary>
        /// 上传文件
        /// </summary>
        /// <param name="stream">文件流</param>
        /// <returns>Oss文件地址</returns>
        private async Task<string> PutObject(Stream stream, string key, string mimeType)
        {
            var bucketInfo = BucketInfo.CreateByRegion(CommConstant.OssRegion, CommConstant.OssBucket);
            var requestContent = new RequestContent
            {
                ContentType = RequestContentType.Stream,
                StreamContent = stream,
                MimeType = mimeType
            };

            var result = await _client.PutObjectAsync(bucketInfo, key, requestContent);
            if (!result.IsSuccess)
            {
                var message = string.Format("ErrorMessage:{0}", result.ErrorMessage);
                if (result.ErrorResult != null)
                {
                    message += string.Format("{0}HostId:{1}{2}RequestId:{3}{4}Code:{5}{6}Message:{7}{8}", Environment.NewLine,
                       result.ErrorResult.HostId, Environment.NewLine,
                       result.ErrorResult.RequestId, Environment.NewLine,
                       result.ErrorResult.Code, Environment.NewLine,
                       result.ErrorResult.Message, Environment.NewLine
                     );
                }
                LogHelper.WriteError(message, result.InnerException);
                return string.Empty;
            }
            return key;
        }

        /// <summary>
        /// 根据文件后缀名获取ContentType
        /// </summary>
        /// <param name="suffix">文件后缀名</param>
        /// <returns>ContentType</returns>
        private string GetContentTypeBySuffix(string suffix)
        {
            switch (suffix)
            {
                case ".jpg":
                    return "image/jpeg";
                case ".png":
                    return "image/png";
                case ".bmp":
                    return "application/x-bmp";
                case ".gif":
                    return "image/gif";
                default:
                    return "application/octet-stream";
            }
        }
    }
}
