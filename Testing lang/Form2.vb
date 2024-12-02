Imports System.Windows.Forms.VisualStyles.VisualStyleElement

Public Class Form2
    Private books As List(Of Book)

    ' Constructor to receive the list of books
    Public Sub New(books As List(Of Book))
        InitializeComponent()
        Me.books = books
        LoadBooks()
    End Sub

    ' Method to load books and display them as PictureBoxes
    Private Sub LoadBooks()
        ' Clear any existing PictureBoxes
        FlowLayoutPanel1.Controls.Clear()

        ' Loop through the books and add PictureBoxes to the FlowLayoutPanel
        For Each book In books
            Dim picBox As New PictureBox()
            picBox.Size = New Size(100, 150) ' Adjust size as needed
            picBox.Image = book.CoverImage ' Use the book's cover image
            picBox.SizeMode = PictureBoxSizeMode.StretchImage
            picBox.Tag = book ' Store the book object in the Tag property

            ' Add a click event to show the book description
            AddHandler picBox.Click, AddressOf Book_Click

            FlowLayoutPanel1.Controls.Add(picBox)
        Next
    End Sub

    ' Display book description when a PictureBox is clicked
    Private Sub Book_Click(sender As Object, e As EventArgs)
        Dim picBox As PictureBox = CType(sender, PictureBox)
        Dim book As Book = CType(picBox.Tag, Book) ' Get the book object from the Tag property

        ' Display book description in a Label (or any other control)
        Label1.Text = "Description: " & book.Description

        ' Optionally display chapters for the book
        ShowChapters(book)
    End Sub

    ' Method to display chapters of the clicked book
    Private Sub ShowChapters(book As Book)
        ' Clear existing chapter list
        ListBox1.Items.Clear()

        ' Add each chapter title to the ListBox
        For Each chapter As Chapter In book.Chapters
            ListBox1.Items.Add(chapter.Title)
        Next
    End Sub

    ' Event handler for when a chapter is selected from the ListBox
    Private Sub ListBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListBox1.SelectedIndexChanged
        If ListBox1.SelectedIndex >= 0 Then
            Dim selectedChapter As Chapter = books(0).Chapters(ListBox1.SelectedIndex) ' Assuming you're showing the chapters for the first book
            RichTextBox1.Text = selectedChapter.Content ' Show the chapter content in a RichTextBox (or another control)
        End If
    End Sub
End Class
