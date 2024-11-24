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
    public partial class FROMSusungdv : UserControl
    {
        private KetNoiData ketNoiData = new KetNoiData();

        public FROMSusungdv()
        {
            InitializeComponent();
        }
        private void FROMSusungdv_Load(object sender, EventArgs e)
        {
            // Truy vấn dữ liệu MaKhachHang từ bảng KhachHang
            string queryKhachHang = "SELECT MaKhachHang FROM KhachHang";
            DataTable dataTableKhachHang = ketNoiData.ExecuteQuery(queryKhachHang);

            // Đổ dữ liệu vào ComboBox MaKhachHang
            comboxmakh.DataSource = dataTableKhachHang;
            comboxmakh.DisplayMember = "MaKhachHang";

            // Truy vấn dữ liệu MaDichVu tư bang dv
            string queryDichVu = "SELECT MaDichVu FROM DichVu";
            DataTable dataTableDichVu = ketNoiData.ExecuteQuery(queryDichVu);

            // Đổ dữ liệu vào ComboBox MaDichVu
            comboxMadichvu.DataSource = dataTableDichVu;
            comboxMadichvu.DisplayMember = "MaDichVu";
            // Truy vấn dữ liệu từ bảng SuDungDichVu
            // Truy vấn dữ liệu từ bảng SuDungDichVu
            string querySuDungDichVu = "SELECT * FROM SuDungDichVu"; // Thay đổi cột cần lấy nếu cần
            DataTable dataTableSuDungDichVu = ketNoiData.ExecuteQuery(querySuDungDichVu);

            // Đổ dữ liệu vào Guna2DataGridView
            guna2viewSudungdv.DataSource = dataTableSuDungDichVu;


        }


        private void btnluasudungdichvu_Click(object sender, EventArgs e)
        {
            // Kiểm tra xem các TextBox có chứa giá trị hợp lệ hay không
            if (string.IsNullOrWhiteSpace(comboxmakh.Text) ||
                string.IsNullOrWhiteSpace(comboxMadichvu.Text) ||
                string.IsNullOrWhiteSpace(txtsoluong.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ và chính xác thông tin.");
                return;
            }

            // Lưu dữ liệu vào bảng SuDungDichVu
            string maKhachHang = comboxmakh.Text;
            string maDichVu = comboxMadichvu.Text;
            int soLuong;
            if (!int.TryParse(txtsoluong.Text, out soLuong))
            {
                MessageBox.Show("Số lượng phải là số nguyên.");
                return;
            }
            // Kiểm tra xem dữ liệu đã tồn tại trong bảng SuDichvu hay chưa
            string queryCheck = $"SELECT COUNT(*) FROM SuDungDichVu WHERE MaKhachHang = {maKhachHang} AND MaDichVu = {maDichVu}";
            int count = Convert.ToInt32(ketNoiData.ExecuteScalar(queryCheck));

            // Nếu đã tồn tại, thông báo lỗi và không thêm dữ liệu mới
            if (count > 0)
            {
                MessageBox.Show("Mã khách hàng và mã dich vu đã tồn tại trong bảng SuDungdichvu.");
                return;
            }

            // Lấy giá trị NgaySuDung từ một DateTimePicker hoặc từ một nguồn khác
            DateTime ngaySuDung = guna2DateTimengaysudung.Value; // Giả sử bạn có một DateTimePicker tên là guna2DateTimePicker1

            string queryInsert = $"INSERT INTO SuDungDichVu (MaKhachHang, MaDichVu, SoLuong, NgaySuDung) VALUES ('{maKhachHang}', '{maDichVu}', {soLuong}, '{ngaySuDung:yyyy-MM-dd}')";
            try
            {
                ketNoiData.ExecuteNonQuery(queryInsert);
                MessageBox.Show("Lưu sử dụng dịch vụ thành công.");

                // Refresh the DataGridView
                FROMSusungdv_Load(sender, e);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi xảy ra: " + ex.Message);
            }

        }
        private void btnxoasudungdv_Click(object sender, EventArgs e)
        {
            // Kiểm tra xem người dùng đã chọn bản ghi hay chưa
            if (guna2viewSudungdv.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn bản ghi để xóa.");
                return;
            }

            // Lấy MaSuDungDichVu từ bản ghi được chọn
            string maSuDungDichVu = guna2viewSudungdv.SelectedRows[0].Cells["MaSuDungDichVu"].Value.ToString();

            string queryDelete = $"DELETE FROM SuDungDichVu WHERE MaSuDungDichVu = '{maSuDungDichVu}'";
            try
            {
                ketNoiData.ExecuteNonQuery(queryDelete);
                MessageBox.Show("Xóa sử dụng dịch vụ thành công.");

                // Refresh the DataGridView
                FROMSusungdv_Load(sender, e);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi xảy ra: " + ex.Message);
            }
        }

        private void comboxmakh_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboxMadichvu_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void txtsoluong_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2DateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void Sudungphongguna2view_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void buttonluuy_Click(object sender, EventArgs e)
        {


        }

        private void buttonluuy_Click_1(object sender, EventArgs e)
        {
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            Luuy2 luuy= new Luuy2();
            luuy.Show();
        }
    }


}

