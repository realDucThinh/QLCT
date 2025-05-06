using System;
using System.Data;
using System.Windows.Forms;
using ExpenseApp.BLL;

namespace ExpenseApp
{
    public partial class Form1 : Form
    {
        private ExpenseBLL expenseBLL = new ExpenseBLL();
        //private ExpenseBLL bll = new ExpenseBLL();  // Declare and initialize the bll object


        public Form1()
        {
            InitializeComponent();
            LoadExpenses();
            LoadCategories();                           
        }

        private void LoadCategories()
        {
            comboBoxCategory.Items.AddRange(new string[]
            {
        "Tiền phòng", "Tiền điện", "Thức ăn", "Đi lại", "Linh tinh", "Mua sắm"
            });
            comboBoxCategory.SelectedIndex = 0; // Default to the first item
        }

        private void LoadExpenses()
        {
            var expenses = expenseBLL.GetExpenses();  // Lấy các khoản chi tiêu từ BLL

            // Tạo một DataTable để hiển thị dữ liệu trong DataGridView
            DataTable dt = new DataTable();
            dt.Columns.Add("ID", typeof(int));
            dt.Columns.Add("Số Tiền", typeof(decimal));
            dt.Columns.Add("Danh Mục", typeof(string));
            dt.Columns.Add("Ngày Thêm", typeof(DateTime));

            foreach (var expense in expenses)
            {
                dt.Rows.Add(expense.ID, expense.Amount, expense.Category, expense.DateAdded);  // Thêm các khoản chi vào DataTable
            }

            dataGridViewExpenses.DataSource = dt;  // Cập nhật DataGridView
        }


        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (decimal.TryParse(txtAmount.Text, out decimal amount))
            {
                string category = comboBoxCategory.SelectedItem.ToString();  // Lấy danh mục từ ComboBox

                // Thêm khoản chi vào cơ sở dữ liệu
                if (expenseBLL.AddExpense(amount, category))
                {
                    LoadExpenses();  // Cập nhật lại DataGridView với các khoản chi tiêu
                    MessageBox.Show("Thêm khoản chi thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Thêm thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Nhập số tiền hợp lệ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
