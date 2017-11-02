using cn.jpush.api.push.mode;
using cn.jpush.api.push.notification;
using Dialysis.Common.Enum;
using System.Collections.Generic;

namespace Dialysis.Common
{
    public class JPushNotification : JPushBase
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="appTypeEnum">App类型枚举</param>
        /// <param name="key">key</param>
        /// <param name="tag">tag</param>
        /// <param name="content">content</param>
        /// <param name="value">value</param>
        public JPushNotification(AppTypeEnum appTypeEnum, int key, string tag, string content = "", string value = "", bool isDevModel = false)
            : base(appTypeEnum, key, tag, content, value, isDevModel)
        {

        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="appTypeEnum">App类型枚举</param>
        /// <param name="key">key</param>
        /// <param name="tag">tag</param>
        /// <param name="content">content</param>
        /// <param name="value">value</param>
        public JPushNotification(AppTypeEnum appTypeEnum, int key, IEnumerable<string> tags, string content = "", string value = "", bool isDevModel = false)
            : base(appTypeEnum, key, tags, content, value, isDevModel)
        {

        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="appTypeEnum">App类型枚举</param>
        /// <param name="key">key</param>
        /// <param name="tag">tag</param>
        /// <param name="content">content</param>
        /// <param name="value">value</param>
        public JPushNotification(AppTypeEnum appTypeEnum, int key, IEnumerable<int> tags, string content = "", string value = "", bool isDevModel = false)
            : base(appTypeEnum, key, tags, content, value, isDevModel)
        {

        }

        protected override void AddKeyContentAndExtras(PushPayload pushPayload)
        {
            pushPayload.notification = new Notification();
            pushPayload.notification.setAlert(Content);
            var androidNotification = new AndroidNotification().AddExtra("key", Key);
            var iosNotification = new IosNotification().AddExtra("key", Key);

            if (!string.IsNullOrEmpty(Value))
            {
                androidNotification.AddExtra("value", Value);
                iosNotification.AddExtra("value", Value);
            }
            pushPayload.notification.setAndroid(androidNotification).setIos(iosNotification);
        }
    }
}
