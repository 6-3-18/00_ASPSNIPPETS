Imports System.IO
Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration

Partial Class VB
    Inherits System.Web.UI.Page
    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Me.BindGrid()
        End If
    End Sub
    Private Sub BindGrid()
        Dim constr As String = ConfigurationManager.ConnectionStrings("constr").ConnectionString
        Using con As New SqlConnection(constr)
            Using cmd As New SqlCommand()
                cmd.CommandText = "SELECT Id, Name FROM tblFiles"
                cmd.Connection = con
                con.Open()
                GridView1.DataSource = cmd.ExecuteReader()
                GridView1.DataBind()
                con.Close()
            End Using
        End Using
    End Sub
    Protected Sub Upload(sender As Object, e As EventArgs)
        For Each postedFile As HttpPostedFile In FileUpload1.PostedFiles
            Dim filename As String = Path.GetFileName(postedFile.FileName)
            Dim contentType As String = postedFile.ContentType
            Using fs As Stream = postedFile.InputStream
                Using br As New BinaryReader(fs)
                    Dim bytes As Byte() = br.ReadBytes(Convert.ToInt32(fs.Length))
                    Dim constr As String = ConfigurationManager.ConnectionStrings("constr").ConnectionString
                    Using con As New SqlConnection(constr)
                        Dim query As String = "insert into tblFiles values (@Name, @ContentType, @Data)"
                        Using cmd As New SqlCommand(query)
                            cmd.Connection = con
                            cmd.Parameters.AddWithValue("@Name", filename)
                            cmd.Parameters.AddWithValue("@ContentType", contentType)
                            cmd.Parameters.AddWithValue("@Data", bytes)
                            con.Open()
                            cmd.ExecuteNonQuery()
                            con.Close()
                        End Using
                    End Using
                End Using
            End Using
        Next
        Response.Redirect(Request.Url.AbsoluteUri)
    End Sub

End Class
