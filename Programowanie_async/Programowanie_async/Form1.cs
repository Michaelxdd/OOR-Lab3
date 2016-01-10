using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Programowanie_async
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            
            moja2metoda();
            label1.Text = "Czekam na odpowiedź..."; // Tekst, który pojawia się po wciśnięciu klawisza
        }

        private async void moja2metoda()
        {
            var result = await mojametodasync("Michał"); //2 wątek
            label1.Text = result;
        }
        
        private Task<string> mojametodasync(string name)
        {
            return Task.Factory.StartNew(() => mojametoda(name));
        }
        
        private string mojametoda(string name) //1 wątek
        {
            Thread.Sleep(2500); // opóźnienie 2,5 sekundowe
            return "Witaj " + name;
        }
    }
}
