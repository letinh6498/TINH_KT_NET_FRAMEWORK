using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kt.Model
{
    public class DiemSV
    {
        private String maSV;
        private String maMH;
        private int diem;

        public DiemSV()
        {
        }

        public DiemSV(DataRow row)
        {
            this.MaSV = row["maSV"].ToString();
            this.MaMH = row["maMonHoc"].ToString();
            this.Diem = Convert.ToInt32(row["diem"].ToString());
        }

        public string MaSV { get => maSV; set => maSV = value; }
        public string MaMH { get => maMH; set => maMH = value; }
        public int Diem { get => diem; set => diem = value; }
        /*public int getDiem()
        {
            return this.diem;
        }
        public void setDiem(int diem)
        {
            this.diem = diem;
        }*/
    }
}
