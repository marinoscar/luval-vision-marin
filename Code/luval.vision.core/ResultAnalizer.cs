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
            var dir = new DirectoryInfo(directoryName);
            var files = dir.GetFiles("*.celeris", SearchOption.TopDirectoryOnly);
            var items = LoadFromFiles(files.Select(i => i.FullName));
            var res = new List<Dictionary<string, string>>();
            foreach (var i in items)
            {
                res.AddRange(GetValues(i));
            }
            var sb = new StringBuilder();
            if (!res.Any()) return sb.ToString();
            var header = res.First();
            sb.AppendLine(string.Join(",", header.Keys));
            foreach(var r in res)
            {
                sb.AppendLine(string.Join(",", r.Values));
            }
            return sb.ToString();
        }

        private List<Dictionary<string, string>> GetValues(ProcessResult r)
        {
            var res = new List<Dictionary<string, string>>();
            foreach(var map in r.Mappings)
            {
                var d = new Dictionary<string, string>();
                d["Id"] = r.Id;
                d["Image_Height"] = Conv(r.ImageInfo.Height);
                d["Image_Width"] = Conv(r.ImageInfo.Width);
                d["Image_HorResolution"] = Conv(r.ImageInfo.HorizontalResolution);
                d["Image_VerResolution"] = Conv(r.ImageInfo.VerticalResolution);
                d["Image_WorkingHeight"] = Conv(r.ImageInfo.WorkingHeight);
                d["Image_WorkingWidth"] = Conv(r.ImageInfo.WorkingWidth);
                d["Image_Name"] = Conv(r.ImageInfo.Name);
                d["Image_Format"] = Conv(r.ImageInfo.Format);
                d["QualityType"] = Conv(r.QualityType);
                d["Map_Name"] = Conv(map.AttributeName);
                var mapRes = r.TextResults.First(i => i.Map.AttributeName == map.AttributeName);
                d["Map_AnchorRankMath"] = Conv(mapRes.AnchorRankMath);
                d["Map_ElementTextNotFound"] = Conv(mapRes.ElementTextNotFound);
                d["Map_IsAnchorOnLeft"] = Conv(mapRes.IsAnchorOnLeft);
                d["Map_IsResultTagged"] = Conv(mapRes.IsResultTagged);
                d["Map_NotFound"] = Conv(mapRes.NotFound);
                d["Map_RelativeOffsetX"] = Conv(mapRes.RelativeOffsetX);
                d["Map_RelativeOffsetY"] = Conv(mapRes.RelativeOffsetY);
                if (mapRes.RelativeLocation == null) mapRes.RelativeLocation = new OcrRelativeLocation();
                d["Map_IsTopHalf"] = Conv(mapRes.RelativeLocation.IsTopHalf);
                d["Map_Quadrant"] = Conv(mapRes.RelativeLocation.Quadrant);
                d["Map_HorizontalThird"] = Conv(mapRes.RelativeLocation.HorizontalThird);
                d["Map_HorizontalQuadrant"] = Conv(mapRes.RelativeLocation.HorizontalQuadrant);
                d["Map_HorizontalSixth"] = Conv(mapRes.RelativeLocation.HorizontalSixth);
                d["Map_HorizontalEight"] = Conv(mapRes.RelativeLocation.HorizontalEight);
                d["Map_VerticalThird"] = Conv(mapRes.RelativeLocation.VerticalThird);
                d["Map_VerticalQuadrant"] = Conv(mapRes.RelativeLocation.VerticalQuadrant);
                d["Map_VerticalSixth"] = Conv(mapRes.RelativeLocation.VerticalSixth);
                d["Map_VerticalEight"] = Conv(mapRes.RelativeLocation.VerticalEight);
                d["Map_RelativeWidth"] = Conv(mapRes.RelativeLocation.Width);
                d["Map_RelativeHeight"] = Conv(mapRes.RelativeLocation.Height);
                if (mapRes.AnchorElement == null) mapRes.AnchorElement = new OcrElement();
                d["Map_Anchor_Text"] = Conv(mapRes.AnchorElement.Text);
                d["Map_Anchor_IsTopHalf"] = Conv(mapRes.AnchorElement.Location.RelativeLocation.IsTopHalf);
                d["Map_Anchor_Quadrant"] = Conv(mapRes.AnchorElement.Location.RelativeLocation.Quadrant);
                d["Map_Anchor_HorizontalThird"] = Conv(mapRes.AnchorElement.Location.RelativeLocation.HorizontalThird);
                d["Map_Anchor_HorizontalQuadrant"] = Conv(mapRes.AnchorElement.Location.RelativeLocation.HorizontalQuadrant);
                d["Map_Anchor_HorizontalSixth"] = Conv(mapRes.AnchorElement.Location.RelativeLocation.HorizontalSixth);
                d["Map_Anchor_HorizontalEight"] = Conv(mapRes.AnchorElement.Location.RelativeLocation.HorizontalEight);
                d["Map_Anchor_VerticalThird"] = Conv(mapRes.AnchorElement.Location.RelativeLocation.VerticalThird);
                d["Map_Anchor_VerticalQuadrant"] = Conv(mapRes.AnchorElement.Location.RelativeLocation.VerticalQuadrant);
                d["Map_Anchor_VerticalSixth"] = Conv(mapRes.AnchorElement.Location.RelativeLocation.VerticalSixth);
                d["Map_Anchor_VerticalEight"] = Conv(mapRes.AnchorElement.Location.RelativeLocation.VerticalEight);
                if (mapRes.ResultElement == null) mapRes.ResultElement = new OcrElement();
                d["Map_Result_Text"] = Conv(mapRes.ResultElement.Text);
                d["Map_Result_IsTopHalf"] = Conv(mapRes.ResultElement.Location.RelativeLocation.IsTopHalf);
                d["Map_Result_Quadrant"] = Conv(mapRes.ResultElement.Location.RelativeLocation.Quadrant);
                d["Map_Result_HorizontalThird"] = Conv(mapRes.ResultElement.Location.RelativeLocation.HorizontalThird);
                d["Map_Result_HorizontalQuadrant"] = Conv(mapRes.ResultElement.Location.RelativeLocation.HorizontalQuadrant);
                d["Map_Result_HorizontalSixth"] = Conv(mapRes.ResultElement.Location.RelativeLocation.HorizontalSixth);
                d["Map_Result_HorizontalEight"] = Conv(mapRes.ResultElement.Location.RelativeLocation.HorizontalEight);
                d["Map_Result_VerticalThird"] = Conv(mapRes.ResultElement.Location.RelativeLocation.VerticalThird);
                d["Map_Result_VerticalQuadrant"] = Conv(mapRes.ResultElement.Location.RelativeLocation.VerticalQuadrant);
                d["Map_Result_VerticalSixth"] = Conv(mapRes.ResultElement.Location.RelativeLocation.VerticalSixth);
                d["Map_Result_VerticalEight"] = Conv(mapRes.ResultElement.Location.RelativeLocation.VerticalEight);
                d["Map_Result_HasNumber"] = Conv(_resolverMgr.ContainsNumber(mapRes.ResultElement.Text));
                d["Map_Result_HasCode"] = Conv(_resolverMgr.ContainsCode(mapRes.ResultElement.Text));
                d["Map_Result_HasDate"] = Conv(_resolverMgr.ContainsDate(mapRes.ResultElement.Text));
                d["Map_Result_HasAmount"] = Conv(_resolverMgr.ContainsAmount(mapRes.ResultElement.Text));
                res.Add(d);
            }
            return res;
        }


        private string Conv(object obj)
        {
            if (obj is DateTime) return ((DateTime)obj).ToString("YYYY-MM-DD hh:mm:ss");
            if (obj == null) return string.Empty;
            return Convert.ToString(obj);
        }

        private List<ProcessResult> LoadFromFiles(IEnumerable<string> files)
        {
            var res = new List<ProcessResult>();
            foreach(var f in files)
            {
                var i = JsonConvert.DeserializeObject<ProcessResult>(File.ReadAllText(f));
                res.Add(i);
            }
            return res;
        }



    }
}

