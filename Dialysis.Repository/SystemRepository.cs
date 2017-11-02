using Dialysis.Common;
using Dialysis.Domain;
using Dialysis.Domain.Models;
using Dialysis.Dto.Admin;
using Dialysis.Dto.WebApi;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dialysis.Repository
{
    public class SystemRepository
    {
        private readonly DialysisContext _context;
        private readonly MyOptions _optionsAccessor;
        private readonly Flakey.IdGenerator _idGenerator;

        public SystemRepository(DialysisContext context, IOptions<MyOptions> optionsAccessor)
        {
            _context = context;
            _optionsAccessor = optionsAccessor.Value;
            _idGenerator = IdGenerator.CreateGenerator(_optionsAccessor.GeneratorId);
        }

        /// <summary>
        /// 新增系统用户
        /// </summary>
        /// <param name="entity">系统用户实体</param>
        public void AddUser(Administrator entity)
        {
            entity.Id = _idGenerator.CreateId();
            entity.AddTime = DateTime.Now;
            entity.UpdateTime = DateTime.Now;
            entity.Password = CommConstant.InitialPassword;

            _context.Administrator.Add(entity);
        }

        /// <summary>
        /// 删除系统用户
        /// </summary>
        /// <param name="id">系统用户Id</param>
        public void DeleteUser(long id)
        {
            _context.Administrator.Remove(new Administrator { Id = id });
        }

        /// <summary>
        /// 更新系统用户
        /// </summary>
        /// <param name="entity">系统用户实体</param>
        /// <returns></returns>
        public async Task UpdateUser(Administrator entity)
        {
            var user = await _context.Administrator.FindAsync(entity.Id);
            user.HospitalId = entity.HospitalId;
            //user.IsSuperManager = entity.IsSuperManager;
            user.LoginName = entity.LoginName;
            user.UserDesc = entity.UserDesc;
            user.UpdateTime = DateTime.Now;
        }

        /// <summary>
        /// 更新系统用户密码
        /// </summary>
        /// <param name="input">更新密码输入</param>
        /// <returns></returns>
        public async Task UpdateUserPassword(UpdatePasswordInput input)
        {
            var user = await _context.Administrator.FindAsync(input.Id);
            user.Password = EnctypeHelper.GetEncryptedStr(input.Password);
            user.UpdateTime = DateTime.Now;
        }

        /// <summary>
        /// 根据Id获取系统用户实体
        /// </summary>
        /// <param name="id">Id</param>
        /// <returns>系统用户实体</returns>
        public async Task<Administrator> GetAdministratorById(long id)
        {
            var user = await _context.Administrator.FindAsync(id);

            return user;
        }

        /// <summary>
        /// 根据用户名获取系统用户实体
        /// </summary>
        /// <param name="loginName">登录名</param>
        /// <returns>系统用户实体</returns>
        public async Task<Administrator> GetAdministratorByLoginName(string loginName)
        {
            var user = await _context.Administrator.Where(i => i.LoginName == loginName).FirstOrDefaultAsync();

            return user;
        }

        /// <summary>
        /// 管理员登录
        /// </summary>
        /// <param name="input">管理员登录输入</param>
        /// <returns>系统用户实体</returns>
        public async Task<Administrator> Login(AdminLoginInput input)
        {
            var user = await _context.Administrator.Where(i => i.LoginName == input.LoginName && i.Password == EnctypeHelper.GetEncryptedStr(input.Password)).FirstOrDefaultAsync();

            return user;
        }

        /// <summary>
        /// 根据搜索输入分页获取系统用户实体列表
        /// </summary>
        /// <param name="input">管理员搜索输入</param>
        /// <returns>系统用户实体列表</returns>
        public async Task<Tuple<List<AdministratorViewDto>, int>> GetAdministratorPageList(AdministratorSearchInput input)
        {
            var query = _context.Administrator.Where(i => !i.IsSuperManager);

            if (!string.IsNullOrEmpty(input.LoginName))
            {
                query = query.Where(i => i.LoginName.Contains(input.LoginName));
            }
            if (input.HospitalId != -1)
            {
                query = query.Where(i => i.HospitalId == input.HospitalId);
            }

            int total = query.Count();
            var userList = await query.Include(t => t.Hospital).Select(t => new AdministratorViewDto
            {
                Id = t.Id,
                LoginName = t.LoginName,
                IsSuperManager = t.IsSuperManager,
                HospitalName = t.Hospital.HospitalName
            }).OrderBy(i => i.Id).Skip(input.PageSize * (input.PageIndex - 1)).Take(input.PageSize).ToListAsync();

            return new Tuple<List<AdministratorViewDto>, int>(userList, total); ;
        }

        /// <summary>
        /// 根据父键获取系统字典列表
        /// </summary>
        /// <param name="parentValue">父键</param>
        /// <returns>系统字典实体列表</returns>
        public async Task<List<Dictionary>> GetDictionaryListByParentValue(int parentValue)
        {
            var dictionaryList = await _context.Dictionary.Where(i => i.ParentValue == parentValue).OrderBy(i => i.SortId).ToListAsync();

            return dictionaryList;
        }

        /// <summary>
        /// 根据父键获取某一字典类别下最大键值
        /// </summary>
        /// <param name="parentValue">父键值</param>
        /// <returns></returns>
        public async Task<int> GetMaxIdByParentValue(int parentValue)
        {
            int max = await (from d in _context.Dictionary
                             where d.ParentValue == parentValue
                             select d.Id).MaxAsync();

            return max;
        }

        /// <summary>
        /// 根据父键获取某一字典类别下最大排序Id
        /// </summary>
        /// <param name="parentValue">父键值</param>
        /// <returns></returns>
        public async Task<int> GetMaxSortIdByParentValue(int parentValue)
        {
            int max = await (from d in _context.Dictionary
                             where d.ParentValue == parentValue
                             select d.SortId).MaxAsync();

            return max;
        }

        /// <summary>
        /// 根据字典ID获取字典详情
        /// </summary>
        /// <param name="id">Id</param>
        /// <returns></returns>
        public async Task<Dictionary> GetDictionaryById(int id)
        {
            var dictionary = await _context.Dictionary.Where(i => i.Id == id).FirstOrDefaultAsync();

            return dictionary;
        }

        /// <summary>
        /// 新增系统字典
        /// </summary>
        /// <param name="entity">系统字典实体</param>
        public void AddDictionary(Dictionary entity)
        {
            entity.AddTime = DateTime.Now;
            entity.UpdateTime = DateTime.Now;

            _context.Dictionary.Add(entity);
        }

        /// <summary>
        /// 删除系统字典
        /// </summary>
        /// <param name="id">Id</param>
        public void DeleteDictionary(int id)
        {
            _context.Dictionary.Remove(new Dictionary { Id = id });
        }

        /// <summary>
        /// 更新系统字典
        /// </summary>
        /// <param name="entity">系统字典实体</param>
        /// <returns></returns>
        public async Task UpdateDictionary(Dictionary entity)
        {
            var dictionary = await _context.Dictionary.FindAsync(entity.Id);
            dictionary.Description = entity.Description;
            dictionary.Logo = entity.Logo;
            dictionary.Name = entity.Name;
            dictionary.UpdateTime = DateTime.Now;
        }

        /// <summary>
        /// 根据字典搜索输入分页获取字典实体列表
        /// </summary>
        /// <param name="input">字典搜索输入</param>
        /// <returns>字典实体列表</returns>
        public async Task<Tuple<List<Dictionary>, int>> GetDictionaryPageList(DictionarySearchInput input)
        {
            var query = _context.Dictionary.AsQueryable();

            if (!string.IsNullOrEmpty(input.Name))
            {
                query = query.Where(i => i.Name.Contains(input.Name));
            }

            if (input.ParentValue != -1)
            {
                query = query.Where(i => i.ParentValue == input.ParentValue);
            }

            int total = query.Count();
            var dictionaryList = await query.OrderBy(i => i.SortId).Skip(input.PageSize * (input.PageIndex - 1)).Take(input.PageSize).ToListAsync();

            return new Tuple<List<Dictionary>, int>(dictionaryList, total);
        }

        /// <summary>
        /// 获取版本信息
        /// </summary>
        /// <param name="versionCode">当前版本号</param>
        /// <param name="versionType">版本类型（0-医护端，1-患者端）</param>
        /// <returns></returns>
        public async Task<Dialysis.Domain.Models.Version> GetLatestVersion(int versionCode, int versionType)
        {
            var version = await _context.Version.Where(i => i.VersionCode > versionCode && i.VersionType == versionType).OrderByDescending(i => i.Id).FirstOrDefaultAsync();

            return version;
        }
    }
}
