using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace WatchListMovies.Infrastructure.Persistent.Ef.Genre
{
    public class GenreConfiguration : IEntityTypeConfiguration<Domain.GenreAgg.Genre>
    {
        public void Configure(EntityTypeBuilder<Domain.GenreAgg.Genre> builder)
        {
            builder.HasIndex(b => b.ApiModelId);
            builder.HasIndex(b => b.Name);
            builder.HasIndex(b => b.GenreType);

        }
    }
}
