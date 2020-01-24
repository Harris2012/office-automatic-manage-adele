using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Dapper;

using Canos.OfficeAutomatic.Repository.Entity;

namespace Canos.OfficeAutomatic.Repository.Mysql
{
    public class MysqlMetaNoticeCategoryRepository : IMetaNoticeCategoryRepository
    {

        private MysqlConnectionProvider connectionProvider;

        public MysqlMetaNoticeCategoryRepository(MysqlConnectionProvider connectionProvider)
        {
            this.connectionProvider = connectionProvider;
        }

        public MetaNoticeCategoryEntity GetById(int id)
        {
            string sql = "select name as Name, title as Title from `oam_notice_category` where Id = ?";

            using (var mysqlConn = connectionProvider.GetConnection())
            {
                return mysqlConn.QueryFirstOrDefault<MetaNoticeCategoryEntity>(sql, new { Id = id });
            }
        }

        public List<MetaNoticeCategoryEntity> GetEntityList()
        {
            string sql = "select name as Name, title as Title from `oam_notice_category`";

            using (var mysqlConn = connectionProvider.GetConnection())
            {
                return mysqlConn.Query<MetaNoticeCategoryEntity>(sql).ToList();
            }
        }
    }
}
