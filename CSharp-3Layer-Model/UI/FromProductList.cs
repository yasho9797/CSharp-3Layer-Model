using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BL;
using BlApi;

namespace UI
{
    public partial class FromProductList : Form
    {
        IBL bl = BlApi.Factory.Get();
        public FromProductList()
        {
            InitializeComponent();
            textBox1.Text = "סנן לפי/קטגוריה";
            textBox1.ForeColor = Color.Gray;
        }
        // טעינת הטופס - כאן כדאי לקרוא לנתונים בפעם הראשונה
        private void FromProductList_Load(object sender, EventArgs e)
        {
            RefreshData();
        }

        // פונקציית עזר לרענון הטבלה
        private void RefreshData()
        {
            var list = bl.Product.ReadAll()
                        .OrderBy(p => p.ProductId) // ממיין מהקטן לגדול
                        .ToList();

            dataGridView1.DataSource = list;
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string filter = textBox1.Text.ToLower();

            if (string.IsNullOrEmpty(filter) || filter == "סנן לפי/קטגוריה")
            {
                RefreshData(); // אם התיבה ריקה, הציגי הכל
            }
            else
            {
                // סינון הרשימה הקיימת לפי שם קטגוריה
                var filteredList = bl.Product.ReadAll()
                    .Where(p => p.Category.ToString().ToLower().Contains(filter))
                    .ToList();

                dataGridView1.DataSource = filteredList;
            }
        }


        //פונקצית הוספת מוצר חדש
        private void button1_Click(object sender, EventArgs e)
        {
            // יצירת מופע חדש של טופס המוצר
            FromProduct frm = new FromProduct();
            frm.ShowDialog();

            // לאחר סגירת הטופס, לקרוא לפונקציית רענון לטבלה
            RefreshData();
        }

        //פונקצית עדכון מוצר
        private void button2_Click(object sender, EventArgs e)
        {
            // בדיקה אם נבחרה שורה בטבלה
            if (dataGridView1.CurrentRow != null)
            {
                // שליפת האובייקט הנבחר (נניח שהטבלה מקושרת למוצרים של ה-BO)
                var selectedProduct = dataGridView1.CurrentRow.DataBoundItem as BO.Product;

                // פתיחת טופס המוצר ושליחת הנתונים לעדכון
                FromProduct frm = new FromProduct(selectedProduct);
                frm.ShowDialog();

                // רענון הטבלה בסיום
                RefreshData();
            }
            else
            {
                MessageBox.Show("אנא בחרו מוצר מהרשימה לעדכון");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow != null)
            {
                // 1. שליפת המוצר הנבחר
                var selectedProduct = dataGridView1.CurrentRow.DataBoundItem as BO.Product;

                // 2. שאלת אישור מהמשתמש (ליתר ביטחון)
                var result = MessageBox.Show($"האם אתה בטוח שברצונך למחוק את {selectedProduct.ProductName}?",
                                             "אישור מחיקה", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    try
                    {
                        // 3. ביצוע המחיקה דרך ה-BL
                        bl.Product.Delete(selectedProduct.ProductId);

                        // 4. רענון הטבלה
                        RefreshData();
                        MessageBox.Show("המוצר נמחק בהצלחה");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("שגיאה במחיקה: " + ex.Message);
                    }
                }
            }
            else
            {
                MessageBox.Show("אנא בחרו מוצר למחיקה מהרשימה");
            }
        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            if (textBox1.Text == "סנן לפי/קטגוריה")
            {
                textBox1.Text = ""; // מוחק את הטקסט באופן אוטומטי
                textBox1.ForeColor = Color.Black; // משנה לצבע כתיבה רגיל
            }
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox1.Text))
            {
                textBox1.Text = "סנן לפי/קטגוריה"; // מחזיר את טקסט ההסבר אם התיבה ריקה
                textBox1.ForeColor = Color.Gray; // מחזיר לצבע אפור כדי שיראה כמו placeholder
            }
        }

        private void FromProductList_Load_1(object sender, EventArgs e)
        {
            RefreshData();
        }

        private void txtAgain_Click(object sender, EventArgs e)
        {
            this.Close(); // סוגר את המסך הנוכחי ומחזיר לתפריט הקודם
        }
    }
}
