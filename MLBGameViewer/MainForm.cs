﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MLBGameViewer.Objects;

namespace MLBGameViewer
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
        private List<Game> games;

        private GameRequest r = new GameRequest();

        public static selectedGame requestedGame;

        private void MainForm_Load(object sender, EventArgs e)
        {


            games = ((initForm)Owner).SelectedSchedule.games;
            
            for (int i = 0; i < ((initForm)this.Owner).SelectedSchedule.games.Count; i++)
            {
                gameList.Rows.Insert(i, games[i].away.name, games[i].home.name);
            }
            
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            Console.WriteLine(games[gameList.CurrentRow.Index].id);
            Console.WriteLine("kappa");
        }

        private void button2_Click(object sender, EventArgs e)
        {

            if (((initForm)Owner).trial)
            {
                r.accessLevel = "t";
            }
            else {
                r.accessLevel = "p";
            }

            r.APIKEY = ((initForm)Owner).APIKEY;

            r.gameId = games[gameList.CurrentRow.Index].id;
            requestedGame = r.getGame();

            GameView gameViewer = new GameView();
            gameViewer.Show(this);

            this.Hide();

            Console.WriteLine(games[gameList.CurrentRow.Index].id);
        }
    }
}
