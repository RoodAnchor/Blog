using AutoMapper;
using Blog.Data.Entities;
using Blog.Data.Repositories;
using Blog.Data.UoW;
using Blog.Logic.Models;
using Blog.Logic.Exceptions;

namespace Blog.Logic.Services;

public class CommentService : ICommentService
{
    private readonly IRepository<CommentEntity> _commentRepo;
    private readonly UserRepository? _userRepo;
    private readonly PostRepository? _postRepo;
    private readonly IMapper _mapper;

    public CommentService(
        IUnitOfWork unitOfWork,
        IMapper mapper)
    {
        _commentRepo = unitOfWork.GetRepository<CommentEntity>(false);
        _userRepo = unitOfWork.GetRepository<UserEntity>() as UserRepository;
        _postRepo = unitOfWork.GetRepository<PostEntity>() as PostRepository;
        _mapper = mapper;
    }

    public async Task CreateComment(CommentModel comment)
    {
        var entity = _mapper.Map<CommentEntity>(comment);

        entity.Post = await _postRepo!.Get(comment.PostId);
        entity.User = await _userRepo!.Get(comment.UserId);

        await _commentRepo.Create(entity);
    }

    public async Task<CommentModel> GetComment(int id)
    {
        var entity = await _commentRepo.Get(id);
        var comment = _mapper.Map<CommentModel>(entity);

        return comment;
    }

    public List<CommentModel> GetComments()
    {
        var entities = _commentRepo.GetAll();
        var comments = _mapper.Map<List<CommentModel>>(entities);

        return comments;
    }

    public async Task UpdateComment(CommentModel comment)
    {
        var entity = await _commentRepo.Get(comment.Id);

        if (entity == null) throw new CommentNotFoundException();

        entity.Content = comment.Content;

        await _commentRepo.Update(entity);
    }

    public async Task DeleteComment(CommentModel comment)
    {
        var entity = await _commentRepo.Get(comment.Id);

        if (entity == null) throw new CommentNotFoundException();

        await _commentRepo.Delete(entity);
    }
}
