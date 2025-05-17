using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WatchListMovies.Common.Domain;

namespace WatchListMovies.Domain.CastAgg
{
    public class CastExternalId : BaseEntity
    {
        public CastExternalId()
        {

        }

        public CastExternalId(
            Guid castId,
            long? apiModelId,
            string? freebaseMid,
            string? freebaseId,
            string? imdbId,
            long? tvrageId,
            string? wikidataId,
            string? facebookId,
            string? instagramId,
            string? tiktokId,
            string? twitterId,
            string? youtubeId)
        {
            CastId = castId;
            ApiModelId = apiModelId;
            FreebaseMid = freebaseMid;
            FreebaseId = freebaseId;
            ImdbId = imdbId;
            TvrageId = tvrageId;
            WikidataId = wikidataId;
            FacebookId = facebookId;
            InstagramId = instagramId;
            TiktokId = tiktokId;
            TwitterId = twitterId;
            YoutubeId = youtubeId;
        }

        public Guid CastId { get; set; }
        public long? ApiModelId { get; set; }
        public string? FreebaseMid { get; set; }
        public string? FreebaseId { get; set; }
        public string? ImdbId { get; set; }
        public long? TvrageId { get; set; }
        public string? WikidataId { get; set; }
        public string? FacebookId { get; set; }
        public string? InstagramId { get; set; }
        public string? TiktokId { get; set; }
        public string? TwitterId { get; set; }
        public string? YoutubeId { get; set; }
    }
}
