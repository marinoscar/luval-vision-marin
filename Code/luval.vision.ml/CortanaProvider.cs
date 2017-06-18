﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using luval.vision.core;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.Configuration;
using RestSharp;
using System.Net;

namespace luval.vision.ml
{
    public class CortanaProvider : IModelProvider
    {
        public List<ModelResult> Execute(List<Dictionary<string, object>> elements)
        {
            var response = GetResponse(elements);
            if(response.StatusCode != HttpStatusCode.OK)
                throw new InvalidOperationException(string.Format("Unable to process request status {0}\n{1}", response.StatusCode, response.Content), response.ErrorException);
            return ParseResponse(response.Content);
        }

        private JObject GetPayload(List<Dictionary<string, object>> elements)
        {
            var json = new JObject();
            if (!elements.Any()) return json;
            var values = new List<List<object>>();
            elements.ForEach(d => values.Add(d.Values.ToList()));
            json["Inputs"]["invoice_set"]["ColumnNames"] = JArray.FromObject(elements.First().Select(i => i.Key).ToArray());
            json["Inputs"]["invoice_set"]["ColumnNames"] = JArray.FromObject(values);
            json["GlobalParameters"] = new JObject();
            return json;
        }

        private IRestResponse GetResponse(List<Dictionary<string, object>> elements)
        {
            var key = ConfigurationManager.AppSettings["azure.vision.ml.token"];
            var endPoint = ConfigurationManager.AppSettings["luval.vision.ml.endpoint.request"];
            var client = new RestClient(endPoint);
            var request = new RestRequest(Method.POST);
            var payload = GetPayload(elements).ToString();
            request.AddParameter("Authorization", string.Format("Bearer {0}", key), ParameterType.HttpHeader);
            request.AddHeader("Content-Length", payload.Length.ToString());
            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("Accept", "application/json");
            return client.Execute(request);
        }

        private List<ModelResult> ParseResponse(string content)
        {
            var resultArrays = new List<List<string>>();
            var criteria = "Scored Probabilities for Class ";
            var json = JObject.Parse(content);
            var columnNames = json["Results"]["invoice_result"]["value"]["ColumnNames"].ToObject<List<string>>();
            var values = json["Results"]["invoice_result"]["value"]["Values"].ToObject<List<List<string>>>().ToList();
            var labelIndex = columnNames.IndexOf("Scored Labels");
            var attributeScores = columnNames.Where(i => i.StartsWith(criteria)).ToList();
            var mapResults = attributeScores.Select(i => i.Replace(criteria, "").Trim()).ToList();
            var results = new List<ModelResult>();
            foreach(var e in values)
            {
                var modelRes = new ModelResult() { ScoredAttribute = e[labelIndex] };
                var attScore = new Dictionary<string, double>();
                for (int i = 0; i < attributeScores.Count; i++)
                {
                    attScore[mapResults[i]] = Convert.ToDouble(columnNames.IndexOf(attributeScores[i]));
                }
                results.Add(modelRes);
            }
            return results;

        }
    }
}
