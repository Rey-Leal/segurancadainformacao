using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Data.OleDb;

namespace SegurancaInformacao
{
    class DaoRespostas
    {
        public static String SalvaRespostas(ArrayList respostas)
        {
            try
            {
                OleDbConnection conexao = Conexao.Conecta();
                OleDbCommand cmd = new OleDbCommand("INSERT INTO respostas (um, dois, tres, quatro, cinco, seis, sete, oito, nove, dez, onze, doze, treze, quatorze, quinze, dezesseis, dezessete, dezoito, dezenove, vinte, vinteUm, vinteDois) VALUES ('" + respostas[0] + "','" + respostas[1] + "','" + respostas[2] + "','" + respostas[3] + "','" + respostas[4] + "','" + respostas[5] + "','" + respostas[6] + "','" + respostas[7] + "','" + respostas[8] + "','" + respostas[9] + "','" + respostas[10] + "','" + respostas[11] + "','" + respostas[12] + "','" + respostas[13] + "','" + respostas[14] + "','" + respostas[15] + "','" + respostas[16] + "','" + respostas[17] + "','" + respostas[18] + "','" + respostas[19] + "','" + respostas[20] + "','" + respostas[21] + "')", conexao);
                conexao.Open();
                cmd.ExecuteScalar();
                conexao.Close();
                return "Resposta cadastrada com sucesso!";
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static String ExecutaSql(String comando)
        {
            try
            {
                OleDbConnection conexao = Conexao.Conecta();
                OleDbCommand cmd = new OleDbCommand(comando, conexao);
                conexao.Open();
                OleDbDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    return dr[0].ToString();
                }
                else
                {
                    return "00 %";
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
