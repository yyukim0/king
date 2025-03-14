using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using KingMeServer;

namespace ProjetoPi
{
    public partial class Form1 : Form
    {
        public string Versao { get; set; }
        public int idPartidaSelecionada { get; set; }
        public Form1()
        {
            InitializeComponent();
            ListarPartidas();
        }

        public void AtualizarTela()
        {
            label4.Text = Versao;
        }

        private void ListarPartidas()
        {
            string retorno = Jogo.ListarPartidas("T");
            textBox1.Text = retorno;

            retorno = retorno.Replace("\r", "");
            retorno = retorno.Substring(0, retorno.Length - 1);
            string[] partidas = retorno.Split('\n');

            listBox1.Items.Clear();
            for (int i = 0; i < partidas.Length - 1; i++)
            {
                listBox1.Items.Add(partidas[i]);
            }
        }

        private void listBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            string senha = txtRequestSenha.Text;
            string partida = listBox1.SelectedItem.ToString();
            string[] dadosPartida = partida.Split(',');

            int idPartida = Convert.ToInt32(dadosPartida[0]);
            string nomePartida = dadosPartida[1];
            string data = dadosPartida[2];

            label1.Text = idPartida.ToString();
            label2.Text = senha;
            label3.Text = data;
            label5.Text = txtRequestSenha.Text;


            //lblExibirCartas.Text = Jogo.ListarCartas(, senha);

            string retorno = Jogo.ListarJogadores(idPartida);


            retorno = retorno.Replace("\r", "");
            string[] jogadores = retorno.Split('\n');

            listBox2.Items.Clear();
            for (int i = 0; i < jogadores.Length; i++)
            {
                listBox2.Items.Add(jogadores[i]);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string senha = txtRequestSenha.Text;
            string nomeJogador = txtRequestNome.Text;
            int idPartida = Convert.ToInt32(txtRequestId.Text);
            string idJogador = Jogo.Entrar(idPartida, nomeJogador, senha);
            lblSenhaId.Text = idJogador;

            //lblCartas.Text = Jogo.ListarCartas(Convert.ToInt32(idJogador, senha); //mostra na label das cartas qual a carta do jogador
        }

        //n�o tira esse m�todo
        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void button3_Click(object sender, EventArgs e)
        {
            string nomePartida = txtRequestSala.Text;
            string senha = txtRequestSenha.Text;
            string grupo = txtRequestGrupo.Text;

            string retorno = Jogo.CriarPartida(nomePartida, senha, grupo);

            if (retorno.StartsWith("ERRO"))
            {
                MessageBox.Show("Erro ao criar partida:\n" + retorno.Substring(5), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                int idNovaPartida = Convert.ToInt32(retorno);

                label1.Text = $"ID: {idNovaPartida}";
                label5.Text = $"Senha: {senha}";

                MessageBox.Show("Partida criada com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ListarPartidas();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string idJogador = lblSenhaId.Text;
            idJogador = idJogador.Substring(0, 4);
            int idPrincipal = Convert.ToInt32(idJogador);
            lblResposta.Text = idJogador;

            string senha = lblSenhaId.Text;
            senha = senha.Substring(5);
            lblSenhaResposta.Text = senha;


            Jogo.Iniciar(idPrincipal, senha);
        }

        private void lblPedirNome_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click_1(object sender, EventArgs e)
        {

        }

        private void lblGrupo_Click(object sender, EventArgs e)
        {

        }

        private void lblPedirNome_Click_1(object sender, EventArgs e)
        {

        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
