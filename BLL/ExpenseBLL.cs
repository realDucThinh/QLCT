using System.Collections.Generic;
using ExpenseApp.DAL;

namespace ExpenseApp.BLL
{
    //Hé lô anh em!
    //Hé lô lần 2 nè anh em!
    //Hé lô lần 3 nè anh em!
    //Hé lô lần 4 nè anh em!
    public class ExpenseBLL
    {
        private ExpenseDAL dal = new ExpenseDAL();

        public List<Expense> GetExpenses()
        {
            return dal.GetExpenses();  // Lấy danh sách các khoản chi tiêu từ DAL
        }


        public bool AddExpense(decimal amount, string category)
        {
            return dal.AddExpense(amount, category);  // Gọi phương thức DAL để thêm vào DB
        }


        public bool RemoveExpense(int id)
        {
            return dal.RemoveExpense(id);
        }

    }
}
