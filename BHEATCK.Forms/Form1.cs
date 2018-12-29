using BHEATCK.Forms.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic.FileIO;
using System.Diagnostics;

namespace BHEATCK.Forms
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;

            List<BetForcast> betForcasts = new List<BetForcast>();
            using (TextFieldParser csvParser = new TextFieldParser("test.csv"))
            {
                csvParser.SetDelimiters(new string[] { "," });
                csvParser.CommentTokens = new string[] { "#" };
                csvParser.HasFieldsEnclosedInQuotes = true;

                // Skip the row with the column names
                string[] fields = csvParser.ReadFields();

                Debug.Assert(fields != null, nameof(fields) + " != null");

                while (!csvParser.EndOfData)
                {
                    // Read current line fields, pointer moves to the next line.
                    fields = csvParser.ReadFields();
                    if (!string.IsNullOrWhiteSpace(fields[1]))
                    {
                        betForcasts.Add(BetForcast.GetForcast(fields[0], Convert.ToDouble(fields[4]), Convert.ToDouble(fields[1])));
                        betForcasts.Add(BetForcast.GetForcast(fields[0], Convert.ToDouble(fields[2]), Convert.ToDouble(fields[3])));
                    }
                }

                dataGridView1.DataSource = betForcasts;

                Cursor = Cursors.Arrow;
            }
        }
    }
}
