//using System;
//using System.Windows.Forms;

//namespace ExpenseApp
//{
//    internal static class Program
//    {
//        [STAThread]
//        static void Main()
//        {
//            Application.EnableVisualStyles();
//            Application.SetCompatibleTextRenderingDefault(false);
//            Application.Run(new Form1()); // Chạy Form1 khi ứng dụng bắt đầu
//        }
//    }
//}


using System;
using System.Windows.Forms;

namespace ExpenseApp
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Xử lý lỗi toàn cục để tránh crash ứng dụng
            Application.ThreadException += (sender, e) =>
            {
                MessageBox.Show("Lỗi không mong muốn: " + e.Exception.Message,
                                "Lỗi hệ thống",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            };

            try
            {
                Application.Run(new Form1()); // Chạy Form1 khi ứng dụng bắt đầu
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi khi khởi động ứng dụng: " + ex.Message,
                                "Lỗi",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
        }
    }
}

