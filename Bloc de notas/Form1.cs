using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

//CREADO POR KEVIN ROMERO GRACIAS AL TUTORIAL DE PABLO LOPEZ
//LINK DEL VIDEO https://www.youtube.com/watch?v=BU-uFypvOog

namespace Bloc_de_notas
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            BackColor = Color.Coral;
            TransparencyKey = BackColor;
        }

        private void nuevoToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (richTextBox1.Text == null || richTextBox1.Text == ""){
                 
            }
            else
            {
                string message = "Desea guardar el archivo?";    
                string title = "Bloc de notas";

                MessageBoxButtons buttons = MessageBoxButtons.YesNoCancel;
                DialogResult result;

                result = MessageBox.Show(this, message, title, buttons);

                if (result == DialogResult.No)
                {
                    string nameFile = "Sin titulo";

                    this.Text = nameFile + " : Bloc de Notas";

                    richTextBox1.Clear();
                }
                else
                {
                    if(result == DialogResult.Yes)
                    {
                        guardarComoToolStripMenuItem_Click( sender, e);
                    }
                }
                
            }

        }

        private void abrirToolStripMenuItem_Click(object sender, EventArgs e)
        {

            OpenFileDialog fileOpen = new OpenFileDialog();
            fileOpen.Filter = "Archivos de texto (.txt)|*.txt|*Todos los archivos (*.*)|*.*";
            fileOpen.Title = "Abrir archivo";

            var result = fileOpen.ShowDialog();

            if (result == DialogResult.OK)
            {
                System.IO.StreamReader fileRead = new System.IO.StreamReader(fileOpen.FileName);
                richTextBox1.Text = fileRead.ReadToEnd();
                this.Text = fileOpen.FileName;

            }
        }

        private void guardarComoToolStripMenuItem_Click(object sender, EventArgs e)
        {
             SaveFileDialog fileSave = new SaveFileDialog();
            fileSave.Filter = "Archivos de texto(.txt) | *.txt";
            fileSave.Title = "Guardar como...";
            fileSave.FileName = "Sin Titulo.txt";

             var sf = fileSave.ShowDialog();

             if (sf == DialogResult.OK)
             {
                 using (var file = new System.IO.StreamWriter(fileSave.FileName))
                 {
                     file.WriteLine(richTextBox1.Text);
                 }

                this.Text = fileSave.FileName;

             }


        }

        private void guardarToolStripMenuItem_Click(object sender, EventArgs e)
        {
     
            SaveFileDialog fileSave = new SaveFileDialog();

            this.Text = fileSave.FileName;

            string ruta = this.Text;

            if (this.Text == "Bloc de Notas")
            {
                guardarComoToolStripMenuItem_Click(sender,  e);

            }
            else
            {
                if (this.Text != "Bloc de Notas")
                {
                    richTextBox1.SaveFile(this.Text, RichTextBoxStreamType.PlainText);

                    this.Text = fileSave.FileName;
                }
                

            }
            this.Text = fileSave.FileName;
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void adelanteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Redo();
        }

        private void atrasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Undo();
        }

        private void copiarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Copy();
        }

        private void pegarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Paste();
        }

        private void cortarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Cut();
        }

        private void seleccionarTodoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectAll();
        }

        private void borrarTodoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();
        }

        private void horaYFechaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DateTime fecha = DateTime.Now;
            richTextBox1.Text = fecha.ToString();
        }

        private void estiloDeFuenteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FontDialog fileFont = new FontDialog();
            fileFont.Font = richTextBox1.Font;

            if(fileFont.ShowDialog() == DialogResult.OK){
                richTextBox1.Font = fileFont.Font;
            }
        }

        private void colorDeFuenteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ColorDialog fileColor = new ColorDialog();
            
            if(fileColor.ShowDialog() == DialogResult.OK)
            {
                richTextBox1.ForeColor = fileColor.Color;
            }
        }

        private void colorDeFondoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ColorDialog fileFondo = new ColorDialog();

            if(fileFondo.ShowDialog() == DialogResult.OK)
            {
                richTextBox1.BackColor = fileFondo.Color;
            }
        }

        private void acercaDeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Creado por Kevin Romero \n Version: 1.0");
        }

        
    }
}
