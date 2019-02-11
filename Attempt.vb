Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration
Imports DBAccessSubsystem
Imports BaseSubsystem

Public Class Attempt
    Inherits BaseClass
    Dim fldAttemptID, fldTaskID As Integer
    Dim fldAttempt, fldOutcome As String
    Dim fldAttemptCompletedOn As DateTime
    Dim fldSucceeded As Boolean
    Dim AccDB As AccessDB

    Sub New()
        fldAttemptID = 0
        fldTaskID = 0
        fldAttempt = ""
        fldOutcome = ""
        fldSucceeded = False
        fldAttemptCompletedOn = DateTime.Parse("January 1, 1753")
        CreateObjects()
    End Sub

    Sub New(ByVal environment As String)
        fldAttemptID = 0
        fldTaskID = 0
        fldAttempt = ""
        fldOutcome = ""
        fldSucceeded = False
        fldAttemptCompletedOn = DateTime.Parse("January 1, 1753")
        Me.Environment = environment
        CreateObjects()
    End Sub

    Sub New(ByVal AID As Integer, ByVal TID As Integer, ByVal A As String, _
            ByVal O As String, ByVal S As Boolean, ByVal CO As DateTime)
        fldAttemptID = AID
        fldTaskID = TID
        fldAttempt = A
        fldOutcome = O
        fldSucceeded = S
        fldAttemptCompletedOn = CO
        CreateObjects()
    End Sub

    Sub New(ByVal AID As Integer, ByVal TID As Integer, ByVal A As String, _
            ByVal O As String, ByVal S As Boolean, ByVal CO As DateTime, _
            ByVal environment As String)
        fldAttemptID = AID
        fldTaskID = TID
        fldAttempt = A
        fldOutcome = O
        fldSucceeded = S
        fldAttemptCompletedOn = CO
        Me.Environment = environment
        CreateObjects()
    End Sub

    Sub CreateObjects()
        Me.AccDB = New AccessDB
        Me.AccDB.Environment = Me.Environment
    End Sub

    Public Property AttemptID() As Integer
        Get
            Return fldAttemptID
        End Get
        Set(ByVal Value As Integer)
            fldAttemptID = Value
        End Set
    End Property

    Public Property TaskID() As Integer
        Get
            Return fldTaskID
        End Get
        Set(ByVal Value As Integer)
            fldTaskID = Value
        End Set
    End Property

    Public Property Attempt() As String
        Get
            Return fldAttempt
        End Get
        Set(ByVal Value As String)
            fldAttempt = Value
        End Set
    End Property

    Public Property Outcome() As String
        Get
            Return fldOutcome
        End Get
        Set(ByVal Value As String)
            fldOutcome = Value
        End Set
    End Property

    Public Property AttemptCompletedOn() As DateTime
        Get
            Return fldAttemptCompletedOn
        End Get
        Set(ByVal Value As DateTime)
            fldAttemptCompletedOn = Value
        End Set
    End Property

    Public Property AttemptSucceeded() As Boolean
        Get
            Return fldSucceeded
        End Get
        Set(ByVal Value As Boolean)
            fldSucceeded = Value
        End Set
    End Property

    Sub AssignFlds(ByRef AccDB As AccessDB, ByVal recd As Integer)
        If (AccDB.Succeeded) Then
            Me.AttemptID = Integer.Parse(AccDB.Records(recd, 0))
            Me.TaskID = Integer.Parse(AccDB.Records(recd, 1))
            Me.AttemptCompletedOn = DateTime.Parse(AccDB.Records(recd, 2))
            Me.AttemptSucceeded = Boolean.Parse(AccDB.Records(recd, 3))
            Me.Attempt = AccDB.Records(recd, 4)
            Me.Outcome = AccDB.Records(recd, 5)
        Else
            Me.AccumulateErrors(AccDB.ErrorMsgs, AccDB.NoOfErrorMsgs)
        End If
    End Sub

    Sub AssignFld(ByRef AccDB As AccessDB, ByVal recd As Integer, _
            ByVal FldName As String)
        If (AccDB.Succeeded) Then
            Select Case FldName
                Case "AttemptID"
                    Me.AttemptID = Integer.Parse(AccDB.Records(recd, 0))
                Case "TaskID"
                    Me.TaskID = Integer.Parse(AccDB.Records(recd, 1))
                Case "CompletedOn"
                    Me.AttemptCompletedOn = DateTime.Parse(AccDB.Records(recd, 2))
                Case "Succeeded"
                    Me.AttemptSucceeded = Boolean.Parse(AccDB.Records(recd, 3))
                Case "Attempt"
                    Me.Attempt = AccDB.Records(recd, 4)
                Case "Outcome"
                    Me.Outcome = AccDB.Records(recd, 5)
            End Select
        Else
            Me.AccumulateErrors(AccDB.ErrorMsgs, AccDB.NoOfErrorMsgs)
        End If
    End Sub

    Sub Check()
        Try
            DateTime.Parse(Me.AttemptCompletedOn)
        Catch
            Me.AccumulateErrors(Me.AccDB.ErrorMsgs, _
              Me.AccDB.NoOfErrorMsgs, Err.Description)
        End Try
    End Sub

    Public Sub Copy(ByRef Attempt As Attempt)
        Me.AttemptID = Attempt.AttemptID
        Me.TaskID = Attempt.TaskID
        Me.AttemptCompletedOn = "January 1, 1753"
        Me.AttemptSucceeded = False
        Me.Attempt = Attempt.Attempt
        Me.Outcome = Attempt.Outcome
    End Sub

    Sub GetAttempt(ByVal AttemptID As Integer)
        Me.AccDB.SelectWithKey(AttemptID, "AttemptID", "Attempts")
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

            Me.AccDB.Command.CommandText = "INSERT INTO Attempts(" & _
                "TaskID, CompletedOn, Succeeded, Attempt, Outcome) " & _
                "VALUES (" & _
                "@TaskID, @CompletedOn, @Succeeded, @Attempt, @Outcome)"
            Me.AccDB.Command.Parameters.Clear()
            Me.AccDB.Command.Parameters.Add("@TaskID", SqlDbType.Int)
            Me.AccDB.Command.Parameters.Add("@CompletedOn", SqlDbType.DateTime)
            Me.AccDB.Command.Parameters.Add("@Succeeded", SqlDbType.Bit)
            Me.AccDB.Command.Parameters.Add("@Attempt", SqlDbType.Text)
            Me.AccDB.Command.Parameters.Add("@Outcome", SqlDbType.Text)
            Me.AccDB.Command.Parameters("@TaskID").Value = fldTaskID
            Me.AccDB.Command.Parameters("@CompletedOn").Value = fldAttemptCompletedOn
            Me.AccDB.Command.Parameters("@Succeeded").Value = fldSucceeded
            Me.AccDB.Command.Parameters("@Attempt").Value = fldAttempt
            Me.AccDB.Command.Parameters("@Outcome").Value = fldOutcome
            Me.AccDB.ExecNonQuery()
        Catch
            Me.AccumulateErrors(Me.AccDB.ErrorMsgs, _
              Me.AccDB.NoOfErrorMsgs, Err.Description)
        End Try
    End Sub
End Class

