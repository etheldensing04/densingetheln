﻿using densingetheln.Entities;
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
    public partial class Form1 : Form
    {
        private readonly DensingdbEntities _context = new DensingdbEntities();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            var result = _context.Categories.ToList();

            categoryBindingSource.DataSource = result;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Category newCategory = new Category();
            newCategory.CategoryName = textBox1.Text.Trim();

            _context.Categories.Add(newCategory);
            _context.SaveChanges();

            var result = _context.Categories.ToList();
            categoryBindingSource.DataSource = _context.Categories.ToList();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string searchText = textBox2.Text.Trim();
            var result = _context.Categories
                     .Where(q => q.CategoryName.Contains(searchText)).ToList();

            categoryBindingSource.DataSource = result;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string toBeDeleted = textBox3.Text.Trim();
            var itemToDelete = _context.Categories
                              .Where(q => q.Id.ToString() == toBeDeleted)
                              .FirstOrDefault();
            _context.Categories.Remove(itemToDelete);
            _context.SaveChanges();

            categoryBindingSource.DataSource = _context.Categories.ToList();
        }

        private void testAdd_Click(object sender, EventArgs e)
        {
            CategoryAdd NewAdd = new CategoryAdd();
            NewAdd.ShowDialog();

            categoryBindingSource.DataSource = _context.Categories.ToList();
        }
    }
}
