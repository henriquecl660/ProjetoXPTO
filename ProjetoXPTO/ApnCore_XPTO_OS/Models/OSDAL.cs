using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace ApnCore_XPTO_OS.Models
{
    public class OSDAL : IOSDAL
    {
        
        string connectionString = @"Data Source= DESKTOP-L92A5M8;Initial Catalog= DBAtividade;Integrated Security=True;";


        public IEnumerable<OS> GetAllOSs()
        {
            List<OS> lstOS = new List<OS>();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("PR_SEL_TB_XPTO_OS", con);
                cmd.CommandType = CommandType.StoredProcedure;

                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    OS os = new OS();

                    os.NUM_OS = Convert.ToInt32(rdr["NUM_OS"]);
                    os.TITULO_SERV = rdr["TITULO_SERV"].ToString();
                    os.CNPJ_CLI = Convert.ToInt64(rdr["CNPJ_CLI"]);
                    os.NOME_CLI = rdr["NOME_CLI"].ToString();
                    os.CPF_PREST = Convert.ToInt64(rdr["CPF_PREST"]);
                    os.NOME_PREST = rdr["NOME_PREST"].ToString();
                    os.DATA_SERV = Convert.ToDateTime(rdr["DATA_SERV"]);
                    os.VALOR_SERV = Convert.ToDecimal(rdr["VALOR_SERV"]);

                    lstOS.Add(os);
                }
                con.Close();
            }
            return lstOS;
        }

        public void AddOS(OS os)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string comandoSQL = @"PR_INS_TB_XPTO_OS";
                SqlCommand cmd = new SqlCommand(comandoSQL, con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@TITULO_SERV", os.TITULO_SERV    );
                cmd.Parameters.AddWithValue("@CNPJ_CLI"   , os.CNPJ_CLI       );
                cmd.Parameters.AddWithValue("@NOME_CLI"   , os.NOME_CLI       );
                cmd.Parameters.AddWithValue("@CPF_PREST"  , os.CPF_PREST      );
                cmd.Parameters.AddWithValue("@NOME_PREST" , os.NOME_PREST     );
                cmd.Parameters.AddWithValue("@DATA_SERV"  , os.DATA_SERV      );
                cmd.Parameters.AddWithValue("@VALOR_SERV", os.VALOR_SERV);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        public void DeleteOS(int? num_os)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string comandoSQL = "Delete from TB_XPTO_OS where NUM_OS = @NUM_OS";
                SqlCommand cmd = new SqlCommand(comandoSQL, con);
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("@NUM_OS", num_os);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        public OS GetOS(int? num_os)
        {
            List<OS> lstOS = new List<OS>();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("PR_SEL_ONE_TB_XPTO_OS", con);

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@NUM_OS", num_os);

                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                OS os = new OS();

                while (rdr.Read())
                {


                    os.NUM_OS = Convert.ToInt32(rdr["NUM_OS"]);
                    os.TITULO_SERV = rdr["TITULO_SERV"].ToString();
                    os.CNPJ_CLI = Convert.ToInt64(rdr["CNPJ_CLI"]);
                    os.NOME_CLI = rdr["NOME_CLI"].ToString();
                    os.CPF_PREST = Convert.ToInt64(rdr["CPF_PREST"]);
                    os.NOME_PREST = rdr["NOME_PREST"].ToString();
                    os.DATA_SERV = Convert.ToDateTime(rdr["DATA_SERV"]);
                    os.VALOR_SERV = Convert.ToDecimal(rdr["VALOR_SERV"]);

                }

                return os;
            }
        }

        public void UpdateOS(OS os)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string comandoSQL = "PR_UPD_TB_XPTO_OS";
                SqlCommand cmd = new SqlCommand(comandoSQL, con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@NUM_OS", os.NUM_OS);
                cmd.Parameters.AddWithValue("@TITULO_SERV", os.TITULO_SERV);
                cmd.Parameters.AddWithValue("@CNPJ_CLI", os.CNPJ_CLI);
                cmd.Parameters.AddWithValue("@NOME_CLI", os.NOME_CLI);
                cmd.Parameters.AddWithValue("@CPF_PREST", os.CPF_PREST);
                cmd.Parameters.AddWithValue("@NOME_PREST", os.NOME_PREST);
                cmd.Parameters.AddWithValue("@DATA_SERV", os.DATA_SERV);
                cmd.Parameters.AddWithValue("@VALOR_SERV", os.VALOR_SERV);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }
    }
}
