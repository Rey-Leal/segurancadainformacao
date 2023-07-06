using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data.OleDb;

namespace SegurancaInformacao
{
    class Conexao
    {
        //Access
        public static OleDbConnection Conecta()
        {
            try
            {
                String mapa = System.IO.Directory.GetCurrentDirectory().ToString();
                String caminho = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source= " + mapa + @"\SegurancaInformacao.mdb";
                OleDbConnection conexao = new OleDbConnection(caminho);
                return conexao;
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }

        //SQL
        //public static SqlConnection Conecta()
        //{
        //    try
        //    {
        //        String caminho = @"Data Source=D:\Rey Leal\Documents\Projects Desktop\SegurancaInformacao\SegurancaInformacao\SegurancaInformacao.sdf";
        //        SqlConnection conexao = new SqlConnection(caminho);
        //        return conexao;
        //    }
        //    catch (SqlException ex)
        //    {
        //        throw ex;
        //    }
        //}
    }
}
