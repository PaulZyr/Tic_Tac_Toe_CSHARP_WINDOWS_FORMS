using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tic_Tac_Toe_CSHARP_FORMS
{
    [Serializable]
    public partial class MainForm : Form
    {
        string _nextMove;
        int _winX, _lostX, _drawX;
        int _winO, _lostO, _drawO;
        string _path;
        string _lastGameStarted;
        public MainForm()
        {
            InitializeComponent();
            _nextMove = "X";
            playerNameX_textBox.Text = "Player 1";
            playerNameO_textBox.Text = "Player 2";
            _winX = _lostX = _drawX = 0;
            _winO = _lostO = _drawO = 0;
            _path = "default.tt";
            _lastGameStarted = _nextMove;
        }

        private void restartGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RestartGame();
        }
        private void openGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                using (StreamReader sr = new StreamReader(_path))
                {
                    string str = sr.ReadLine();
                    string[] tmp = str.Split(' ');
                    if (tmp.Length != 10) throw new Exception("Wrong File");
                    playerNameX_textBox.Text = tmp[0];
                    playerNameO_textBox.Text = tmp[1];
                    _nextMove = tmp[2];
                    _winX = Int32.Parse(tmp[3]);
                    _lostX = Int32.Parse(tmp[4]); 
                    _drawX = Int32.Parse(tmp[5]);
                    _winO = Int32.Parse(tmp[6]); 
                    _lostO = Int32.Parse(tmp[7]); 
                    _drawO = Int32.Parse(tmp[8]); ;
                    _path = tmp[9];
                    CheckWin();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                //Console.WriteLine(ex.Message);
            }
        }
        private void saveGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //if (!File.Exists(_path)) File.Create(_path);

            try
            {
                using (StreamWriter sw = new StreamWriter(_path, false))
                {
                    sw.WriteLine(playerNameX_textBox.Text + " " 
                        + playerNameO_textBox.Text + " " 
                        + _nextMove + " " + _winX + " " + _lostX
                        + " " + _drawX + " " + _winO + " " + _lostO
                        + " " + _drawO + " " + _path);
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }
        private void ClearBoard()
        {
            button1.Text = "";
            button2.Text = "";
            button3.Text = "";
            button4.Text = "";
            button5.Text = "";
            button6.Text = "";
            button7.Text = "";
            button8.Text = "";
            button9.Text = "";
        }
        private void NextGame()
        {
            if (_lastGameStarted == "X")
            {
                _nextMove = _lastGameStarted = "O";

            }
            else _nextMove = _lastGameStarted = "X";
        }
        private void RestartGame()
        {
            _nextMove = "X";
            playerNameX_textBox.Text = "Player 1";
            playerNameO_textBox.Text = "Player 2";
            _winX = _lostX = _drawX = 0;
            _winO = _lostO = _drawO = 0;
            ClearBoard();
            _nextMove = _lastGameStarted = "X";
            CheckWin();
        }
        private void ChangeNextMove()
        {
            if (_nextMove == "X") _nextMove = "O";
            else _nextMove = "X";
            nextMoveInfoLabel.Text = "Next Move '" + _nextMove + "'";
        }
        private void CheckWin()
        {
            int n = CountWin();
            if (n == 1)
            {
                MessageBox.Show($"Game Over!\nCongrats to {playerNameX_textBox.Text}");
                _winX++;
                _lostO++;
                ClearBoard();
                NextGame();
            }
            else if (n == -1)
            {
                MessageBox.Show($"Game Over!\nCongrats to {playerNameO_textBox.Text}");
                _winO++;
                _lostX++;
                ClearBoard();
                NextGame();
            } 
            else if (n == 0)
            {
                MessageBox.Show($"Game Over!\nDRAW!");
                _drawX++;
                _drawO++;
                ClearBoard();
                NextGame();
            }
            resultXLabel.Text
                = $"W-{_winX}; L-{_lostX}; D-{_drawX}";
            resultOLabel.Text
                = $"W-{_winO}; L-{_lostO}; D-{_drawO}";
        }
        private int CountWin()
        {
            if ((button1.Text != "" && button1.Text == button2.Text
                && button2.Text == button3.Text)
                || (button4.Text != "" && button4.Text == button5.Text
                && button5.Text == button6.Text)
                || (button7.Text != "" && button7.Text == button8.Text
                && button8.Text == button9.Text)
                || (button1.Text != "" && button1.Text == button4.Text
                && button4.Text == button7.Text)
                || (button2.Text != "" && button2.Text == button5.Text
                && button5.Text == button8.Text)
                || (button3.Text != "" && button3.Text == button6.Text
                && button6.Text == button9.Text)
                || (button1.Text != "" && button1.Text == button5.Text
                && button5.Text == button9.Text)
                || (button3.Text != "" && button3.Text == button5.Text
                && button5.Text == button7.Text))
            {
                if (_nextMove == "X") return 1;
                else return -1;
            }
            else if (button1.Text != "" && button2.Text != ""
                && button3.Text != "" && button4.Text != ""
                && button5.Text != "" && button6.Text != ""
                && button7.Text != "" && button8.Text != ""
                && button9.Text != "") return 0;
            return 2;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (button1.Text=="")
            {
                button1.Text = _nextMove;
                CheckWin();
                ChangeNextMove();
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            if (button2.Text == "")
            {
                button2.Text = _nextMove;
                CheckWin();
                ChangeNextMove();
            }
        }
        private void button3_Click(object sender, EventArgs e)
        {
            if (button3.Text == "")
            {
                button3.Text = _nextMove;
                CheckWin();
                ChangeNextMove();
            }
        }
        private void button4_Click(object sender, EventArgs e)
        {
            if (button4.Text == "")
            {
                button4.Text = _nextMove;
                CheckWin();
                ChangeNextMove();
            }
        }
        private void button5_Click(object sender, EventArgs e)
        {
            if (button5.Text == "")
            {
                button5.Text = _nextMove;
                CheckWin();
                ChangeNextMove();
            }
        }
        private void button6_Click(object sender, EventArgs e)
        {
            if (button6.Text == "")
            {
                button6.Text = _nextMove;
                CheckWin();
                ChangeNextMove();
            }
        }
        private void button7_Click(object sender, EventArgs e)
        {
            if (button7.Text == "")
            {
                button7.Text = _nextMove;
                CheckWin();
                ChangeNextMove();
            }
        }
        private void button8_Click(object sender, EventArgs e)
        {
            if (button8.Text == "")
            {
                button8.Text = _nextMove;
                CheckWin();
                ChangeNextMove();
            }
        }
        private void button9_Click(object sender, EventArgs e)
        {
            if (button9.Text == "")
            {
                button9.Text = _nextMove;
                CheckWin();
                ChangeNextMove();
            }
        }
    }
}
