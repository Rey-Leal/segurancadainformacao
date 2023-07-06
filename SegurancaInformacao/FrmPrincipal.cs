using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data.OleDb;

namespace SegurancaInformacao
{
    public partial class FrmPrincipal : Form
    {
        public FrmPrincipal()
        {
            InitializeComponent();
        }

        public String um, dois, tres, quatro, cinco, seis, sete, oito, nove, dez;
        public String onze, doze, treze, quatorze, quinze, dezesseis, dezessete, dezoito, dezenove;
        public String vinte, vinteUm, vinteDois;
        public ArrayList respostas = new ArrayList();

        public void LimparCampos()
        {
            comboBox1.Text = "";
            comboBox2.Text = "";
            comboBox3.Text = "";
            comboBox4.Text = "";
            comboBox5.Text = "";
            comboBox6.Text = "";
            comboBox7.Text = "";
            comboBox8.Text = "";
            comboBox9.Text = "";
            comboBox10.Text = "";
            comboBox11.Text = "";
            comboBox12.Text = "";
            comboBox13.Text = "";
            comboBox14.Text = "";
            comboBox15.Text = "";
            comboBox16.Text = "";
            comboBox17.Text = "";
            comboBox18.Text = "";
            comboBox19.Text = "";
            comboBox20.Text = "";
            comboBox21.Text = "";
            comboBox22.Text = "";
            txtComando.Clear();
            lbPercento.Text = "00 %";
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                if (respostas != null)
                {
                    respostas.Clear();
                }
                if ((comboBox1.Text != "") && (comboBox2.Text != "") && (comboBox3.Text != "") && (comboBox4.Text != "") && (comboBox5.Text != "") && (comboBox6.Text != "") && (comboBox7.Text != "") && (comboBox8.Text != "") && (comboBox9.Text != "") && (comboBox10.Text != "") && (comboBox11.Text != "") && (comboBox12.Text != "") && (comboBox13.Text != "") && (comboBox14.Text != "") && (comboBox15.Text != "") && (comboBox16.Text != "") && (comboBox17.Text != "") && (comboBox18.Text != "") && (comboBox19.Text != "") && (comboBox20.Text != "") && (comboBox21.Text != "") && (comboBox22.Text != ""))
                {
                    um = comboBox1.Text;
                    dois = comboBox2.Text;
                    tres = comboBox3.Text;
                    quatro = comboBox4.Text;
                    cinco = comboBox5.Text;
                    seis = comboBox6.Text;
                    sete = comboBox7.Text;
                    oito = comboBox8.Text;
                    nove = comboBox9.Text;
                    dez = comboBox10.Text;
                    onze = comboBox11.Text;
                    doze = comboBox12.Text;
                    treze = comboBox13.Text;
                    quatorze = comboBox14.Text;
                    quinze = comboBox15.Text;
                    dezesseis = comboBox16.Text;
                    dezessete = comboBox17.Text;
                    dezoito = comboBox18.Text;
                    dezenove = comboBox19.Text;
                    vinte = comboBox20.Text;
                    vinteUm = comboBox21.Text;
                    vinteDois = comboBox22.Text;

                    respostas.Add(um);
                    respostas.Add(dois);
                    respostas.Add(tres);
                    respostas.Add(quatro);
                    respostas.Add(cinco);
                    respostas.Add(seis);
                    respostas.Add(sete);
                    respostas.Add(oito);
                    respostas.Add(nove);
                    respostas.Add(dez);
                    respostas.Add(onze);
                    respostas.Add(doze);
                    respostas.Add(treze);
                    respostas.Add(quatorze);
                    respostas.Add(quinze);
                    respostas.Add(dezesseis);
                    respostas.Add(dezessete);
                    respostas.Add(dezoito);
                    respostas.Add(dezenove);
                    respostas.Add(vinte);
                    respostas.Add(vinteUm);
                    respostas.Add(vinteDois);

                    String salva = DaoRespostas.SalvaRespostas(respostas);

                    MessageBox.Show(salva, "Segurança e Privacidade da Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LimparCampos();
                }
                else
                {
                    MessageBox.Show("Preencha todas as respostas", "Segurança e Privacidade da Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            LimparCampos();
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            DialogResult dialog = MessageBox.Show("Deseja realmente sair?", "Segurança e Privacidade", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (dialog == DialogResult.OK)
            {
                Application.Exit();
            }
        }

        private void FrmPrincipal_Load(object sender, EventArgs e)
        {
            txtComando.Text = "SELECT (COUNT(id)/(SELECT COUNT(id) AS tot FROM respostas WHERE respostas.id > 0)*100) AS perc FROM respostas WHERE respostas.dois ='B'";
        }

        private void btnExecutar_Click(object sender, EventArgs e)
        {
            if (txtComando.Text != "")
            {
                try
                {
                    String comando = txtComando.Text;
                    String executa = DaoRespostas.ExecutaSql(comando);
                    if (executa.Length > 10)
                    {
                        executa = executa.Substring(0, 10);
                    }
                    lbPercento.Text = executa + " %";
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                } 
            }
            else
            {
                MessageBox.Show("Digite uma consulta SQL", "Segurança e Privacidade da Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnLimpar2_Click(object sender, EventArgs e)
        {
            LimparCampos();
        }

        private void btnExemplo_Click(object sender, EventArgs e)
        {
            LimparCampos();
            String exemplo = "SELECT (COUNT(id)/(SELECT COUNT(id) AS tot FROM respostas WHERE respostas.id > 0)*100) AS perc FROM respostas WHERE respostas.dois ='B'";
            txtComando.Text = exemplo;
        }
    }
}
