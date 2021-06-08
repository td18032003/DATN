using Dapper;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Upload.Entity;
using Upload.Interface;
using Upload.Models;

namespace Upload.Implement
{
    public class BaseBL : IBaseBL
    {
        public IConfiguration _configuration;
        public string _connectionString;
        public IDbConnection _dBConnection;
        public string _tableName = null;
        public BaseBL(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = _configuration.GetConnectionString("ConnectDB");
            _dBConnection = new MySqlConnection(_connectionString);
        }
        public void SetTableName(string tableName)
        {
            _tableName = tableName;
        }
        //Hàm get all
        public virtual async Task<object> GetAll<T>(Type curentType)
        {
            var resul = await _dBConnection.QueryAsync<T>($"SELECT * FROM {_tableName};", commandType: CommandType.Text);
            return resul;
        }
        //Hàm paging
        public async Task<object> Paging<T>(PagingRequest pagingRequest, Type curentType)
        {
            var startIndex = (pagingRequest.PageIndex - 1) * pagingRequest.PageSize + 1;
            var endIndex = pagingRequest.PageIndex * pagingRequest.PageSize;
            string where = string.IsNullOrEmpty(pagingRequest.Filter) ? "" : pagingRequest.Filter + "AND";
            string commandText = $"SELECT * FROM (SELECT * , row_number() OVER (order by {curentType.Name}ID) AS row_num FROM {_tableName}) t WHERE {where} row_num BETWEEN {startIndex} AND {endIndex} ORDER BY {curentType.Name}ID;";
            var resul = await _dBConnection.QueryAsync<T>(commandText, commandType: CommandType.Text);
            return resul;
        }
        //Hàm get id
        public async Task<object> GetByID<T>(string id, Type curentType)
        {
            var resul = await _dBConnection.QueryAsync<T>($"SELECT * FROM {_tableName} WHERE {curentType.Name}ID = '{id}';", commandType: CommandType.Text);
            return resul;
        }
        //Hàm insert chung
        public async Task<object> Insert(object param, Type curentType)
        {
            await BeforeSave(param);
            var parameters = GetParameters(param, curentType);
            var resul =  await _dBConnection.ExecuteScalarAsync<object>($"Proc_{curentType.Name}_Insert", parameters, commandType: CommandType.StoredProcedure);
            if(resul != null)
            {
                await AfterSave(param);
            }
            return resul;
        }
        public virtual async Task BeforeSave(object param)
        {

        }
        public virtual async Task AfterSave(object param)
        {

        }
        //Hàm sửa chung
        public async Task<object> Update(object param, Type curentType)
        {
            var parameters = GetParameters(param, curentType);
            var resul = await _dBConnection.ExecuteAsync($"Proc_{curentType.Name}_Update", parameters, commandType: CommandType.StoredProcedure);
            return resul;
        }
        //Hàm sửa danh sách
        public async Task<object> SaveList<T>(List<T> param, Type curentType)
        {
            foreach(var item in param)
            {
                await Update(item, curentType);
            };
            return param;
        }
        //Hàm xóa chung
        public async Task<object> Delete(string id, Type curentType)
        {
            string commanText = $"DELETE FROM {_tableName} WHERE {curentType.Name}ID = '{id}';";
            var resul = await _dBConnection.ExecuteAsync(commanText, commandType: CommandType.Text);
            return resul;
        }
        //Hàm xóa danh sách id
        public async Task<object> DeleteList(List<string> listID, Type curentType)
        {
            foreach (var id in listID)
            {
                await Delete(id, curentType);
            };
            return true;
        }
        //Hàm tách param vào stored
        public DynamicParameters GetParameters(object param, Type curentType)
        {
            var parameters = new DynamicParameters();
            var properties = curentType.GetProperties();
            Type typeParam = param.GetType();
            foreach (var property in properties)
            {
                var propertyName = property.Name;
                var propertyType = property.PropertyType;
                var propertyValue = property.GetValue(param);
                if (propertyType == typeof(Guid) || propertyType == typeof(Guid?))
                {
                    parameters.Add($"v_{propertyName}", propertyValue, DbType.String);
                }
                else
                {
                    parameters.Add($"v_{propertyName}", propertyValue);
                }
            }
            return parameters;
        }
        //Hàm xử lý trả về khi lỗi
        public ServiceResponse Error(Exception e)
        {
            ServiceResponse res = new ServiceResponse();
            res.Success = false;
            res.Data = null;
            res.Code = 99;
            res.Message = e.Message;
            return res;
        }
        public async Task<object> QueryAsync<T>(string sql)
        {
            return await _dBConnection.QueryAsync<T>(sql);
        }
    }
}
