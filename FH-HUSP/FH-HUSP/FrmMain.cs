using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

public partial class FrmMain : Form
{
    public FrmMain()
    {
        InitializeComponent();
    }
    public void addDataToTreeViewForMining()
    {
        TreeNode node = new TreeNode();
        string file = txtInputFile.Text.Substring(txtInputFile.Text.LastIndexOf("\\") + 1, txtInputFile.Text.LastIndexOf(".") - txtInputFile.Text.LastIndexOf("\\") - 1);
        node = listTreeHUSP.Nodes.Add("HUS-Span Mining Algorithm in database " + file + " with minUntil = " + txtminUntil.Text);
        switch (file)
        {
            case "demo":
                {
                    node.Nodes.Add("Size: 1 KB, #Sequences: 5, #Distinct items: 6, Avg seq length: 7");
                    break;
                }
            case "kosarak10k":
                {
                    node.Nodes.Add("Size: 0.98 MB, #Sequences: 10000, #Distinct items: 10094, Avg seq length: 8.14");
                    break;
                }
            case "sign":
                {
                    node.Nodes.Add("Size: 375 KB, #Sequences: 800, #Distinct items: 267, Avg seq length: 51.99");
                    break;
                }
            case "fifa":
                {
                    node.Nodes.Add("Size: 7.59 MB, #Sequences: 20450, #Distinct items: 2990, Avg seq length: 34.74");
                    break;
                }
            case "bible":
                {
                    node.Nodes.Add("Size: 8.56 MB, #Sequences: 36369, #Distinct items: 13905, Avg seq length: 21.64");
                    break;
                }
            case "bmswebview1":
                {
                    node.Nodes.Add("Size: 2.80 MB, #Sequences: 59601, #Distinct items: 497, Avg seq length: 2.51");
                    break;
                }
            case "bmswebview2":
                {
                    node.Nodes.Add("Size: 3.45 MB, #Sequences: 77512, #Distinct items: 3340, Avg seq length: 4.62");
                    break;
                }
            case "kosarak990k":
                {
                    node.Nodes.Add("Size: 57.2 MB, #Sequences: 990002, #Distinct items: 41270, Avg seq length: 8.14");
                    break;
                }
        }
        node.Nodes.Add("Total time: ~" + (husSpan.endTimestamp - husSpan.startTimestamp) + " ms");
        node.Nodes.Add("Memory Usage: ~" + (husSpan.currentProc.PrivateMemorySize64 / 1024) / 1024 + "Mb");
        if (txtMaxLength.Text == "")
            node.Nodes.Add("Max length: All");
        else
            node.Nodes.Add("Max length: " + txtMaxLength.Text);
        TreeNode childNode = new TreeNode("High-utility sequential patterns count: " + husSpan.patternCount);
        node.Nodes.Add(childNode);
        for (int i = 0; i < husSpan.highUtilitySet.Count(); i++)
        {
            Dictionary<int[], IList<UtilityChainForReMining>> UtilityPattern = husSpan.highUtilitySet.ElementAt(i).Key;
            float utility = husSpan.highUtilitySet.ElementAt(i).Value;
            int[] items = UtilityPattern.First().Key;
            StringBuilder buffer = new StringBuilder();
            buffer.Append('<');
            buffer.Append('(');
            for (int j = 0; j < items.Length; j++)
            {
                if (items[j] == -1)
                {
                    buffer.Append(")(");
                }
                else
                {
                    buffer.Append(items[j]);
                }
            }
            buffer.Append(")>:");
            buffer.Append(utility);
            childNode.Nodes.Add(buffer.ToString());
        }
        listTreeHUSP.ExpandAll();
    }

    public void addDataToTreeViewForHiding()
    {
        TreeNode node = new TreeNode();
        string file = txtInputFile.Text.Substring(txtInputFile.Text.LastIndexOf("\\") + 1, txtInputFile.Text.LastIndexOf(".") - txtInputFile.Text.LastIndexOf("\\") - 1);
        node = listTreeHUSP.Nodes.Add("FH-HUSP Algorithm in database " + file + " with minUntil = " + txtminUntil.Text);
        switch (file)
        {
            case "demo":
                {
                    node.Nodes.Add("Size: 1 KB, #Sequences: 5, #Distinct items: 6, Avg seq length: 7");
                    break;
                }
            case "kosarak10k":
                {
                    node.Nodes.Add("Size: 0.98 MB, #Sequences: 10000, #Distinct items: 10094, Avg seq length: 8.14");
                    break;
                }
            case "sign":
                {
                    node.Nodes.Add("Size: 375 KB, #Sequences: 800, #Distinct items: 267, Avg seq length: 51.99");
                    break;
                }
            case "fifa":
                {
                    node.Nodes.Add("Size: 7.59 MB, #Sequences: 20450, #Distinct items: 2990, Avg seq length: 34.74");
                    break;
                }
            case "bible":
                {
                    node.Nodes.Add("Size: 8.56 MB, #Sequences: 36369, #Distinct items: 13905, Avg seq length: 21.64");
                    break;
                }
            case "bmswebview1":
                {
                    node.Nodes.Add("Size: 2.80 MB, #Sequences: 59601, #Distinct items: 497, Avg seq length: 2.51");
                    break;
                }
            case "bmswebview2":
                {
                    node.Nodes.Add("Size: 3.45 MB, #Sequences: 77512, #Distinct items: 3340, Avg seq length: 4.62");
                    break;
                }
            case "kosarak990k":
                {
                    node.Nodes.Add("Size: 57.2 MB, #Sequences: 990002, #Distinct items: 41270, Avg seq length: 8.14");
                    break;
                }
        }
        node.Nodes.Add("Total time: ~" + (husSpan.endTimestamp - husSpan.startTimestamp) + " ms");
        node.Nodes.Add("Memory Usage: ~" + (husSpan.currentProc.PrivateMemorySize64 / 1024) / 1024 + "Mb");
        node.Nodes.Add("Note", "Please choose the file named: sanitized_ouput.txt by Browse button Before Remining");
        node.Nodes["Note"].ForeColor = System.Drawing.Color.Red;
        #region "Test - Begin"
        //if (txtMaxLength.Text == "")
        //    node.Nodes.Add("Max length: All");
        //else
        //    node.Nodes.Add("Max length: " + txtMaxLength.Text);
        //TreeNode childNode = new TreeNode("High-utility sequential patterns count: " + husSpan.patternCount);
        //node.Nodes.Add(childNode);
        //for (int i = 0; i < husSpan.highUtilitySetForHiding.Count(); i++)
        //{
        //    Dictionary<int[], IList<UtilityChain>> UtilityPattern = husSpan.highUtilitySetForHiding.ElementAt(i).Key;
        //    float utility = husSpan.highUtilitySetForHiding.ElementAt(i).Value;
        //    int[] items = UtilityPattern.First().Key;
        //    StringBuilder buffer = new StringBuilder();
        //    buffer.Append('<');
        //    buffer.Append('(');
        //    for (int j = 0; j < items.Length; j++)
        //    {
        //        if (items[j] == -1)
        //        {
        //            buffer.Append(")(");
        //        }
        //        else
        //        {
        //            buffer.Append(items[j]);
        //        }
        //    }
        //    buffer.Append(")>:");
        //    buffer.Append(utility);
        //    childNode.Nodes.Add(buffer.ToString());
        //}
        //listTreeHUSP.ExpandAll();
        #endregion
        listTreeHUSP.ExpandAll();
    }
    FHHUSP_Hiding husSpan = new FHHUSP_Hiding();
    private void btnOpen_Click(object sender, EventArgs e)
    {
        OpenFileDialog openFileDialog = new OpenFileDialog();
        openFileDialog.InitialDirectory = Path.GetDirectoryName(Application.ExecutablePath);
        openFileDialog.Title = "Browse Text Files";

        openFileDialog.CheckFileExists = true;
        openFileDialog.CheckPathExists = true;
        openFileDialog.Multiselect = true;

        openFileDialog.DefaultExt = "txt";
        openFileDialog.Filter = "Data (.txt)|*.txt|All files (*.*)|*.*";
        openFileDialog.FilterIndex = 1;

        if (openFileDialog.ShowDialog() == DialogResult.OK)
        {
            txtInputFile.Text = openFileDialog.FileName;
        }
        else
            return;
    }

    private void btnHiding_Click(object sender, EventArgs e)
    {
        listTreeHUSP.Nodes.Clear();
        string external = txtInputFile.Text.Substring(0, txtInputFile.Text.LastIndexOf("."));
        external += "_ExternalUtility.txt";
        if (txtInputFile.Text.Substring(txtInputFile.Text.LastIndexOf(@"\") + 1, txtInputFile.TextLength - txtInputFile.Text.LastIndexOf(@"\") - 1) != "sanitized_ouput")
        {

            string externalModifyData = Path.GetDirectoryName(Application.ExecutablePath); //txtInputFile.Text.Substring(0, txtInputFile.Text.LastIndexOf(@"\"));
            externalModifyData += "\\sanitized_ouput_ExternalUtility.txt";
            File.Delete(externalModifyData);
            File.Copy(external, externalModifyData, true);
        }

        // run the algorithm
        if (txtminUntil.Text == "")
        {
            MessageBox.Show("Input minimum utility");
            txtminUntil.Focus();
        }
        else
        {
            husSpan.startTimestamp = DateTimeHelperClass.CurrentUnixTimeMillis();
            Dictionary<int, QMatrixHUSSpan> database =
                husSpan.loadDataWithInternalExternal(external, txtInputFile.Text, int.Parse(txtminUntil.Text));
            if (txtMaxLength.Text != "")
            {
                husSpan.setMaxPatternLength(int.Parse(txtMaxLength.Text));
            }
            husSpan.firstWriteData = true;
            husSpan._willModifiedData = true;
            husSpan.runAlgorithm(database, string.Empty);
            addDataToTreeViewForHiding();
            txtOutputFile.Text = "sanitized_ouput.txt";
            MessageBox.Show("Finish");
            File.Delete(Path.GetDirectoryName(Application.ExecutablePath) + "\\tmpFile.txt");
        }
    }

    private void btnHUSSpan_Click(object sender, EventArgs e)
    {
        listTreeHUSP.Nodes.Clear();
        string external = txtInputFile.Text.Substring(0, txtInputFile.Text.LastIndexOf("."));
        external += "_ExternalUtility.txt";

        // the path for saving the patterns found
        string output = ".//husp_output.txt";
        // run the algorithm
        if (txtminUntil.Text == "")
            MessageBox.Show("Input minimum utility");
        else
        {
            Dictionary<int, QMatrixHUSSpan> database = husSpan.loadDataWithInternalExternal(external, txtInputFile.Text, int.Parse(txtminUntil.Text));
            if (txtMaxLength.Text != "")
            {
                husSpan.setMaxPatternLength(int.Parse(txtMaxLength.Text));
            }
            husSpan.runAlgorithmForReMining(database, output);
            MessageBox.Show("Finish");
            addDataToTreeViewForMining();
        }
    }

    private void btnShowData_Click(object sender, EventArgs e)
    {
        System.Diagnostics.Process.Start(txtInputFile.Text);
    }

    private void btnOpenFile_Click(object sender, EventArgs e)
    {
        System.Diagnostics.Process.Start(Path.GetDirectoryName(Application.ExecutablePath) + "/" + txtOutputFile.Text);
    }

    private void btnExit_Click(object sender, EventArgs e)
    {
        Application.Exit();
    }
}
