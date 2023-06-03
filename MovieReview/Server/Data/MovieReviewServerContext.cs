using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MovieReview.Server.Model;

namespace MovieReview.Server.Data
{
    public class MovieReviewServerContext : DbContext
    {
        public MovieReviewServerContext (DbContextOptions<MovieReviewServerContext> options)
            : base(options)
        {
        }

        public DbSet<MovieReview.Server.Model.MovieData> MovieData { get; set; } = default!;
    }
}
