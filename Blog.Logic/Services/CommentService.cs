using AutoMapper;
using Blog.Data.Entities;
using Blog.Data.Repositories;
using Blog.Data.UoW;
using Blog.Logic.Models;

namespace Blog.Logic.Services
{
    public class CommentService : ICommentService
    {
        private readonly IRepository<CommentEntity> _repo;
        private readonly IMapper _mapper;

        public CommentService(
            IUnitOfWork unitOfWork,
            IMapper mapper)
        {
            _repo = unitOfWork.GetRepository<CommentEntity>(false);
            _mapper = mapper;
        }

        public async Task CreateComment(CommentModel comment)
        {
            var entity = _mapper.Map<CommentEntity>(comment);

            await _repo.Create(entity);
        }

        public async Task<CommentModel> GetComment(int id)
        {
            var entity = await _repo.Get(id);
            var comment = _mapper.Map<CommentModel>(entity);

            return comment;
        }

        public List<CommentModel> GetComments()
        {
            var entities = _repo.GetAll();
            var comments = _mapper.Map<List<CommentModel>>(entities);

            return comments;
        }

        public async Task UpdateComment(CommentModel comment)
        {
            var entity = await _repo.Get(comment.Id);

            entity.Content = comment.Content;

            await _repo.Update(entity);
        }

        public async Task DeleteComment(CommentModel comment)
        {
            var entity = await _repo.Get(comment.Id);

            await _repo.Delete(entity);
        }
    }
}
