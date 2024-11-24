using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Drawing.Printing;
using Guna.UI2.WinForms;


namespace quanlykhachsan12345
{
    public partial class Hoadon : UserControl
    {

        private KetNoiData ketNoiData = new KetNoiData();
        private int selectedUsageId;
        public Hoadon()
        {
            InitializeComponent();



        }
        private decimal TinhTongTienSuDungPhong(int maSuDungPhong)
        {
            decimal tongTien = 0;

            // Lấy thông tin giá phòng và ngày thuê, ngày trả từ bảng SuDungPhong
            string query = $"SELECT P.Gia, SP.NgayThue AS NgayThuePhong, SP.NgayTra AS NgayTraPhong " +
                           $"FROM Phong P " +
                           $"JOIN SuDungPhong SP ON P.MaPhong = SP.MaPhong " +
                           $"WHERE SP.MaSuDungPhong = {maSuDungPhong}";
            DataTable dataTable = ketNoiData.ExecuteQuery(query);

            if (dataTable.Rows.Count > 0)
            {
                decimal Gia = Convert.ToDecimal(dataTable.Rows[0]["Gia"]);
                DateTime ngayThuePhong = Convert.ToDateTime(dataTable.Rows[0]["NgayThuePhong"]);
                DateTime ngayTraPhong = Convert.ToDateTime(dataTable.Rows[0]["NgayTraPhong"]);

                // Tính số ngày sử dụng phòng
                int soNgay = (ngayTraPhong - ngayThuePhong).Days;
                if (soNgay == 0) soNgay = 1; // Nếu cùng ngày thì tính là 1 ngày

                // Tính tổng tiền sử dụng phòng
                tongTien = Gia * soNgay;
            }

            return tongTien;
        }
        private decimal TinhTongTienSuDungDichVu(int maSuDungDichVu, int SoLuong)
        {
            decimal tongTien = 0;

            // Lấy thông tin đơn giá dịch vụ từ bảng DichVu
            string query = $"SELECT DonGia FROM DichVu WHERE MaDichVu = (SELECT MaDichVu FROM SuDungDichVu WHERE MaSuDungDichVu = {maSuDungDichVu})";
            decimal DonGia = Convert.ToDecimal(ketNoiData.ExecuteScalar(query));

            // Tính tổng tiền sử dụng dịch vụ
            tongTien = DonGia * SoLuong;

            return tongTien;
        }

        private void Hoadon_Load(object sender, EventArgs e)
        {
            string query = "SELECT * FROM HoaDon";
            DataTable dataTable = ketNoiData.ExecuteQuery(query);

            // Cấu hình Guna2DataGridView
            guna2Datahoadon.AutoGenerateColumns = true;
            guna2Datahoadon.DataSource = dataTable;

            // Truy vấn dữ liệu và đổ vào các ComboBox
            string queryKhachHang = "SELECT MaKhachHang FROM KhachHang";
            DataTable dataTableKhachHang = ketNoiData.ExecuteQuery(queryKhachHang);
            comboxmakhachhang.DataSource = dataTableKhachHang;
            comboxmakhachhang.DisplayMember = "MaKhachHang";

            string querySuDungDichVu = "SELECT MaSuDungDichVu FROM SuDungDichVu";
            DataTable dataTableSuDungDichVu = ketNoiData.ExecuteQuery(querySuDungDichVu);
            comboxmasudungdv.DataSource = dataTableSuDungDichVu;
            comboxmasudungdv.DisplayMember = "MaSuDungDichVu";

            string querySuDungPhong = "SELECT MaSuDungPhong FROM SuDungPhong";
            DataTable dataTableSuDungPhong = ketNoiData.ExecuteQuery(querySuDungPhong);
            comboxmasudungphong.DataSource = dataTableSuDungPhong;
            comboxmasudungphong.DisplayMember = "MaSuDungPhong";

            string queryTenKhachHang = "SELECT TenKhachHang FROM KhachHang";
            DataTable dataTableTenKhachHang = ketNoiData.ExecuteQuery(queryTenKhachHang);
            if (dataTableTenKhachHang.Rows.Count > 0)
            {
                txttenkhachhang.Text = dataTableTenKhachHang.Rows[0]["TenKhachHang"].ToString();
            }
            else
            {
                txttenkhachhang.Text = "Không có dữ liệu";
            }

        }

        private void guna2Datahoadon_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnthanhtoan_Click(object sender, EventArgs e)
        {



            string maKhachHang = comboxmakhachhang.Text;
            string tenKhachHang = txttenkhachhang.Text;
            string maSuDungDV = comboxmasudungdv.Text;
            string maSuDungPhong = comboxmasudungphong.Text;
            DateTime ngayThanhToan = guna2DateTimePicker1.Value;
            int soLuongDichVu = 1; // Thay bằng giá trị thực tế từ control tương ứng





            // Tính tổng tiền sử dụng dịch vụ
            decimal tongTienSuDungDichVu = TinhTongTienSuDungDichVu(int.Parse(maSuDungDV), soLuongDichVu);

            // Tính tổng tiền sử dụng phòng
            decimal tongTienSuDungPhong = TinhTongTienSuDungPhong(int.Parse(maSuDungPhong));

            // Tổng tiền thanh toán = tổng tiền sử dụng dịch vụ + tổng tiền sử dụng phòng
            decimal tongTienThanhToan = tongTienSuDungDichVu + tongTienSuDungPhong;

            // Xây dựng câu truy vấn SQL
            string queryInsert = $"INSERT INTO HoaDon (MaKhachHang, TenKhachHang, MaSuDungDichVu, MaSuDungPhong, NgayXuatHoaDon, TongTien) " +
                                 $"VALUES ('{maKhachHang}', '{tenKhachHang}', '{maSuDungDV}', '{maSuDungPhong}', '{ngayThanhToan:yyyy-MM-dd}', {tongTienThanhToan})";

            try
            {
                ketNoiData.ExecuteNonQuery(queryInsert);
                MessageBox.Show("Lưu hóa đơn thành công.");

                // Cập nhật lại dữ liệu trên Guna2DataGridView
                Hoadon_Load(sender, e);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi xảy ra: " + ex.Message);
            }


        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {

        }

        private void guna2DateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void comboxmakhachhang_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboxmasudungdv_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboxmasudungphong_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void txttenkhachhang_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnxoa_Click(object sender, EventArgs e)
        {
            if (guna2Datahoadon.SelectedRows.Count > 0)
            {
                // Lấy mã hóa đơn của dòng được chọn
                int maHoaDon = Convert.ToInt32(guna2Datahoadon.SelectedRows[0].Cells["MaHoaDon"].Value);

                // Xác nhận việc xóa
                DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa hóa đơn này không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    try
                    {
                        // Xóa hóa đơn từ cơ sở dữ liệu
                        string queryDelete = $"DELETE FROM HoaDon WHERE MaHoaDon = {maHoaDon}";
                        ketNoiData.ExecuteNonQuery(queryDelete);

                        // Hiển thị thông báo
                        MessageBox.Show("Xóa hóa đơn thành công.");

                        // Cập nhật lại dữ liệu trên Guna2DataGridView
                        Hoadon_Load(sender, e);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Có lỗi xảy ra: " + ex.Message);
                    }
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn hóa đơn cần xóa.");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            printDocument1.Print();
            PrintDialog printDialog = new PrintDialog();
            printDialog.Document = printDocument1;

            if (printDialog.ShowDialog() == DialogResult.OK)
            {
                printDocument1.Print();
            }
        }

        private void printDocument1_PrintPage(object sender, PrintPageEventArgs e)
        {
            // Kiểm tra xem có dòng nào được chọn không
            if (guna2Datahoadon.SelectedRows.Count > 0)
            {
                // Lấy dòng được chọn
                DataGridViewRow selectedRow = guna2Datahoadon.SelectedRows[0];

                // Trích xuất dữ liệu từ dòng được chọn
                string maKhachHang = selectedRow.Cells["MaKhachHang"].Value.ToString();
                string tenKhachHang = selectedRow.Cells["TenKhachHang"].Value.ToString();
                string maSuDungDV = selectedRow.Cells["MaSuDungDichVu"].Value.ToString();
                string maSuDungPhong = selectedRow.Cells["MaSuDungPhong"].Value.ToString();
                DateTime ngayXuatHoaDon = Convert.ToDateTime(selectedRow.Cells["NgayXuatHoaDon"].Value);
                decimal tongTien = Convert.ToDecimal(selectedRow.Cells["TongTien"].Value);

                // Tính toán tiền sử dụng dịch vụ và phòng
                decimal tongTienSuDungDichVu = TinhTongTienSuDungDichVu(int.Parse(maSuDungDV), 1); // Thay số lượng thực tế
                decimal tongTienSuDungPhong = TinhTongTienSuDungPhong(int.Parse(maSuDungPhong));
                decimal tongTienThanhToan = tongTienSuDungDichVu + tongTienSuDungPhong;

                // Vẽ nội dung hóa đơn trên trang in
                e.Graphics.DrawString("HÓA ĐƠN BÁN HÀNG", new Font("Arial", 18, FontStyle.Bold), Brushes.Black, new Point(100, 50));
                e.Graphics.DrawString($"Mã KH: {maKhachHang} - Tên KH: {tenKhachHang}", new Font("Arial", 12), Brushes.Black, new Point(100, 100));
                e.Graphics.DrawString($"Mã SD Phòng: {maSuDungPhong} - Mã SD DV: {maSuDungDV}", new Font("Arial", 12), Brushes.Black, new Point(100, 150));
                e.Graphics.DrawString($"Ngày xuất hóa đơn: {ngayXuatHoaDon.ToShortDateString()}", new Font("Arial", 12), Brushes.Black, new Point(100, 200));
                e.Graphics.DrawString($"Dịch vụ: {tongTienSuDungDichVu} VND", new Font("Arial", 12), Brushes.Black, new Point(100, 250));
                e.Graphics.DrawString($"Phòng: {tongTienSuDungPhong} VND", new Font("Arial", 12), Brushes.Black, new Point(100, 300));
                e.Graphics.DrawString($"Tổng cộng: {tongTienThanhToan} VND", new Font("Arial", 12, FontStyle.Bold), Brushes.Black, new Point(100, 350));
            }
            }
    }
}
