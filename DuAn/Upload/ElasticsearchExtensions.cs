using Elasticsearch.Net;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Nest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Upload.Models;

namespace Upload
{
    public static class ElasticsearchExtensions
    {
        public static void AddElasticsearch(this IServiceCollection services, IConfiguration configuration)
        {
            var defaultIndex = configuration["elasticsearch:index"];
            services.AddSingleton<IElasticClient>(sp =>
            {
                var config = sp.GetRequiredService<IConfiguration>();
                var settings = new ConnectionSettings(config["cloudId"], new BasicAuthenticationCredentials("elastic", config["password"]))
                .DefaultIndex(defaultIndex).DefaultMappingFor<File>(m => m.IndexName("content"));

                return new ElasticClient(settings);
            });
        }

        private static void AddDefaultMappings(ConnectionSettings settings)
        {
            settings.
                DefaultMappingFor<File>(m => m
                .Ignore(p => p.TenantID)
            );
        }

        private static void CreateIndex(IElasticClient client, string indexName)
        {
            var createIndexResponse = client.Indices.Create(indexName,
                index => index.Map<File>(x => x.AutoMap())
            );
        }
    }
}
