using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Windows.Forms;

namespace Volkov_HW_WinForms_19
{
    public partial class Form1 : Form
    {
        int Remoteport;
        int LocalPort;
        IPAddress adress;


        public Form1()
        {
            InitializeComponent();
            button2.Enabled = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "")
            {
                try
                {
                    adress = IPAddress.Parse(textBox1.Text);
                    MessageBox.Show(adress.ToString());
                    Remoteport = int.Parse(textBox2.Text);
                    LocalPort = int.Parse(textBox3.Text);
                    Thread thread = new Thread(new ThreadStart(ThreadFundReceive));
                    thread.IsBackground= true;
                    thread.Start();
                    button1.Enabled = false;
                    button2.Enabled = true;
                }
                catch (FormatException ex)
                {
                    MessageBox.Show(ex.Message);
                }
                catch (Exception ex2)
                {
                    MessageBox.Show(ex2.Message);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(textBox5.Text != "")
            {
                richTextBox1.Text += "You: " + textBox5.Text + "\n";
                UdpClient client = new UdpClient();
                IPEndPoint ipend = new IPEndPoint(adress, Remoteport);
                try
                {
                    byte[] bytes = Encoding.Unicode.GetBytes(textBox5.Text);
                    client.Send(bytes, bytes.Length, ipend);
                }
                catch (SocketException ex)
                {
                    MessageBox.Show(ex.Message);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    client.Close();
                }
            }
        }

        private void ThreadFundReceive()
        {
            try
            {
                while (true)
                {
                    UdpClient client = new UdpClient(LocalPort);
                    IPEndPoint ipend = null;
                    byte[] responce = client.Receive(ref ipend);
                    string strResult = Encoding.Unicode.GetString(responce);
                    richTextBox1.ForeColor = Color.Green;
                    richTextBox1.Text += "User: " + strResult + "\n";
                    client.Close();
                }
            }
            catch(SocketException ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
