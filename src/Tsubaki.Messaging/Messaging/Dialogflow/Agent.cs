/*
namespace Tsugumi.Messaging.Dialogflow
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Tsugumi.Configuration;

    using ApiAi;
    using Tsugumi.Configuration.Attributes;
    using ApiAi.Models;
    using System.Threading;
    using System.Diagnostics;

    using Dialogflow = Google.Apis.Dialogflow.v2;


    public class Agent
    {
        private readonly ConfigModel _config;

        public bool DevelopMode { get; }

        private const string SECRET_YML = "df.yml";

        [Route(SECRET_YML)]
        private class Config : SelfKeeper<Config>
        {
            public string Client { get; private set; }
            public string Developer { get; private set; }
        }

        public Agent(bool developMode = false)
        {
            var df = new Dialogflow.DialogflowService();
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

        public async Task<QueryResponseModel> QueryAsync(MessageBody message, CancellationToken token = default(CancellationToken))
        {
            try
            {
                return await Task.Run(() => QueryService.SendRequest(this._config, message.Payload), token);
            }
            catch (AggregateException)
            {

            }
            return default(QueryResponseModel);
        }

        public IEnumerable<EntityResponseModel> GetEntities()
        {
            return EntityService.GetEntities(this._config);
        }

        public async Task<IEnumerable<EntityResponseModel>> GetEntitiesAsync(CancellationToken token = default(CancellationToken))
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
            return default(IEnumerable<EntityResponseModel>);
        }
    }
}
*/