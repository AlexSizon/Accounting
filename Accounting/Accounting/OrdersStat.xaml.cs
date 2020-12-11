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
    /// Interaction logic for OrdersStat.xaml
    /// </summary>
    public partial class OrdersStat : Window
    {
        List<Order> SelectedOrders;
        public OrdersStat(List<Order> _orders)
        {
            InitializeComponent();
            SelectedOrders = _orders;
            dataGridStats.ItemsSource = SelectedOrders;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Order tempOrder = new Order();
            foreach (var item in SelectedOrders)
            {
                tempOrder.Total_Price += item.Total_Price;
                tempOrder.Work += item.Work;
                tempOrder.My_Work += item.My_Work;
                tempOrder.Girls_Work += item.Girls_Work;
                tempOrder.Cloths_Price += item.Cloths_Price;
                tempOrder.Implements_Price += item.Implements_Price;
                tempOrder.Equipment_Coating += item.Equipment_Coating;
            }
            Total_price_Lb.Content = (int)tempOrder.Total_Price;
            Work_price_Lb.Content = (int)tempOrder.Work;
            My_work_Lb.Content = (int)tempOrder.My_Work;
            Girls_work_Lb.Content = (int)tempOrder.Girls_Work;
            The_cost_of_cloth_Lb.Content = (int)tempOrder.Cloths_Price;
            The_cost_of_implements_Lb.Content = (int)tempOrder.Implements_Price;
            Sum_of_equipment_coating_Lb.Content = (int)tempOrder.Equipment_Coating;
        }
    }
}
