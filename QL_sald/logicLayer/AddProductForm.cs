using System;
using System.Collections.Generic;
using System.Windows.Forms;
using ValueObject;
using QL_sald.logicLayer;

namespace QL_sald
{
    public partial class AddProductForm : Form
    {
        private FoodLL foodLL;
        private CategoriesLL categoriesLL;
        private IngredientsLL ingredientsLL;

        public AddProductForm()
        {
            InitializeComponent();
            foodLL = new FoodLL();
            categoriesLL = new CategoriesLL();
            ingredientsLL = new IngredientsLL();
            LoadCategories();
            LoadIngredients();
            LoadFoodItems(); // Add this method call
        }

        private void LoadCategories()
        {
            List<Category> categories = categoriesLL.GetAllCategories();
            cmbCategory.DataSource = categories;
            cmbCategory.DisplayMember = "CategoryName";
            cmbCategory.ValueMember = "CategoryId";
        }

        private void LoadIngredients()
        {
            List<Ingredient> ingredients = ingredientsLL.GetAllIngredients();
            cmbIngredient.DataSource = ingredients;
            cmbIngredient.DisplayMember = "IngredientName";
            cmbIngredient.ValueMember = "IngredientId";
        }

        private void LoadFoodItems()
        {
            List<Food> foods = foodLL.GetAllFoods(); 
            guna2DataGridView1.DataSource = foods; 
        }

        private void btnBrowseImage_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.bmp";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                txtImageURL.Text = ofd.FileName;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
           
        }

    }
}
