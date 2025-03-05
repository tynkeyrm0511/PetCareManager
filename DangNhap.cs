using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PetCareManager
{
    public partial class frmDangNhap: Form
    {
        public frmDangNhap()
        {
            InitializeComponent();
        }
        public bool KiemTraDangNhap(string taikhoan, string matkhau)
        {
            bool hopLe = false;
            using (SqlConnection conn = KetNoiCSDL.MoKetNoi())
            {
                try
                {
                    string query = "SELECT * FROM QuanTriVien WHERE TenDangNhap = @TenDangNhap AND MatKhau = @MatKhau";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@TenDangNhap", taikhoan);
                    cmd.Parameters.AddWithValue("@MatKhau", matkhau);

                    int result = (int)cmd.ExecuteScalar();
                    hopLe = (result > 0);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Có lỗi xảy ra: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    KetNoiCSDL.DongKetNoi(conn);
                }
            }
            return hopLe;
        }
        private void btnThoat_Click(object sender, EventArgs e)
        {
            DialogResult rs = MessageBox.Show("Bạn có chắc chắn muốn thoát khỏi ứng dụng không?", "Xác nhận thoát", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if(rs == DialogResult.Yes)
            {
                Application.Exit();
            }
            Console.Write("Test Commit");
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            string taikhoan = txtTaiKhoan.Text;
            string matkhau = txtMatKhau.Text;
            if (KiemTraDangNhap(taikhoan, matkhau))
            {
                MessageBox.Show("Đăng nhập thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                // Mở form chính hoặc thực hiện hành động khi đăng nhập thành công
                frmThuCung mainForm = new frmThuCung();
                this.Hide();
                mainForm.Show();
            }
            else
            {
                MessageBox.Show("Tên đăng nhập hoặc mật khẩu không đúng.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
