
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kt.Service
{
    public static class SinhVienService
    {
        private static string  con = "Data Source=TINH;Initial Catalog=QLSinhVien;User ID=sa;password=123";
        public static DataTable getSinhVien()
        {
            string sql = "SELECT Ma, Hoten, CASE WHEN Gioitinh = 1 THEN 'Nam'ELSE N'Nữ' END as GioiTinh, Ngaysinh, maNhom as Khoa FROM SINHVIEN";
            DataTable data = Connection.Instance.ExecuteQuery(sql);
            return data;
        }
        public static void AddSV(string ma, string ten, int gt, DateTime ns, string khoa)
        {
            SqlConnection connection = new SqlConnection(con);
            connection.Open();
            string sql = "INSERT INTO SINHVIEN VALUES (@ma,@ten,@gt, @ns,@khoa)";
            SqlCommand command = new SqlCommand(sql, connection);
            command.Parameters.AddWithValue("@ma", ma);
            command.Parameters.AddWithValue("@ten", ten);
            command.Parameters.AddWithValue("@gt", gt);
            command.Parameters.AddWithValue("@ns", ns);
            command.Parameters.AddWithValue("@khoa", khoa);
            command.ExecuteNonQuery();
            connection.Close();           
        }
        public static void UpdateSV(string ma, string ten, int gt, DateTime ns)
        {
            SqlConnection connection = new SqlConnection(con);
            connection.Open();
            string sql = "UPDATE SINHVIEN SET HoTen= @ten, GioiTinh = @gt , NgaySinh = @ns WHERE Ma = @ma";
            SqlCommand command = new SqlCommand(sql, connection);
            command.Parameters.AddWithValue("@ma", ma);
            command.Parameters.AddWithValue("@ten", ten);
            command.Parameters.AddWithValue("@gt", gt);
            command.Parameters.AddWithValue("@ns", ns);
            command.ExecuteNonQuery();
            connection.Close();
        }
        public static void DeleteSV(string masv)
        {
            string sql = "DELETE FROM DIEM WHERE maSV = N'"+masv+ "' DELETE FROM SINHVIEN WHERE Ma = N'" + masv + "'";
            Connection.Instance.ExecuteNonQuery(sql);

        }
    }
}
