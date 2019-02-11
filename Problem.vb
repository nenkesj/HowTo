Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration
Imports DBAccessSubsystem
Imports BaseSubsystem

Public Class Problem
    Inherits BaseClass

    Dim fldProblemID, fldNodeID, fldProblemNo As Integer
    Dim fldTitle, fldImpacts, fldDetails, fldProblemSystem, fldClient, _
        fldLpar As String
    Dim fldOccurred As DateTime
    Dim AccDB As AccessDB

    Sub New()
        fldProblemID = 0
        fldNodeID = 0
        fldTitle = ""
        fldOccurred = DateTime.Now
        fldImpacts = ""
        fldDetails = ""
        fldProblemSystem = ""
        fldProblemNo = 0
        fldClient = ""
        fldLpar = ""
        CreateObjects()
    End Sub

    Sub New(ByVal environment As String)
        fldProblemID = 0
        fldNodeID = 0
        fldTitle = ""
        fldOccurred = DateTime.Now
        fldImpacts = ""
        fldDetails = ""
        fldProblemSystem = ""
        fldProblemNo = 0
        fldClient = ""
        fldLpar = ""
        Me.Environment = environment
        CreateObjects()
    End Sub

    Sub New(ByVal PID As Integer, ByVal NID As Integer, _
            ByVal T As String, ByVal O As DateTime, ByVal I As String, _
            ByVal D As String, ByVal PS As String, ByVal PN As Integer, _
            ByVal C As String, ByVal L As String)
        fldProblemID = PID
        fldNodeID = NID
        fldTitle = T
        fldOccurred = O
        fldImpacts = I
        fldDetails = D
        fldProblemSystem = PS
        fldProblemNo = PN
        fldClient = C
        fldLpar = L
        CreateObjects()
    End Sub

    Sub New(ByVal PID As Integer, ByVal NID As Integer, _
            ByVal T As String, ByVal O As DateTime, ByVal I As String, _
            ByVal D As String, ByVal PS As String, ByVal PN As Integer, _
            ByVal C As String, ByVal L As String, _
            ByVal environment As String)
        fldProblemID = PID
        fldNodeID = NID
        fldTitle = T
        fldOccurred = O
        fldImpacts = I
        fldDetails = D
        fldProblemSystem = PS
        fldProblemNo = PN
        fldClient = C
        fldLpar = L
        Me.Environment = environment
        CreateObjects()
    End Sub

    Sub CreateObjects()
        Me.AccDB = New AccessDB
        Me.AccDB.Environment = Me.Environment
    End Sub

    Public Property ProblemID() As Integer
        Get
            Return fldProblemID
        End Get
        Set(ByVal Value As Integer)
            fldProblemID = Value
        End Set
    End Property

    Public Property NodeID() As Integer
        Get
            Return fldNodeID
        End Get
        Set(ByVal Value As Integer)
            fldNodeID = Value
        End Set
    End Property

    Public Property Title() As String
        Get
            Return fldTitle
        End Get
        Set(ByVal Value As String)
            fldTitle = Value
        End Set
    End Property

    Public Property Occurred() As DateTime
        Get
            Return fldOccurred
        End Get
        Set(ByVal Value As DateTime)
            fldOccurred = Value
        End Set
    End Property

    Public Property Impacts() As String
        Get
            Return fldImpacts
        End Get
        Set(ByVal Value As String)
            fldImpacts = Value
        End Set
    End Property

    Public Property Details() As String
        Get
            Return fldDetails
        End Get
        Set(ByVal Value As String)
            fldDetails = Value
        End Set
    End Property

    Public Property ProblemSystem() As String
        Get
            Return fldProblemSystem
        End Get
        Set(ByVal Value As String)
            fldProblemSystem = Value
        End Set
    End Property

    Public Property ProblemNo() As Integer
        Get
            Return fldProblemNo
        End Get
        Set(ByVal Value As Integer)
            fldProblemNo = Value
        End Set
    End Property

    Public Property Client() As String
        Get
            Return fldClient
        End Get
        Set(ByVal Value As String)
            fldClient = Value
        End Set
    End Property

    Public Property Lpar() As String
        Get
            Return fldLpar
        End Get
        Set(ByVal Value As String)
            fldLpar = Value
        End Set
    End Property

    Sub AssignFlds(ByRef AccDB As AccessDB, ByVal recd As Integer)
        If (AccDB.Succeeded) Then
            Me.ProblemID = Integer.Parse(AccDB.Records(recd, 0))
            Me.NodeID = Integer.Parse(AccDB.Records(recd, 1))
            Me.title = AccDB.Records(recd, 2)
            Me.Occurred = DateTime.Parse(AccDB.Records(recd, 3))
            Me.Impacts = AccDB.Records(recd, 4)
            Me.Details = AccDB.Records(recd, 5)
            Me.ProblemSystem = AccDB.Records(recd, 6)
            Me.ProblemNo = Integer.Parse(AccDB.Records(recd, 7))
            Me.Client = AccDB.Records(recd, 8)
            Me.Lpar = AccDB.Records(recd, 9)
        Else
            Me.AccumulateErrors(AccDB.ErrorMsgs, AccDB.NoOfErrorMsgs)
        End If
    End Sub

    Sub AssignFld(ByRef AccDB As AccessDB, ByVal recd As Integer, _
            ByVal FldName As String)
        If (AccDB.Succeeded) Then
            Select Case FldName
                Case "ProblemID"
                    Me.ProblemID = Integer.Parse(AccDB.Records(recd, 0))
                Case "NodeID"
                    Me.NodeID = Integer.Parse(AccDB.Records(recd, 1))
                Case "Title"
                    Me.Title = AccDB.Records(recd, 2)
                Case "Occurred"
                    Me.Occurred = DateTime.Parse(AccDB.Records(recd, 3))
                Case "Impacts"
                    Me.Impacts = AccDB.Records(recd, 4)
                Case "Details"
                    Me.Details = AccDB.Records(recd, 5)
                Case "ProblemSystem"
                    Me.ProblemSystem = AccDB.Records(recd, 6)
                Case "ProblemNo"
                    Me.ProblemNo = Integer.Parse(AccDB.Records(recd, 7))
                Case "Client"
                    Me.Client = AccDB.Records(recd, 8)
                Case "Lpar"
                    Me.Lpar = AccDB.Records(recd, 9)
            End Select
        Else
            Me.AccumulateErrors(AccDB.ErrorMsgs, AccDB.NoOfErrorMsgs)
        End If
    End Sub

    Sub Check()
        Try
            DateTime.Parse(Me.Occurred)
        Catch
            Me.AccumulateErrors(Me.AccDB.ErrorMsgs, _
              Me.AccDB.NoOfErrorMsgs, Err.Description)
        End Try
    End Sub

    Public Sub Copy(ByRef Problem As Problem)
        Me.ProblemID = Problem.ProblemID
        Me.NodeID = Problem.NodeID
        Me.Title = Problem.Title
        Me.Occurred = Problem.Occurred
        Me.Impacts = Problem.Impacts
        Me.Details = Problem.Details
        Me.ProblemSystem = Problem.ProblemSystem
        Me.ProblemNo = Problem.ProblemNo
        Me.Client = Problem.Client
        Me.Lpar = Problem.Lpar
    End Sub

    Sub GetProblem(ByVal ProblemID As Integer)
        Me.AccDB.SelectWithKey(ProblemID, "ProblemID", "Problems")
        AssignFlds(Me.AccDB, 0)
    End Sub


    Public Sub Insert()
        Try
            Check()
            If (Not Me.Succeeded) Then
                Throw New Exception("Task Checks Failed")
            End If

            Me.AccDB.WorkStation = _
            CType(ConfigurationSettings.AppSettings.GetValues("WorkStation")(0), String)

            If (Me.Environment <> "Test") Then
                Me.AccDB.DBName = _
                CType(ConfigurationSettings.AppSettings.GetValues("DBName")(0), String)
            Else
                Me.AccDB.DBName = _
                CType(ConfigurationSettings.AppSettings.GetValues("tstDBName")(0), String)
            End If

            Me.AccDB.Command.CommandText = "INSERT INTO Problems (" & _
                "NodeID, Title, Occurred, Impacts, " & _
                "Details, ProblemSystem, ProblemNo, Client, Lpar) " & _
                "VALUES (" & _
                "@NodeID, @Title, @Occurred, @Impacts, " & _
                "@Details, @ProblemSystem, @ProblemNo, @Client, @Lpar)"
            Me.AccDB.Command.Parameters.Clear()
            Me.AccDB.Command.Parameters.Add("@NodeID", SqlDbType.Int)
            Me.AccDB.Command.Parameters.Add("@Title", SqlDbType.VarChar)
            Me.AccDB.Command.Parameters.Add("@Occurred", SqlDbType.DateTime)
            Me.AccDB.Command.Parameters.Add("@Impacts", SqlDbType.VarChar)
            Me.AccDB.Command.Parameters.Add("@Details", SqlDbType.Text)
            Me.AccDB.Command.Parameters.Add("@ProblemSystem", SqlDbType.VarChar)
            Me.AccDB.Command.Parameters.Add("@ProblemNo", SqlDbType.Int)
            Me.AccDB.Command.Parameters.Add("@Client", SqlDbType.VarChar)
            Me.AccDB.Command.Parameters.Add("@Lpar", SqlDbType.VarChar)
            Me.AccDB.Command.Parameters("@NodeID").Value = fldNodeID
            Me.AccDB.Command.Parameters("@Title").Value = fldTitle
            Me.AccDB.Command.Parameters("@Occurred").Value = fldOccurred
            Me.AccDB.Command.Parameters("@Impacts").Value = fldImpacts
            Me.AccDB.Command.Parameters("@Details").Value = fldDetails
            Me.AccDB.Command.Parameters("@ProblemSystem").Value = fldProblemSystem
            Me.AccDB.Command.Parameters("@ProblemNo").Value = fldProblemNo
            Me.AccDB.Command.Parameters("@Client").Value = fldClient
            Me.AccDB.Command.Parameters("@Lpar").Value = fldLpar
            Me.AccDB.ExecNonQuery()
        Catch
            Me.AccumulateErrors(Me.AccDB.ErrorMsgs, _
              Me.AccDB.NoOfErrorMsgs, Err.Description)
        End Try
    End Sub
End Class


