using finance.api.DTOs.Comment;
using finance.api.Models;

namespace finance.api.Interfaces
{
    public interface ICommentRepository
    {
        public Task<List<Comment>> GetAllAsyn(CommentGetAllQuery query);
        public Task<Comment?> GetByIdAsync(int id);
        public Task<Comment> CreateAsync(Comment model);
        public Task<Comment?> UpdateAsync(int id, Comment model);
        public Task<Comment?> DeleteAsync(int id);
    }
}
