﻿using FreshFood.Components;
using FreshFood.EF;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FreshFood.Screen
{
    public partial class HomeForm : Form
    {
        private AppDB appDB = new AppDB();
        public HomeForm()
        {
            InitializeComponent();
            pnMenu.VerticalScroll.Visible = false;
            pnMenu.HorizontalScroll.Visible = false;
        }

        private void HomeForm_Load(object sender, EventArgs e)
        {
            foreach (var category in appDB.Categories.ToList())
            {
                MenuItemUC menuItem = new MenuItemUC(category);
                menuItem.Width = pnMenu.Width;
                menuItem.Height = 30;
                menuItem.Show();
                
                menuItem.Click += MenuItem_Click;
                menuItem.lbl.MouseClick += MenuItem_Click;
                menuItem.pnImage.MouseClick += MenuItem_Click;
                pnMenu.Controls.Add(menuItem);
            }
        }

        private void MenuItem_Click(object sender, EventArgs e)
        {
            Control control = sender as Control;
            Category category = (Category)control.Tag;
            pnProducts.Controls.Clear();

            foreach (var item in category.Products.ToList())
            {
                ProductUC productUC = new ProductUC(item);
                lblCategory.Text = category.Name;
                productUC.Show();
                pnProducts.Controls.Add(productUC);
            }
        }

        private void panel5_MouseClick(object sender, MouseEventArgs e)
        {
            pnProducts.Controls.Clear();
            lblCategory.Text = "Tất cả";
            foreach (var item in appDB.Products.ToList())
            {
                ProductUC productUC = new ProductUC(item);
                productUC.Show();
                pnProducts.Controls.Add(productUC);
            }
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            pnProducts.Controls.Clear();

            foreach (var item in appDB.Products.Where(x => x.Name.Contains(txtTimKiem.Text)).ToList())
            {
                ProductUC productUC = new ProductUC(item);
                productUC.Show();
                pnProducts.Controls.Add(productUC);
            }
        }
    }
}
