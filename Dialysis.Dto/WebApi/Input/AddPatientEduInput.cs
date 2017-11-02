using System;
using System.Collections.Generic;
using System.Text;

namespace Dialysis.Dto.WebApi
{
    /// <summary>
    /// 患教输入
    /// </summary>
    public class AddPatientEduInput
    {
        /// <summary>
        /// 医生Id
        /// </summary>
        public long DoctorId { get; set; }

        /// <summary>
        /// 患者Id数组
        /// </summary>
        public List<long> PatientIds { get; set; }

        /// <summary>
        /// 课程类别Id数组
        /// </summary>
        public List<AddCourseInput> CourseList { get; set; }
    }

    /// <summary>
    /// 课程输入
    /// </summary>
    public class AddCourseInput
    {
        /// <summary>
        /// 课程类别Id
        /// </summary>
        public int CourseTypeId { get; set; }

        /// <summary>
        /// 课程类别对应的课程Id数组
        /// </summary>
        public List<long> CourseIds { get; set; }
    }
}
