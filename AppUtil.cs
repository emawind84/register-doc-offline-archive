using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

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

        public async static Task<IDictionary> RequestPMISToken(string host, string username, string password, bool pwdEncoded = false)
        {
            string url = String.Format("{0}/Main/Token.action", host);

            var values = new Dictionary<string, string> {
                { "user_no", username },
                { "passwd", pwdEncoded?Base64Encode(password):password },
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

        public static DataGridCell FindDataGridCell(DependencyObject dep)
        {
            // iteratively traverse the visual tree
            while ((dep != null) && !(dep is System.Windows.Controls.DataGridCell))
            {
                dep = VisualTreeHelper.GetParent(dep);
            }
            if (dep is System.Windows.Controls.DataGridCell)
            {
                return dep as System.Windows.Controls.DataGridCell;
            }
            return null;
        }

        public static DataGridRow FindDataGridRow(DependencyObject dep)
        {
            dep = FindDataGridCell(dep);
            if (dep != null)
            {
                var cell = dep as System.Windows.Controls.DataGridCell;
                // navigate further up the tree
                while ((dep != null) && !(dep is DataGridRow))
                {
                    dep = VisualTreeHelper.GetParent(dep);
                }
                DataGridRow row = dep as DataGridRow;
                return row;
            }
            return null;
        }

        public static void FileManagerOnSingleClick(object sender, MouseButtonEventArgs e)
        {
            //System.Windows.Controls.DataGrid grid = sender as System.Windows.Controls.DataGrid;
            //DataGridRow dgr = grid.ItemContainerGenerator.ContainerFromItem(grid.SelectedItem) as DataGridRow;

            var cell = FindDataGridCell((DependencyObject)e.OriginalSource);
            if (cell != null)
            {
                var row = FindDataGridRow(cell);
                if (row != null)
                {
                    DataGridBoundColumn col = cell.Column as DataGridBoundColumn;

                    if (col.DisplayIndex == 2)
                    {
                        RegisterFile file = row.Item as RegisterFile;
                        RegisterFileService.OpenRegisterFileLocation(file);
                    }
                }
            }
        }

        public static void FileManagerOnDoubleClick(object sender, MouseButtonEventArgs e)
        {
            DataGridRow row = FindDataGridRow((DependencyObject)e.OriginalSource);
            if (row != null)
            {
                RegisterFile file = row.Item as RegisterFile;
                RegisterFileService.OpenRegisterFile(file);
            }
        }

        public static string Base64Encode(string plainText)
        {
            var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(plainText);
            return System.Convert.ToBase64String(plainTextBytes);
        }

        public static string Base64Decode(string base64EncodedData)
        {
            var base64EncodedBytes = System.Convert.FromBase64String(base64EncodedData);
            return System.Text.Encoding.UTF8.GetString(base64EncodedBytes);
        }

    }
}
