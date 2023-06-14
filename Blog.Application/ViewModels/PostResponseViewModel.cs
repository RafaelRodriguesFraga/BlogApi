using Blog.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Application.ViewModels
{
    public class PostResponseViewModel
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string Meta { get; set; }
        public string[] Tags { get; set; }
        public string Slug { get; set; }
        //public ThumbnailViewModel Thumbnail { get; set; }

        //public static implicit operator Post(PostResponseViewModel viewModel)
        //{
        //    return new Post(viewModel.Title, viewModel.Content, viewModel.Meta, viewModel.Tags);
        //}
      
    }
}
