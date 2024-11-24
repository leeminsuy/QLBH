using System;
using System.Data;
using System.Windows.Forms;

namespace quanlykhachsan12345
{
    public partial class phong : UserControl
    {
        private KetNoiData ketNoiData = new KetNoiData(); // Tạo một đối tượng kết nối CSDL
        private int selectedRoomId; // Biến để lưu mã phòng được chọn để sửa

        public phong()
        {
            InitializeComponent();
        }

        private void phong_Load(object sender, EventArgs e)
        {
            // Load dữ liệu từ cơ sở dữ liệu khi UserControl được tạo
            LoadData();
        }

        private void LoadData()
        {
            // Lấy dữ liệu từ bảng Phong
            string query = "SELECT * FROM Phong";
            DataTable dataTable = ketNoiData.ExecuteQuery(query);

            // Hiển thị dữ liệu lên DataGridView
            dataviewgiaodienphong.DataSource = dataTable;
        }

        private void luubt1_Click(object sender, EventArgs e)
        {
            // Kiểm tra xem các TextBox có chứa giá trị hợp lệ hay không
            if (string.IsNullOrWhiteSpace(txttenphong.Text) ||
                string.IsNullOrWhiteSpace(txtloaiphong.Text) ||
                string.IsNullOrWhiteSpace(txttrangthai.Text) ||
                string.IsNullOrWhiteSpace(txtgia.Text) ||
                !decimal.TryParse(txtgia.Text, out decimal gia))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ và chính xác thông tin.");
                return;
            }

            // Lấy dữ liệu từ các TextBox
            string tenPhong = txttenphong.Text;
            string loaiPhong = txtloaiphong.Text;
            string trangThai = txttrangthai.Text;

            // Tạo câu lệnh SQL để thêm phòng vào bảng Phong
            string insertQuery = $"INSERT INTO Phong (TenPhong, LoaiPhong, TrangThai, Gia) VALUES (N'{tenPhong}', N'{loaiPhong}', N'{trangThai}', {gia})";

            // Thực hiện truy vấn INSERT bằng phương thức ExecuteNonQuery
            int rowsAffected = ketNoiData.ExecuteNonQuery(insertQuery);

            // Kiểm tra xem việc thêm phòng đã thành công hay không
            if (rowsAffected > 0)
            {
                MessageBox.Show("Thêm phòng thành công!");
                // Sau khi thêm thành công, cập nhật lại dữ liệu trên DataGridView
                LoadData();
            }
            else
            {
                MessageBox.Show("Thêm phòng thất bại!");
            }
        }

        private void btnxoagiaodienphong_Click(object sender, EventArgs e)
        {
            try
            {
                // Kiểm tra xem có dòng nào được chọn hay không
                if (dataviewgiaodienphong.CurrentRow == null)
                {
                    MessageBox.Show("Vui lòng chọn phòng cần xóa.");
                    return;
                }

                // Lấy mã phòng từ dòng được chọn trên DataGridView
                int maPhong = Convert.ToInt32(dataviewgiaodienphong.CurrentRow.Cells["MaPhong"].Value);

                // Tạo câu lệnh SQL để xóa phòng từ bảng Phong
                string deleteQuery = $"DELETE FROM Phong WHERE MaPhong = {maPhong}";

                // Thực hiện truy vấn DELETE bằng phương thức ExecuteNonQuery
                int rowsAffected = ketNoiData.ExecuteNonQuery(deleteQuery);

                // Kiểm tra xem việc xóa phòng đã thành công hay không
                if (rowsAffected > 0)
                {
                    MessageBox.Show("Xóa phòng thành công!");
                    // Sau khi xóa thành công, cập nhật lại dữ liệu trên DataGridView
                    LoadData();
                }
                else
                {
                    MessageBox.Show("Xóa phòng thất bại!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"PHÒNG ĐANG ĐƯỢC SỬ DỤNG KO XÓA ĐƯỢC: {ex.Message}");
            }
        }

        private void btnsuagiaodienphong_Click(object sender, EventArgs e)
        {
            try
            {
                // Kiểm tra xem có dòng nào được chọn hay không
                if (dataviewgiaodienphong.CurrentRow == null)
                {
                    MessageBox.Show("Vui lòng chọn phòng cần sửa.");
                    return;
                }

                // Lấy mã phòng từ dòng được chọn trên DataGridView
                selectedRoomId = Convert.ToInt32(dataviewgiaodienphong.CurrentRow.Cells["MaPhong"].Value);

                // Lấy dữ liệu của phòng được chọn và hiển thị lên các TextBox
                txttenphong.Text = dataviewgiaodienphong.CurrentRow.Cells["TenPhong"].Value.ToString();
                txtloaiphong.Text = dataviewgiaodienphong.CurrentRow.Cells["LoaiPhong"].Value.ToString();
                txttrangthai.Text = dataviewgiaodienphong.CurrentRow.Cells["TrangThai"].Value.ToString();
                txtgia.Text = dataviewgiaodienphong.CurrentRow.Cells["Gia"].Value.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Đã xảy ra lỗi: {ex.Message}");
            }
        }



        private void btncapnhatphong_Click_1(object sender, EventArgs e)
        {
            // Kiểm tra xem các TextBox có chứa giá trị hợp lệ hay không
            if (string.IsNullOrWhiteSpace(txttenphong.Text) ||
                string.IsNullOrWhiteSpace(txtloaiphong.Text) ||
                string.IsNullOrWhiteSpace(txttrangthai.Text) ||
                string.IsNullOrWhiteSpace(txtgia.Text) ||
                !decimal.TryParse(txtgia.Text, out decimal gia))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ và chính xác thông tin.");
                return;
            }

            // Lấy dữ liệu từ các TextBox
            string tenPhong = txttenphong.Text;
            string loaiPhong = txtloaiphong.Text;
            string trangThai = txttrangthai.Text;

            // Tạo câu lệnh SQL để cập nhật thông tin phòng
            string updateQuery = $"UPDATE Phong SET TenPhong = N'{tenPhong}', LoaiPhong = N'{loaiPhong}', TrangThai = N'{trangThai}', Gia = {gia} WHERE MaPhong = {selectedRoomId}";

            // Thực hiện truy vấn UPDATE bằng phương thức ExecuteNonQuery
            int rowsAffected = ketNoiData.ExecuteNonQuery(updateQuery);

            // Kiểm tra xem việc cập nhật phòng đã thành công hay không
            if (rowsAffected > 0)
            {
                MessageBox.Show("Cập nhật phòng thành công!");
                // Sau khi cập nhật thành công, cập nhật lại dữ liệu trên DataGridView
                LoadData();
            }
            else
            {
                MessageBox.Show("Cập nhật phòng thất bại!");
            }
        }

        private void guna2btnnutchuyensudungphong_Click(object sender, EventArgs e)
        {

        }

        private void dataviewgiaodienphong_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void buttonluuy_Click(object sender, EventArgs e)
        {
            Luuy formLuuy = new Luuy();

            // Hiển thị form mới
            formLuuy.Show();
        }
    }
}
