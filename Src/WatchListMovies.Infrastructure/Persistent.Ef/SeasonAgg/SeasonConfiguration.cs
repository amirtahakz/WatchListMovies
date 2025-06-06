using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WatchListMovies.Domain.CompanyAgg;

namespace WatchListMovies.Infrastructure.Persistent.Ef.SeasonAgg
{
    public class SeasonConfiguration : IEntityTypeConfiguration<Domain.SeasonAgg.Season>
    {
        public void Configure(EntityTypeBuilder<Domain.SeasonAgg.Season> builder)
        {
            builder.HasKey(b => b.Id);
            builder.HasIndex(b => b.ApiModelId).IsUnique();
            builder.HasIndex(b => b.Name);
        }
    }
}
