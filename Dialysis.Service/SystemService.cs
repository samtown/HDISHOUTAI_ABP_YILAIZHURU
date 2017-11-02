using AutoMapper;
using Dialysis.Domain.Models;
using Dialysis.Dto.Admin;
using Dialysis.Dto.WebApi;
using Dialysis.Dto.WebApi.Output;
using Dialysis.Repository;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Dialysis.Service
{
    public class SystemService
    {
        public readonly SystemRepository _repository;
        public readonly IUnitWork _unitWork;

        public SystemService(SystemRepository repository, IUnitWork unitWork)
        {
            _repository = repository;
            _unitWork = unitWork;
        }

        /// <summary>
        /// 根据搜索输入分页获取系统用户实体列表
        /// </summary>
        /// <param name="input">管理员搜索输入</param>
        /// <returns>系统用户实体列表</returns>
        public async Task<Tuple<List<AdministratorViewDto>, int>> GetAdministratorList(AdministratorSearchInput searchInput)
        {
            return await _repository.GetAdministratorPageList(searchInput);
        }

        /// <summary>
        /// 获取管理员信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<AdministratorDto> GetAdministrator(long id)
        {
            return Mapper.Map<Administrator, AdministratorDto>(await _repository.GetAdministratorById(id));
        }

        /// <summary>
        /// 修改后台用户
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<OutputBase> Update(AdministratorDto model)
        {
            var administrator = await _repository.GetAdministratorById(model.Id);
            if (administrator == null)
            {
                return OutputBase.Fail("该用户不存在");
            }
            administrator.LoginName = model.LoginName;
            administrator.IsSuperManager = model.IsSuperManager;
            administrator.HospitalId = model.HospitalId;
            administrator.UpdateTime = DateTime.Now;
            return _unitWork.Commit() ? OutputBase.Success("更新成功") : OutputBase.Fail("更新失败");
        }

        /// <summary>
        /// 新增后台用户
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public OutputBase Add(AdministratorDto model)
        {
            var administator = new Administrator
            {
                LoginName = model.LoginName,
                IsSuperManager = model.IsSuperManager,
                HospitalId = model.HospitalId,
            };
            _repository.AddUser(administator);

            return _unitWork.Commit() ? OutputBase.Success("新增成功") : OutputBase.Fail("新增失败");
        }

        /// <summary>
        /// 删除后台用户
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public OutputBase Delete(long id)
        {
            _repository.DeleteUser(id);
            return _unitWork.Commit() ? OutputBase.Success("删除成功") : OutputBase.Fail("删除失败");
        }

        /// <summary>
        /// 根据字典ID获取字典详情
        /// </summary>
        /// <param name="id">Id</param>
        /// <returns></returns>
        public async Task<List<DictDto>> GetDictionaryListByParentValue(int id)
        {
            var dictionary = await _repository.GetDictionaryListByParentValue(id);

            return Mapper.Map<List<Dictionary>, List<DictDto>>(dictionary);
        }

        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task<AdminLoginUserInfo> Login(AdminLoginInput input)
        {
            return Mapper.Map<Administrator, AdminLoginUserInfo>(await _repository.Login(input));
        }

        /// <summary>
        /// 获取最新版本信息
        /// </summary>
        /// <param name="versionCode">版本号</param>
        /// <param name="versionType">版本类型（0-医护端，1-患者端）</param>
        /// <returns></returns>
        public async Task<GetLatestVersionOutput> GetLatestVersion(int versionCode, int versionType)
        {
            var version = await _repository.GetLatestVersion(versionCode, versionType);
            if (version != null)
            {
                return new GetLatestVersionOutput
                {
                    VersionName = version.VersionName,
                    UpdateLog = version.UpdateLog,
                    DownloadUrl = version.DownloadUrl,
                    UpdateTime = version.AddTime,
                    FileMD5 = version.FileMD5
                };
            }
            return null;
        }
    }
}
