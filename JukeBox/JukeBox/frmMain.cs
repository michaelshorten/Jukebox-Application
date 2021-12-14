using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JukeBox
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            Thread t = new Thread(new ThreadStart(StartForm));
            t.Start();
            Thread.Sleep(5000);
            InitializeComponent();
            t.Abort();
        }

        public void StartForm()
        {
            Application.Run(new frmSplash());
        }


        SpindleStack spindle1 = new SpindleStack();
        SpindleStack spindle2 = new SpindleStack();
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (spindle1.getSize < spindle1.getCapacity)
            {
                try
                {
                    CD_Node newNode = new CD_Node();
                    newNode.Artist = txtArtist.Text;
                    newNode.Album = txtAlbum.Text;
                    newNode.Tracks = (Convert.ToInt32(txtTrack.Text));
                    newNode.Duration = (Convert.ToDouble(txtDuration.Text));
                    spindle1.Push(newNode);
                }
                catch (FormatException fex)
                {
                    MessageBox.Show("Invalid Value\n" + fex.ToString());
                    string error = "\n" + DateTime.Now.ToString() + " " + fex.Message;
                    File.AppendAllText(@"H:\Year Two\First Semester\Unit 19 - Data Structures And Algorithms\Assignment02_Program\JukeBox\JukeBox\ErrorLog.txt", "\n" + error);
                }
                lblOutput.Text = spindle1.list();
                lblCount.Text = spindle1.getSize.ToString();

                string activity = "\n" + DateTime.Now.ToString() + " " + txtArtist.Text + " Added To Stack";
                File.AppendAllText(@"H:\Year Two\First Semester\Unit 19 - Data Structures And Algorithms\Assignment02_Program\JukeBox\JukeBox\ActivityLog.txt", activity + "\n");

                string strText = File.ReadAllText(@"H:\Year Two\First Semester\Unit 19 - Data Structures And Algorithms\Assignment02_Program\JukeBox\JukeBox\ActivityLog.txt");
                txtLog.Text = strText;
            }
            else
            {
                lblFull.Text = "Juke Box Full!";
                string activity = "\n" + DateTime.Now.ToString() + " " + "Juke Box Is Full";
                File.AppendAllText(@"H:\Year Two\First Semester\Unit 19 - Data Structures And Algorithms\Assignment02_Program\JukeBox\JukeBox\ActivityLog.txt", activity + "\n");

                string strText = File.ReadAllText(@"H:\Year Two\First Semester\Unit 19 - Data Structures And Algorithms\Assignment02_Program\JukeBox\JukeBox\ActivityLog.txt");
                txtLog.Text = strText;
            }
            clearAcctFields();
        }
        private void clearAcctFields()
        {
            //Clears All Fields (Also used within Add button for text to clear after account has been  added)
            txtAlbum.Text = "";
            txtAlbumRemove.Text = "";
            txtArtist.Text = "";
            txtArtistSearch.Text = "";
            txtDuration.Text = "";
            txtTrack.Text = "";
            txtTracksearch.Text = "";
        }
        private void btnRemove_Click(object sender, EventArgs e)
        {
            //if(Convert.ToInt32(txtAlbumRemove.Text) < spindle1.getCapacity)
            //{

            //}
            CD_Node removeNode = spindle1.pop();
            if (removeNode != null)
            {
                lblOutput.Text = "Removed !" + removeNode.Artist + removeNode.Album;

                string activity = "\n" + DateTime.Now.ToString() + " " + " Removed From Stack";
                File.AppendAllText(@"H:\Year Two\First Semester\Unit 19 - Data Structures And Algorithms\Assignment02_Program\JukeBox\JukeBox\ActivityLog.txt", activity + "\n");

                string strText = File.ReadAllText(@"H:\Year Two\First Semester\Unit 19 - Data Structures And Algorithms\Assignment02_Program\JukeBox\JukeBox\ActivityLog.txt");
                txtLog.Text = strText;
            }
            else
            {
                lblOutput.Text = "NO VINYLS ADDED";

                string activity = "\n" + DateTime.Now.ToString() + " " + " No Vinyls Added";
                File.AppendAllText(@"H:\Year Two\First Semester\Unit 19 - Data Structures And Algorithms\Assignment02_Program\JukeBox\JukeBox\ActivityLog.txt", activity + "\n");

                string strText = File.ReadAllText(@"H:\Year Two\First Semester\Unit 19 - Data Structures And Algorithms\Assignment02_Program\JukeBox\JukeBox\ActivityLog.txt");
                txtLog.Text = strText;
            }
            lblCount.Text = spindle1.getSize.ToString();
            lblOutput.Text = spindle1.list();
            clearAcctFields();
        }

        private void btnViewList_Click(object sender, EventArgs e)
        {
            lblOutput.Text = spindle1.list();
            clearAcctFields();
        }

        private void btnPeek_Click(object sender, EventArgs e)
        {
            CD_Node peekNode = spindle1.peek();
            if (peekNode != null)
            {
                lblOutput.Text = peekNode.Artist + peekNode.Album;
            }
            else
            {
                lblOutput.Text = "NO VINYLS ON STACK";

                string activity = "\n" + DateTime.Now.ToString() + " " + " No Vinyls On Stack";
                File.AppendAllText(@"H:\Year Two\First Semester\Unit 19 - Data Structures And Algorithms\Assignment02_Program\JukeBox\JukeBox\ActivityLog.txt", activity + "\n");

                string strText = File.ReadAllText(@"H:\Year Two\First Semester\Unit 19 - Data Structures And Algorithms\Assignment02_Program\JukeBox\JukeBox\ActivityLog.txt");
                txtLog.Text = strText;
            }
            clearAcctFields();
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            if (spindle1.contains(txtArtist.Text))
            {
                lblOutput.Text = "Found";
                string activity = "\n" + DateTime.Now.ToString() + " " + " Song Found";
                File.AppendAllText(@"H:\Year Two\First Semester\Unit 19 - Data Structures And Algorithms\Assignment02_Program\JukeBox\JukeBox\ActivityLog.txt", activity + "\n");
                
                string strText = File.ReadAllText(@"H:\Year Two\First Semester\Unit 19 - Data Structures And Algorithms\Assignment02_Program\JukeBox\JukeBox\ActivityLog.txt");
                txtLog.Text = strText;

            }
            else
            {
                lblOutput.Text = "Not Found";
                string activity = "\n" + DateTime.Now.ToString() + " " + " Song Not Found";
                File.AppendAllText(@"H:\Year Two\First Semester\Unit 19 - Data Structures And Algorithms\Assignment02_Program\JukeBox\JukeBox\ActivityLog.txt", activity + "\n");

                string strText = File.ReadAllText(@"H:\Year Two\First Semester\Unit 19 - Data Structures And Algorithms\Assignment02_Program\JukeBox\JukeBox\ActivityLog.txt");
                txtLog.Text = strText;

            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                if (spindle1.search(txtArtistSearch.Text, Convert.ToInt32(txtTracksearch.Text)))
                {
                    lblUserOutput.Text = "Found";
                    string activity = "\n" + DateTime.Now.ToString() + " " + " Song Found";
                    File.AppendAllText(@"H:\Year Two\First Semester\Unit 19 - Data Structures And Algorithms\Assignment02_Program\JukeBox\JukeBox\ActivityLog.txt", activity + "\n");

                    string strText = File.ReadAllText(@"H:\Year Two\First Semester\Unit 19 - Data Structures And Algorithms\Assignment02_Program\JukeBox\JukeBox\ActivityLog.txt");
                    txtLog.Text = strText;
                    lblPlaying.Text = "Now Playing Track " + txtTracksearch.Text + "      BY   " + txtArtistSearch.Text;
                }
                else
                {
                    lblUserOutput.Text = "Not Found";
                    string activity = "\n" + DateTime.Now.ToString() + " " + " Song Not Found";
                    File.AppendAllText(@"H:\Year Two\First Semester\Unit 19 - Data Structures And Algorithms\Assignment02_Program\JukeBox\JukeBox\ActivityLog.txt", activity + "\n");

                    string strText = File.ReadAllText(@"H:\Year Two\First Semester\Unit 19 - Data Structures And Algorithms\Assignment02_Program\JukeBox\JukeBox\ActivityLog.txt");
                    txtLog.Text = strText;
                }
            }
            catch (FormatException fex)
            {
                MessageBox.Show("Invalid Value\n" + fex.ToString());
                string error = "\n" + DateTime.Now.ToString() + " " + fex.Message;
                File.AppendAllText(@"H:\Year Two\First Semester\Unit 19 - Data Structures And Algorithms\Assignment02_Program\JukeBox\JukeBox\ErrorLog.txt", "\n" + error);
            }
            clearAcctFields();
        }

        private void btnRemoveSpecific_Click(object sender, EventArgs e)
        {
            try
            {
                Convert.ToInt32(txtAlbumRemove.Text);
            }
            catch (FormatException fex)
            {
                MessageBox.Show("Invalid Value\n" + fex.ToString());
                string error = "\n" + DateTime.Now.ToString() + " " + fex.Message;
                File.AppendAllText(@"H:\Year Two\First Semester\Unit 19 - Data Structures And Algorithms\Assignment02_Program\JukeBox\JukeBox\ErrorLog.txt", "\n" + error);
            }

            try
            {
                int cd = Convert.ToInt32(txtAlbumRemove.Text);

                for (int i = 1; i < cd; i++)
                {
                    CD_Node deletion = spindle1.pop();
                    spindle2.Push(deletion);
                }
                spindle1.pop();

                while (spindle2.peek() != null)
                {
                    CD_Node deletion = spindle2.pop();
                    spindle1.Push(deletion);
                }
                lblOutput.Text = spindle1.list();
                lblCount.Text = spindle1.getSize.ToString();
            }
            catch (FormatException fex)
            {
                MessageBox.Show("Invalid Value\n" + fex.ToString());
                string error = "\n" + DateTime.Now.ToString() + " " + fex.Message;
                File.AppendAllText(@"H:\Year Two\First Semester\Unit 19 - Data Structures And Algorithms\Assignment02_Program\JukeBox\JukeBox\ErrorLog.txt", "\n" + error);
            }
            string activity = "\n" + DateTime.Now.ToString() + " " + " Song Removed From Stack";
            File.AppendAllText(@"H:\Year Two\First Semester\Unit 19 - Data Structures And Algorithms\Assignment02_Program\JukeBox\JukeBox\ActivityLog.txt", activity + "\n");

            string strText = File.ReadAllText(@"H:\Year Two\First Semester\Unit 19 - Data Structures And Algorithms\Assignment02_Program\JukeBox\JukeBox\ActivityLog.txt");
            txtLog.Text = strText;
            clearAcctFields();

        }

        private void grpbInput_Enter(object sender, EventArgs e)
        {

        }

        private void lblLogo_Click(object sender, EventArgs e)
        {

        }

        private void txtLog_TextChanged(object sender, EventArgs e)
        {
            txtLog.ScrollBars = ScrollBars.Vertical;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
            File.WriteAllText(@"H:\Year Two\First Semester\Unit 19 - Data Structures And Algorithms\Assignment02_Program\JukeBox\JukeBox\ActivityLog.txt", "");
        }
    }
}
