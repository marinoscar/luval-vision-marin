using luval.vision.core;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace luval.vision.ml
{
    public class ModelProcesor
    {
        public ModelProcesor(IModelProvider provider)
        {
            Provider = provider;
        }

        public IModelProvider Provider { get; private set; }

        public IEnumerable<ModelResult> GetScoredResults(ProcessResult processResult)
        {
            PrepareResultModel(processResult);
            var mappingVector = ResultAnalizer.GetMappingVector(processResult);
            var elements = FilterElements(mappingVector);
            var result = Provider.Execute(elements);
            var resultText = JsonConvert.SerializeObject(result); 
            return result;
        }

        private void PrepareResultModel(ProcessResult processResult)
        {
            var mappings = processResult.Mappings;
            foreach(var map in processResult.Mappings)
            {
                if (processResult.TextResults.Any(i => i.Map.AttributeName == map.AttributeName)) continue;
                processResult.TextResults.Add(new MappingResult() {
                    AnchorElement = new OcrElement(),
                    ElementTextNotFound = true,
                    Map = map,
                    NotFound = true,
                });
            }
        }

        private List<Dictionary<string, object>> FilterElements(List<Dictionary<string, object>> elements)
        {
            var keys = ConfigurationManager.AppSettings["ml.request.columns"].Split(",".ToCharArray());
            var result = new List<Dictionary<string, object>>();
            foreach(var el in elements)
            {
                var filteredEl = new Dictionary<string, object>();
                foreach(var key in keys)
                {
                    filteredEl[key] = el[key];
                }
                result.Add(filteredEl);
            }
            return result;
        }
    }
}
