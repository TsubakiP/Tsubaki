
namespace Tsubaki.Messaging.Dialogflow
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using Tsubaki.Configuration;

    using ApiAi;
    using Tsubaki.Configuration.Attributes;
    using ApiAi.Exceptions;
    using ApiAi.Models;
    using Tsubaki.Exceptions;
    using System.Threading;
    using System.Diagnostics;

    public class Agent
    {
        private readonly ConfigModel _config;

        public bool DevelopMode { get; }

        private const string SECRET_YML = "secret.yml";

        [Route(SECRET_YML)]
        private class Config : SelfDisciplined<Config>
        {
            public string Client { get; private set; }
            public string Developer { get; private set; }
        }

        public Agent(bool developMode = false)
        {
            var clientSecret = Config.Load();
            if (developMode && !string.IsNullOrWhiteSpace(clientSecret.Developer))
            {
                this._config = new ConfigModel
                {
                    AccesTokenDeveloper = clientSecret.Developer,
                };
            }
            else if (!developMode && !string.IsNullOrWhiteSpace(clientSecret.Client))
            {
                this._config = new ConfigModel
                {
                    AccesTokenClient = clientSecret.Client,
                };
            }
            else
            {
                throw new TsubakiException($"Unable to load config file '{SECRET_YML}'.");
            }
            this.DevelopMode = developMode;
        }

        public async Task<QueryResponseModel> QueryAsync(MessageBody message, CancellationToken token = default)
        {
            try
            {
                return await Task.Run(() => QueryService.SendRequest(this._config, message.Payload), token);
            }
            catch (AggregateException)
            {

            }
            return default;
        }

        public IEnumerable<EntityResponseModel> GetEntities()
        {
            return EntityService.GetEntities(this._config);
        }

        public async Task<IEnumerable<EntityResponseModel>> GetEntitiesAsync(CancellationToken token = default)
        {
            try
            {
                return await Task.Run(() => EntityService.GetEntities(this._config), token);
            }
            catch (AggregateException ae)
            {
                foreach (var item in ae.InnerExceptions)
                {
                    Debug.WriteLine(item.Message);
                }
            }
            return default;
        }
    }
}