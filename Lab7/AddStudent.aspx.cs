using lab7.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;

namespace lab7
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        private List<Student> Students = new List<Student>();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["students"] != null)
            {
                Students = (List<Student>)Session["students"];
                
            }

            Dispaly_Students();

        }


        public void Add_Student (object sender, EventArgs e)
        {
            

            switch (ddlType.SelectedValue)
            {
                case "fulltime":
                    FulltimeStudent fts = new FulltimeStudent(stdName.Text);
                    Students.Add(fts);
                    break;

                case "parttime":
                    ParttimeStudent pts = new ParttimeStudent(stdName.Text);
                    Students.Add(pts);
                    break;

                case "coop":
                    CoopStudent cos = new CoopStudent(stdName.Text);
                    Students.Add(cos);
                    break;
            }

            Session["students"] = Students;
            Dispaly_Students();

            stdName.Text = string.Empty;
            ddlType.Text = string.Empty;

        }


        public void Delete_Student(object sender, EventArgs e)
        {
            Session.Clear();
            Students = new List<Student>();
            Dispaly_Students();
        }


        public void Dispaly_Students ()
        {
            tblStudents.Rows.Clear();
            //create header
            TableHeaderRow tableHearderRow = new TableHeaderRow();

            TableHeaderCell idHeaderCell = new TableHeaderCell();
            idHeaderCell.Text = "ID";
            tableHearderRow.Cells.Add(idHeaderCell);

            TableHeaderCell nameHeaderCell = new TableHeaderCell();
            nameHeaderCell.Text = "Name";
            tableHearderRow.Cells.Add(nameHeaderCell);

            tblStudents.Rows.Add(tableHearderRow);

            //create students row
            if (Students.Count > 0)
            {
                tblStudents.Rows.Add(tableHearderRow);

                foreach (Student student in Students)
                {
                    TableRow newStudentRow = new TableRow();

                    TableCell IdCell = new TableCell();
                    IdCell.Text = student.Id.ToString();
                    newStudentRow.Cells.Add(IdCell);

                    TableCell nameCell = new TableCell();
                    nameCell.Text = student.Name;
                    newStudentRow.Cells.Add(nameCell);

                    tblStudents.Rows.Add(newStudentRow);
                }
            } else
            {
                TableRow noStudent = new TableRow();

                TableCell noStudnetCell = new TableCell();
                noStudnetCell.Text = "No Student Yet!";
                noStudnetCell.ForeColor = System.Drawing.Color.Red;
                noStudnetCell.CssClass = "text-center";
                noStudent.Cells.Add(noStudnetCell);
                noStudnetCell.Attributes["colspan"] = tableHearderRow.Cells.Count.ToString();


                tblStudents.Rows.Add(noStudent);

            }
        }
    }
}