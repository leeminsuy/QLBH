using System;
using System.Data;
using System.Windows.Forms;

namespace quanlykhachsan12345
{
    public partial class testkh : UserControl
    {
        private KetNoiData ketNoiData = new KetNoiData(); // Sử dụng đối tượng KetNoiData để kết nối CSDL
        private int selectedCustomerId = -1; // Biến để lưu mã khách hàng được chọn để sửa

        public testkh()
        {
            InitializeComponent();
        }

        private void testkh_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            string query = "SELECT * FROM KhachHang";
            DataTable dataTable = ketNoiData.ExecuteQuery(query);
            guna2giaodienkh.DataSource = dataTable;
        }

        private void btnluukh_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(btnhoten.Text) ||
                string.IsNullOrWhiteSpace(btndiachi.Text) ||
                string.IsNullOrWhiteSpace(btnsodienthoai.Text) ||
                string.IsNullOrWhiteSpace(btnemail.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin.");
                return;
            }

            string tenKhachHang = btnhoten.Text;
            string diaChi = btndiachi.Text;
            string soDienThoai = btnsodienthoai.Text;
            string email = btnemail.Text;

            string query = "INSERT INTO KhachHang (TenKhachHang, DiaChi, SoDienThoai, Email) VALUES (@TenKhachHang, @DiaChi, @SoDienThoai, @Email)";
            var parameters = new Dictionary<string, object>();
            parameters["@TenKhachHang"] = tenKhachHang;
            parameters["@DiaChi"] = diaChi;
            parameters["@SoDienThoai"] = soDienThoai;
            parameters["@Email"] = email;

            int rowsAffected = ketNoiData.ExecuteNonQuery(query, parameters);
            if (rowsAffected > 0)
            {
                MessageBox.Show("Thêm khách hàng thành công!");
                LoadData();
            }
            else
            {
                MessageBox.Show("Thêm khách hàng thất bại!");
            }
        }

        private void btnsuakh_Click(object sender, EventArgs e)
        {
            if (guna2giaodienkh.CurrentRow == null)
            {
                MessageBox.Show("Vui lòng chọn khách hàng cần sửa.");
                return;
            }

            selectedCustomerId = Convert.ToInt32(guna2giaodienkh.CurrentRow.Cells["MaKhachHang"].Value);
            btnhoten.Text = guna2giaodienkh.CurrentRow.Cells["TenKhachHang"].Value.ToString();
            btndiachi.Text = guna2giaodienkh.CurrentRow.Cells["DiaChi"].Value.ToString();
            btnsodienthoai.Text = guna2giaodienkh.CurrentRow.Cells["SoDienThoai"].Value.ToString();
            btnemail.Text = guna2giaodienkh.CurrentRow.Cells["Email"].Value.ToString();
        }

        private void btncapnhapkh_Click(object sender, EventArgs e)
        {
            if (selectedCustomerId == -1)
            {
                MessageBox.Show("Vui lòng chọn khách hàng cần cập nhật.");
                return;
            }

            string tenKhachHang = btnhoten.Text;
            string diaChi = btndiachi.Text;
            string soDienThoai = btnsodienthoai.Text;
            string email = btnemail.Text;

            string query = "UPDATE KhachHang SET TenKhachHang = @TenKhachHang, DiaChi = @DiaChi, SoDienThoai = @SoDienThoai, Email = @Email WHERE MaKhachHang = @MaKhachHang";
            var parameters = new Dictionary<string, object>();
            parameters["@TenKhachHang"] = tenKhachHang;
            parameters["@DiaChi"] = diaChi;
            parameters["@SoDienThoai"] = soDienThoai;
            parameters["@Email"] = email;
            parameters["@MaKhachHang"] = selectedCustomerId;

            int rowsAffected = ketNoiData.ExecuteNonQuery(query, parameters);
            if (rowsAffected > 0)
            {
                MessageBox.Show("Cập nhật khách hàng thành công!");
                LoadData();
                selectedCustomerId = -1; // Reset sau khi cập nhật
            }
            else
            {
                MessageBox.Show("Cập nhật khách hàng thất bại!");
            }
        }

        private void btnxoakh_Click(object sender, EventArgs e)
        {
            if (guna2giaodienkh.CurrentRow == null)
            {
                MessageBox.Show("Vui lòng chọn khách hàng cần xóa.");
                return;
            }

            int maKhachHang = Convert.ToInt32(guna2giaodienkh.CurrentRow.Cells["MaKhachHang"].Value);
            string query = "DELETE FROM KhachHang WHERE MaKhachHang = @MaKhachHang";
            var parameters = new Dictionary<string, object>();
            parameters["@MaKhachHang"] = maKhachHang;

            int rowsAffected = ketNoiData.ExecuteNonQuery(query, parameters);
            if (rowsAffected > 0)
            {
                MessageBox.Show("Xóa khách hàng thành công!");
                LoadData();
            }
            else
            {
                MessageBox.Show("Xóa khách hàng thất bại!");
            }
        }

        private void guna2giaodienkh_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnemail_TextChanged(object sender, EventArgs e)
        {

        }

        private void buttonluuy_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            Luuy luuy = new Luuy();
            luuy.BringToFront();
        }
    }
}
