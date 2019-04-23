using System;
using System.Windows.Forms;
using TennisSimulator.Scripts.Mechanics;

namespace TennisSimulator
{
    public partial class MainForm : Form
    {
        private OpenFileDialog _openFileDialog;

        public MainForm()
        {
            InitializeComponent();
            _openFileDialog = new OpenFileDialog()
            {
                FileName = "Select a json file",
                Filter = "JSON files (*.json)|*.json",
                Title = "Open Json File"
            };
        }

        private void ButtonOpenJson_Click(object sender, EventArgs e)
        {
            if (_openFileDialog.ShowDialog() == DialogResult.OK)
            {
                if (_openFileDialog.FileName != "" && _openFileDialog.FileName.EndsWith(".json"))
                {
                    SimulationManager inputHandler = new SimulationManager(_openFileDialog.FileName);
                }
                else
                {
                    MessageBox.Show("File is not a valid file. Select a json file.");
                }
            }
        }
    }
}
