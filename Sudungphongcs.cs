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
    public partial class Sudungphongcs : UserControl
    {

        private KetNoiData ketNoiData = new KetNoiData();
        private int selectedUsageId; // Biến để lưu mã sử dụng phòng được chọn để sửa
        public Sudungphongcs()
        {
            InitializeComponent();

        }
        // Kết nối CSDL và truy vấn dữ liệu
        private void LoadData()
        {
            // Truy vấn dữ liệu MaKhachHang từ bảng KhachHang
            string queryKhachHang = "SELECT MaKhachHang FROM KhachHang";
            DataTable dataTableKhachHang = ketNoiData.ExecuteQuery(queryKhachHang);

            // Đổ dữ liệu vào ComboBox MaKhachHang
            comboxmakh.DataSource = dataTableKhachHang;
            comboxmakh.DisplayMember = "MaKhachHang";

            // Truy vấn dữ liệu MaPhong từ bảng Phong
            string queryPhong = "SELECT MaPhong FROM Phong";
            DataTable dataTablePhong = ketNoiData.ExecuteQuery(queryPhong);

            // Đổ dữ liệu vào ComboBox MaPhong
            comboxmaphong.DataSource = dataTablePhong;
            comboxmaphong.DisplayMember = "MaPhong";

            // Truy vấn dữ liệu từ bảng SuDungPhong
            string query = "SELECT * FROM SuDungPhong";
            DataTable dataTable = ketNoiData.ExecuteQuery(query);

            // Cấu hình Guna2DataGridView
            guna2dataphong.AutoGenerateColumns = true;
            guna2dataphong.DataSource = dataTable;



        }




        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Sudungphongcs_Load(object sender, EventArgs e)
        {
            comboxmakh.ValueMember = "MaKhachHang";


            LoadData();
        }

        private void txtmasudungphong_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2DateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void guna2DateTimePicker2_ValueChanged(object sender, EventArgs e)
        {

        }

        private void btnlusudungphong_Click(object sender, EventArgs e)
        {
            // Kiểm tra xem các ComboBox có chứa giá trị hợp lệ hay không
            if (comboxmakh.SelectedItem == null ||
                comboxmaphong.SelectedItem == null ||
                guna2DateTimengaythue.Value >= guna2DateTimengaytra.Value)
            {
                MessageBox.Show("Vui lòng nhập đầy đủ và chính xác thông tin.");
                return;
            }

            // Lấy dữ liệu từ các ComboBox và DateTimePicker
            int maKhachHang = Convert.ToInt32(((DataRowView)comboxmakh.SelectedItem)["MaKhachHang"]);
            int maPhong = Convert.ToInt32(((DataRowView)comboxmaphong.SelectedItem)["MaPhong"]);

            DateTime ngayThue = guna2DateTimengaythue.Value;
            DateTime ngayTra = guna2DateTimengaytra.Value;

            // Kiểm tra xem dữ liệu đã tồn tại trong bảng SuDungPhong hay chưa
            string queryCheck = $"SELECT COUNT(*) FROM SuDungPhong WHERE MaKhachHang = {maKhachHang} AND MaPhong = {maPhong}";
            int count = Convert.ToInt32(ketNoiData.ExecuteScalar(queryCheck));

            // Nếu đã tồn tại, thông báo lỗi và không thêm dữ liệu mới
            if (count > 0)
            {
                MessageBox.Show("Mã khách hàng và mã phòng đã tồn tại trong bảng SuDungPhong.");
                return;
            }

            // Tạo câu lệnh SQL để thêm sử dụng phòng vào bảng SuDungPhong
            string insertQuery = $"INSERT INTO SuDungPhong (MaKhachHang, MaPhong, NgayThue, NgayTra) VALUES ({maKhachHang}, {maPhong}, '{ngayThue:yyyy-MM-dd}', '{ngayTra:yyyy-MM-dd}')";

            // Thực hiện truy vấn INSERT bằng phương thức ExecuteNonQuery
            int rowsAffected = ketNoiData.ExecuteNonQuery(insertQuery);

            // Kiểm tra xem việc thêm sử dụng phòng đã thành công hay không
            if (rowsAffected > 0)
            {
                MessageBox.Show("Thêm sử dụng phòng thành công!");
                // Sau khi thêm thành công, cập nhật lại dữ liệu trên DataGridView
                LoadData();
            }
            else
            {
                MessageBox.Show("Thêm sử dụng phòng thất bại!");
            }
        }

        private void btnxoasudungphong_Click(object sender, EventArgs e)
        {
            try
            {
                // Kiểm tra xem có dòng nào được chọn hay không
                if (guna2dataphong.CurrentRow == null)
                {
                    MessageBox.Show("Vui lòng chọn sử dụng phòng cần xóa.");
                    return;
                }

                // Lấy mã sử dụng phòng từ dòng được chọn trên DataGridView
                int maSuDungPhong = Convert.ToInt32(guna2dataphong.CurrentRow.Cells[0].Value); // Sử dụng chỉ mục 0 để truy cập cột đầu tiên

                // Tạo câu lệnh SQL để xóa sử dụng phòng từ bảng SuDungPhong
                string deleteQuery = $"DELETE FROM SuDungPhong WHERE MaSuDungPhong = {maSuDungPhong}";

                // Thực hiện truy vấn DELETE bằng phương thức ExecuteNonQuery
                int rowsAffected = ketNoiData.ExecuteNonQuery(deleteQuery);

                // Kiểm tra xem việc xóa sử dụng phòng đã thành công hay không
                if (rowsAffected > 0)
                {
                    MessageBox.Show("Xóa sử dụng phòng thành công!");
                    // Sau khi xóa thành công, cập nhật lại dữ liệu trên DataGridView
                    LoadData();
                }
                else
                {
                    MessageBox.Show("Xóa sử dụng phòng thất bại!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Đã xảy ra lỗi: {ex.Message}");
            }
        }

        private void btnsuasudungphong_Click(object sender, EventArgs e)
        {
            try
            {
                // Kiểm tra xem có dòng nào được chọn hay không
                if (guna2dataphong.CurrentRow == null)
                {
                    MessageBox.Show("Vui lòng chọn sử dụng phòng cần xóa.");
                    return;
                }

                // Lấy mã sử dụng phòng từ dòng được chọn trên DataGridView
                int maSuDungPhong = Convert.ToInt32(guna2dataphong.CurrentRow.Cells[0].Value); // Sử dụng chỉ mục 0 để truy cập cột đầu tiên

                // Tạo câu lệnh SQL để xóa sử dụng phòng từ bảng SuDungPhong
                string deleteQuery = $"DELETE FROM SuDungPhong WHERE MaSuDungPhong = {maSuDungPhong}";

                // Thực hiện truy vấn DELETE bằng phương thức ExecuteNonQuery
                int rowsAffected = ketNoiData.ExecuteNonQuery(deleteQuery);

                // Kiểm tra xem việc xóa sử dụng phòng đã thành công hay không
                if (rowsAffected > 0)
                {
                    MessageBox.Show("Xóa sử dụng phòng thành công!");
                    // Sau khi xóa thành công, cập nhật lại dữ liệu trên DataGridView
                    LoadData();
                }
                else
                {
                    MessageBox.Show("Xóa sử dụng phòng thất bại!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Đã xảy ra lỗi: {ex.Message}");
            }
        }

        private void btncapnhatsudungphong_Click(object sender, EventArgs e)
        {

        }

        private void guna2dataphong_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void guna2dataphong_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void buttonluuy_Click(object sender, EventArgs e)
        {
           
        }

        private void guna2dataphong_CellContentClick_2(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            Luuy2 nu = new Luuy2();
            nu.Show();
        }
    }
}
