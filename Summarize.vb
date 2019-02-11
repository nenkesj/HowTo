Public Class SummarizeSentence
    Dim inc As Boolean
    Dim para As Integer
    Dim sentNo As Integer
    Dim sent As String
    Public Property Include() As Boolean
        Get
            Return inc
        End Get
        Set(ByVal Value As Boolean)
            inc = Value
        End Set
    End Property
    Public Property Paragraph() As Integer
        Get
            Return para
        End Get
        Set(ByVal Value As Integer)
            para = Value
        End Set
    End Property
    Public Property SentenceNo() As Integer
        Get
            Return sentNo
        End Get
        Set(ByVal Value As Integer)
            sentNo = Value
        End Set
    End Property
    Public Property Sentence() As String
        Get
            Return sent
        End Get
        Set(ByVal Value As String)
            sent = Value
        End Set
    End Property
End Class

