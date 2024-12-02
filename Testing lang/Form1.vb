Public Class Form1
    ' List to store books
    Dim books As New List(Of Book)

    ' Button click event to add a book
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        ' Check if the title and description fields are not empty
        If String.IsNullOrEmpty(TextBox1.Text) Or String.IsNullOrEmpty(TextBox2.Text) Then
            MessageBox.Show("Please fill in all fields.")
            Return
        End If

        ' Create a new Book object
        Dim newBook As New Book With {
            .Title = TextBox1.Text, ' Book title from TextBox1
            .Description = TextBox2.Text, ' Book description from TextBox2
            .CoverImage = PictureBox1.Image ' Store the image directly from PictureBox1
        }

        ' Add the book to the list
        books.Add(newBook)

        ' Optionally clear the input fields
        TextBox1.Clear()
        TextBox2.Clear()
        PictureBox1.Image = Nothing ' Clear the preview image

        ' Open Form2 and pass the list of books
        Dim form2 As New Form2(books)
        form2.Show()
    End Sub

    ' Button click event to open a file dialog and select an image
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        ' Open the file dialog to choose an image
        Dim openFileDialog As New OpenFileDialog()
        openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.bmp"

        ' If the user selects a file and clicks OK
        If openFileDialog.ShowDialog() = DialogResult.OK Then
            ' Display the image in PictureBox1
            PictureBox1.Image = Image.FromFile(openFileDialog.FileName)
            PictureBox1.SizeMode = PictureBoxSizeMode.StretchImage ' Adjust the image size
        End If
    End Sub

    ' Button click event to add a chapter
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        ' Check if the chapter title and content are not empty
        If String.IsNullOrEmpty(TextBox3.Text) Or String.IsNullOrEmpty(RichTextBox1.Text) Then
            MessageBox.Show("Please fill in both chapter title and content.")
            Return
        End If

        ' Assuming the selected book is the last book in the list (you can modify this based on your selection logic)
        Dim selectedBook As Book = books.Last()

        ' Add the chapter to the selected book
        selectedBook.AddChapter(TextBox3.Text, RichTextBox1.Text)

        ' Optionally clear the chapter fields
        TextBox3.Clear()
        RichTextBox1.Clear()
    End Sub
End Class
