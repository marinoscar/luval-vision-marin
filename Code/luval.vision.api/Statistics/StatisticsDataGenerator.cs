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

        public Data GenerateDataFromDateOccurrencePairs(IEnumerable<DocumentStatistics> dateOccurrencePairsList)
        {
            if (CollectionValidator.IEnumerableCollectionIsNotNull(dateOccurrencePairsList))
            {
                StatisticsData = BuildStatisticsData(StatisticsData, dateOccurrencePairsList);
                return StatisticsData;
            }
            else
            {
                return StatisticsData;
            }
        }

        private Data BuildStatisticsData(Data data, IEnumerable<DocumentStatistics> statistics)
        {
            data.cols = FillColumns(data.cols);
            data.rows = FillRowsWithDocumentStatistics(data.rows, statistics);
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

        private List<Row> FillRowsWithDocumentStatistics(List<Row> rows, IEnumerable<DocumentStatistics> statistics)
        {
            foreach(var statistic in statistics)
            {
                var rowContents = new List<C>();
                rowContents.Add(new C() { v = statistic.Date });
                rowContents.Add(new C() { v = statistic.Ocurrences.ToString() });
                rows.Add(new Row() { c = rowContents });
            }
            return rows;
        }
    }
}