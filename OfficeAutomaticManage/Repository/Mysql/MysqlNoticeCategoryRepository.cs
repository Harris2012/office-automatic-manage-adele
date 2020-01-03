using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Dapper;

using Canos.OfficeAutomatic.Repository.Entity;
using Canos.OfficeAutomatic.Repository.Request;

namespace Canos.OfficeAutomatic.Repository.Mysql
{
    public class MysqlNoticeCategoryRepository : INoticeCategoryRepository
    {

        private MysqlConnectionProvider connectionProvider;

        public MysqlNoticeCategoryRepository(MysqlConnectionProvider connectionProvider)
        {
            this.connectionProvider = connectionProvider;
        }

        /// <summary>
        /// 根据id获取单个实体
        /// </summary>
        /// <param name="id">实体编号</param>
        /// <returns>实体</returns>
        public NoticeCategoryEntity GetEntityById(int id)
        {
            string sql = @"
select
  id as Id,
  name as Name,
  title as Title,
  remark as Remark,
  data_status as DataStatus,
  create_time as CreateTime,
  last_update_time as LastUpdateTime,
  1 as _
from `notice_category`
where
  id = @Id
  and data_status = 1;";

            using (var mysqlConn = connectionProvider.GetConnection())
            {
                return mysqlConn.QueryFirstOrDefault<NoticeCategoryEntity>(sql, new { Id = id });
            }
        }

        /// <summary>
        /// 根据主属性获取单个实体
        /// </summary>
        public NoticeCategoryEntity GetEntityByPrimaryProperty(NoticeCategoryGetEntityByPrimaryPropertyRequest request)
        {
            string sql = @"
select
  id as Id,
  name as Name,
  title as Title,
  remark as Remark,
  data_status as DataStatus,
  create_time as CreateTime,
  last_update_time as LastUpdateTime
from `notice_category`
where
  name = @Name
  and data_status = 1;";

            using (var mysqlConn = connectionProvider.GetConnection())
            {
                return mysqlConn.QueryFirstOrDefault<NoticeCategoryEntity>(sql, request);
            }
        }

        /// <summary>
        /// 获取所有实体
        /// </summary>
        /// <returns>实体列表</returns>
        public List<NoticeCategoryEntity> GetEntityList()
        {
            string sql = @"
select
  id as Id,
  name as Name,
  title as Title,
  remark as Remark,
  data_status as DataStatus,
  create_time as CreateTime,
  last_update_time as LastUpdateTime,
  1 as _
from `notice_category`
where
  data_status = 1;";

            using (var mysqlConn = connectionProvider.GetConnection())
            {
                return mysqlConn.Query<NoticeCategoryEntity>(sql).ToList();
            }
        }

        /// <summary>
        /// 分页获取实体列表
        /// </summary>
        /// <param name="pageIndex">页码，从1开始</param>
        /// <param name="pageSize">每页个数</param>
        /// <returns>实体列表</returns>
        public List<NoticeCategoryEntity> GetPagedEntityList(int pageIndex, int pageSize)
        {
            string sql = @"
select
  id as Id,
  name as Name,
  title as Title,
  remark as Remark,
  data_status as DataStatus,
  create_time as CreateTime,
  last_update_time as LastUpdateTime,
  1 as _
from `notice_category`
where
  data_status = 1
limit @Start, @Count";

            using (var mysqlConn = connectionProvider.GetConnection())
            {
                return mysqlConn.Query<NoticeCategoryEntity>(sql, new { Start = (pageIndex - 1) * pageSize, Count = pageSize }).ToList();
            }
        }

        /// <summary>
        /// 获取实体总个数
        /// </summary>
        public int GetTotalCount()
        {
            string sql = @"select count(1) from `notice_category` where data_status = 1";

            using (var mysqlConn = connectionProvider.GetConnection())
            {
                return mysqlConn.QuerySingle<int>(sql);
            }
        }

        /// <summary>
        /// 新增实体
        /// </summary>
        public void Create(NoticeCategoryEntity entity)
        {
            string sql = @"
insert into `notice_category`(
  name,
  title,
  remark,
  data_status,
  create_time,
  last_update_time)
values(
  @Name,
  @Title,
  @Remark,
  @DataStatus,
  @CreateTime,
  @LastUpdateTime);";

            using (var mysqlConn = connectionProvider.GetConnection())
            {
                mysqlConn.Execute(sql, entity);
            }
        }

        /// <summary>
        /// 根据id更新单个实体
        /// </summary>
        public void UpdateById(NoticeCategoryEntity entity)
        {
            string sql = @"
update `notice_category`
set
  name = @Name,
  title = @Title,
  remark = @Remark,
  data_status = @DataStatus,
  create_time = @CreateTime,
  last_update_time = @LastUpdateTime
where
  id = @Id;";

            using (var mysqlConn = connectionProvider.GetConnection())
            {
                mysqlConn.Execute(sql, entity);
            }
        }

        /// <summary>
        /// 根据主属性更新单个实体
        /// </summary>
        public void UpdateByPrimaryProperty(NoticeCategoryEntity entity)
        {
            string sql = @"
update `notice_category`
set
  id = @Id,
  title = @Title,
  remark = @Remark,
  data_status = @DataStatus,
  create_time = @CreateTime,
  last_update_time = @LastUpdateTime
where
  name = @Name;";

            using (var mysqlConn = connectionProvider.GetConnection())
            {
                mysqlConn.Execute(sql, entity);
            }
        }

        /// <summary>
        /// 启用实体
        /// </summary>
        public void Enable(int id)
        {
            string sql = @"update `notice_category` set data_status = 1 where id = @Id;";

            using (var mysqlConn = connectionProvider.GetConnection())
            {
                mysqlConn.Execute(sql, new { Id = id });
            }
        }

        /// <summary>
        /// 禁用实体
        /// </summary>
        public void Disable(int id)
        {
            string sql = @"update `notice_category` set data_status = 2 where id = @Id;";

            using (var mysqlConn = connectionProvider.GetConnection())
            {
                mysqlConn.Execute(sql, new { Id = id });
            }
        }
    }
}
