using finance.api.Data;
using finance.api.DTOs.Comment;
using finance.api.Interfaces;
using finance.api.Models;
using Microsoft.EntityFrameworkCore;

namespace finance.api.Repository
{
    public class CommentRepository : ICommentRepository
    {
        private readonly AppDBContext db;
        public CommentRepository(AppDBContext db)
        {
            this.db = db;
        }

        public async Task<Comment> CreateAsync(Comment model)
        {
            await db.Comments.AddAsync(model);
            await db.SaveChangesAsync();
            return model;
        }

        public async Task<Comment?> DeleteAsync(int id)
        {
            var model = await db.Comments.FirstOrDefaultAsync(v => v.Id == id);
            if (model == null)
            {
                return null;
            }
            db.Comments.Remove(model);
            await db.SaveChangesAsync();
            return model;
        }

        public async Task<List<Comment>> GetAllAsyn(CommentGetAllQuery query)
        {
            var comments = db.Comments.AsQueryable();
            if (query.Title != null)
                comments = comments.Where(v => v.Title.Contains(query.Title));
            return await comments.ToListAsync();
        }

        public async Task<Comment?> GetByIdAsync(int id)
        {
            return await db.Comments.FirstOrDefaultAsync(v => v.Id == id);
        }

        public async Task<Comment?> UpdateAsync(int id, Comment updateModel)
        {
            var model = await db.Comments.FirstOrDefaultAsync(v => v.Id == id);
            if (model == null)
            {
                return null;
            }

            model.Title = updateModel.Title;
            model.Content = updateModel.Content;
            model.StockId = updateModel.StockId;

            await db.SaveChangesAsync();
            return model;
        }
    }
}
