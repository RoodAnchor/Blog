using AutoMapper;
using Blog.API.Contracts.Models.Comment;
using Blog.Logic.Models;
using Blog.Logic.Services;
using Microsoft.AspNetCore.Mvc;

namespace Blog.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CommentController : ControllerBase
{
    private ICommentService _commentService;
    private IMapper _mapper;

    public CommentController(
        ICommentService commentService,
        IMapper mapper)
    {
        _commentService = commentService;
        _mapper = mapper;
    }

    #region Create
    [HttpPost]
    [Route("[action]")]
    public async Task Create([FromBody] CreateCommentRequest newComment)
    {
        var comment = _mapper.Map<CommentModel>(newComment);

        await _commentService.CreateComment(comment);
    }
    #endregion Create

    #region Read
    [HttpGet]
    [Route("[action]/{id}")]
    public async Task<GetCommentResponse> GetById(int id)
    {
        var comment = await _commentService.GetComment(id);

        return _mapper.Map<GetCommentResponse>(comment);
    }

    [HttpGet]
    [Route("[action]/{id}")]
    public async Task<IEnumerable<GetCommentResponse>> GetAll()
    {
        var comments =_commentService.GetComments();

        return _mapper.Map<IEnumerable<GetCommentResponse>>(comments);
    }
    #endregion Read

    #region Update
    [HttpPut]
    [Route("[action]")]
    public async Task Update([FromBody] UpdateCommentRequest updatedComment)
    {
        var comment = _mapper.Map<CommentModel>(updatedComment);

        await _commentService.UpdateComment(comment);
    }
    #endregion Update

    #region Delete
    [HttpDelete]
    [Route("[action]")]
    public async Task Delete ([FromBody] DeleteCommentRequest commentToDelete)
    {
        var comment = _mapper.Map<CommentModel>(commentToDelete);

        await _commentService.DeleteComment(comment);
    }
    #endregion Delete
}
