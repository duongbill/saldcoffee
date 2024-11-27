using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using QL_sald.logicLayer;
using ValueObject;

namespace QL_sald.compoment
{
    public partial class FoodCPT : UserControl
    {
        private FoodLL foodLL;

        public FoodCPT()
        {
            InitializeComponent();
            foodLL = new FoodLL();
            LoadData();
        }

        private void LoadData()
        {
            var foods = foodLL.GetFoods();
            Console.WriteLine($"Foods count: {foods.Count}");

            if (foods.Count > 0)
            {
                Food selectedFood = foods[0];
                txtFoodName.Text = selectedFood.FoodName;
                txtPrice.Text = selectedFood.Price.ToString("C");

                if (!string.IsNullOrEmpty(selectedFood.ImageURL))
                {
                    try
                    {
                        pic.Image = Image.FromFile(selectedFood.ImageURL);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Không thể tải ảnh: " + ex.Message);
                    }
                }
            }
       
        }
    }
}
