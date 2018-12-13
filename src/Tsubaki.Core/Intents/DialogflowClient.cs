
namespace Tsubaki.Core.Intents
{
    using ApiAi;
    using ApiAi.Enums;
    using ApiAi.Models;
    using System.Diagnostics;
    using Tsubaki.Core.Conversions;

    public sealed class DialogflowClient : IQueryClient
    {
        private readonly ConfigModel _cfg;       

        public DialogflowClient(string token)
        { 
            this._cfg = new ConfigModel
            {
                AccesTokenClient = token,
                Language = LanguagesEnum.ChineseTraditional
            };
        }

        public IQueryConversion Query(string text)
        {
            try
            {
                var q = QueryService.SendRequest(this._cfg, text);
                var result = QueryConversion.Create(q.IntentName, q.Parameters);
                Debug.WriteLine(" ---- Dialogflow Response ----");
                Debug.WriteLine("Intent: " + result.Intent);
                foreach (var item in result.Parameters)
                {
                    Debug.WriteLine($"Parameter: ['{item.Key}': '{(string.IsNullOrWhiteSpace(item.Value) ? "<empty>" : item.Value)}']");
                }
                Debug.WriteLine(" ---------------------------- ");

                return result;
            }
            catch (ApiAi.Exceptions.ApiAiException e)
            {
                throw e;
            }
        }
    }
}
