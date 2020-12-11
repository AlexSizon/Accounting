using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Accounting
{
    /// <summary>
    /// Interaction logic for ChangeProcentProperties.xaml
    /// </summary>
    public partial class ChangeProcentProperties : Window
    {
        public ProcentProperties ProcentProperties;
        public ChangeProcentProperties(ProcentProperties prop)
        {
            InitializeComponent();
            ProcentProperties = prop;
            My_Work_For_Sewing_Tb.Text = (ProcentProperties.ProcentMyWork * 100).ToString();
            Girls_Work_For_Sewing_Tb.Text = (ProcentProperties.ProcentGirlsWork * 100).ToString();
            Equipment_Coating_For_Sewing_Tb.Text = (ProcentProperties.ProcentEquipmentCoating * 100).ToString();
            My_Work_For_Fix_Tb.Text = (ProcentProperties.FixProcentMyWork * 100).ToString();
            Girls_Work_For_Fix_Tb.Text = (ProcentProperties.FixProcentGirlsWork * 100).ToString();
            Equipment_Coating_For_Fix_Tb.Text = (ProcentProperties.FixProcentEquipmentCoating * 100).ToString();
        }

        private void Save_Properties(object sender, RoutedEventArgs e)
        {
            try
            {
                ProcentProperties.ProcentMyWork = Double.Parse(My_Work_For_Sewing_Tb.Text) / 100;
                ProcentProperties.ProcentGirlsWork = Double.Parse(Girls_Work_For_Sewing_Tb.Text) / 100;
                ProcentProperties.ProcentEquipmentCoating = Double.Parse(Equipment_Coating_For_Sewing_Tb.Text) / 100;
                ProcentProperties.FixProcentMyWork = Double.Parse(My_Work_For_Fix_Tb.Text) / 100;
                ProcentProperties.FixProcentGirlsWork = Double.Parse(Girls_Work_For_Fix_Tb.Text) / 100;
                ProcentProperties.FixProcentEquipmentCoating = Double.Parse(Equipment_Coating_For_Fix_Tb.Text) / 100;
            }
            catch (FormatException ex)
            {
                MessageBox.Show("Check fields data correctness");
            }
            Close();
        }
    }
}
