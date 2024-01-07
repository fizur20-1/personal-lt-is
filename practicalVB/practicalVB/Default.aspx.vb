Imports System.Data.SqlClient

Public Class _Default
    Inherits Page



    Dim connect As New SqlConnection("Data Source=DESKTOP-B8UM566\MSSQLSERVER2022;Initial Catalog=Candidate_Practical_1;Integrated Security=True")

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        If Not IsPostBack Then

            ListEmployee()
        End If

    End Sub

    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim FirstName As String = TextBox1.Text
        Dim LastName As String = TextBox2.Text
        Dim BirthDate As DateTime = DateTime.Parse(TextBox4.Text) ' Parse to DateTime
        Dim JoinDate As DateTime = DateTime.Parse(TextBox5.Text) ' Parse to DateTime
        Dim Designation As String = TextBox3.Text

        connect.Open()

        Dim command As New SqlCommand("Insert_Employee", connect)
        command.CommandType = CommandType.StoredProcedure
        Dim Unique_Id As Integer = HiddenField1.Value
        ' Add parameters
        command.Parameters.AddWithValue("@employee_id", Unique_Id)
        command.Parameters.AddWithValue("@first_name", FirstName)
        command.Parameters.AddWithValue("@last_name", LastName)
        command.Parameters.AddWithValue("@birth_date", BirthDate)
        command.Parameters.AddWithValue("@join_date", JoinDate)
        command.Parameters.AddWithValue("@designation", Designation)

        command.ExecuteNonQuery()
        MsgBox("Inserted", MsgBoxStyle.Information, "Message")
        connect.Close()
        ListEmployee()
    End Sub


    Protected Sub GridView1_RowCommand(ByVal sender As Object, ByVal e As GridViewCommandEventArgs) Handles GridView1.RowCommand

        If e.CommandName = "UpdateRow" Then
            ' Retrieve data and populate TextBox controls for editing

            Dim rowIndex As Integer = Convert.ToInt32(e.CommandArgument)
            EditEmployee(rowIndex)


            ' Refresh the GridView after saving changes



        ElseIf e.CommandName = "DeleteRow" Then
            ' Delete employee
            Dim rowIndex As Integer = Convert.ToInt32(e.CommandArgument)
            DeleteEmployee(rowIndex)
            ListEmployee() ' Refresh the GridView after deletion
        End If


    End Sub
    Dim j As Integer = 0
    Private Sub EditEmployee(ByVal uniqueId As Integer)

        Dim rowIndex As Integer = -1

        For i As Integer = 0 To GridView1.Rows.Count - 1
            If Convert.ToInt32(GridView1.DataKeys(i)("UniqueId")) = uniqueId Then
                rowIndex = i
                Exit For
            End If
        Next

        If rowIndex <> -1 Then
            ' Retrieve data and populate TextBox controls for editing

            TextBox1.Text = GridView1.Rows(rowIndex).Cells(1).Text
            TextBox2.Text = GridView1.Rows(rowIndex).Cells(2).Text
            TextBox4.Text = GridView1.Rows(rowIndex).Cells(3).Text ' assuming BirthDate is in the 3rd column
            TextBox5.Text = GridView1.Rows(rowIndex).Cells(4).Text ' assuming JoinDate is in the 4th column
            TextBox3.Text = GridView1.Rows(rowIndex).Cells(5).Text ' assuming Designation is in the 5th column
            j = uniqueId


            Dim btnUpdate As Button = TryCast(GridView1.Rows(rowIndex).FindControl("btnUpdate"), Button)

            btnSave.Visible = True


            btnUpdate.Visible = False


        End If
    End Sub
    'Private Sub SaveEmployee()
    '    ' Retrieve updated values from TextBox controls
    '    Dim updatedFirstName As String = TextBox1.Text
    '    Dim updatedLastName As String = TextBox2.Text
    '    Dim updatedBirthDate As DateTime = DateTime.Parse(TextBox4.Text)
    '    Dim updatedJoinDate As DateTime = DateTime.Parse(TextBox5.Text)
    '    Dim updatedDesignation As String = TextBox3.Text

    '    ' Get the index of the selected row
    '    Dim rowIndex As Integer = j

    '    ' Call the stored procedure to update the employee
    '    connect.Open()
    '    Dim updateCommand As New SqlCommand("Insert_Employee", connect)
    '    updateCommand.CommandType = CommandType.StoredProcedure
    '    Dim Unique_Id As String = HiddenField1.Value
    '    updateCommand.Parameters.AddWithValue("@employee_id", Unique_Id)
    '    updateCommand.Parameters.AddWithValue("@first_name", updatedFirstName)
    '    updateCommand.Parameters.AddWithValue("@last_name", updatedLastName)
    '    updateCommand.Parameters.AddWithValue("@birth_date", updatedBirthDate)
    '    updateCommand.Parameters.AddWithValue("@join_date", updatedJoinDate)
    '    updateCommand.Parameters.AddWithValue("@designation", updatedDesignation)

    '    updateCommand.ExecuteNonQuery()
    '    connect.Close()



    'End Sub



    Private Sub DeleteEmployee(ByVal uniqueId As Integer)

        Dim deleteCommand As New SqlCommand("DELETE FROM Employee WHERE UniqueId = @UniqueId", connect)
        deleteCommand.Parameters.AddWithValue("@UniqueId", uniqueId)
        Try
            connect.Open()
            deleteCommand.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox("Error deleting employee: " & ex.Message, MsgBoxStyle.Exclamation, "Error")
        Finally
            connect.Close()
        End Try
    End Sub


    Private Sub ListEmployee()
        Dim adapter As New SqlDataAdapter("SELECT * FROM Employee_View", connect)
        Dim dt As New DataTable()
        adapter.Fill(dt)
        GridView1.DataSource = dt

        GridView1.DataBind()
    End Sub

    Protected Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Dim updatedFirstName As String = TextBox1.Text
        Dim updatedLastName As String = TextBox2.Text
        Dim updatedBirthDate As DateTime = DateTime.Parse(TextBox4.Text)
        Dim updatedJoinDate As DateTime = DateTime.Parse(TextBox5.Text)
        Dim updatedDesignation As String = TextBox3.Text

        ' Get the index of the selected row


        ' Call the stored procedure to update the employee
        connect.Open()
        Dim updateCommand As New SqlCommand("Insert_Employee", connect)
        updateCommand.CommandType = CommandType.StoredProcedure
        ' Dim Unique_Id As Integer = HiddenField1.Value
        updateCommand.Parameters.AddWithValue("@employee_id", 6)
        updateCommand.Parameters.AddWithValue("@first_name", updatedFirstName)
        updateCommand.Parameters.AddWithValue("@last_name", updatedLastName)
        updateCommand.Parameters.AddWithValue("@birth_date", updatedBirthDate)
        updateCommand.Parameters.AddWithValue("@join_date", updatedJoinDate)
        updateCommand.Parameters.AddWithValue("@designation", updatedDesignation)

        updateCommand.ExecuteNonQuery()
        connect.Close()
        btnSave.Visible = False
        ListEmployee()

    End Sub
End Class
