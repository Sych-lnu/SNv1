using MongoDB.Driver;
using SNv1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using RedisCacheDAL;

namespace SNv1Forms
{
    public partial class Form2 : Form
    {
        public int page;
        public int index = 0;
        //public int friendIndex = 0;
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            ShowPostsList();
            page = 1;
        }
        public void ShowPostsList()
        {
            index = -1;
            page = 1;
            PostsList.Items.Clear();
            WriterDAL writer = new WriterDAL(Program.host, Program.port);
            ReaderDAL reader = new ReaderDAL(Program.host, Program.port);
            if (reader.CheckExisting("post-content") == 1)
            {
                var allPosts = reader.GetList("post-content");
                for (int i = 0; i < allPosts.Count(); i++)
                {
                    PostsList.Items.Add(allPosts[i]);
                }
                //PostsList.Items.Add("cache used");
            }
            else
            {
                var usersCollection = Program.database.GetCollection<User>("posts");
                var postsDefinition = Builders<User>.Projection.Include("Posts");
                var postsResult = usersCollection.Find(Builders<User>.Filter.Empty).Project<User>(postsDefinition).ToList();
                var allPosts = postsResult[0].Posts;
                for (int i = 1; i < postsResult.Count; i++)
                {
                    for (int j = 0; j < postsResult[i].Posts.Count; j++)
                    {
                        allPosts.Add(postsResult[i].Posts[j]);
                    }
                }
                Sort(allPosts);
                List<string> postsInfo = new List<string>();
                for (int i = 0; i < allPosts.Count(); i++)
                {
                    string itemText = allPosts[i].Author + ": " + allPosts[i].Content;
                    postsInfo.Add(itemText);
                    PostsList.Items.Add(itemText);
                }
                writer.SaveList("post-content", postsInfo);
            }
            label1.Text = "Create New Post!";
        }
        public void ShowCommentsList(Post post)
        {
            page = 2;
            PostsList.Items.Clear();
            for (int i = 0; i < post.Comments.Count; i++)
            {
                string itemText = post.Comments[i].Author + ": " + post.Comments[i].Content;
                PostsList.Items.Add(itemText);
            }
            label1.Text = "Comment This Post";

        }
        public void Sort(List<Post> posts)
        {
            for (int i = 0; i < posts.Count; i++)
            {
                for (int j = i + 1; j < posts.Count; j++)
                {
                    if (posts[i].CreateTime < posts[j].CreateTime)
                    {
                        var temp = posts[i];

                        posts[i] = posts[j];

                        posts[j] = temp;
                    }
                }
            }
        }

        private void PostButton_Click(object sender, EventArgs e)
        {
            if (page == 1)
            {
                string postContent = PostContentField.Text;
                if (postContent == "")
                {
                    postContent = "default content";
                }
                var usersCollection = Program.database.GetCollection<User>("posts");
                var newPost = new Post(postContent, Program.currentUser.Email);
                var updateDefinition = Builders<User>.Update.AddToSet("Posts", newPost);
                var updateResult = usersCollection.UpdateOne(u => u.Email == Program.currentUser.Email, updateDefinition);
                PostContentField.Text = "";
                ShowPostsList();
            }
            else
            {
                string postContent = PostContentField.Text;
                if (postContent == "")
                {
                    postContent = "default content";
                }
                PostContentField.Text = "";
                var usersCollection = Program.database.GetCollection<User>("posts");
                var postsDefinition = Builders<User>.Projection.Include("Posts");
                var postsResult = usersCollection.Find(Builders<User>.Filter.Empty).Project<User>(postsDefinition).ToList();
                var allPosts = new List<Post>();
                for (int i = 0; i < postsResult.Count; i++)
                {
                    for (int j = 0; j < postsResult[i].Posts.Count; j++)
                    {
                        allPosts.Add(postsResult[i].Posts[j]);
                    }
                }
                Sort(allPosts);
                if (index >= 0)
                {
                    int postIndex = 0, authorIndex = 0;
                    var newPost = allPosts[index];
                    for (int i = 0; i < postsResult.Count; i++)
                    {
                        for (int j = 0; j < postsResult[i].Posts.Count; j++)
                        {
                            if (newPost.CreateTime == postsResult[i].Posts[j].CreateTime)
                            {
                                postIndex = j;
                                authorIndex = i;
                                break;
                            }
                        }
                    }
                    Comment comment = new Comment(postContent, Program.currentUser.Email);
                    newPost.Comments.Add(comment);
                    List<Post> posts = postsResult[authorIndex].Posts;
                    posts[postIndex] = newPost;
                    var updateDefinition = Builders<User>.Update.Set("Posts", posts);
                    var updateResult = usersCollection.UpdateOne(u=>u.Email==newPost.Author, updateDefinition);
                    PostContentField.Text = "";
                    ShowPostsList();


                }
            }

        }
    


        private void PostsList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (page == 1)
            {
                var usersCollection = Program.database.GetCollection<User>("posts");
                var postsDefinition = Builders<User>.Projection.Include("Posts");
                var postsResult = usersCollection.Find(Builders<User>.Filter.Empty).Project<User>(postsDefinition).ToList();
                var allPosts = postsResult[0].Posts;
                for (int i = 1; i < postsResult.Count; i++)
                {
                    for (int j = 0; j < postsResult[i].Posts.Count; j++)
                    {
                        allPosts.Add(postsResult[i].Posts[j]);
                    }
                }
                Sort(allPosts);
                index = PostsList.SelectedIndex;
                if (index < allPosts.Count && index >= 0)
                {
                    LikeButton.Enabled = true;
                    ShowCommentsList(allPosts[index]);
                }

            }
        }

        private void Return_Click(object sender, EventArgs e)
        {
            page = 1;
            ShowPostsList();
        }

        private void label1_Click(object sender, EventArgs e)
        {


        }

        private void LikeButton_Click(object sender, EventArgs e)
        {
            var usersCollection = Program.database.GetCollection<User>("posts");
            var postsDefinition = Builders<User>.Projection.Include("Posts");
            var postsResult = usersCollection.Find(Builders<User>.Filter.Empty).Project<User>(postsDefinition).ToList();
            var allPosts = new List<Post>();
            for (int i = 0; i < postsResult.Count; i++)
            {
                for (int j = 0; j < postsResult[i].Posts.Count; j++)
                {
                    allPosts.Add(postsResult[i].Posts[j]);
                }
            }
            Sort(allPosts);
            int postIndex = 0, authorIndex = 0;
            var newPost = allPosts[index];
            for (int i = 0; i < postsResult.Count; i++)
            {
                for (int j = 0; j < postsResult[i].Posts.Count; j++)
                {
                    if (newPost.CreateTime == postsResult[i].Posts[j].CreateTime)
                    {
                        postIndex = j;
                        authorIndex = i;
                        break;
                    }
                }
            }
            newPost.Reactions[0].Count++;
            List<Post> posts = postsResult[authorIndex].Posts;
            posts[postIndex] = newPost;
            var updateDefinition = Builders<User>.Update.Set("Posts", posts);
            var updateResult = usersCollection.UpdateOne(u => u.Email == newPost.Author, updateDefinition);
            LikeButton.Enabled = false;
        }

        private void UsersListOpen_Click(object sender, EventArgs e)
        {
            Form3 form3 = new Form3();
            form3.Show();
            this.Hide();
            form3.Focus();
        }
    }
}
