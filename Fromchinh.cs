namespace quanlykhachsan12345
{
    public partial class fromchinh : Form
    {
        public fromchinh()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {


        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void luubt1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load_1(object sender, EventArgs e)
        {
          
        }

        private void testkh1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {
            Dangnhap1 dangnhap1 = new Dangnhap1();
            this.Hide();                                 //quay ve dang nhap
            dangnhap1.Show();
        }

        private void panelmoving_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnphong_Click(object sender, EventArgs e)
        {
            phong1.Visible = true;
            phong1.BringToFront();
            testkh1.Visible =false; // dùng để ẩn from khác và hiển thị from phong
            dichvu11.Visible =false;
           sudungphongcs1.Visible =false;
            


        }

        private void btnthoat_Click(object sender, EventArgs e)
        {
            this.Hide(); // ẩn from hiện tại
            Dangnhap1 dangnhap = new Dangnhap1();
            dangnhap.Show();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnkhachhang_Click(object sender, EventArgs e)
        {
            testkh1.Visible = true;
            testkh1.BringToFront();
           

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void btnthemdichvu_Click(object sender, EventArgs e)
        {
            dichvu11.Visible=true;
            dichvu11.BringToFront();
        }

        private void btndatphong_Click(object sender, EventArgs e)
        {
            sudungphongcs1.Visible=true;
            sudungphongcs1.BringToFront();
        }

        private void btnsudungdv_Click(object sender, EventArgs e)
        {
            fromSusungdv1.Visible=true;
            fromSusungdv1.BringToFront();
        }

        private void btnthongke_Click(object sender, EventArgs e)
        {
            thongke1.Visible=true;
            thongke1.BringToFront();
        
        }

        private void btnhoadon_Click(object sender, EventArgs e)
        {
            hoadon1.Visible = true;
            hoadon1.BringToFront();
        }
    }
}
