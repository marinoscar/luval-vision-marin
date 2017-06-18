using luval.vision.core.resolvers;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace luval.vision.core
{
    public class ResultAnalizer
    {

        private StringResolverManager _resolverMgr;
        public event EventHandler<ProgressEventArgs> Progress;


        public ResultAnalizer()
        {
            _resolverMgr = new StringResolverManager();
        }

        private void OnEventRaised<T>(EventHandler<T> ev, T e)
        {
            EventHandler<T> handler = ev;
            if (handler != null)
            {
                handler(this, e);
            }
        }

        protected virtual void OnProgress(ProgressEventArgs e)
        {
            OnEventRaised(Progress, e);
        }

        public void FromDirectoryToCsv(string directoryName, string csvFileName)
        {
            var text = FromDirectoryToCsv(directoryName);
            File.WriteAllText(csvFileName, text);
        }

        public string FromDirectoryToCsv(string directoryName)
        {
            var items = FromDirectory(directoryName);
            var res = new List<Dictionary<string, object>>();
            GetValues(res, items);
            var sb = new StringBuilder();
            if (!res.Any()) return sb.ToString();
            var header = res.First();
            sb.AppendLine(string.Join(",", header.Keys));
            BuildString(res, sb, "Building the csv file", (r) => {
                return string.Join(",", r.Values.Select(i => Conv(i)));
            });
            return sb.ToString();
        }

        public void FromDirectoryToSql(string directoryName, string sqlTableName, bool createTableStatement, string sqlFileName)
        {
            var content = FromDirectoryToSql(directoryName, sqlTableName, createTableStatement);
            File.WriteAllText(sqlFileName, content);
        }

        public string FromDirectoryToSql(string directoryName, string sqlTableName, bool createTableStatement)
        {
            var items = FromDirectory(directoryName);
            var res = new List<Dictionary<string, object>>();
            GetValues(res, items);
            var sb = new StringBuilder();
            if (!res.Any()) return sb.ToString();
            var header = res.First();
            if (createTableStatement)
                sb.AppendLine(GetSqlTableDefinition(sqlTableName, header));
            BuildString(res, sb, "Building the sql file", (r) => {
                return GetSqlInsert(sqlTableName, r);
            });
            return sb.ToString();
        }

        private void BuildString(List<Dictionary<string, object>> res, StringBuilder sb, string message, Func<Dictionary<string, object>, string> function)
        {
            var cnt = 0;
            foreach (var r in res)
            {
                cnt++;
                sb.AppendLine(function(r));
                OnProgress(new ProgressEventArgs(message, cnt, res.Count));
            }
        }

        private void GetValues(List<Dictionary<string, object>> res, IEnumerable<ProcessResult> items)
        {
            var cnt = 0;
            var total = items.Count();
            foreach (var i in items)
            {
                cnt++;
                OnProgress(new ProgressEventArgs("Extracting values", cnt, total) { });
                res.AddRange(GetValues(i));
            }
        }

        public IEnumerable<ProcessResult> FromDirectory(string directoryName)
        {
            var dir = new DirectoryInfo(directoryName);
            var files = dir.GetFiles("*.celeris", SearchOption.TopDirectoryOnly);
            return LoadFromFiles(files.Select(i => i.FullName));
        }


        private List<Dictionary<string, object>> GetValues(ProcessResult r)
        {
            var res = new List<Dictionary<string, object>>();
            foreach (var map in r.Mappings)
            {
                var d = new Dictionary<string, object>();
                d["Id"] = r.Id;
                d["Image_Height"] = r.ImageInfo.Height;
                d["Image_Width"] = r.ImageInfo.Width;
                d["Image_HorResolution"] = r.ImageInfo.HorizontalResolution;
                d["Image_VerResolution"] = r.ImageInfo.VerticalResolution;
                d["Image_WorkingHeight"] = r.ImageInfo.WorkingHeight;
                d["Image_WorkingWidth"] = r.ImageInfo.WorkingWidth;
                d["Image_Name"] = r.ImageInfo.Name;
                d["Image_Format"] = r.ImageInfo.Format;
                d["QualityType"] = r.QualityType;
                d["UnIdentifiedLines"] = r.UnIdentifiedLines;
                d["TotalIdentifiedLines"] = r.OcrResult.Lines.Count;
                d["TotalLinesInFile"] = r.OcrResult.Lines.Count + r.UnIdentifiedLines;
                d["OcrItemIdentificationPercentage"] = (1d - ((double)r.UnIdentifiedLines / ((double)r.OcrResult.Lines.Count + (double)r.UnIdentifiedLines))) * 100d;
                d["Map_Name"] = map.AttributeName;
                var mapRes = r.TextResults.First(i => i.Map.AttributeName == map.AttributeName);
                d["Map_AnchorRankMath"] = mapRes.AnchorRankMath;
                d["Map_ElementTextNotFound"] = mapRes.ElementTextNotFound;
                d["Map_NotFound"] = mapRes.NotFound;
                d["Map_IsAnchorOnLeft"] = mapRes.IsAnchorOnLeft;
                d["Map_IsResultTagged"] = mapRes.IsResultTagged;
                d["Map_RelativeOffsetX"] = mapRes.RelativeOffsetX;
                d["Map_RelativeOffsetY"] = mapRes.RelativeOffsetY;
                if (mapRes.RelativeLocation == null) mapRes.RelativeLocation = new OcrRelativeLocation();
                d["Map_IsTopHalf"] = mapRes.RelativeLocation.IsTopHalf;
                d["Map_Quadrant"] = mapRes.RelativeLocation.Quadrant;
                d["Map_HorizontalThird"] = mapRes.RelativeLocation.HorizontalThird;
                d["Map_HorizontalQuadrant"] = mapRes.RelativeLocation.HorizontalQuadrant;
                d["Map_HorizontalSixth"] = mapRes.RelativeLocation.HorizontalSixth;
                d["Map_HorizontalEight"] = mapRes.RelativeLocation.HorizontalEight;
                d["Map_VerticalThird"] = mapRes.RelativeLocation.VerticalThird;
                d["Map_VerticalQuadrant"] = mapRes.RelativeLocation.VerticalQuadrant;
                d["Map_VerticalSixth"] = mapRes.RelativeLocation.VerticalSixth;
                d["Map_VerticalEight"] = mapRes.RelativeLocation.VerticalEight;
                d["Map_RelativeWidth"] = mapRes.RelativeLocation.Width;
                d["Map_RelativeHeight"] = mapRes.RelativeLocation.Height;
                if (mapRes.AnchorElement == null) mapRes.AnchorElement = new OcrElement();
                d["Map_Anchor_Text"] = mapRes.AnchorElement.Text;
                d["Map_Anchor_IsTopHalf"] = mapRes.AnchorElement.Location.RelativeLocation.IsTopHalf;
                d["Map_Anchor_Quadrant"] = mapRes.AnchorElement.Location.RelativeLocation.Quadrant;
                d["Map_Anchor_HorizontalThird"] = mapRes.AnchorElement.Location.RelativeLocation.HorizontalThird;
                d["Map_Anchor_HorizontalQuadrant"] = mapRes.AnchorElement.Location.RelativeLocation.HorizontalQuadrant;
                d["Map_Anchor_HorizontalSixth"] = mapRes.AnchorElement.Location.RelativeLocation.HorizontalSixth;
                d["Map_Anchor_HorizontalEight"] = mapRes.AnchorElement.Location.RelativeLocation.HorizontalEight;
                d["Map_Anchor_VerticalThird"] = mapRes.AnchorElement.Location.RelativeLocation.VerticalThird;
                d["Map_Anchor_VerticalQuadrant"] = mapRes.AnchorElement.Location.RelativeLocation.VerticalQuadrant;
                d["Map_Anchor_VerticalSixth"] = mapRes.AnchorElement.Location.RelativeLocation.VerticalSixth;
                d["Map_Anchor_VerticalEight"] = mapRes.AnchorElement.Location.RelativeLocation.VerticalEight;
                if (mapRes.ResultElement == null) mapRes.ResultElement = new OcrElement();
                var resultLine = r.OcrResult.Lines.FirstOrDefault(i => mapRes.ResultElement.Id > 0 && mapRes.ResultElement.Id == i.Id);
                d["Map_Result_Text"] = mapRes.ResultElement.Text;
                d["Map_Result_Value"] = mapRes.Value;
                d["Map_ResultScalarRank"] = mapRes.ScalarRank;
                d["Map_Result_IsTopHalf"] = mapRes.ResultElement.Location.RelativeLocation.IsTopHalf;
                d["Map_Result_Quadrant"] = mapRes.ResultElement.Location.RelativeLocation.Quadrant;
                d["Map_Result_HorizontalThird"] = mapRes.ResultElement.Location.RelativeLocation.HorizontalThird;
                d["Map_Result_HorizontalQuadrant"] = mapRes.ResultElement.Location.RelativeLocation.HorizontalQuadrant;
                d["Map_Result_HorizontalSixth"] = mapRes.ResultElement.Location.RelativeLocation.HorizontalSixth;
                d["Map_Result_HorizontalEight"] = mapRes.ResultElement.Location.RelativeLocation.HorizontalEight;
                d["Map_Result_VerticalThird"] = mapRes.ResultElement.Location.RelativeLocation.VerticalThird;
                d["Map_Result_VerticalQuadrant"] = mapRes.ResultElement.Location.RelativeLocation.VerticalQuadrant;
                d["Map_Result_VerticalSixth"] = mapRes.ResultElement.Location.RelativeLocation.VerticalSixth;
                d["Map_Result_VerticalEight"] = mapRes.ResultElement.Location.RelativeLocation.VerticalEight;
                d["Map_Result_HasNumber"] = resultLine == null ? false : resultLine.HasNumber;
                d["Map_Result_HasCode"] = resultLine == null ? false : resultLine.HasCode;
                d["Map_Result_HasDate"] = resultLine == null ? false : resultLine.HasDate;
                d["Map_Result_HasAmount"] = resultLine == null ? false : resultLine.HasAmount;
                d["Map_IsScalarRank"] = (bool)d["Map_Result_HasNumber"] || (bool)d["Map_Result_HasDate"] || (bool)d["Map_Result_HasAmount"];
                res.Add(d);
            }
            return res;
        }

        private string GetSqlInsert(string tableName, Dictionary<string, object> dic)
        {
            var values = string.Join(",", dic.Values.Select(i => SqlFormat(i)));
            return string.Format("INSERT INTO {0} ({1}) VALUES ({2});", tableName, string.Join(",", dic.Keys), values);
        }

        private string GetSqlTableDefinition(string tableName, Dictionary<string, object> dic)
        {
            var cols = new List<string>();
            foreach (KeyValuePair<string, object> kv in dic)
            {
                cols.Add(string.Format("{0} {1} NULL", kv.Key, GetSqlType(kv.Value.GetType())));
            }
            return GetTableTemplate().Replace("@table", tableName).Replace("@columns", string.Join(", ", cols));
        }

        private string SqlFormat(object obj)
        {
            if (obj == null) return "NULL";
            var str = Conv(obj).Replace("'", "''");
            return obj.GetType().IsValueType ? str : string.Format("'{0}'", str);

        }
        private string GetSqlType(Type type)
        {
            if (type == typeof(bool)) return "BIT";
            if (type == typeof(short)) return "SMALLINT";
            if (type == typeof(int)) return "INT";
            if (type == typeof(long)) return "BIGINT";
            if (type == typeof(double)) return "DECIMAL";
            if (type == typeof(decimal)) return "DECIMAL";
            if (type == typeof(DateTime)) return "DATETIME";
            return "VARCHAR(MAX)";
        }

        private string GetTableTemplate()
        {
            return @"
IF OBJECT_ID('@table') IS NOT NULL
BEGIN
	DROP TABLE @table;
END
GO
CREATE TABLE @table(
IndentityId int IDENTITY(1,1) primary key,
@columns,
UtcTimestamp datetime DEFAULT(GETUTCDATE())
);
";
        }

        private string Conv(object obj)
        {
            if (obj is DateTime) return ((DateTime)obj).ToString("YYYY-MM-DD hh:mm:ss");
            if (obj is bool) return ((bool)obj) ? "1" : "0";
            if (obj == null) return string.Empty;
            return Convert.ToString(obj);
        }

        private List<ProcessResult> LoadFromFiles(IEnumerable<string> files)
        {
            var res = new List<ProcessResult>();
            var count = 0;
            foreach (var f in files)
            {
                var i = JsonConvert.DeserializeObject<ProcessResult>(File.ReadAllText(f));
                res.Add(i);
                count++;
                OnProgress(new ProgressEventArgs("Loading file data into memory", count, files.Count()));
            }
            return res;
        }



    }
}

