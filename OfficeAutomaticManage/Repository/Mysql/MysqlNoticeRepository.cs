using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Dapper;

using Canos.OfficeAutomatic.Repository.Entity;
using Canos.OfficeAutomatic.Repository.Request;

namespace Canos.OfficeAutomatic.Repository.Mysql
{
    public class MysqlNoticeRepository : INoticeRepository
    {

        private MysqlConnectionProvider connectionProvider;

        public MysqlNoticeRepository(MysqlConnectionProvider connectionProvider)
        {
            this.connectionProvider = connectionProvider;
        }

        /// <summary>
        /// 根据id获取单个实体
        /// </summary>
        /// <param name="id">实体编号</param>
        /// <returns>实体</returns>
        public NoticeEntity GetEntityById(int id)
        {
            string sql = @"
select
  id as Id,
  title as Title,
  body as Body,
  category as Category,
  data_status as DataStatus,
  create_time as CreateTime,
  last_update_time as LastUpdateTime,
  1 as _
from `notice`
where
  id = @Id
  and data_status = 1;";

            using (var mysqlConn = connectionProvider.GetConnection())
            {
                return mysqlConn.QueryFirstOrDefault<NoticeEntity>(sql, new { Id = id });
            }
        }

        /// <summary>
        /// 获取所有实体
        /// </summary>
        /// <returns>实体列表</returns>
        public List<NoticeEntity> GetEntityList()
        {
            string sql = @"
select
  id as Id,
  title as Title,
  body as Body,
  category as Category,
  data_status as DataStatus,
  create_time as CreateTime,
  last_update_time as LastUpdateTime,
  1 as _
from `notice`
where
  data_status = 1;";

            using (var mysqlConn = connectionProvider.GetConnection())
            {
                return mysqlConn.Query<NoticeEntity>(sql).ToList();
            }
        }

        /// <summary>
        /// 分页获取实体列表
        /// </summary>
        /// <param name="pageIndex">页码，从1开始</param>
        /// <param name="pageSize">每页个数</param>
        /// <returns>实体列表</returns>
        public List<NoticeEntity> GetPagedEntityList(int pageIndex, int pageSize)
        {
            string sql = @"
select
  id as Id,
  title as Title,
  body as Body,
  category as Category,
  data_status as DataStatus,
  create_time as CreateTime,
  last_update_time as LastUpdateTime,
  1 as _
from `notice`
where
  data_status = 1
limit @Start, @Count";

            using (var mysqlConn = connectionProvider.GetConnection())
            {
                return mysqlConn.Query<NoticeEntity>(sql, new { Start = (pageIndex - 1) * pageSize, Count = pageSize }).ToList();
            }
        }

        /// <summary>
        /// 获取实体总个数
        /// </summary>
        public int GetTotalCount()
        {
            string sql = @"select count(1) from `notice` where data_status = 1";

            using (var mysqlConn = connectionProvider.GetConnection())
            {
                return mysqlConn.QuerySingle<int>(sql);
            }
        }

        /// <summary>
        /// 新增实体
        /// </summary>
        public void Create(NoticeEntity entity)
        {
            string sql = @"
insert into `notice`(
  title,
  body,
  category,
  data_status,
  create_time,
  last_update_time)
values(
  @Title,
  @Body,
  @Category,
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
        public void UpdateById(NoticeEntity entity)
        {
            string sql = @"
update `notice`
set
  title = @Title,
  body = @Body,
  category = @Category,
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
        /// 启用实体
        /// </summary>
        public void Enable(int id)
        {
            string sql = @"update `notice` set data_status = 1 where id = @Id;";

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
            string sql = @"update `notice` set data_status = 2 where id = @Id;";

            using (var mysqlConn = connectionProvider.GetConnection())
            {
                mysqlConn.Execute(sql, new { Id = id });
            }
        }
    }
}
