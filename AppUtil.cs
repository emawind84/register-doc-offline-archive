using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace pmis
{
    public class AppUtil
    {

        public static IEnumerable<DataGridRow> GetDataGridRows(System.Windows.Controls.DataGrid grid)
        {
            var itemsSource = grid.ItemsSource as IEnumerable;
            if (null == itemsSource) yield return null;
            foreach (var item in itemsSource)
            {
                var row = grid.ItemContainerGenerator.ContainerFromItem(item) as DataGridRow;
                if (null != row) yield return row;
            }
        }

        public async static Task<IDictionary> RequestPMISToken(string host, string username, string password)
        {
            string url = String.Format("{0}/Main/Token.action", host);

            var values = new Dictionary<string, string> {
                { "user_no", username },
                { "passwd", password },
                { "cmd", "sso" },
                { "auth_type", "basic" }
            };

            using (var client = new HttpClient())
            {
                var content = new FormUrlEncodedContent(values);
                var response = await client.PostAsync(url, content);
                response.EnsureSuccessStatusCode();
                var responseString = await response.Content.ReadAsStringAsync();
                IDictionary obj = JsonConvert.DeserializeObject<IDictionary>(responseString);
                return obj;
            }
        }

    }
}
