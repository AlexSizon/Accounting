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
    /// Interaction logic for Add.xaml
    /// </summary>
    public partial class Add : Window
    {
        public Order Order { get; set; }
        public Add()
        {
            InitializeComponent();
            Order = new Order();
        }

        private void Add_New_Order(object sender, RoutedEventArgs e)
        {
            Order.Task = Task_Tb.Text;
            Order.Сustomer_Name = Customer_Name_Tb.Text;
            Order.IsFix = (bool)IsFixCb.IsChecked;
            try
            {
                Order.Work = Double.Parse(Work_Price_Tb.Text);
                Order.Total_Price = Double.Parse(Total_Price_Tb.Text);
            }
            catch (FormatException ex)
            {
                MessageBox.Show("Check fields Work price and Total price data correctness");
            }
            this.Close();
        }

        private void Add_Cloth(object sender, RoutedEventArgs e)
        {
            Order.Cloths += ClothNameTb.Text + ":" + ClothPriceTb.Text + ",\n";
            try
            {
                Order.Cloths_Price += Double.Parse(ClothPriceTb.Text);
            }
            catch (FormatException ex)
            {
                MessageBox.Show("Check fields Cloth price data correctness");
            }
            ClothLb.Items.Add(ClothNameTb.Text + ":" + ClothPriceTb.Text);
        }

        private void Add_Implement(object sender, RoutedEventArgs e)
        {
            Order.Implements += ImplementNameTb.Text + ":" + ImplementPriceTb.Text + ",\n";
            try
            {
                Order.Implements_Price += Double.Parse(ImplementPriceTb.Text);
            }
            catch (FormatException ex)
            {
                MessageBox.Show("Check fields Implement price data correctness");
            }
            ImplementLb.Items.Add(ImplementNameTb.Text + ":" + ImplementPriceTb.Text);
        }

        private void Delete_Implement(object sender, RoutedEventArgs e)
        {
            string temp=(string)ImplementLb.SelectedItem;
            int indexstr = ImplementLb.SelectedIndex;
            if (temp == null)
            {
                MessageBox.Show("Please select item to delete");
            }
            else
            {
                //Order.Implements.Remove();
            }
        }
    }
}
