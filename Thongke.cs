using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace quanlykhachsan12345
{
    public partial class Thongke : UserControl
    {
        private KetNoiData ketNoiData = new KetNoiData();
        public Thongke()
        {
            InitializeComponent();
        }

        private void guna2Datadoanhthu_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Thongke_Load(object sender, EventArgs e)
        {

        }




        private void btnhienthidoanhthu_Click(object sender, EventArgs e)
        {

            try
            {
                // Lấy ngày bắt đầu và kết thúc từ DateTimePicker
                DateTime tuNgay = guna2DateTimengaydau.Value;
                DateTime denNgay = guna2DateTimengaycuoi.Value;

                // Truy vấn tổng doanh thu từ bảng Hoadon cho khoảng thời gian được chọn
                string query = $"SELECT NgayXuatHoaDon, TongTien FROM HoaDon WHERE NgayXuatHoaDon BETWEEN '{tuNgay:yyyy-MM-dd}' AND '{denNgay:yyyy-MM-dd}'";
                DataTable dataTable = ketNoiData.ExecuteQuery(query);

                // Hiển thị kết quả tính được và khoảng thời gian trên Guna2DataGridView
                guna2Datadoanhthu.DataSource = dataTable;

                // Tính tổng doanh thu
                decimal totalRevenue = 0;
                foreach (DataRow row in dataTable.Rows)
                {
                    totalRevenue += Convert.ToDecimal(row["TongTien"]);
                }
                // Gán giá trị tổng doanh thu vào Label
                gunatongdoanhthu.Text = totalRevenue.ToString("N2");

                guna2Datadoanhthu.Text = $"Từ {tuNgay:dd/MM/yyyy} đến {denNgay:dd/MM/yyyy}";

            }
            catch (Exception ex)
            {
                // Xử lý ngoại lệ nếu có lỗi xảy ra
                MessageBox.Show("Có lỗi xảy ra: " + ex.Message);
            }

        }

        private void guna2DateTimengaydau_ValueChanged(object sender, EventArgs e)
        {

        }

        private void guna2DateTimePicker2_ValueChanged(object sender, EventArgs e)
        {

        }

        private void btnxoathongke_Click(object sender, EventArgs e)
        {

        }

        private void gunatongdoanhthu_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
