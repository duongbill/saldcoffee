using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QL_sald.compoment;
using QL_sald.logicLayer;
using ValueObject;

namespace QL_sald
{
    public partial class MenuIngre : Form
    {
        private IngredientsLL ingredientsLL;

        public MenuIngre()
        {
            InitializeComponent();
            ingredientsLL = new IngredientsLL();
            LoadIngredientItems();
        }

        private void LoadIngredientItems()
        {
            try
            {
                List<Ingredient> ingredients = ingredientsLL.GetAllIngredients();

                flowLayoutPanel1.Padding = new Padding(20, 5, 5, 5);
                flowLayoutPanel1.AutoScroll = true;
                flowLayoutPanel1.Controls.Clear(); // Xóa các control hiện tại

                foreach (Ingredient ingredient in ingredients)
                {
                    IngreCPT ingreCPT = new IngreCPT();
                    ingreCPT.LoadData(ingredient);
                    ingreCPT.Margin = new Padding(0);
                    ingreCPT.Width = 140;
                    ingreCPT.Dock = DockStyle.None;

                    flowLayoutPanel1.Controls.Add(ingreCPT);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải dữ liệu: {ex.Message}");
            }
        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {
            // Custom paint code if needed
        }

        private void flowLayoutPanel1_Paint_1(object sender, PaintEventArgs e)
        {

        }
    }
}
