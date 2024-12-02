Public Class Book
    Public Property Title As String
    Public Property Description As String
    Public Property CoverImage As Image ' Property to store book cover image
    Public Property Chapters As New List(Of Chapter) ' List of chapters

    ' Method to add a chapter to the book
    Public Sub AddChapter(chapterTitle As String, chapterContent As String)
        Dim newChapter As New Chapter With {
            .Title = chapterTitle,
            .Content = chapterContent
        }
        Chapters.Add(newChapter)
    End Sub
End Class

' Class to represent a Chapter
Public Class Chapter
    Public Property Title As String
    Public Property Content As String
End Class
