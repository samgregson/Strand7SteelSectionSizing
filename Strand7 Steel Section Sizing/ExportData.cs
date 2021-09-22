using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Strand7_Steel_Section_Sizing
{
    class ExportData
    {
        public static void WriteCSV<T>(IEnumerable<T> items, string path)
        {
            Type itemType = typeof(T);
            var props = itemType.GetProperties(BindingFlags.Public | BindingFlags.Instance); //.OrderBy(p => p.Name);
            var propsFiltered = props.Where(x => x.Name != "AssociatedElevation");

            using (var writer = new StreamWriter(path))
            {
                writer.WriteLine(string.Join(", ", propsFiltered.Select(p =>
                {
                    var header = p.Name.Replace(',', ';');
                    switch (header)
                    {
                        case "Volume":
                            header += " (m^3)";
                            break;
                        case "Density":
                            header += " (kg/m^3)";
                            break;
                        case "Weight":
                            header += " (kg)";
                            break;
                        case "Area":
                            header += " (m^2)";
                            break;
                        case "EmbodiedCarbon":
                            header += " (kg)";
                            break;
                        case "RebarWeight":
                            header += " (kg)";
                            break;
                        case "RebarGwp":
                            header += " (kgC02/kg)";
                            break;
                        case "RebarEmbodiedCarbon":
                            header += " (kgCO2)";
                            break;
                        default:
                            break;
                    }
                    return header;
                })));

                foreach (var item in items)
                {
                    writer.WriteLine(string.Join(", ", propsFiltered.Select(p =>
                    {
                        var obj = p.GetValue(item, null);
                        if (obj is string) return ((string)obj).Replace(',', ';');
                        else return obj;
                    })));
                }
            }
        }

        /// <summary>
        /// Write to CSV
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void SaveData_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Forms.SaveFileDialog saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            saveFileDialog.Filter = "CSV files (*.csv)|*.csv|All files (*.*)|*.*";
            saveFileDialog.FilterIndex = 1;
            saveFileDialog.RestoreDirectory = true;
            saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            if (saveFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                //var sorted = a_RevitReader.RevitElementData.OrderBy(x => x.Material.ToString()).ThenBy(y => y.MaterialName).ThenBy(z => z.CategoryReassigned.ToString());
                //WriteCSV<RevitElement>(sorted, saveFileDialog.FileName);
            }
        }
    }
}
