using kt.Service;
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

namespace kt
{
    public partial class frmAddStudent : Form
    {
        string khoa = " ";
        frmInFoStudent frm = new frmInFoStudent();
        public frmAddStudent(string khoa)
        {
            InitializeComponent();
            this.khoa = khoa;
            txtKhoa.Enabled = false;
            txtKhoa.Text = khoa;
        }

        private void ThemSVVan_Load(object sender, EventArgs e)
        {

        }

        private void BtnThem_Click(object sender, EventArgs e)
        {
            try
            {
                errorProvider.Clear();
                if (String.IsNullOrEmpty(txtma.Text))
                {
                    errorProvider.SetError(txtma, "Vui lòng nhập mã sinh viên");
                    return;
                }
                else
                {
                    errorProvider.Clear();
                    if (String.IsNullOrEmpty(txtten.Text))
                    {
                        errorProvider.SetError(txtten, "Vui lòng nhập tên sinh viên");
                        return;
                    }
                    else
                    {
                        int gt = 0;
                        if (chkgtinh.Checked == true)
                        {
                            gt = 1;
                        }
                        else gt = 0;
                        string ma = txtma.Text;//Guid.NewGuid().ToString();
                        SinhVienService.AddSV(ma, txtten.Text, gt, dtpNS.Value, khoa);
                        //MessageBox.Show("txtname.Text,  gt, dtpNgaysinh.Value, "+"van");
                        //ResetForm();
                        MessageBox.Show("Bạn đã thêm thành công");

                        this.Hide();
                        frm.ShowDialog();
                    }
                }
            }catch(SqlException ex)
            {
                if(ex.Number == 2627)
                {
                    errorProvider.SetError(txtma, "Trùng mã sinh viên. Vui lòng nhập lại.");
                }
            }
        }


        private void BtnTroVe_Click(object sender, EventArgs e)
        {
            this.Hide();
            frm.ShowDialog();
        }
    }
}
