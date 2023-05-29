using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Saklambac.NetFramework.Database;

namespace denemIMDB
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        SaklambacDb<Registration> saklambacDb = new SaklambacDb<Registration>();
        Registration registration = new Registration();
        ListOfPicturebox picturebox = new ListOfPicturebox();
        PictureBox[] pictureBoxes = new PictureBox[31];
        

        private void Form1_Load(object sender, EventArgs e)
        {
            Check();
            label1.Visible = false;
            label2.Visible = false;
        }

        private void HideAllPicturebox()
        {
            for (int i = 1; i< pictureBoxes.Length; i++)
            {
                pictureBoxes[i].Visible = false;
            }
        }

        private async Task listPicturebox()
        {
            pictureBoxes[0] = null;
            pictureBoxes[1] = pictureBox1;
            pictureBoxes[2] = pictureBox2;
            pictureBoxes[3] = pictureBox3;
            pictureBoxes[4] = pictureBox4;
            pictureBoxes[5] = pictureBox5;
            pictureBoxes[6] = pictureBox6;
            pictureBoxes[7] = pictureBox7;
            pictureBoxes[8] = pictureBox8;
            pictureBoxes[9] = pictureBox9;
            pictureBoxes[10] = pictureBox10;
            pictureBoxes[11] = pictureBox11;
            pictureBoxes[12] = pictureBox12;
            pictureBoxes[13] = pictureBox13;
            pictureBoxes[14] = pictureBox14;
            pictureBoxes[15] = pictureBox15;
            pictureBoxes[16] = pictureBox16;
            pictureBoxes[17] = pictureBox17;
            pictureBoxes[18] = pictureBox18;
            pictureBoxes[19] = pictureBox19;
            pictureBoxes[20] = pictureBox20;
            pictureBoxes[21] = pictureBox21;
            pictureBoxes[22] = pictureBox22;
            pictureBoxes[23] = pictureBox23;
            pictureBoxes[24] = pictureBox24;
            pictureBoxes[25] = pictureBox25;
            pictureBoxes[26] = pictureBox26;
            pictureBoxes[27] = pictureBox27;
            pictureBoxes[28] = pictureBox28;
            pictureBoxes[29] = pictureBox29;
            pictureBoxes[30] = pictureBox30;
        }

        private async Task Check()
        {
            dataGridView1.DataSource = saklambacDb.GetAll();
            dataGridView1.Columns[0].Visible = false;
            await listPicturebox();
            HideAllPicturebox();

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (!row.IsNewRow)
                {
                    int noCell = Convert.ToInt32(row.Cells["No"].Value);
                    pictureBoxes[noCell].Visible = true;
                }
            }
        }

        private bool name_check(string name)
        {
            for (int i = 1; i < dataGridView1.Rows.Count; i++)
            {
                if (dataGridView1.Rows[i].Cells["Name"].Value.ToString() == name)
                    return true;
            }
            return false;
        }

        private bool no_check(int no)
        {
            if (no == 0)
                return true;
            for (int i = 0; i< dataGridView1.Rows.Count; i++)
            {
                if (Convert.ToInt32(dataGridView1.Rows[i].Cells["No"].Value) == no)
                    return true;    
            }
            return false;
        }

        private async void buttonChoose_Click(object sender, EventArgs e)
        {
            
            Random random = new Random();
            int choosenNumber = 0;
            while (no_check(choosenNumber) && dataGridView1.RowCount != 30)
            {
                choosenNumber = random.Next(1, 31);
            }
            registration.Id = choosenNumber.ToString();
            registration.No = choosenNumber;
            registration.Name = registration.Movies[registration.No];
            label1.Visible = true;
            label1.Text = registration.Name;
            if (name_check(registration.Name))
            {
                MessageBox.Show("This movie has already been choosen");
            }
            else
            {
                saklambacDb.Add(registration);
                await Check();
            }
        }

        private async void buttonDelete_Click(object sender, EventArgs e)
        {
            Registration deletedRegister = new Registration();
            if (dataGridView1.SelectedCells.Count > 0)
            {
                saklambacDb.DeleteWithId(label2.Text);
                await Check();
            }
            else
                MessageBox.Show("Please select any cells");
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            registration.Name = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            registration.Id = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString(); 
            label1.Visible=true;
            label1.Text = registration.Name;
            label2.Text = registration.Id;
        }
    }
}
