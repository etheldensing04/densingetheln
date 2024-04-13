using densingetheln.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace densingetheln
{
    public partial class UpdateCategory : Form
    {
        private readonly DensingdbEntities _context = new DensingdbEntities();
        private int _id;
        private BindingSource _bindingsource;
        private object _bindingSource;
        private object selectedCategory;

        public UpdateCategory()
        {
            InitializeComponent();
        }
        public UpdateCategory(int ID, BindingSource bindingSource) :this()
        {
            _id = ID;
            _bindingsource = bindingSource;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var SelectedCategory = _context.Categories.Where(q => q.Id == _id).FirstOrDefault();

            SelectedCategory.CategoryName = textBox1.Text.Trim();

            _context.SaveChanges();

            _bindingsource.DataSource = _context.Categories.ToList();

            this.Close();
        }

        private void UpdateCategory_Load(object sender, EventArgs e)
        {
            var selectedCategory = _context.Categories.Where(q => q.Id == _id).FirstOrDefault();
            textBox1.Text = selectedCategory.CategoryName;
        }
    }
}

