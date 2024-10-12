using AutoMapper;
using Blog.API.Contracts.Models.Tag;
using Blog.Logic.Models;
using Blog.Logic.Services;
using Microsoft.AspNetCore.Mvc;

namespace Blog.API.Controllers;
[Route("api/[controller]")]
[ApiController]
public class TagController : ControllerBase
{
    private ITagService _tagService;
    private IMapper _mapper;

    public TagController(
        ITagService tagService, 
        IMapper mapper)
    {
        _tagService = tagService;
        _mapper = mapper;
    }        

    #region Create
    [HttpPost]
    [Route("[action]")]
    public async Task CreateTag([FromBody] CreateTagRequest newTag)
    {
        var tag = _mapper.Map<TagModel>(newTag);

        await _tagService.CreateTag(tag);
    }
    #endregion Create

    #region Read
    [HttpGet]
    [Route("[action]/{id}")]
    public async Task<GetTagResponse> GetById(int id)
    {
        var tag = await _tagService.GetTag(id);

        return _mapper.Map<GetTagResponse>(tag);
    }

    [HttpGet]
    [Route("[action]")]
    public async Task<IEnumerable<GetTagResponse>> GetAll()
    {
        var tags = await _tagService.GetTags();

        return _mapper.Map<IEnumerable<GetTagResponse>>(tags);

    }
    #endregion Read

    #region Update
    [HttpPut]
    [Route("[action]")]
    public async Task Update([FromBody] UpdateTagRequest updatedTag)
    {
        var tag = _mapper.Map<TagModel>(updatedTag);

        await _tagService.UpdateTag(tag);
    }
    #endregion Update

    #region Delete
    [HttpDelete]
    [Route("[action]")]
    public async Task Delete([FromBody] DeleteTagRequest tagToDelete) 
    {
        var tag = _mapper.Map<TagModel>(tagToDelete);

        await _tagService.DeleteTag(tag);
    }
    #endregion Delete
}
