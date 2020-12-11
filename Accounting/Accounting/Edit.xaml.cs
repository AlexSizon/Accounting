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
    /// Interaction logic for Edit.xaml
    /// </summary>
    public partial class Edit : Window
    {
        public Order Order { get; set; }
        public Edit(Order order)
        {
            InitializeComponent();
            Order = order;
            Total_Price_Tb.Text = Order.Total_Price.ToString();
            Work_Price_Tb.Text = Order.Work.ToString();
            Customer_Name_Tb.Text = Order.Сustomer_Name;
            Task_Tb.Text = Order.Task;
            IsFixCb.IsChecked = Order.IsFix;

            //for (int i = 0; i < 20; i++)
            //{

                //ClothLb.Items.add(  Order.Implements.;
            //}
        }

        private void Edit_Order(object sender, RoutedEventArgs e)
        {
            Order.Task = Task_Tb.Text;
            Order.Сustomer_Name = Customer_Name_Tb.Text;
            Order.IsFix = (bool)IsFixCb.IsChecked;
            //Order.Implements = "шёлк:30,\nшёлк:20";
            try
            {
                Order.Work = Int32.Parse(Work_Price_Tb.Text);
                Order.Total_Price = Int32.Parse(Total_Price_Tb.Text);
            }
            catch (FormatException ex)
            {
                MessageBox.Show("Check fields Work price and Total price data correctness");
            }
            Close();
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
    }
}
