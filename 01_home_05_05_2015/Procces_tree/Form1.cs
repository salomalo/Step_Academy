using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Procces_tree
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            InitializeTreeView();
        }

        Process[] _process = Process.GetProcesses();

        private void InitializeTreeView()
        {
            foreach (Process p in _process)
            {
                if (GetParentProcessId(p.Id) == 0)
                {
                    treeView1.Nodes.Add(p.ProcessName, p.ProcessName);
                    // foreach (Process p2 in _process)
                    // {
                    //    if (GetParentProcessId(p2.Id) == p.Id)
                    //    {
                    //        treeView1.Nodes[p.ProcessName].Nodes.Add(p2.ProcessName, p2.ProcessName);
                    //    }
                    //}

                    foreach (Process proc in GetChildProcesses(p))
                    {
                        treeView1.Nodes[p.ProcessName].Nodes.Add(proc.ProcessName, proc.ProcessName);
                    }
                }
            }
        } //  InitializeTreeView()


        int GetParentProcessId(int Id)
        {
            int parentId = 0;
            using (ManagementObject obj = new ManagementObject("win32_process.handle=" + Id.ToString()))
            {
                obj.Get();
                parentId = Convert.ToInt32(obj["ParentProcessId"]);
            }
            return parentId;
        } // GetParentProcessId


        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            //String tmp = treeView1.SelectedNode.Name;
            //richTextBox1.Text = tmp;
            //Process[] pr = Process.GetProcessesByName(tmp);
            //foreach (Process p in pr)
            //{
            //    MessageBox.Show(p.ProcessName + " " + p.Id.ToString());
            //}

        } // treeView1_AfterSelect


        private void treeView1_BeforeExpand(object sender, TreeViewCancelEventArgs e)
        {
            TreeNode nd = new TreeNode();
            //nd.Name = "ss";
            foreach (TreeNode node in e.Node.Nodes)
            {
                node.Nodes.Clear();
                AddNode(nd);
            }
        } // treeView1_BeforeExpand

        public void AddNode(TreeNode root1)
        {
            foreach (Process p in _process)
            {
                if (GetChildProcesses(p) != null)
                {
                    foreach (Process proc in GetChildProcesses(p))
                    {
                        root1.Nodes[p.ProcessName].Nodes.Add(proc.ProcessName, proc.ProcessName);
                    }
                }
            }
        } // AddNode


        private void treeView1_AfterExpand(object sender, TreeViewEventArgs e)
        {}

        private void treeView1_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {        
                TreeNode nd = new TreeNode();
                //nd.Name = "ss";
                foreach (TreeNode node in e.Node.Nodes)
                {
                    MessageBox.Show(node.Name);
                    node.Nodes.Clear();
                    //AddNode(nd);

                    foreach (Process p in _process)
                    {
                        if (GetChildProcesses(p) != null)
                        {
                            foreach (Process proc in GetChildProcesses(p))
                            {
                                treeView1.Nodes[node.Name].Nodes.Add(proc.ProcessName, proc.ProcessName);
                            }
                        }
                    }
                }
       
        } // treeView1_NodeMouseClick 


        public List<Process> GetChildProcesses(Process process)
        {
            var results = new List<Process>();
            string queryText = string.Format("select processid from win32_process where parentprocessid = {0}", process.Id);
            using (var searcher = new ManagementObjectSearcher(queryText))
            {
                foreach (var obj in searcher.Get())
                {
                    object data = obj.Properties["processid"].Value;
                    if (data != null)
                    {
                        // retrieve the process
                        var childId = Convert.ToInt32(data);
                        var childProcess = Process.GetProcessById(childId);
                        // ensure the current process is still live
                        if (childProcess != null)
                            results.Add(childProcess);
                    }
                }
            }
            return results;
        }// GetChildProcesses


        //////////////////////////////////////////////////////////////////////////////////

        //List<int> parent;
        //List<Process> parentProc;

        //public Form1()
        //{
        //    InitializeComponent();
        //    Process[] p = Process.GetProcesses();
        //    parent = new List<int>();
        //    parentProc = new List<Process>();

        //    foreach (Process el in p)
        //    {
        //        if (GetParentId(el) != null && !parent.Exists(c => c == GetParentId(el)))
        //        {
        //            try
        //            {
        //                parent.Add((int)GetParentId(el));
        //                parentProc.Add(Process.GetProcessById((int)GetParentId(el)));
        //            }
        //            catch (Exception ex)
        //            {
        //            }
        //        }
        //    }
        //    //   MessageBox.Show(parent.Count.ToString());

        //    foreach (var el in parentProc)
        //    {
        //        TreeNode tn = new TreeNode(el.ProcessName);
        //        treeView1.Nodes.Add(tn);
        //        foreach (var e in GetChildProcesses(el))
        //        {
        //            tn.Nodes.Add(e.ProcessName);
        //        }
        //    }
        //    //  MessageBox.Show(parentProc.Count.ToString());
        //}

        //public int? GetParentId(Process process)
        //{
        //    string queryText = string.Format("select parentprocessid from win32_process where processid = {0}", process.Id);
        //    using (var searcher = new ManagementObjectSearcher(queryText))
        //   {
        //        foreach (var obj in searcher.Get())
        //        {
        //            object data = obj.Properties["parentprocessid"].Value;
        //            if (data != null)
        //                return Convert.ToInt32(data);
        //        }
        //    }
        //    return null;
        //}




    } // Form1 
}
