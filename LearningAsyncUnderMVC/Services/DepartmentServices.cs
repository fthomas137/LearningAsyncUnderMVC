﻿using LearningAsyncUnderMVC.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace LearningAsyncUnderMVC.Services
{
    public class DepartmentServices : IDisposable
    {
        private MyDB _db = new MyDB();

        public void Dispose()
        {
            _db.Dispose();
        }

        public async Task<Department> GetAsync(int id)
        {
            return await _db.Departments.FirstOrDefaultAsync(d => d.Id == id);
        }

        public async Task<List<Department>> GetAllAsync()
        {
            return await _db.Departments.ToListAsync();
        }

        public async Task<int> CreateAsync(Department department)
        {
            _db.Departments.Add(department);
            var result = await _db.SaveChangesAsync();
            return result;
        }

        public async Task<int> UpdateAsync(Department department)
        {
            _db.Entry(department).State = EntityState.Modified;
            return await _db.SaveChangesAsync();

        }

        public async Task<int> DeleteAsync(int id)
        {
            var department = await _db.Departments.FirstOrDefaultAsync(d => d.Id == id);
            _db.Departments.Remove(department);
            var result = await _db.SaveChangesAsync();
            return result;
        }

    }
}