using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

using luval.vision.core;
using luval.vision.entity;

namespace luval.vision.api.Statistics
{
    public class StatisticsDataGenerator
    {
        private Data StatisticsData;

        public StatisticsDataGenerator()
        {
            StatisticsData = new Data()
            {
                cols = new List<Col>(),
                rows = new List<Row>()
            };
        }

        public Data GenerateDataFromDocuments(IEnumerable<OcrDocument> documentCollection)
        {
            if(CollectionValidator.IEnumerableCollectionIsNotNull(documentCollection))
            {
                return GetStatisticsData(documentCollection);
            }
            else
            {
                return StatisticsData;
            }
        }

        private Data GetStatisticsData(IEnumerable<OcrDocument> documents)
        {
            StatisticsData = GetStatisticsDataFromDocuments(StatisticsData, documents);
            return StatisticsData;
        }

        private Data GetStatisticsDataFromDocuments(Data data, IEnumerable<OcrDocument> documents)
        {
            data.cols = FillColumns(data.cols);
            data.rows = FillRowsWithDocumentsData(data.rows, documents);
            return data;
        }

        private List<Col> FillColumns(List<Col> cols)
        {
            cols.Add(new Col()
            {
                id = "d",
                label = "Date",
                type = "string"
            });
            cols.Add(new Col()
            {
                id = "n",
                label = "Number of Documents",
                type = "number"
            });
            return cols;
        }

        private List<Row> FillRowsWithDocumentsData(List<Row> rows, IEnumerable<OcrDocument> documents)
        {
            var dates = new List<string>();
            var occurrences = new List<int>();

            SetDocumentDatesAndOccurrences(documents, dates, occurrences);

            FillRows(rows, dates, occurrences);
            return rows;
        }

        private void SetDocumentDatesAndOccurrences(IEnumerable<OcrDocument> documents, List<string> dates, List<int> occurrences)
        {
            foreach (var doc in documents)
            {
                var date = GetDateInDoc(doc);
                var testIndex = dates.FindIndex(x => x == date);
                if (testIndex != -1)
                {
                    occurrences[testIndex] += 1;
                }
                else
                {
                    dates.Add(date);
                    /* It appears at least once. */
                    occurrences.Add(1);
                }
            }
        }

        private void FillRows(List<Row> rows, List<string> dates, List<int> occurrences)
        {
            for (int i = 0; i < dates.Count; i++)
            {
                var rowContents = new List<C>();
                rowContents.Add(new C() { v = dates[i] });
                rowContents.Add(new C() { v = occurrences[i].ToString() });
                rows.Add(new Row() { c = rowContents });
            }
        }

        private string GetDateInDoc(OcrDocument doc)
        {
            /* Regular expression matches date in format: yyyy-mm-ddThh:MM:ss.usZ */
            Regex date_regex = new Regex(@"UtcTimestamp(.*?)\d{4}-\d{2}-\d{2}T\d{2}:\d{2}:\d{2}.\d{1,7}Z");
            var rawDate = date_regex.Match(doc.Content).ToString();
            var formattedDate = GetDateInYearMonthDayFormat(rawDate);
            return formattedDate;
        }

        private string GetDateInYearMonthDayFormat(string rawDateString)
        {
            /* Date format is: yyyy-mm-dd. */
            return rawDateString.Substring(15, 10);
        }
    }
}