using System;
using System.Collections.Generic;
using System.Text;

namespace Dialysis.Dto.WebApi
{
    /// <summary>
    /// 食物详情
    /// </summary>
    public class FoodNutritionDto
    {
        /// <summary>
        /// 主键
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// 食品名称
        /// </summary>
        public string FoodName { get; set; }

        /// <summary>
        /// 食物类别
        /// </summary>
        public int FoodType { get; set; }

        /// <summary>
        /// Logo
        /// </summary>
        public string Logo { get; set; }

        /// <summary>
        /// 可食部分
        /// </summary>
        public int EdiblePart { get; set; }

        /// <summary>
        /// 能量
        /// </summary>
        public decimal Energy { get; set; }

        /// <summary>
        /// 水分
        /// </summary>
        public decimal Water { get; set; }

        /// <summary>
        /// 蛋白质
        /// </summary>
        public decimal PRO { get; set; }

        /// <summary>
        /// 脂肪
        /// </summary>
        public decimal Fat { get; set; }

        /// <summary>
        /// 膳食纤维
        /// </summary>
        public decimal DF { get; set; }

        /// <summary>
        /// 碳水化合物
        /// </summary>
        public decimal Carbohydrate { get; set; }

        /// <summary>
        /// 钠
        /// </summary>
        public decimal Na { get; set; }

        /// <summary>
        /// 钙
        /// </summary>
        public decimal Ca { get; set; }

        /// <summary>
        /// 铁
        /// </summary>
        public decimal Fe { get; set; }

        /// <summary>
        /// 钾
        /// </summary>
        public decimal K { get; set; }

        /// <summary>
        /// 磷
        /// </summary>
        public decimal P { get; set; }

        /// <summary>
        /// 肾病(0-可吃，1-少吃，2-不吃)
        /// </summary>
        public int Nephropathy { get; set; }

        /// <summary>
        /// 高血压(0-可吃，1-少吃，2-不吃)
        /// </summary>
        public int Hypertension { get; set; }

        /// <summary>
        /// 糖尿病(0-可吃，1-少吃，2-不吃)
        /// </summary>
        public int Diabetes { get; set; }
    }
}
