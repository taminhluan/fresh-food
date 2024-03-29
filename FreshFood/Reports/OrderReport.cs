﻿using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Linq;
using DevExpress.XtraReports.UI;
using FreshFood.EF;

namespace FreshFood.Reports
{
    public partial class OrderReport : DevExpress.XtraReports.UI.XtraReport
    {
        private SellOrder sellOrder;
        public object DataBindingMode { get; private set; }

        public OrderReport()
        {
            InitializeComponent();
        }

        public OrderReport(SellOrder sellOrder)
        {
            InitializeComponent();
            this.sellOrder = sellOrder;

            lblFullName.Text = sellOrder.Fullname;
            lblAddress.Text = sellOrder.Address;
            lblPhoneNumber.Text = sellOrder.PhoneNumber;

            if (sellOrder.Date != null)
            {
                lblNgayMuaHang.Text = sellOrder.Date.Value.ToString("dd/M/yyyy");
            }

            lblToDay.Text = DateTime.Today.ToString("dd/M/yyyy");

            double total = sellOrder.SellOrderDetails.Sum(x => x.Price * x.Quantity).Value;
            lblTongTien.Text = total.ToString();

        }

    }
}
