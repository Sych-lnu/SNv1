using MongoDB.Driver;
using SNv1;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Header;

namespace SNv1Forms
{
    public partial class Form3 : Form
    {
        public string email = "";
        public Form3()
        {
            InitializeComponent();
            Add.Enabled = false;
        }

        private void NotFriendsList_SelectedIndexChanged(object sender, EventArgs e)
        {
            FriendsList.Items.Clear();
            var usersCollection = Program.database.GetCollection<User>("posts");
            var postsDefinition = Builders<User>.Projection.Include("Posts");
            var postsResult = usersCollection.Find(Builders<User>.Filter.Empty).Project<User>(postsDefinition).ToList();
            int index = NotFriendsList.SelectedIndex;
            if(index>=0 && index < postsResult.Count)
            {
                Add.Enabled = true;
                email = NotFriendsList.Items[index].ToString();
                for (int i = 0; i < postsResult[index].Posts.Count; i++)
                {
                    FriendsList.Items.Add(postsResult[index].Posts[i].Content);
                }
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Back_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.Show();
            this.Hide();
            form2.Focus();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            NotFriendsList.Items.Clear();
            var usersCollection = Program.database.GetCollection<User>("posts");
            var postsDefinition = Builders<User>.Projection.Include("Email");
            var postsResult = usersCollection.Find(Builders<User>.Filter.Empty).Project<User>(postsDefinition).ToList();
            for (int i = 0; i < postsResult.Count; i++)
            {
                NotFriendsList.Items.Add(postsResult[i].Email);
            }
        }

        private void Add_Click(object sender, EventArgs e)
        {
            if(!Program.currentUser.Friends.Contains(email) &&email!="" )
            {
                Add.Enabled = false;
                Program.currentUser.Friends.Add(email);
                email = "";
                var usersCollection = Program.database.GetCollection<User>("posts");
                var updateDefinition = Builders<User>.Update.Set("Friends", Program.currentUser.Friends);
                var updateResult = usersCollection.UpdateOne(u => u.Email == Program.currentUser.Email, updateDefinition);

            }
        }
    }
}
