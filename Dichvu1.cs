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
    public partial class dichvu1 : UserControl
    {
        private KetNoiData ketNoiData = new KetNoiData(); // Tạo một đối tượng kết nối CSDL
        private int selectedRoomId; // Biến để lưu mã phòng được chọn để sửa

        public dichvu1()
        {
            InitializeComponent();
        }

        private void dichvu1_Load(object sender, EventArgs e)
        {
            // Load dữ liệu từ cơ sở dữ liệu khi UserControl được tạo
            LoadData();
        }

        private void LoadData()
        {


            // Lấy dữ liệu từ bảng DichVu
            string query = "SELECT * FROM DichVu";
            DataTable dataTable = ketNoiData.ExecuteQuery(query);

            // Hiển thị dữ liệu lên DataGridView
            guna2datadichvu.DataSource = dataTable;



        }

        private void comboxloaidichvu_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void txtmotadichvu_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtgiadichvu_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnluudv_Click(object sender, EventArgs e)
        {
            // Kiểm tra xem các TextBox có chứa giá trị hợp lệ hay không
            if (string.IsNullOrWhiteSpace(comboxtendichvu.Text) ||
                string.IsNullOrWhiteSpace(txtmotadichvu.Text) ||
                string.IsNullOrWhiteSpace(txtgiadichvu.Text) ||
                !decimal.TryParse(txtgiadichvu.Text, out decimal giaDichVu))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ và chính xác thông tin.");
                return;
            }

            // Lấy dữ liệu từ các TextBox
            string tenDichVu = comboxtendichvu.Text;
            string moTa = txtmotadichvu.Text;

            // Tạo câu lệnh SQL để thêm dịch vụ vào bảng DichVu
            string insertQuery = $"INSERT INTO DichVu (TenDichVu, MoTa, DonGia) VALUES (N'{tenDichVu}', N'{moTa}', {giaDichVu})";

            // Thực hiện truy vấn INSERT bằng phương thức ExecuteNonQuery
            int rowsAffected = ketNoiData.ExecuteNonQuery(insertQuery);

            // Kiểm tra xem việc thêm dịch vụ đã thành công hay không
            if (rowsAffected > 0)
            {
                MessageBox.Show("Thêm dịch vụ thành công!");
                // Sau khi thêm thành công, cập nhật lại dữ liệu trên DataGridView
                LoadData();
            }
            else
            {
                MessageBox.Show("Thêm dịch vụ thất bại!");
            }
        }

        private void btnxoadv_Click(object sender, EventArgs e)
        {
            try
            {
                // Kiểm tra xem có dòng nào được chọn hay không
                if (guna2datadichvu.CurrentRow == null)
                {
                    MessageBox.Show("Vui lòng chọn dịch vụ cần xóa.");
                    return;
                }

                // Lấy mã dịch vụ từ dòng được chọn trên DataGridView
                int maDichVu = Convert.ToInt32(guna2datadichvu.CurrentRow.Cells["MaDichVu"].Value);

                // Tạo câu lệnh SQL để xóa dịch vụ từ bảng DichVu
                string deleteQuery = $"DELETE FROM DichVu WHERE MaDichVu = {maDichVu}";

                // Thực hiện truy vấn DELETE bằng phương thức ExecuteNonQuery
                int rowsAffected = ketNoiData.ExecuteNonQuery(deleteQuery);

                // Kiểm tra xem việc xóa dịch vụ đã thành công hay không
                if (rowsAffected > 0)
                {
                    MessageBox.Show("Xóa dịch vụ thành công!");
                    // Sau khi xóa thành công, cập nhật lại dữ liệu trên DataGridView
                    LoadData();
                }
                else
                {
                    MessageBox.Show("Xóa dịch vụ thất bại!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Đã xảy ra lỗi: {ex.Message}");
            }
        }

        private void btnsuadv_Click(object sender, EventArgs e)
        {
            try
            {
                // Kiểm tra xem có dòng nào được chọn hay không
                if (guna2datadichvu.CurrentRow == null)
                {
                    MessageBox.Show("Vui lòng chọn dịch vụ cần sửa.");
                    return;
                }

                // Lấy mã dịch vụ từ dòng được chọn trên DataGridView
                int maDichVu = Convert.ToInt32(guna2datadichvu.CurrentRow.Cells["MaDichVu"].Value);

                // Lấy dữ liệu của dịch vụ được chọn và hiển thị lên các TextBox
                comboxtendichvu.Text = guna2datadichvu.CurrentRow.Cells["TenDichVu"].Value.ToString();
                txtmotadichvu.Text = guna2datadichvu.CurrentRow.Cells["MoTa"].Value.ToString();
                txtgiadichvu.Text = guna2datadichvu.CurrentRow.Cells["DonGia"].Value.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Đã xảy ra : {ex.Message}");
            }
        }

        private void btncapnhatdv_Click_1(object sender, EventArgs e)
        {
            // Kiểm tra xem các TextBox có chứa giá trị hợp lệ hay không
            if (string.IsNullOrWhiteSpace(comboxtendichvu.Text) ||
                string.IsNullOrWhiteSpace(txtmotadichvu.Text) ||
                string.IsNullOrWhiteSpace(txtgiadichvu.Text) ||
                !decimal.TryParse(txtgiadichvu.Text, out decimal giaDichVu))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ và chính xác thông tin.");
                return;
            }

            // Lấy dữ liệu từ các TextBox
            string tenDichVu = comboxtendichvu.Text;
            string moTa = txtmotadichvu.Text;

            // Lấy mã dịch vụ từ dòng được chọn trên DataGridView
            int maDichVu = Convert.ToInt32(guna2datadichvu.CurrentRow.Cells["MaDichVu"].Value);

            // Tạo câu lệnh SQL để cập nhật thông tin dịch vụ
            string updateQuery = $"UPDATE DichVu SET TenDichVu = N'{tenDichVu}', MoTa = N'{moTa}', DonGia = {giaDichVu} WHERE MaDichVu = {maDichVu}";

            // Thực hiện truy vấn UPDATE bằng phương thức ExecuteNonQuery
            int rowsAffected = ketNoiData.ExecuteNonQuery(updateQuery);

            // Kiểm tra xem việc cập nhật dịch vụ đã thành công hay không
            if (rowsAffected > 0)
            {
                MessageBox.Show("Cập nhật dịch vụ thành công!");
                // Sau khi cập nhật thành công, cập nhật lại dữ liệu trên DataGridView
                LoadData();
            }
            else
            {
                MessageBox.Show("Cập nhật dịch vụ thất bại!");
            }
        }

        private void guna2datadichvu_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void buttonluuy_Click(object sender, EventArgs e)
        {
            Luuy formLuuy = new Luuy();

            // Hiển thị form lưu ý
            formLuuy.Show();
        }
    }
}
