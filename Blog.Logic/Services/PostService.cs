using AutoMapper;
using Blog.Data.Entities;
using Blog.Data.Repositories;
using Blog.Data.UoW;
using Blog.Logic.Extensions;
using Blog.Logic.Models;

namespace Blog.Logic.Services
{
    public class PostService : IPostService
    {
        private readonly IRepository<PostEntity> _repo;
        private readonly IMapper _mapper;

        public PostService(
            IUnitOfWork unitOfWork,
            IMapper mapper) 
        {
            _repo = unitOfWork.GetRepository<PostEntity>(false);
            _mapper = mapper;
        }

        public async Task CreatePost(PostModel post)
        {
            var entity = _mapper.Map<PostEntity>(post);

            await _repo.Create(entity);
        }

        public List<PostModel> GetPosts()
        {
            var entities = _repo.GetAll();
            var posts = _mapper.Map<List<PostModel>>(entities);

            return posts;
        }

        public List<PostModel> GetPosts(int authorId)
        {
            return GetPosts().Where(x => x.UserId == authorId).ToList();
        }

        public async Task UpdatePost(PostModel post)
        {
            var entity = await _repo.Get(post.Id);

            entity.MergeChanges(post);

            await _repo.Update(entity);
        }

        public async Task DeletePost(PostModel post)
        {
            var entity = await _repo.Get(post.Id);

            await _repo.Delete(entity);
        }
    }
}
