using Lab6.Models;
using lab7.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Reflection;
using System.Runtime.Remoting.Messaging;
using System.Web.Services.Description;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;


namespace Lab6
{
    public partial class RegisterCourse : System.Web.UI.Page
    {
        List<Student> students = new List<Student>();
        List<Course> selectedCourses = new List<Course>();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                if (Session["students"] != null)
                {
                    students = (List<Student>)Session["students"];
                }

                int index = ddlStudent.SelectedIndex - 1;
                if (index >= 0)
                {
                    if (students[index].RegisteredCourses.Count > 0)
                    {
                        lblPrecheck.Visible = true;
                        lblPrecheck.Text = Summary(index);
                        lblError.Visible = false;
                    } else
                    {
                        lblPrecheck.Visible = false;
                    }
                   
                }else
                {
                    Response.Redirect("./RegisterCourse.aspx");
                }
            }

            if (!IsPostBack)
            {
                if (Session["students"] != null)
                {
                    students = (List<Student>)Session["students"];
                }

                ddlStudent.Items.Add(new ListItem("Select...", ""));
                foreach (Student student in students)
                {
                    ddlStudent.Items.Add(new ListItem(student.ToString()));
                }


                foreach (Course course in Helper.GetAvailableCourses())
                {
                    string c = $"{course.Title}-{course.WeeklyHours}hours/week";
                    cblCourses.Items.Add(new ListItem(c));
                }
            }
        }



        protected void ddlStudent_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Session["students"] != null)
            {
                students = (List<Student>)Session["students"];
            }

            int index = ddlStudent.SelectedIndex - 1;
            foreach (ListItem check_course in cblCourses.Items)
            {
                check_course.Selected = false;
            }

            Precheck_courses(index);
        }

        protected void SubmitButton_Clicked(object sender, EventArgs e)
        {


            lblError.Visible = false;
            int index = ddlStudent.SelectedIndex - 1;

            if (Session["students"] != null)
            {
                students = (List<Student>)Session["students"];
            };

            Add_courses();

            try
            {
                students[index].RegisterCourses(selectedCourses);
                lblPrecheck.Visible = true;
                lblPrecheck.Text = Summary(index);
                Session["students"] = students;
            }
            catch (Exception ex)
            {
                lblError.Visible = true;
                lblError.Text = ex.Message;
                lblPrecheck.Visible = false;
            }

        }


        protected void Precheck_courses(int index)
        {
            foreach (Course course in students[index].RegisteredCourses)
            {
                string text = $"{course.Title}-{course.WeeklyHours}hours/week";

                foreach (ListItem check_course in cblCourses.Items)
                {
                    if (text == check_course.ToString())
                    {
                        check_course.Selected = true;
                    }
                }
            }
        }

        protected string Summary(int index)
        {
            return $"Selected student has registered {students[index].RegisteredCourses.Count} course(s), {students[index].TotalWeeklyHours()} hours weekly";
        }

        protected void Add_courses ()
        {
            foreach (ListItem selected_course in cblCourses.Items)
            {
                if (selected_course.Selected)
                {
                    foreach (Course course in Helper.GetAvailableCourses())
                    {
                        string text = $"{course.Title}-{course.WeeklyHours}hours/week";

                        if (selected_course.Text == text)
                        {
                            selectedCourses.Add(course);
                        }
                    }
                }
            }
        }
    }
}