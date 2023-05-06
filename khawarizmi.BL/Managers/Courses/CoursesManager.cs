using khawarizmi.BL.Dtos;
using khawarizmi.DAL.Models;
using khawarizmi.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace khawarizmi.BL.Managers;

public class CoursesManager : ICoursesManager
{
    private readonly ITagsRepo _tagsRepo;
    private readonly ICoursesRepo _coursesRepo;
    private readonly ICategoriesRepo _categoriesRepo;

    public CoursesManager(ICoursesRepo coursesRepo, ICategoriesRepo categoriesRepo, ITagsRepo tagsRepo)
	{
        _tagsRepo = tagsRepo;
        _coursesRepo = coursesRepo;
        _categoriesRepo = categoriesRepo;
    }
    public void AddNewCourse(string userId, CourseAddDto newCourse)
    {
        IQueryable<Tag> tags = _tagsRepo.GetTagsByCategory(newCourse.Category);

        Category? category = _categoriesRepo.GetCategoryByName(newCourse.Category);
        if(category == null) { return; }

        Course CourseToAdd = new Course() 
        {
            Name = newCourse.Title, 
            Description = newCourse.Description, 
            CourseImage = newCourse.Image ?? "" ,
            CategoryId = category.Id,
            Tags = tags.ToList(),
            UserId = userId
        };

        _coursesRepo.AddNewCourse(CourseToAdd);
    }
}
