﻿using Dapper;
using DataAccess.Entities;
using DataAccess.Infrastructure;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public class RoomsFeatureRepository : GenericRepository<RoomsFeatures>, IRoomsFeatureRepository
    {
        IConnectionFactory _connectionFactory;

        public RoomsFeatureRepository(IConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }
        public async Task<List<RoomsFeatures>> GetAllBlogByPageIndex(int pageIndex, int pageSize)
        {
            var query = "usp_GetAllBlogPostByPageIndex";
            var param = new DynamicParameters();
            param.Add("@PageIndex", pageIndex);
            param.Add("@PageSize", pageSize);
            var list = await SqlMapper.QueryAsync<RoomsFeatures>(_connectionFactory.GetConnection, query, param, commandType: CommandType.StoredProcedure);
            return list.ToList();
        }
    }
}
