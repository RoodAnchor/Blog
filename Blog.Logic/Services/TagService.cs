using AutoMapper;
using Blog.Data.Entities;
using Blog.Data.Repositories;
using Blog.Data.UoW;
using Blog.Logic.Models;

namespace Blog.Logic.Services
{
    public class TagService : ITagService
    {
        private readonly IRepository<TagEntity> _repo;
        private readonly IMapper _mapper;

        public TagService(
            IUnitOfWork unitOfWork,
            IMapper mapper)
        {
            _repo = unitOfWork.GetRepository<TagEntity>(false);
            _mapper = mapper;
        }

        public async Task CreateTag(TagModel tag)
        {
            var entity = _mapper.Map<TagEntity>(tag);

            await _repo.Create(entity);
        }

        public async Task<TagModel> GetTag(int id) 
        {
            var entity = await _repo.Get(id);
            var tag = _mapper.Map<TagModel>(entity);

            return tag;
        }

        public List<TagModel> GetTags()
        {
            var entities = _repo.GetAll();
            var tags = _mapper.Map<List<TagModel>>(entities);

            return tags;
        }

        public async Task UpdateTag(TagModel tag)
        {
            var entity = await _repo.Get(tag.Id);

            entity.Name = tag.Name;

            await _repo.Update(entity);
        }

        public async Task DeleteTag(TagModel tag)
        {
            var entity = await _repo.Get(tag.Id);

            await _repo.Delete(entity);
        }
    }
}
