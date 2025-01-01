using finance.api.DTOs.Comment;
using finance.api.Models;

namespace finance.api.Mappers
{
    public static class CommentMappers
    {
        public static CommentDto ToDto(this Comment model)
        {
            return new CommentDto
            {
                Id = model.Id,
                Content = model.Content,
                CreateOn = model.CreateOn,
                StockId = model.StockId,
                Title = model.Title
            };
        }

        public static Comment ToModel(this CommentDto dto)
        {
            return new Comment()
            {
                Content = dto.Content,
                StockId = dto.StockId,
                Title = dto.Title
            };
        }

        public static Comment ToModel(this CreateCommentDto dto)
        {
            return new Comment()
            {
                Content = dto.Content,
                StockId = dto.StockId,
                Title = dto.Title
            };
        }
        public static Comment ToModel(this UpdateCommentDto dto)
        {
            return new Comment()
            {
                Content = dto.Content,
                StockId = dto.StockId,
                Title = dto.Title
            };
        }

    }
}
