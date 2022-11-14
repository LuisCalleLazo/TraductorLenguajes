using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace TraductorLenguajes.Registros.RestPassword
{
    /// <summary>
    /// Lógica de interacción para VerificCodigoGmail.xaml
    /// </summary>
    public partial class VerificCodigoGmail : Window
    {
        string gmail;
        int codigo_verific;
        public VerificCodigoGmail(string gmail)
        {
            this.gmail = gmail;
            InitializeComponent();
            MessageBox.Show(EnvioCodigo());
        }

        public string EnvioCodigo()
        {
            string resp;
            int codigo = GetCodigo();
            this.codigo_verific = codigo;
            
            string body = @"
            <style>
                h1{color: #045;}
                h2{color: #400;}
            </style>" +
            "<h1>El código de verificación es:</h1>" +
            $"<h2><b>{codigo}</b></h2>";
            
            resp = EnviarCorreo(this.gmail, "Codigo de verificación", body);
            return resp;
        }
        public int GetCodigo()
        {
            var seed = Environment.TickCount;
            Random random = new Random(seed);

            int num1, num2, num3, codigo=1;

            num1 = random.Next(0, 99);
            num2 = random.Next(0, 99);
            num3 = random.Next(0, 999);

            codigo = num1;
            codigo = (codigo * 100) + num2;
            codigo = (codigo * 1000) + num3;

            return codigo;
        }
        public string EnviarCorreo(string correo_enviar, string titulo, string mensaje)
        {
            string resp;
            logic obj_logic = new logic();
            resp = obj_logic.SendMail(correo_enviar, titulo, mensaje);
            return resp;
        }
        private void VerificarCodigo(object sender, RoutedEventArgs e)
        {
            if (this.codigo_verific == Int32.Parse(this.codigo.Text))
            {
                MessageBox.Show("El código introducido es correcto");
                ElegirCuenta ventana_new_pass = new ElegirCuenta(this.gmail);
                ventana_new_pass.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("El código ingresado es incorrecto");
            }
        }

        private void Volver(object sender, RoutedEventArgs e)
        {
            OlvidoContra ventana_contra = new OlvidoContra(this.gmail);
            ventana_contra.Show();
            this.Close();
        }
        private void codigo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key >= Key.D0 && e.Key <= Key.D9 || e.Key >= Key.NumPad0 && e.Key <= Key.NumPad9)
                e.Handled = false;
            else
                e.Handled = true;
        }
    }
}
