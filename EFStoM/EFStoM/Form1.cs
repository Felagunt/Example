using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Entity;

namespace EFStoM
{
    public partial class Form1 : Form
    {
        SoccerContext db; 
        public Form1()
        {
            InitializeComponent();

            db = new SoccerContext();
            db.Players.Load();
            dataGridView1.DataSource = db.Players.Local.ToBindingList();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            PlayerForm plForm = new PlayerForm();
            //из комад в дб формаируется список
            List<Team> teams = db.Teams.ToList();
            plForm.comboBox2.DataSource = teams;
            plForm.comboBox2.ValueMember = "Id";
            plForm.comboBox2.DisplayMember = "Name";

            DialogResult result = plForm.ShowDialog(this);

            if (result == DialogResult.Cancel)
                return;

            Player player = new Player();
            player.Age = (int)plForm.numericUpDown1.Value;
            player.Name = plForm.textBox1.Text;
            player.Position = plForm.comboBox1.SelectedItem.ToString();
            player.Team = (Team)plForm.comboBox2.SelectedItem;

            db.Players.Add(player);
            db.SaveChanges();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int index = dataGridView1.SelectedRows[0].Index;
                int id = 0;
                bool converted = Int32.TryParse(dataGridView1[0, index].Value.ToString(), out id);
                if (converted == false)
                    return;

                Player player = db.Players.Find(id);
                PlayerForm plForm = new PlayerForm();
                plForm.numericUpDown1.Value = player.Age;
                plForm.comboBox1.SelectedItem = player.Position;
                plForm.textBox1.Text = player.Name;

                List<Team> teams = db.Teams.ToList();
                plForm.comboBox2.DataSource = teams;
                plForm.comboBox2.ValueMember = "id";
                plForm.comboBox2.DisplayMember = "Name";

                if (player.Team != null)
                    plForm.comboBox2.SelectedValue = player.Team.Id;

                DialogResult result = plForm.ShowDialog(this);
                if (result == DialogResult.Cancel)
                    return;

                player.Age = (int)plForm.numericUpDown1.Value;
                player.Name = plForm.textBox1.Text;
                player.Position = plForm.comboBox1.SelectedItem.ToString();
                player.Team = (Team)plForm.comboBox2.SelectedItem;

                db.Entry(player).State = EntityState.Modified;
                db.SaveChanges();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if(dataGridView1.SelectedRows.Count>0)
            {
                int index = dataGridView1.SelectedRows[0].Index;
                int id = 0;
                bool converted = Int32.TryParse(dataGridView1[0,index].Value.ToString(), out id);

                if (converted == false)
                    return;

                Player player = db.Players.Find(id);
                db.Players.Remove(player);
                db.SaveChanges();

            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            AllTeams teams = new AllTeams();
            teams.Show();
        }
    }
}
