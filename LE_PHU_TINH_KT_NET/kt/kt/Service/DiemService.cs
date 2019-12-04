using kt.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kt.Service
{
    public class DiemService
    {
        private static DiemService instance;
        private static string con = "Data Source=TINH;Initial Catalog=QLSinhVien;User ID=sa;password=123";
        public static DiemService Instance
        {
            get { if (instance == null) instance = new DiemService(); return DiemService.instance; }
            private set { DiemService.instance = value; }
        }
        public List<DiemSV> getDiembySV(String masv)
        {
          
            String sql = "select maSV, maMonHoc, diem from DIEM where maSV = N'"+masv+"'";
            DataTable data = Connection.Instance.ExecuteQuery(sql);
            List<DiemSV> listName = data.AsEnumerable().Select(m => new DiemSV()
            {
                MaSV = m.Field<string>("maSV"),
                MaMH = m.Field<string>("maMonHoc"),
                Diem = m.Field<int>("Diem"),
            }).ToList();           
            return listName;
        }
        public double getDTB(string masv)
        {
            SqlConnection connection = new SqlConnection(con);
            connection.Open();
            String sql = "select SUM(diem)/COUNT(maSV) as DIEMTB from DIEM where maSV='"+masv+"'";
            SqlCommand command = new SqlCommand(sql, connection);
            int s = (int)command.ExecuteScalar();
            connection.Close();
            return s;

        }
        public void addDiemSV(string masv, string mamh, int diem)
        {
            SqlConnection connection = new SqlConnection(con);
            connection.Open();
            string sql = "INSERT INTO DIEM VALUES(@maSV, @mamh, @diem)";
            SqlCommand command = new SqlCommand(sql, connection);
            command.Parameters.AddWithValue("@maSV", masv);
            command.Parameters.AddWithValue("@mamh", mamh);
            command.Parameters.AddWithValue("@diem", diem);
            command.ExecuteNonQuery();
            connection.Close();
        }
        public void updateDiemSV(string masv, string mamh, int diem)
        {
            SqlConnection connection = new SqlConnection(con);
            connection.Open();
            string sql = "UPDATE DIEM SET  diem = @diem WHERE maSV = @masv and maMonHoc= @mamh";
            SqlCommand command = new SqlCommand(sql, connection);
            command.Parameters.AddWithValue("@maSV", masv);
            command.Parameters.AddWithValue("@mamh", mamh);
            command.Parameters.AddWithValue("@diem", diem);
            command.ExecuteNonQuery();
            connection.Close();
        }
    }
}
