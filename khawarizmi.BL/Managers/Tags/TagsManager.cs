using khawarizmi.BL.Dtos;
using khawarizmi.DAL.Models;
using khawarizmi.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace khawarizmi.BL.Managers;

public class TagsManager : ITagsManager
{
    private readonly ITagsRepo _tagsRepo;
    public TagsManager(ITagsRepo tagsRepo)
	{
        _tagsRepo = tagsRepo;
	}
    public List<TagReadDto>? GetTagsByCategory(int categoryId)
    {
        List<TagReadDto>? relatedTags = _tagsRepo.GetTagsByCategoryId(categoryId)?.Select(t => new TagReadDto(t.Id,t.Name)).ToList();

        return relatedTags;
    }
}
