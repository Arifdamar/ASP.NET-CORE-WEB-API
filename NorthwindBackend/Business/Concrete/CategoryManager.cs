﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
    public class CategoryManager : ICategoryService
    {
        private ICategoryDal _categoryDal;

        public CategoryManager(ICategoryDal categoryDal)
        {
            _categoryDal = categoryDal;
        }

        public IDataResult<Category> Get(int categoryId)
        {
            return new SuccessDataResult<Category>(_categoryDal.Get(category => category.CategoryId == categoryId));
        }

        public IDataResult<List<Category>> GetList()
        {
            return new SuccessDataResult<List<Category>>(_categoryDal.GetList().ToList());
        }

        public IResult Add(Category category)
        {
            // Business rules
            _categoryDal.Add(category);
            return new SuccessResult("Category added successfully!");
        }

        public IResult Delete(Category category)
        {
            _categoryDal.Delete(category);
            return new SuccessResult("Category deleted successfully!");
        }

        public IResult Update(Category category)
        {
            _categoryDal.Update(category);
            return new SuccessResult("Category updated successfully!");
        }
    }
}
