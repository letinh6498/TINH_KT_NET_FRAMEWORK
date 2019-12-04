using kt.Model;
using kt.Service;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace kt
{
    public partial class frmInFoStudent : Form
    {
        public String masv;
        public String makhoa;
        public frmInFoStudent()
        {
            InitializeComponent();
            LoadSV();

        }

        private void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadSV();
        }

        public void LoadSV()
        {
            bdDS.DataSource = SinhVienService.getSinhVien();
            dtgDS.DataSource = bdDS;
        }

        public void ResetForm()
        {
            txtname.Text = " ";
            chkgt.Checked = false;
        }

        private void DtgDS_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dtgDS.Rows[e.RowIndex];
                txtname.Text = row.Cells[1].Value.ToString();
                String gt = row.Cells[2].Value.ToString();
                if(gt.ToLower().Equals("nam"))
                {
                    chkgt.Checked = true;

                }
                else
                {
                    chkgt.Checked = false;
                }
                dtpNgaysinh.Value = Convert.ToDateTime(row.Cells[3].Value.ToString());
                 makhoa = row.Cells[4].Value.ToString();
                masv = row.Cells[0].Value.ToString();
                List<DiemSV> diems = DiemService.Instance.getDiembySV(masv);
                if (makhoa.Contains("cntt"))
                {
                    /* foreach(DiemSV diem in diems)
                     {
                         txtCsap.Text = Convert.ToString(diem.Diem);
                     }*/
                    if (diems.Count >0)
                    {
                        txtpascal.Text = Convert.ToString(diems[1].Diem);
                        txtCsap.Text = Convert.ToString(diems[0].Diem);
                        txtSql.Text = Convert.ToString(diems[2].Diem);
                        txtVHCD.Text = " ";
                        txtVHHD.Text = " ";
                        txtCohoc.Text = " ";
                        txtQuanghoc.Text = " ";
                        txtDien.Text = " ";
                        txtVatLyHĐ.Text = " ";
                        txtDTB.Text = Convert.ToString(DiemService.Instance.getDTB(masv));
                        
                    }
                    else
                    {
                        txtpascal.Text = " ";
                        txtCsap.Text = " ";
                        txtSql.Text = " ";
                        txtDTB.Text = "0";
                    }
                    tab.SelectTab(2);

                }
                else if(makhoa.Contains("van")){
                    if (diems.Count <= 0)
                    {
                        txtVHCD.Text = " ";
                        txtVHHD.Text = " ";
                        txtDTB.Text = "0";
                    }
                    else
                    {
                        txtVHCD.Text = Convert.ToString(diems[0].Diem);
                        txtVHHD.Text = Convert.ToString(diems[1].Diem);
                        txtpascal.Text = " ";
                        txtCsap.Text = " ";
                        txtSql.Text = " ";
                        txtCohoc.Text = " ";
                        txtQuanghoc.Text = " ";
                        txtDien.Text = " ";
                        txtVatLyHĐ.Text = " ";
                        txtDTB.Text = Convert.ToString(DiemService.Instance.getDTB(masv));
                        
                    }
                    
                    tab.SelectTab(0);
                }

                else
                {
                    if (makhoa.Contains("vatly")) 
                        {
                        if (diems.Count > 0)
                        {
                            txtCohoc.Text = Convert.ToString(diems[0].Diem);
                            txtQuanghoc.Text = Convert.ToString(diems[2].Diem);
                            txtDien.Text = Convert.ToString(diems[1].Diem);
                            txtVatLyHĐ.Text = Convert.ToString(diems[3].Diem);
                            txtVHCD.Text = " ";
                            txtVHHD.Text = " ";
                            txtpascal.Text = " ";
                            txtCsap.Text = " ";
                            txtSql.Text = " ";
                            txtDTB.Text = Convert.ToString(DiemService.Instance.getDTB(masv));
                            
                        }
                        else
                        {
                            txtCohoc.Text = " ";
                            txtQuanghoc.Text = " "; 
                            txtDien.Text = " ";
                            txtVatLyHĐ.Text = " ";
                            txtDTB.Text = "0";
                        }
                        tab.SelectTab(1);
                    }
                }
            }
        }

        private void BtnXoa_Click(object sender, EventArgs e)
        {
            var rs = MessageBox.Show("Bạn có chắc là muốn xóa sinh viên này không?",
               "Thông báo"
               , MessageBoxButtons.OKCancel,
               MessageBoxIcon.Warning);
            if (rs == DialogResult.OK)
            {

                //var sv = (Sinhvien)bdDS.Current; 
                var ma = dtgDS.CurrentRow.Cells[0].Value.ToString();
                //var masv = sv.Ma;
                //ContactService.DeleteContact(pathContactDataFile, idContact);
                SinhVienService.DeleteSV(ma);

                LoadSV();
                MessageBox.Show("Bạn đã xóa thành công");
            }
            else
            {
                MessageBox.Show("Bạn đã không xóa");
            }
        }

        private void AddSVVan_Click(object sender, EventArgs e)
        {
            frmAddStudent sVVan = new frmAddStudent("van");
            this.Hide();
            sVVan.ShowDialog();
            this.Close();
        }

        private void AddSVVatLy_Click(object sender, EventArgs e)
        {
            frmAddStudent sVVan = new frmAddStudent("vatly");
            this.Hide();
            sVVan.ShowDialog();
        }

        private void AddSVCntt_Click(object sender, EventArgs e)
        {
            frmAddStudent sVVan = new frmAddStudent("cntt");
            this.Hide();
            sVVan.Show();
        }

        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            int gt = 0,tem = 0;
            if (chkgt.Checked == true)
            {
                gt = 1;
            }
            else gt = 0;
            SinhVienService.UpdateSV(masv, txtname.Text, gt, dtpNgaysinh.Value);
            //MessageBox.Show("txtname.Text,  gt, dtpNgaysinh.Value, "+"van");
            if (makhoa.Contains("van"))
            {
                errorProvider.Clear();
                if (txtVHCD.Text == null || !Int32.TryParse(txtVHCD.Text, out tem) || Convert.ToInt32(txtVHCD.Text) < 0 || Convert.ToInt32(txtVHCD.Text) > 10)
                {
                    errorProvider.SetError(txtVHCD, "Vui lòng nhập lại điểm.");
                }
                else
                {
                    errorProvider.Clear();
                    if (String.IsNullOrEmpty(txtVHHD.Text) || !Int32.TryParse(txtVHHD.Text, out tem) || Convert.ToInt32(txtVHHD.Text) < 0 || Convert.ToInt32(txtVHHD.Text) > 10)
                    {
                        errorProvider.SetError(txtVHCD, "Vui lòng nhập lại điểm.");
                    }
                    else
                    {
                        DiemService.Instance.addDiemSV(masv, "vancd", Int32.Parse(txtVHCD.Text));
                        DiemService.Instance.addDiemSV(masv, "vanhd", Int32.Parse(txtVHHD.Text));
                        txtDTB.Text = Convert.ToString(DiemService.Instance.getDTB(masv));
                        LoadSV();
                        MessageBox.Show("Bạn đã cập nhật thành công");
                    }
                }
            }
            else if (makhoa.Contains("vatly"))
            {
                errorProvider.Clear();
                if (txtCohoc.Text == null || !Int32.TryParse(txtCohoc.Text, out tem) || Convert.ToInt32(txtCohoc.Text) < 0 || Convert.ToInt32(txtCohoc.Text) > 10)
                {
                    errorProvider.SetError(txtCohoc, "Vui lòng nhập lại điểm.");
                }
                else
                {
                    errorProvider.Clear();
                    if (txtQuanghoc.Text == null || !Int32.TryParse(txtQuanghoc.Text, out tem) || Convert.ToInt32(txtQuanghoc.Text) < 0 || Convert.ToInt32(txtQuanghoc.Text) > 10)
                    {
                        errorProvider.SetError(txtQuanghoc, "Vui lòng nhập lại điểm.");
                    }
                    else
                    {
                        errorProvider.Clear();
                        if (txtDien.Text == null || !Int32.TryParse(txtDien.Text, out tem) || Convert.ToInt32(txtDien.Text) < 0 || Convert.ToInt32(txtDien.Text) > 10)
                        {
                            errorProvider.SetError(txtDien, "Vui lòng nhập lại điểm.");
                        }
                        else
                        {
                            errorProvider.Clear();
                            if (txtVatLyHĐ.Text == null || !Int32.TryParse(txtVatLyHĐ.Text, out tem) || Convert.ToInt32(txtVatLyHĐ.Text) < 0 || Convert.ToInt32(txtVatLyHĐ.Text) > 10)
                            {
                                errorProvider.SetError(txtVatLyHĐ, "Vui lòng nhập lại điểm.");
                            }
                            else
                            {
                                DiemService.Instance.addDiemSV(masv, "cohoc", Int32.Parse(txtCohoc.Text));
                                DiemService.Instance.addDiemSV(masv, "dien", Int32.Parse(txtDien.Text));
                                DiemService.Instance.addDiemSV(masv, "quanghoc", Int32.Parse(txtQuanghoc.Text));
                                DiemService.Instance.addDiemSV(masv, "VLHN", Int32.Parse(txtVatLyHĐ.Text));
                                txtDTB.Text = Convert.ToString(DiemService.Instance.getDTB(masv));
                                LoadSV();
                                MessageBox.Show("Bạn đã cập nhật thành công");
                            }
                        }
                    }
                }
            }
            else
            {
                if (makhoa.Contains("cntt"))
                {
                    errorProvider.Clear();
                    if (txtpascal.Text == null || !Int32.TryParse(txtpascal.Text, out tem) || Convert.ToInt32(txtpascal.Text) < 0 || Convert.ToInt32(txtpascal.Text) > 10)
                    {
                        errorProvider.SetError(txtpascal, "Vui lòng nhập lại điểm.");
                    }
                    else
                    {
                        errorProvider.Clear();
                        if (txtCsap.Text == null || !Int32.TryParse(txtCsap.Text, out tem) || Convert.ToInt32(txtCsap.Text) < 0 || Convert.ToInt32(txtCsap.Text) > 10)
                        {
                            errorProvider.SetError(txtCsap, "Vui lòng nhập lại điểm.");
                        }
                        else
                        {
                            errorProvider.Clear();
                            if (txtSql.Text == null || !Int32.TryParse(txtSql.Text, out tem) || Convert.ToInt32(txtSql.Text) < 0 || Convert.ToInt32(txtSql.Text) > 10)
                            {
                                errorProvider.SetError(txtSql, "Vui lòng nhập lại điểm.");
                            }
                            else
                            {
                                DiemService.Instance.addDiemSV(masv, "pascal", Int32.Parse(txtpascal.Text));
                                DiemService.Instance.addDiemSV(masv, "cshap", Int32.Parse(txtCsap.Text));
                                DiemService.Instance.addDiemSV(masv, "sql", Int32.Parse(txtSql.Text));
                                txtDTB.Text = Convert.ToString(DiemService.Instance.getDTB(masv));
                                LoadSV();
                                MessageBox.Show("Bạn đã cập nhật thành công");
                            }
                        }
                    }
                }
            }

        }

        private void BtnLuu_Click(object sender, EventArgs e)
        {
            int tem = 0;
            var re = MessageBox.Show("Bạn thực có chắc chắn muốn lưu điểm sinh viên này không?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            if (re == DialogResult.OK)
            {
                if (makhoa.Contains("van"))
                {
                    errorProvider.Clear();
                    if (txtVHCD.Text == null || !Int32.TryParse(txtVHCD.Text, out tem) || Convert.ToInt32(txtVHCD.Text) < 0 || Convert.ToInt32(txtVHCD.Text) > 10)
                    {
                        errorProvider.SetError(txtVHCD, "Vui lòng nhập lại điểm.");
                    }
                    else
                    {
                        errorProvider.Clear();
                        if (String.IsNullOrEmpty(txtVHHD.Text) || !Int32.TryParse(txtVHHD.Text, out tem) || Convert.ToInt32(txtVHHD.Text) < 0 || Convert.ToInt32(txtVHHD.Text) > 10)
                        {
                            errorProvider.SetError(txtVHCD, "Vui lòng nhập lại điểm.");
                        }
                        else
                        {
                            DiemService.Instance.updateDiemSV(masv, "vancd", Int32.Parse(txtVHCD.Text));
                            DiemService.Instance.updateDiemSV(masv, "vanhd", Int32.Parse(txtVHHD.Text));
                            txtDTB.Text = Convert.ToString(DiemService.Instance.getDTB(masv));
                            LoadSV();
                            MessageBox.Show("Lưu thành công");
                        }
                    }
                }
                else if (makhoa.Contains("vatly"))
                {
                    errorProvider.Clear();
                    if (txtCohoc.Text == null || !Int32.TryParse(txtCohoc.Text, out tem) || Convert.ToInt32(txtCohoc.Text) < 0 || Convert.ToInt32(txtCohoc.Text) > 10)
                    {
                        errorProvider.SetError(txtCohoc, "Vui lòng nhập lại điểm.");
                    }
                    else
                    {
                        errorProvider.Clear();
                        if (txtQuanghoc.Text == null || !Int32.TryParse(txtQuanghoc.Text, out tem) || Convert.ToInt32(txtQuanghoc.Text) < 0 || Convert.ToInt32(txtQuanghoc.Text) > 10)
                        {
                            errorProvider.SetError(txtQuanghoc, "Vui lòng nhập lại điểm.");
                        }
                        else
                        {
                            errorProvider.Clear();
                            if (txtDien.Text == null || !Int32.TryParse(txtDien.Text, out tem) || Convert.ToInt32(txtDien.Text) < 0 || Convert.ToInt32(txtDien.Text) > 10)
                            {
                                errorProvider.SetError(txtDien, "Vui lòng nhập lại điểm.");
                            }
                            else
                            {
                                errorProvider.Clear();
                                if (txtVatLyHĐ.Text == null || !Int32.TryParse(txtVatLyHĐ.Text, out tem) || Convert.ToInt32(txtVatLyHĐ.Text) < 0 || Convert.ToInt32(txtVatLyHĐ.Text) > 10)
                                {
                                    errorProvider.SetError(txtVatLyHĐ, "Vui lòng nhập lại điểm.");
                                }
                                else
                                {
                                    DiemService.Instance.updateDiemSV(masv, "cohoc", Int32.Parse(txtCohoc.Text));
                                    DiemService.Instance.updateDiemSV(masv, "dien", Int32.Parse(txtDien.Text));
                                    DiemService.Instance.updateDiemSV(masv, "quanghoc", Int32.Parse(txtQuanghoc.Text));
                                    DiemService.Instance.updateDiemSV(masv, "VLHN", Int32.Parse(txtVatLyHĐ.Text));
                                    txtDTB.Text = Convert.ToString(DiemService.Instance.getDTB(masv));
                                    LoadSV();
                                    MessageBox.Show("Lưu thành công");
                                }
                            }
                        }
                    }
                }
                else
                {
                    if (makhoa.Contains("cntt"))
                    {
                        errorProvider.Clear();
                        if (txtpascal.Text == null || !Int32.TryParse(txtpascal.Text, out tem) || Convert.ToInt32(txtpascal.Text) < 0 || Convert.ToInt32(txtpascal.Text) > 10)
                        {
                            errorProvider.SetError(txtpascal, "Vui lòng nhập lại điểm.");
                        }
                        else
                        {
                            errorProvider.Clear();
                            if (txtCsap.Text == null || !Int32.TryParse(txtCsap.Text, out tem) || Convert.ToInt32(txtCsap.Text) < 0 || Convert.ToInt32(txtCsap.Text) > 10)
                            {
                                errorProvider.SetError(txtCsap, "Vui lòng nhập lại điểm.");
                            }
                            else
                            {
                                errorProvider.Clear();
                                if (txtSql.Text == null || !Int32.TryParse(txtSql.Text, out tem) || Convert.ToInt32(txtSql.Text) < 0 || Convert.ToInt32(txtSql.Text) > 10)
                                {
                                    errorProvider.SetError(txtSql, "Vui lòng nhập lại điểm.");
                                }
                                else
                                {
                                    DiemService.Instance.updateDiemSV(masv, "pascal", Int32.Parse(txtpascal.Text));
                                    DiemService.Instance.updateDiemSV(masv, "cshap", Int32.Parse(txtCsap.Text));
                                    DiemService.Instance.updateDiemSV(masv, "sql", Int32.Parse(txtSql.Text));
                                    txtDTB.Text = Convert.ToString(DiemService.Instance.getDTB(masv));
                                    LoadSV();
                                    MessageBox.Show("Lưu thành công");
                                }
                            }
                        }
                    }
                }


            }
        }

        private void FrmInFoStudent_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
