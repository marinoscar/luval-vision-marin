using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using luval.vision.entity;

namespace luval.vision.bll
{
    public class InvoiceData
    {
        public double? Total { get; set; }
        public double? SubTotal { get; set; }
        public DateTime? DateTime { get; set; }

        public void LoadFromOcr(IEnumerable<LineItem> items)
        {
            var lines = items.Select(i => i.ToText()).ToArray();
            Total = TryGetTotal(lines);
            SubTotal = TryGetSubTotal(lines);
        }

        public static InvoiceData FromOcr(IEnumerable<LineItem> items)
        {
            var i = new InvoiceData();
            i.LoadFromOcr(items);
            return i;
        }

        private double? TryGetTotal(IEnumerable<string> lines)
        {
            return GetAmount("total", lines);
        }

        private double? TryGetSubTotal(IEnumerable<string> lines)
        {
            return GetAmount("sub total", lines);
        }

        private double? TryGetTax(IEnumerable<string> lines)
        {
            return GetAmount("tax", lines);
        }

        private double? GetAmount(string keyword, IEnumerable<string> lines)
        {
            var key = keyword.ToLowerInvariant();
            var subSet = lines.LastOrDefault(i => i.Trim().ToLowerInvariant().Contains(key));
            if (string.IsNullOrWhiteSpace(subSet)) return null;
            var total = subSet.ToLowerInvariant();
            if (string.IsNullOrWhiteSpace(total)) return null;
            var index = total.IndexOf(key) + key.Length;
            var nums = Regex.Matches(total.Remove(0, index), @"[0-9]|-|\.|,").Cast<Match>().Where(i => i.Success).Select(i => i.Value).ToList();
            var result = default(double);
            var s = double.TryParse(string.Join("", nums), out result);
            if (s) return result;
            return null;
        }

        public override string ToString()
        {
            var sw = new StringWriter();
            sw.WriteLine();
            sw.WriteLine("Date Time: {0}", DateTime);
            sw.WriteLine("Sub Total: {0}", SubTotal);
            sw.WriteLine("Total....: {0}", Total);
            sw.WriteLine();
            return sw.ToString();
        }

    }
}
