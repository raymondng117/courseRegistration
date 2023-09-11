using Lab6.Models;
using System;
using System.Web.UI.WebControls;


namespace Lab6
{
    public partial class RegisterCourse : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                foreach (Course course in Helper.GetAvailableCourses())
                {
                    string c = $"  {course.Title} - {course.WeeklyHours}hours/week";
                    cblCourses.Items.Add(new ListItem(c));
                }
            }

        }


        protected void SubmitButton_Clicked(object sender, EventArgs e)
        {
            int max_weekly_hour = 0;
            int max_num_courses = 0;

            contentTable.Rows.Add(CreateHeader());

            foreach (ListItem selected_course in cblCourses.Items)
            {
                if (selected_course.Selected)
                {
                    foreach (Course course in Helper.GetAvailableCourses())
                    {
                        string text = $"  {course.Title} - {course.WeeklyHours}hours/week";

                        if (selected_course.Text == text)
                        {
                            max_weekly_hour += course.WeeklyHours;
                            max_num_courses++;

                            contentTable.Rows.Add(CreateTableDetails(course));
                        }
                    }
                }
            }

            contentTable.Rows.Add(TotalHours(max_weekly_hour));


            while (true)
            {
                if (stdName.Text == "")
                {
                    Error_Message("You must enter a name!");
                    return;
                }

                if (stdType.SelectedValue == "")
                {
                    Error_Message("You must select one of student types!");
                    return;
                }



                switch (stdType.SelectedValue)
                {
                    case "fulltime":
                        if (max_weekly_hour > 16)
                        {
                            Error_Message("Your selection exceeds the maximum weekly hours for full-time students: 16");
                            return;
                        }
                        break;

                    case "parttime":
                        if (max_num_courses > 3)
                        {
                            Error_Message("Your selection exceeds the maximum number of courses for part-time students: 3");
                            return;
                        }
                        break;

                    case "coop":
                        if (max_weekly_hour > 4)
                        {
                            Error_Message("Your selection exceeds the maximum weekly hours for co-op students: 4");
                            return;
                        }
                        else if (max_num_courses > 2)
                        {
                            Error_Message("Your selection exceeds the maximum number of courses for co-op students: 2");
                            return;
                        }
                        break;
                }

                break;
            }

            content.Visible = false;
            contentTable.Visible = true;
        }


        protected void Error_Message(string message)
        {
            lblError.Controls.Clear();
            lblError.Visible = true;
            lblError.Text = message;
        }

        protected TableHeaderRow CreateHeader()
        {
            //create header
            TableHeaderRow tableHearderRow = new TableHeaderRow();

            TableHeaderCell courseCodeHeaderCell = new TableHeaderCell();
            courseCodeHeaderCell.Text = "Course Code";
            tableHearderRow.Cells.Add(courseCodeHeaderCell);

            TableHeaderCell courseTitleHeaderCell = new TableHeaderCell();
            courseTitleHeaderCell.Text = "Course Title";
            tableHearderRow.Cells.Add(courseTitleHeaderCell);

            TableHeaderCell weeklyHoursHeaderCell = new TableHeaderCell();
            weeklyHoursHeaderCell.Text = "Weekly Hours";
            tableHearderRow.Cells.Add(weeklyHoursHeaderCell);

            return tableHearderRow;
        }

        protected TableRow CreateTableDetails(Course course)
        {
            TableRow courseDetailsRow = new TableRow();

            TableCell codeCell = new TableCell();
            codeCell.Text = course.Code;
            courseDetailsRow.Cells.Add(codeCell);

            TableCell titleCell = new TableCell();
            titleCell.Text = course.Title;
            courseDetailsRow.Cells.Add(titleCell);

            TableCell hoursCell = new TableCell();
            hoursCell.Text = course.WeeklyHours.ToString();
            courseDetailsRow.Cells.Add(hoursCell);

            return courseDetailsRow;
        }

        protected TableRow TotalHours(int Hours)
        {

            TableRow totalHoursRow = new TableRow();

            TableCell emptyCell = new TableCell();
            totalHoursRow.Cells.Add(emptyCell);

            TableCell totalCell = new TableCell();
            totalCell.Text = "Total:";
            totalHoursRow.Cells.Add(totalCell);

            TableCell hoursCell = new TableCell();
            hoursCell.Text = Hours.ToString();
            totalHoursRow.Cells.Add(hoursCell);

            return totalHoursRow;

        }
    }
}