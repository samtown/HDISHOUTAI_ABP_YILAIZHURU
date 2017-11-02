using cn.jpush.api.push.mode;
using Dialysis.Common.Enum;
using System.Collections.Generic;

namespace Dialysis.Common
{
    public class JPushMessage : JPushBase
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="appTypeEnum">App类型枚举</param>
        /// <param name="key">key</param>
        /// <param name="tag">tag</param>
        /// <param name="content">content</param>
        /// <param name="value">value</param>
        public JPushMessage(AppTypeEnum appTypeEnum, int key, string tag, string content = "", string value = "", bool isDevModel = false)
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
        public JPushMessage(AppTypeEnum appTypeEnum, int key, IEnumerable<string> tags, string content = "", string value = "", bool isDevModel = false)
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
        public JPushMessage(AppTypeEnum appTypeEnum, int key, IEnumerable<int> tags, string content = "", string value = "", bool isDevModel = false)
            : base(appTypeEnum, key, tags, content, value, isDevModel)
        {
        }

        protected override void AddKeyContentAndExtras(PushPayload pushPayload)
        {
            pushPayload.message = Message.content(Content);
            pushPayload.message.AddExtras("key", Key);

            if (!string.IsNullOrEmpty(Value))
            {
                pushPayload.message.AddExtras("value", Value);
            }
        }
    }
}
