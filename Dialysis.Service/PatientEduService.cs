using AutoMapper;
using Dialysis.Common;
using Dialysis.Common.Enum;
using Dialysis.Domain;
using Dialysis.Domain.Models;
using Dialysis.Dto.WebApi;
using Dialysis.Repository;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Dialysis.Service
{
    public class PatientEduService
    {
        public readonly PatientEduRepository _repository;
        public readonly DoctorRepository _doctorRepository;
        public readonly CourseRepository _courseRepository;
        public readonly SystemRepository _systemRepository;
        public readonly MessageRepository _messageRepository;
        public readonly IUnitWork _unitWork;
        private readonly MyOptions _optionsAccessor;

        public PatientEduService(PatientEduRepository repository, DoctorRepository doctorRepository, CourseRepository courseRepository, SystemRepository systemRepository, MessageRepository messageRepository, IUnitWork unitWork, IOptions<MyOptions> optionsAccessor)
        {
            _unitWork = unitWork;
            _optionsAccessor = optionsAccessor.Value;
            _repository = repository;
            _doctorRepository = doctorRepository;
            _courseRepository = courseRepository;
            _systemRepository = systemRepository;
            _messageRepository = messageRepository;
        }

        /// <summary>
        /// 保存患教
        /// </summary>
        /// <param name="input">患教输入</param>
        /// <returns>是否保存成功</returns>
        public async Task<OutputBase> Add(AddPatientEduInput input)
        {
            var doctor = await _doctorRepository.GetDoctorById(input.DoctorId);
            if (doctor == null)
                return OutputBase.Fail("医生Id参数不正确，该医护人员不存在");
            if (input.PatientIds.Count < 1)
                return OutputBase.Fail("患者Id数组参数个数不能为0");
            if (input.CourseList.Count < 1)
                return OutputBase.Fail("课程列表参数个数不能为0");
            string content = string.Format("{0}医生向您发送了新的课程", doctor.Name);

            var patientEduList = new List<PatientEducation>();
            foreach (var patientId in input.PatientIds)
            {
                var batchNumber = DateTime.Now.ToString(CommConstant.FullTimeFormatString);
                foreach (var course in input.CourseList)
                {
                    _repository.Add(course, patientId, input.DoctorId, batchNumber);
                }

                var messageEntity = new Message
                {
                    IsRead = false,
                    OuterId = batchNumber + input.DoctorId.ToString().PadLeft(18, '0') + patientId.ToString().PadLeft(18, '0'),
                    Content = content,
                    ReceiveId = patientId,
                    Title = "患教课程",
                    Type = (int)MessageTypeEnum.患教课程,
                    SendId = input.DoctorId,
                    SendName = doctor.Name,
                    Url = string.Empty,
                    AppType = (int)AppTypeEnum.Patient
                };
                _messageRepository.Add(messageEntity);

                #region 异步发送JPush Notification、Message
                ThreadPool.QueueUserWorkItem(delegate
                {
                    new JPushMessage(AppTypeEnum.Patient, (int)JPushKeyEnum.PatientEducation, patientId.ToString(), content, messageEntity.OuterId, _optionsAccessor.IsDevModel).SendPush();
                    new JPushNotification(AppTypeEnum.Patient, (int)JPushKeyEnum.PatientEducation, patientId.ToString(), content, messageEntity.OuterId, _optionsAccessor.IsDevModel).SendPush();
                });
                #endregion
            }

            return _unitWork.Commit() ? OutputBase.Success("保存成功") : OutputBase.Fail("保存失败");
        }

        /// <summary>
        /// 根据课程Id获取课程详情
        /// </summary>
        /// <param name="courseId">课程Id</param>
        /// <returns>课程详情</returns>
        public async Task<WebApiOutput<CourseDto>> GetCourseById(long courseId)
        {
            var course = await _courseRepository.GetCourseById(courseId);

            return WebApiOutput<CourseDto>.Success(Mapper.Map<Course, CourseDto>(course));
        }

        /// <summary>
        /// 获取课程列表（课程类别+该课程类别下课程）
        /// </summary>
        /// <returns>课程类别对应的课程列表</returns>
        public async Task<WebApiOutput<List<CourseListOutput>>> GetCourseList()
        {
            var courseTypeList = await _systemRepository.GetDictionaryListByParentValue(CommConstant.PatientEduParentValue);
            List<CourseListOutput> courseList = new List<CourseListOutput>();
            foreach (var item in courseTypeList)
            {
                CourseListOutput course = new CourseListOutput { CourseType = item.Id, CourseTypeName = item.Name };
                var entityList = await _courseRepository.GetCourseListByCourseType(item.Id);
                course.CourseList = Mapper.Map<List<Course>, List<CourseDto>>(entityList);
                courseList.Add(course);
            }

            return WebApiOutput<List<CourseListOutput>>.Success(courseList);
        }

        /// <summary>
        /// 根据外部Id获取患教课程列表（课程类别+该课程类别下课程）
        /// </summary>
        /// <param name="outerId">外部Id</param>
        /// <returns>课程类别对应的课程列表</returns>
        public async Task<WebApiOutput<List<CourseListOutput>>> GetCourseListByOuterId(string outerId)
        {
            if (string.IsNullOrEmpty(outerId) || outerId.Length != CommConstant.PatientEduOutIdLength)
                return WebApiOutput<List<CourseListOutput>>.Fail("外部Id不正确");
            var courseEntityList = await _repository.GetPatientEduListByOuterId(outerId);
            List<CourseListOutput> courseList = new List<CourseListOutput>();
            foreach (var item in courseEntityList)
            {
                CourseListOutput course = new CourseListOutput { CourseType = item.CourseTypeId, CourseTypeName = item.CourseTypeName };
                var entityList = await _courseRepository.GetCourseListByPatientEduId(item.Id);
                course.CourseList = Mapper.Map<List<Course>, List<CourseDto>>(entityList);
                courseList.Add(course);
            }

            return WebApiOutput<List<CourseListOutput>>.Success(courseList);
        }
    }
}
