using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CustomerLibrary;
using FactoryCustomer;
using ICustomerInterface;

namespace WindowsCustomerUI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            /*
            ICustomer icust = null;
            if(cmbCustomerType.SelectedIndex==0)
            {
                icust = new Lead();
            }
            else
            {
                icust = new Customer();
            }*/
            ICustomer icust = null;
           // Factory obj = new Factory();
            icust = Factory.Create(cmbCustomerType.SelectedIndex);
            icust.CustomerName = txtCustomerName.Text;
            icust.Address = rtbAddress.Text;
            icust.PhoneNumber = txtCustomerName.Text;
            icust.BillAmount = Convert.ToDecimal(txtBillAmount.Text);
            icust.BillDate = Convert.ToDateTime(txtBillDate.Text);
        }
    }
}
