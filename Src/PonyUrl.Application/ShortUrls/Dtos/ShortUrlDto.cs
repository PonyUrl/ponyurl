﻿using Newtonsoft.Json;
using PonyUrl.Common;
using PonyUrl.Domain;
using System;
using System.Linq.Expressions;

namespace PonyUrl.Application
{
    public class ShortUrlDto
    {
        [JsonProperty(PropertyName = "id")]
        public Guid Id { get; set; }

        [JsonProperty(PropertyName = "slug_id")]
        public Guid SlugId { get; set; }

        [JsonProperty(PropertyName = "slug_key")]
        public string SlugKey { get; set; }

        [JsonProperty(PropertyName = "long_url")]
        public string LongUrl { get; set; }

        [JsonProperty(PropertyName = "pony_link")]
        public string PonyLink { get; set; }

        [JsonProperty(PropertyName = "hits")]
        public long Hits { get; set; }

        public static Expression<Func<ShortUrl, ShortUrlDto>> Map
        {
            get
            {
                return p => new ShortUrlDto
                {
                    Id = p.Id,
                    SlugId = p.SlugId,
                    LongUrl = p.LongUrl,
                    SlugKey = p.SlugKey,
                    Hits = p.Hits
                };
            }
        }

        public ShortUrlDto MapFromEntity(ShortUrl entity, string routerDomain = "")
        {
            Check.ArgumentNotNull(entity);

            Id = entity.Id;
            SlugId = entity.SlugId;
            LongUrl = entity.LongUrl;
            Hits = entity.Hits;
            SlugKey = entity.SlugKey;
            if (Check.IsValidUrl(routerDomain))
            {
                PonyLink = $"{routerDomain.TrimEnd('/')}/{entity.SlugKey}";
            }
            return this;
        }
    }
}