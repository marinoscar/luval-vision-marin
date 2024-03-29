﻿using luval.vision.core;
using luval.vision.google;
using Microsoft.Recognizers.Text;
using Newtonsoft.Json;
using OfficeOpenXml;
using OfficeOpenXml.Table;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace luval.vision.app
{
    public class BatchProcessing
    {
        private OcrProvider _ocrProvider;
        private ICustomLog _log;

        public BatchProcessing(ICustomLog log)
        {
            if (log == null) throw new ArgumentNullException("log");
            _log = log;
            _ocrProvider = new OcrProvider(new GoogleOcrEngine(), new GoogleVisionLoader());
        }

        public void DoFolder(string folderName, string filter = null)
        {
            ValidateDirParams(folderName);
            var dir = new DirectoryInfo(folderName);
            var json = dir.GetFiles("*.json", SearchOption.TopDirectoryOnly).FirstOrDefault();
            if (json == null) throw new InvalidOperationException(string.Format("Missing json configuration file in folder {0}", folderName));
            DoFolder(folderName, json.FullName, filter);
        }

        public void DoFolder(string folderName, string jsonPath, string filter = null)
        {
            var results = new List<Result>();
            ValidateParams(folderName, jsonPath);
            var json = new FileInfo(jsonPath);
            var options = JsonConvert.DeserializeObject<ConfigOptions>(File.ReadAllText(jsonPath));
            var dir = new DirectoryInfo(folderName);
            if (string.IsNullOrWhiteSpace(filter)) filter = "*.png";
            var files = dir.GetFiles(filter, SearchOption.AllDirectories).ToList();
            _log.WriteInformation("Procesing {0} files", files.Count());
            foreach(var file in files)
            {
                foreach(var result in ProcessFile(file, options))
                {
                    results.Add(new Result() { 
                        File = file, Json = json.Name, FieldResult = result
                    });
                }
                _log.WriteInformation("File {0} of {1} completed", files.IndexOf(file) + 1, files.Count);
            }
            SaveResults(files.First().Directory, results);
        }

        private void SaveResults(DirectoryInfo directory, List<Result> results)
        {
            var fileInfo = new FileInfo(GetOutFileName(directory));
            if (fileInfo.Exists) fileInfo.Delete();

            using (var package = new ExcelPackage(fileInfo))
            {
                var sheet = package.Workbook.Worksheets.Add("Results");
                sheet.Cells[1, 1].Value = "File";
                sheet.Cells[1, 2].Value = "Config";
                sheet.Cells[1, 3].Value = "Field";
                sheet.Cells[1, 4].Value = "Value";
                var row = 2;
                foreach (var result in results)
                {
                    sheet.Cells[row, 1].Value = result.File.Name;
                    sheet.Cells[row, 1].Hyperlink = new Uri("file:///" + result.File.FullName);
                    sheet.Cells[row, 1].Style.Font.UnderLine = true;
                    sheet.Cells[row, 1].Style.Font.Color.SetColor(Color.Blue);

                    sheet.Cells[row, 2].Value = result.Json;
                    sheet.Cells[row, 3].Value = result.FieldResult.Option.FieldName;
                    sheet.Cells[row, 4].Value = result.FieldResult.Value;
                    row++;
                }
                var range = sheet.Cells[1, 1, row-1, 4];
                var tab = sheet.Tables.Add(range, "DataTable");
                tab.TableStyle = TableStyles.Medium2;
                range.AutoFitColumns();
                // Save to file
                package.Save();
            }
        }

        private string GetOutFileName(DirectoryInfo dir)
        {
            return Path.Combine(dir.FullName, "output.xlsx");
        }

        public List<ExtractionResult> ProcessFile(FileInfo fileInfo, ConfigOptions options)
        {
            var ocrResult = _ocrProvider.DoOcr(fileInfo.FullName);
            var extractor = new Extractor(options, ocrResult.Regions.First(), ocrResult.Info);
            return extractor.GetValues().ToList();
        }

        private void ValidateParams(string folderName, string jsonPath)
        {
            ValidateDirParams(folderName);
            if (string.IsNullOrWhiteSpace(jsonPath)) throw new ArgumentNullException("jsonPath");
            if (!File.Exists(jsonPath)) throw new ArgumentException(string.Format("File {0} does not exists", jsonPath));
        }

        private void ValidateDirParams(string folderName)
        {
            if (string.IsNullOrWhiteSpace(folderName)) throw new ArgumentNullException("folderName");
            if (!Directory.Exists(folderName)) throw new ArgumentException(string.Format("Folder {0} does not exists", folderName));
        }

        private class Result { public FileInfo File; public string Json; public ExtractionResult FieldResult;  }

    }
}
