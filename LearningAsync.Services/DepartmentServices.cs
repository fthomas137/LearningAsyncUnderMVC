using LearningAsync.Models.DBTables;
using LearningAsync.Models.Models;
using LearningAsync.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningAsync.Services
{
    public class DepartmentServices : IDisposable
    {
        private DepartmentRepository _repository = new DepartmentRepository();

        public void Dispose()
        {
            _repository.Dispose();
        }

        public async Task<Department> GetAsync(int id)
        {
            return await _repository.GetAsync(id);
        }

        public async Task<List<Department>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<Response> CreateAsync(Department department)
        {
            var response = new Response()
            {
                IsSuccessful = true
            };
            var result = await _repository.CreateAsync(department);
            if (result != 1)
            {
                response.IsSuccessful = false;
                response.ErrorCode = "500";
                response.Message = "Record not created";
            };
            return response;
        }

        public async Task<Response> UpdateAsync(Department department)
        {
            var response = new Response()
            {
                IsSuccessful = true
            };
            var result = await _repository.UpdateAsync(department);
            if (result != 1)
            {
                response.IsSuccessful = false;
                response.ErrorCode = "500";
                response.Message = "Record not created";
            };
            return response;
        }

        public async Task<Response> DeleteAsync(int id)
        {
            var response = new Response()
            {
                IsSuccessful = true
            };
            var result = await _repository.DeleteAsync(id);
            if (result != 1)
            {
                response.IsSuccessful = false;
                response.ErrorCode = "500";
                response.Message = "Record not created";
            };
            return response;
        }

    }
}
