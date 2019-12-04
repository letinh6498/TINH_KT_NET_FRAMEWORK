using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kt.Model
{
    public class Sinhvien
    {
        private String ma;
        private String ten;
        private String gt;
        private DateTime ngaysinh;
        private String maNhom;

        public string Ma { get => ma; set => ma = value; }
        public string Ten { get => ten; set => ten = value; }
        public string Gt { get => gt; set => gt = value; }
        public DateTime Ngaysinh { get => ngaysinh; set => ngaysinh = value; }
        public string MaNhom { get => maNhom; set => maNhom = value; }


        public static explicit operator Sinhvien(DataRow v)
        {
            throw new NotImplementedException();
        }
    }
}
