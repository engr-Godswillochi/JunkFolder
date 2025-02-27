using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.Comment;
using api.Models;

namespace api.Mappers
{
    public static class CommentMapper
    {
        public static CommentDto ToCommentDto (this Comment comment)
        {
            return new CommentDto{
                Id = comment.Id,
                Title = comment.Title,
                Content = comment.Content,
                CreatedBy = comment.Appuser.UserName,
                CreatedOn = comment.CreatedOn,
                StockId = comment.StockId,
            };
        }
        
        public static Comment ToCommentFromCreate (this CreateCommentDto comment, int StockId)
        {
            return new Comment{
                
                Title = comment.Title,
                Content = comment.Content,
                StockId = StockId,
            };
        }

        public static Comment ToCommentFromUpdate (this UpdateCommentRequestDto comment)
        {
            return new Comment{
                
                Title = comment.Title,
                Content = comment.Content
            };
        }
    }
}