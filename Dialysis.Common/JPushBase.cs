using cn.jpush.api;
using cn.jpush.api.common;
using cn.jpush.api.push;
using cn.jpush.api.push.mode;
using Dialysis.Common.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;

namespace Dialysis.Common
{
    public abstract class JPushBase
    {
        protected AppTypeEnum AppTypeEnum { get; set; }
        protected int Key { get; set; }
        protected HashSet<string> Tags { get; set; }
        protected string Content { get; set; }
        protected string Value { get; set; }
        protected bool IsDevModel { get; set; }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="appTypeEnum">App类型枚举</param>
        /// <param name="key">key</param>
        /// <param name="tag">tag</param>
        /// <param name="content">content</param>
        /// <param name="value">value</param>
        protected JPushBase(AppTypeEnum appTypeEnum, int key, string tag, string content = "", string value = "", bool isDevModel = false)
        {
            Tags = new HashSet<string>();   //初始化HashSet

            AppTypeEnum = appTypeEnum;
            Key = key;
            Tags.Add(tag);
            Content = content;
            Value = value;
            IsDevModel = isDevModel;
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="appTypeEnum">App类型枚举</param>
        /// <param name="key">key</param>
        /// <param name="tag">tag</param>
        /// <param name="content">content</param>
        /// <param name="value">value</param>
        protected JPushBase(AppTypeEnum appTypeEnum, int key, IEnumerable<string> tags, string content = "", string value = "", bool isDevModel = false)
        {
            AppTypeEnum = appTypeEnum;
            Key = key;
            Tags = new HashSet<string>(tags);
            Content = content;
            Value = value;
            IsDevModel = isDevModel;
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="appTypeEnum">App类型枚举</param>
        /// <param name="key">key</param>
        /// <param name="tag">tag</param>
        /// <param name="content">content</param>
        /// <param name="value">value</param>
        protected JPushBase(AppTypeEnum appTypeEnum, int key, IEnumerable<int> tags, string content = "", string value = "", bool isDevModel = false)
        {
            AppTypeEnum = appTypeEnum;
            Key = key;
            Tags = new HashSet<string>(tags.Select(t => t.ToString()));
            Content = content;
            Value = value;
            IsDevModel = isDevModel;
        }

        /// <summary>
        /// 创建JPushClient
        /// </summary>
        /// <returns>JPushClient</returns>
        private JPushClient[] CreateClient()
        {
            switch (AppTypeEnum)
            {
                case AppTypeEnum.All:
                    return new JPushClient[]
                    {
                        new JPushClient(CommConstant.JPushAppKeyDoctor, CommConstant.JPushMasterSecretDoctor),
                        new JPushClient(CommConstant.JPushAppKeyPatient, CommConstant.JPushMasterSecretPatient)
                    };
                case AppTypeEnum.Doctor:
                    return new JPushClient[]
                    {
                        new JPushClient(CommConstant.JPushAppKeyDoctor, CommConstant.JPushMasterSecretDoctor)
                    };
                case AppTypeEnum.Patient:
                    return new JPushClient[]
                    {
                        new JPushClient(CommConstant.JPushAppKeyPatient, CommConstant.JPushMasterSecretPatient)
                    };
                default:
                    return null;
            }
        }


        /// <summary>
        /// 发起推送
        /// </summary>
        /// <returns></returns>
        public bool SendPush()
        {
            JPushClient[] clients = CreateClient();
            foreach (var client in clients)
            {
                PushPayload pushPayload = new PushPayload();
                pushPayload.platform = Platform.android_ios();
                pushPayload.audience = Audience.s_tag(Tags);
                pushPayload.options = new Options { apns_production = !IsDevModel };

                AddKeyContentAndExtras(pushPayload);

                try
                {
                    MessageResult result = client.SendPush(pushPayload);

                    if (!result.isResultOK())
                    {
                        LogHelper.WriteInfo("JPush key:" + Key);
                        LogHelper.WriteInfo("JPush tag:" + Tags);
                        LogHelper.WriteInfo("JPush message error:" + result.ResponseResult);
                        return false;
                    }
                }
                catch (APIRequestException ex)
                {
                    //没有满足条件的推送目标，jpush发送了但是没发成功，也返回true
                    if (ex.Status == HttpStatusCode.BadRequest && ex.ErrorCode == 1011)
                    {
                        return true;
                    }
                }
                catch (Exception ex)
                {
                    LogHelper.WriteError("JPush异常", ex);
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// 添加Key、Content和Extras
        /// </summary>
        /// <param name="pushPayload"></param>
        protected virtual void AddKeyContentAndExtras(PushPayload pushPayload)
        {
        }
    }
}
