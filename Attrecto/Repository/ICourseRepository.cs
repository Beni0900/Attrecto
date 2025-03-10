﻿using Attrecto.Data;

namespace Attrecto.Repository
{
    public interface ICourseRepository
    {
        void Create(Course data);
        bool Delete(int id);
        List<Course> GetAll();
        Course? GetById(int id);
        Course? Update(int id, Course data);
    }
}