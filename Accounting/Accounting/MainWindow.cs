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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Accounting
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static ProcentProperties ProcentProperties;
        public static List<Order> Orders;
        public MainWindow(List<Order> _orders)
        {
            InitializeComponent();
            Orders = _orders;
            dataGrid1.ItemsSource = Orders;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            ProcentProperties = PropertiesReaderWriter.ReadJson();
        }

        private void Add_Order(object sender, RoutedEventArgs e)
        {
            Add addWindow = new Add();
            addWindow.ShowDialog();
            Order temp = addWindow.Order;
            if (temp.IsFix)
            {
                temp.My_Work = temp.Work * ProcentProperties.FixProcentMyWork;
                temp.Girls_Work = temp.Work * ProcentProperties.FixProcentGirlsWork;
                double tempWorkPrice = temp.Work - (temp.Work * ProcentProperties.FixProcentEquipmentCoating);
                temp.Equipment_Coating = temp.Total_Price - tempWorkPrice - temp.Implements_Price - temp.Cloths_Price;
                temp.Total_Price = temp.Work;
            }
            else
            {
                temp.My_Work = temp.Work * ProcentProperties.ProcentMyWork;
                temp.Girls_Work = temp.Work * ProcentProperties.ProcentGirlsWork;
                double tempWorkPrice = temp.Work - (temp.Work * ProcentProperties.ProcentEquipmentCoating);
                temp.Equipment_Coating = temp.Total_Price - tempWorkPrice - temp.Implements_Price - temp.Cloths_Price;
            }
            //if (temp.Equipment_Coating <= 0)
            //{
            //    temp.Total_Price = temp.Total_Price - temp.Equipment_Coating + 70;
            //    temp.Equipment_Coating = 70;
            //}
            //else if (temp.Equipment_Coating < 70 && temp.Equipment_Coating > 0)
            //{
            //    double sub = 70 - temp.Equipment_Coating;
            //    temp.Equipment_Coating += sub;
            //    temp.Total_Price += sub;
            //}
            Orders.Add(temp);
            RefreshData();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            OrderReaderWriter.WriteToJson(Orders);
            PropertiesReaderWriter.WriteToJson(ProcentProperties);
        }
        private void Delete_Order(object sender, RoutedEventArgs e)
        {
            if (dataGrid1.SelectedItem != null)
            {
                Orders.Remove((Order)dataGrid1.SelectedItem);
            }
            else
            {
                MessageBox.Show("Please select item to delete");
            }
            RefreshData();
        }
        private void Edit_Order(object sender, RoutedEventArgs e)
        {
            if (dataGrid1.SelectedItem != null)
            {
                Edit editWindow = new Edit((Order)dataGrid1.SelectedItem);
                Orders.Remove((Order)dataGrid1.SelectedItem);
                editWindow.ShowDialog();
                Order temp = editWindow.Order;
                if (temp.IsFix)
                {
                    temp.My_Work = temp.Work * ProcentProperties.FixProcentMyWork;
                    temp.Girls_Work = temp.Work * ProcentProperties.FixProcentGirlsWork;
                    double tempWorkPrice = temp.Work - (temp.Work * ProcentProperties.FixProcentEquipmentCoating);
                    temp.Equipment_Coating = temp.Total_Price - tempWorkPrice - temp.Implements_Price - temp.Cloths_Price;
                    temp.Total_Price = temp.Work;
                }
                else
                {
                    temp.My_Work = temp.Work * ProcentProperties.ProcentMyWork;
                    temp.Girls_Work = temp.Work * ProcentProperties.ProcentGirlsWork;
                    double tempWorkPrice = temp.Work - (temp.Work * ProcentProperties.ProcentEquipmentCoating);
                    temp.Equipment_Coating = temp.Total_Price - tempWorkPrice - temp.Implements_Price - temp.Cloths_Price;
                }
                //if (temp.Equipment_Coating <= 0)
                //{
                //    temp.Total_Price = temp.Total_Price - temp.Equipment_Coating + 70;
                //    temp.Equipment_Coating = 70;
                //}
                //else if (temp.Equipment_Coating < 70 && temp.Equipment_Coating > 0)
                //{
                //    double sub = 70 - temp.Equipment_Coating;
                //    temp.Equipment_Coating += sub;
                //    temp.Total_Price += sub;
                //}
                Orders.Insert(dataGrid1.SelectedIndex, temp);
                RefreshData();
            }
            else
            {
                MessageBox.Show("Please select item to edit");
            }
            RefreshData();
        }
        private void Orders_Stat(object sender, RoutedEventArgs e)
        {
            List<Order> orders = new List<Order>();
            if (dataGrid1.SelectedItem != null)
            {
                foreach (var item in dataGrid1.SelectedItems)
                {
                    orders.Add((Order)item);
                }
                OrdersStat stat = new OrdersStat(orders);
                stat.ShowDialog();
            }
            else
            {
                MessageBox.Show("Please select item to show stats");
            }
        }
        private void RefreshData()
        {
            dataGrid1.ItemsSource = null;
            dataGrid1.ItemsSource = Orders;
        }

        private void Procent_Editor(object sender, RoutedEventArgs e)
        {
            ChangeProcentProperties changeProps = new ChangeProcentProperties(ProcentProperties);
            changeProps.ShowDialog();
            ProcentProperties = changeProps.ProcentProperties;
        }
    }
}