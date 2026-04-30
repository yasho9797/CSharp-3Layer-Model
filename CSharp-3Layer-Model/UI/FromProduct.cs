using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using BlApi;

namespace UI
{
    public partial class FromProduct : Form
    {
        IBL bl = BlApi.Factory.Get();

        public FromProduct(BO.Product product)
        {
            InitializeComponent();
        }
        public FromProduct()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        //כפתור השמירה/עדכון
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                // בדיקה בסיסית שה-ComboBox לא ריק
                if (txtCategory.SelectedItem == null)
                {
                    MessageBox.Show("אנא בחרו קטגוריה");
                    return;
                }

                BO.Product p = new BO.Product()
                {
                    ProductId = int.Parse(txtId.Text),
                    ProductName = txtName.Text,
                    Price = double.Parse(txtPrice.Text),
                    AmountProduct = int.Parse(txtStok.Text),
                    Category = (BO.Category)txtCategory.SelectedItem // עכשיו כשיש DataSource זה יעבוד
                };

                bl.Product.Create(p);
                MessageBox.Show("המוצר נשמר בהצלחה!");
                this.Close();
            }
            catch (Exception ex)
            {
                // ex.Message יעזור לך להבין אם זו בעיית לוגיקה או המרת נתונים
                MessageBox.Show("שגיאה בשמירה: " + ex.Message);
            }
        }

        private void FromProduct_Load(object sender, EventArgs e)
        {
            // ממלא את ה-ComboBox בכל הערכים הקיימים ב-Enum של הקטגוריות
            txtCategory.DataSource = Enum.GetValues(typeof(BO.Category));
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
