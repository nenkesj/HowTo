Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration
Imports DBAccessSubsystem
Imports BaseSubsystem

Public Class Task
    Inherits BaseClass

    Dim fldTaskID, fldNodeID, fldRequestNo As Integer
    Dim fldLpar, fldRequestSystem, fldClient As String
    Dim fldStartedOn, fldCompletedOn As DateTime
    Dim AccDB As AccessDB

    Sub New()
        fldTaskID = 0
        fldNodeID = 0
        fldRequestNo = 0
        fldLpar = ""
        fldRequestSystem = ""
        fldClient = ""
        fldStartedOn = DateTime.Now
        fldCompletedOn = DateTime.Parse("January 1, 1753")
        CreateObjects()
    End Sub

    Sub New(ByVal environment As String)
        fldTaskID = 0
        fldNodeID = 0
        fldRequestNo = 0
        fldLpar = ""
        fldRequestSystem = ""
        fldClient = ""
        fldStartedOn = DateTime.Now
        fldCompletedOn = DateTime.Parse("January 1, 1753")
        Me.Environment = environment
        CreateObjects()
    End Sub

    Sub New(ByVal TID As Integer, ByVal NID As Integer, _
            ByVal RS As String, ByVal RN As Integer, ByVal L As String, _
            ByVal C As String, ByVal SO As DateTime, ByVal CO As DateTime)
        fldTaskID = TID
        fldNodeID = NID
        fldRequestNo = RN
        fldLpar = L
        fldRequestSystem = RS
        fldClient = C
        fldStartedOn = SO
        fldCompletedOn = CO
        CreateObjects()
    End Sub

    Sub New(ByVal TID As Integer, ByVal NID As Integer, _
            ByVal RS As String, ByVal RN As Integer, ByVal L As String, _
            ByVal C As String, ByVal SO As DateTime, ByVal CO As DateTime, _
            ByVal environment As String)
        fldTaskID = TID
        fldNodeID = NID
        fldRequestNo = RN
        fldLpar = L
        fldRequestSystem = RS
        fldClient = C
        fldStartedOn = SO
        fldCompletedOn = CO
        Me.Environment = Environment
        CreateObjects()
    End Sub

    Sub CreateObjects()
        Me.AccDB = New AccessDB
        Me.AccDB.Environment = Me.Environment
    End Sub

    Public Property TaskID() As Integer
        Get
            Return fldTaskID
        End Get
        Set(ByVal Value As Integer)
            fldTaskID = Value
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

    Public Property RequestNo() As Integer
        Get
            Return fldRequestNo
        End Get
        Set(ByVal Value As Integer)
            fldRequestNo = Value
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

    Public Property RequestSystem() As String
        Get
            Return fldRequestSystem
        End Get
        Set(ByVal Value As String)
            fldRequestSystem = Value
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

    Public Property StartedOn() As DateTime
        Get
            Return fldStartedOn
        End Get
        Set(ByVal Value As DateTime)
            fldStartedOn = Value
        End Set
    End Property

    Public Property CompletedOn() As DateTime
        Get
            Return fldCompletedOn
        End Get
        Set(ByVal Value As DateTime)
            fldCompletedOn = Value
        End Set
    End Property

    Sub AssignFlds(ByRef AccDB As AccessDB, ByVal recd As Integer)
        If (AccDB.Succeeded) Then
            Me.TaskID = Integer.Parse(AccDB.Records(recd, 0))
            Me.NodeID = Integer.Parse(AccDB.Records(recd, 1))
            Me.RequestSystem = AccDB.Records(recd, 2)
            Me.RequestNo = Integer.Parse(AccDB.Records(recd, 3))
            Me.StartedOn = DateTime.Parse(AccDB.Records(recd, 4))
            Me.CompletedOn = DateTime.Parse(AccDB.Records(recd, 5))
            Me.Lpar = AccDB.Records(recd, 6)
            Me.Client = AccDB.Records(recd, 7)
        Else
            Me.AccumulateErrors(AccDB.ErrorMsgs, AccDB.NoOfErrorMsgs)
        End If
    End Sub

    Sub AssignFld(ByRef AccDB As AccessDB, ByVal recd As Integer, _
            ByVal FldName As String)
        If (AccDB.Succeeded) Then
            Select Case FldName
                Case "TaskID"
                    Me.NodeID = Integer.Parse(AccDB.Records(recd, 0))
                Case "NodeID"
                    Me.NodeID = Integer.Parse(AccDB.Records(recd, 1))
                Case "RequestSystem"
                    Me.RequestSystem = AccDB.Records(recd, 2)
                Case "RequestNo"
                    Me.RequestNo = Integer.Parse(AccDB.Records(recd, 3))
                Case "StartedOn"
                    Me.StartedOn = DateTime.Parse(AccDB.Records(recd, 4))
                Case "CompletedOn"
                    Me.CompletedOn = DateTime.Parse(AccDB.Records(recd, 5))
                Case "Lpar"
                    Me.Lpar = AccDB.Records(recd, 6)
                Case "Client"
                    Me.Client = AccDB.Records(recd, 7)
            End Select
        Else
            Me.AccumulateErrors(AccDB.ErrorMsgs, AccDB.NoOfErrorMsgs)
        End If
    End Sub

    Sub Check()
        Try
            DateTime.Parse(Me.StartedOn)
            DateTime.Parse(Me.CompletedOn)
        Catch
            Me.AccumulateErrors(Me.AccDB.ErrorMsgs, _
              Me.AccDB.NoOfErrorMsgs, Err.Description)
        End Try
    End Sub

    Public Sub Copy(ByRef Task As Task)
        Me.TaskID = Task.TaskID
        Me.NodeID = Task.NodeID
        Me.RequestSystem = Task.RequestSystem
        Me.RequestNo = Task.RequestNo
        Me.StartedOn = DateTime.Now
        Me.CompletedOn = "January 1, 1753"
        Me.Lpar = Task.Lpar
        Me.Client = Task.Client
    End Sub

    Sub GetTask(ByVal TaskID As Integer)
        Me.AccDB.SelectWithKey(TaskID, "TaskID", "Tasks")
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

            Me.AccDB.Command.CommandText = "INSERT INTO Tasks(" & _
                "NodeID, RequestSystem, RequestNo, StartedOn, Lpar, " & _
                "Client, CompletedOn) " & _
                "VALUES (" & _
                "@NodeID, @RequestSystem, @RequestNo, @StartedOn, " & _
                "@Lpar, @Client, @CompletedOn)"
            Me.AccDB.Command.Parameters.Clear()
            Me.AccDB.Command.Parameters.Add("@NodeID", SqlDbType.Int)
            Me.AccDB.Command.Parameters.Add("@RequestSystem", SqlDbType.VarChar)
            Me.AccDB.Command.Parameters.Add("@RequestNo", SqlDbType.Int)
            Me.AccDB.Command.Parameters.Add("@StartedOn", SqlDbType.DateTime)
            Me.AccDB.Command.Parameters.Add("@Lpar", SqlDbType.VarChar)
            Me.AccDB.Command.Parameters.Add("@Client", SqlDbType.VarChar)
            Me.AccDB.Command.Parameters.Add("@CompletedOn", SqlDbType.DateTime)
            Me.AccDB.Command.Parameters("@NodeID").Value = fldNodeID
            Me.AccDB.Command.Parameters("@RequestSystem").Value = fldRequestSystem
            Me.AccDB.Command.Parameters("@RequestNo").Value = fldRequestNo
            Me.AccDB.Command.Parameters("@StartedOn").Value = fldStartedOn
            Me.AccDB.Command.Parameters("@Lpar").Value = fldLpar
            Me.AccDB.Command.Parameters("@Client").Value = fldClient
            Me.AccDB.Command.Parameters("@CompletedOn").Value = fldCompletedOn
            Me.AccDB.ExecNonQuery()
        Catch
            Me.AccumulateErrors(Me.AccDB.ErrorMsgs, _
              Me.AccDB.NoOfErrorMsgs, Err.Description)
        End Try
    End Sub
End Class


