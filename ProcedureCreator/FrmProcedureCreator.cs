using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace ProcedureCreator
{
    public partial class FrmProcedureCreator : Form
    {
        private class ColumnInfo : CheckBox
        {
            private string columnName;

            public string ColumnName
            {
                get { return columnName; }
                set
                {
                    Text = value;
                    columnName = value;
                }
            }

            public string ColumnType { get; set; }

            public ColumnInfo(string name, string type)
            {
                ColumnName = name;
                ColumnType = type;
                Checked = true;
            }
        }

        private List<ColumnInfo> columns = new List<ColumnInfo>();
        private string tableName;
        private string resultProcedure;

        public FrmProcedureCreator()
        {
            InitializeComponent();
        }

        private void btnGetInfo_Click(object sender, EventArgs e)
        {
            columns.Clear();
            pnlCheckBox.Controls.Clear();
            SetTableName();
            CreateCheckBoxList();
        }

        private void SetTableName()
        {
            var preTableName = txtInput.Text.Split('(')[0].Split('[');
            tableName = preTableName[preTableName.Length - 1].Split(']')[0];
            txtTableName.Text = tableName;
        }

        private void CreateCheckBoxList()
        {
            columns = new List<ColumnInfo>();
            var inputText = txtInput.Text.Split(new string[] { "CREATE TABLE" }, StringSplitOptions.None)[1];
            inputText = inputText.Substring(inputText.IndexOf('(')).Split(new string[] { "CONSTRAINT" }, StringSplitOptions.None)[0];
            var columnsRaw = inputText.Split('[');
            for (int i = 1; i < columnsRaw.Length; i = i + 2)
            {
                var charLength = columnsRaw[i + 1].Contains("CHAR");
                int lengthOfChars;
                if (charLength)
                {
                    lengthOfChars = int.Parse(columnsRaw[i + 1].Split('(')[1].Split(')')[0]);
                    columns.Add(new ColumnInfo(columnsRaw[i].Split(']')[0], columnsRaw[i + 1].Split(']')[0] + "(" + lengthOfChars.ToString() + ")"));
                }
                else
                {
                    columns.Add(new ColumnInfo(columnsRaw[i].Split(']')[0], columnsRaw[i + 1].Split(']')[0]));
                }
            }

            Point point = new Point(25, 5);
            int count = 0;
            foreach (var item in columns)
            {
                point.Y = count * 25;
                item.Location = point;
                pnlCheckBox.Controls.Add(item);
                count++;
            }
        }

        private void CreateCRUD()
        {
            txtResult.Text = "";
            resultProcedure = "CREATE PROCEDURE" + " [dbo].[" + tableName + "_CRUD]\n";
            resultProcedure += "\t@Action INT\n";
            foreach (ColumnInfo item in columns)
            {
                if (item.Checked)
                {
                    resultProcedure += "\t,@" + item.ColumnName + " " + item.ColumnType + " = " + "NULL\n";
                }
            }
            resultProcedure += "AS\n" + "BEGIN\n" + "\tSET NOCOUNT ON;\n\n";
            resultProcedure += "\t--SELECT--\n";
            resultProcedure += "\t IF @Action=0\n";
            resultProcedure += "\t BEGIN\n";
            resultProcedure += "\t\t SELECT ";
            resultProcedure += columns[0].ColumnName;
            resultProcedure += ", ";
            FillWithName();
            resultProcedure += "\n\t\t FROM " + tableName + "\n";
            resultProcedure += "\t END\n\n";

            resultProcedure += "\t--INSERT--\n";
            resultProcedure += "\t IF @Action=1\n";
            resultProcedure += "\t BEGIN\n";
            resultProcedure += "\t\t INSERT INTO " + tableName + " (";
            FillWithName();
            resultProcedure += ")\n\t\t VALUES (";
            FillWithAtName();
            resultProcedure += ")\n\t END\n\n";

            resultProcedure += "\t--UPDATE--\n";
            resultProcedure += "\t IF @Action=2\n";
            resultProcedure += "\t BEGIN\n";
            resultProcedure += "\t\t UPDATE " + tableName;
            resultProcedure += "\n\t\t SET ";
            for (int i = 1; i < columns.Count; i++)
            {
                resultProcedure += columns[i].ColumnName + " = @" + columns[i].ColumnName + ", ";
            }
            resultProcedure = resultProcedure.Substring(0, resultProcedure.Length - 2);
            resultProcedure += "\n\t\tWHERE " + columns[0].ColumnName + " = @" + columns[0].ColumnName;
            resultProcedure += "\n\t END\n\n";

            resultProcedure += "\t--DELETE--\n";
            resultProcedure += "\t IF @Action=3\n";
            resultProcedure += "\t BEGIN\n";
            resultProcedure += "\t\t DELETE FROM " + tableName;
            resultProcedure += "\n\t\t WHERE " + columns[0].ColumnName + " = @" + columns[0].ColumnName;
            resultProcedure += "\n\t END\n\n";
            resultProcedure += "END";
            txtResult.Text = resultProcedure;
        }

        private void CreateInsert()
        {
            txtResult.Text = "";
            resultProcedure = "CREATE PROCEDURE" + " [dbo].[" + tableName + "_Ins]\n";
            foreach (ColumnInfo item in columns)
            {
                if (item.Checked)
                {
                    if (item == columns[0])
                    {
                    }
                    else if (item == columns[1])
                    {
                        resultProcedure += "\t @" + item.ColumnName + " " + item.ColumnType + " = " + "NULL\n";
                    }
                    else
                        resultProcedure += "\t,@" + item.ColumnName + " " + item.ColumnType + " = " + "NULL\n";
                }
            }
            resultProcedure += "\t,@ReturnValue AS INTEGER OUTPUT\n";
            resultProcedure += "AS\n" + "BEGIN\n" + "\tSET NOCOUNT ON;\n\n";
            resultProcedure += "\t--INSERT--\n";
            resultProcedure += "\t BEGIN\n";
            resultProcedure += "\t\t INSERT INTO " + tableName + " (";
            FillWithName();
            resultProcedure += ")\n\t\t VALUES (";
            FillWithAtName();
            resultProcedure += ")\n" + "\t IF @@ERROR <>0\n\t\tSET @ReturnValue = 0\n\t\tELSE\n\t\tSET @ReturnValue =@@IDENTITY" + "\n\t END\nEND\n";
            txtResult.Text = resultProcedure;
        }

        private void CreateUpdate()
        {
            txtResult.Text = "";
            resultProcedure = "CREATE PROCEDURE" + " [dbo].[" + tableName + "_Upd]\n";
            foreach (ColumnInfo item in columns)
            {
                if (item.Checked)
                {
                    if (item == columns[0])
                    {
                        resultProcedure += "\t @" + item.ColumnName + " " + item.ColumnType + " = " + "NULL\n";
                    }
                    else
                        resultProcedure += "\t,@" + item.ColumnName + " " + item.ColumnType + " = " + "NULL\n";
                }
            }
            resultProcedure += "AS\n" + "BEGIN\n" + "\tSET NOCOUNT ON;\n\n";
            resultProcedure += "\t--UPDATE--\n";
            resultProcedure += "\t BEGIN\n";
            resultProcedure += "\t\t UPDATE " + tableName;
            resultProcedure += "\n\t\t SET ";
            for (int i = 1; i < columns.Count; i++)
            {
                resultProcedure += columns[i].ColumnName + " = @" + columns[i].ColumnName + ", ";
            }
            resultProcedure = resultProcedure.Substring(0, resultProcedure.Length - 2);
            resultProcedure += "\n\t\tWHERE " + columns[0].ColumnName + " = @" + columns[0].ColumnName;
            resultProcedure += "\n\t END\nEND\n";

            txtResult.Text = resultProcedure;
        }

        private void CreateDelete()
        {
            txtResult.Text = "";
            resultProcedure = "CREATE PROCEDURE" + " [dbo].[" + tableName + "_Del]\n";

            resultProcedure += "\t @" + columns[0].ColumnName + " " + columns[0].ColumnType + " = " + "NULL\n";
            resultProcedure += "AS\n" + "BEGIN\n" + "\tSET NOCOUNT ON;\n\n";
            resultProcedure += "\t--DELETE--\n";
            resultProcedure += "\t BEGIN\n";
            resultProcedure += "\t\t DELETE FROM " + tableName;
            resultProcedure += "\n\t\t WHERE " + columns[0].ColumnName + " = @" + columns[0].ColumnName;
            resultProcedure += "\n\t END\n\n";
            resultProcedure += "END";
            txtResult.Text = resultProcedure;
        }

        private void CreateSelect()
        {
            txtResult.Text = "";
            resultProcedure = "CREATE PROCEDURE" + " [dbo].[" + tableName + "_Select]\n";

            resultProcedure += "AS\n" + "BEGIN\n" + "\tSET NOCOUNT ON;\n\n";
            resultProcedure += "\t--SELECT--\n";
            resultProcedure += "\t BEGIN\n";
            resultProcedure += "\t\t SELECT ";
            resultProcedure += columns[0].ColumnName;
            resultProcedure += ", ";
            FillWithName();
            resultProcedure += "\n\t\t FROM " + tableName + "\n";
            resultProcedure += "\t END\nEND\n";
            txtResult.Text = resultProcedure;
        }

        private void FillWithName()
        {
            for (int i = 1; i < columns.Count; i++)
            {
                resultProcedure += columns[i].ColumnName;
                resultProcedure += ", ";
            }
            resultProcedure = resultProcedure.Substring(0, resultProcedure.Length - 2);
        }

        private void FillWithAtName()
        {
            for (int i = 1; i < columns.Count; i++)
            {
                resultProcedure += "@" + columns[i].ColumnName;
                resultProcedure += ", ";
            }
            resultProcedure = resultProcedure.Substring(0, resultProcedure.Length - 2);
        }

        private void OperationChange(object sender, EventArgs e)
        {
            var rb = sender as RadioButton;
            //If radiobutton is unchecked do nothing
            if (!rb.Checked)
            {
                return;
            }

            if (rbInsert.Checked == true)
            {
                CreateInsert();
            }
            if (rbUpdate.Checked == true)
            {
                CreateUpdate();
            }
            if (rbDelete.Checked == true)
            {
                CreateDelete();
            }

            if (rbSelect.Checked == true)
            {
                CreateSelect();
            }
            if (rbCRUD.Checked == true)
            {
                CreateCRUD();
            }
        }
    }
}