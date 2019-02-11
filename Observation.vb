Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration
Imports DBAccessSubsystem
Imports BaseSubsystem

Public Class Observation
    Inherits BaseClass

    Dim fldObservationID, fldProblemID As Integer
    Dim fldObservation, fldComment As String
    Dim AccDB As AccessDB

    Sub New()
        fldObservationID = 0
        fldProblemID = 0
        fldObservation = ""
        fldComment = ""
        CreateObjects()
    End Sub

    Sub New(ByVal environment As String)
        fldObservationID = 0
        fldProblemID = 0
        fldObservation = ""
        fldComment = ""
        Me.Environment = environment
        CreateObjects()
    End Sub

    Sub New(ByVal OID As Integer, ByVal PID As Integer, _
            ByVal O As String, ByVal C As String)
        fldObservationID = OID
        fldProblemID = PID
        fldObservation = O
        fldComment = C
        CreateObjects()
    End Sub

    Sub New(ByVal OID As Integer, ByVal PID As Integer, _
           ByVal O As String, ByVal C As String, _
           ByVal environment As String)
        fldObservationID = OID
        fldProblemID = PID
        fldObservation = O
        fldComment = C
        Me.Environment = environment
        CreateObjects()
    End Sub

    Sub CreateObjects()
        Me.AccDB = New AccessDB
        Me.AccDB.Environment = Me.Environment
    End Sub

    Public Property ObservationID() As Integer
        Get
            Return fldObservationID
        End Get
        Set(ByVal Value As Integer)
            fldObservationID = Value
        End Set
    End Property

    Public Property ProblemID() As Integer
        Get
            Return fldProblemID
        End Get
        Set(ByVal Value As Integer)
            fldProblemID = Value
        End Set
    End Property

    Public Property Observation() As String
        Get
            Return fldObservationID
        End Get
        Set(ByVal Value As String)
            fldObservationID = Value
        End Set
    End Property

    Public Property Comment() As String
        Get
            Return fldComment
        End Get
        Set(ByVal Value As String)
            fldComment = Value
        End Set
    End Property

    Sub AssignFlds(ByRef AccDB As AccessDB, ByVal recd As Integer)
        If (AccDB.Succeeded) Then
            Me.ObservationID = Integer.Parse(AccDB.Records(recd, 0))
            Me.ProblemID = Integer.Parse(AccDB.Records(recd, 1))
            Me.Observation = AccDB.Records(recd, 2)
            Me.Comment = DateTime.Parse(AccDB.Records(recd, 3))
        Else
            Me.AccumulateErrors(AccDB.ErrorMsgs, AccDB.NoOfErrorMsgs)
        End If
    End Sub

    Sub AssignFld(ByRef AccDB As AccessDB, ByVal recd As Integer, _
            ByVal FldName As String)
        If (AccDB.Succeeded) Then
            Select Case FldName
                Case "ObservationID"
                    Me.ObservationID = Integer.Parse(AccDB.Records(recd, 0))
                Case "ProblemID"
                    Me.ProblemID = Integer.Parse(AccDB.Records(recd, 1))
                Case "Observation"
                    Me.Observation = AccDB.Records(recd, 2)
                Case "Comment"
                    Me.Comment = DateTime.Parse(AccDB.Records(recd, 3))
            End Select
        Else
            Me.AccumulateErrors(AccDB.ErrorMsgs, AccDB.NoOfErrorMsgs)
        End If
    End Sub

    Sub Check()
        Try
        Catch
            Me.AccumulateErrors(Me.AccDB.ErrorMsgs, _
              Me.AccDB.NoOfErrorMsgs, Err.Description)
        End Try
    End Sub

    Public Sub Copy(ByRef Observation As Observation)
        Me.ObservationID = Observation.ObservationID
        Me.ProblemID = Observation.ProblemID
        Me.Observation = Observation.Observation
        Me.Comment = Observation.Comment
    End Sub

    Sub GetObservation(ByVal ObservationID As Integer)
        Me.AccDB.SelectWithKey(ObservationID, "ObservationID", "Observations")
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

            Me.AccDB.Command.CommandText = "INSERT INTO Observations (" & _
                "ProblemID, Observation, Comment) " & _
                "VALUES (" & _
                "@ProblemID, @Observation, @Comment)"
            Me.AccDB.Command.Parameters.Clear()
            Me.AccDB.Command.Parameters.Add("@ProblemID", SqlDbType.Int)
            Me.AccDB.Command.Parameters.Add("@Observation", SqlDbType.Text)
            Me.AccDB.Command.Parameters.Add("@Comment", SqlDbType.Text)
            Me.AccDB.Command.Parameters("@ProblemID").Value = fldProblemID
            Me.AccDB.Command.Parameters("@Observation").Value = fldObservation
            Me.AccDB.Command.Parameters("@Comment").Value = fldComment
            Me.AccDB.ExecNonQuery()
        Catch
            Me.AccumulateErrors(Me.AccDB.ErrorMsgs, _
              Me.AccDB.NoOfErrorMsgs, Err.Description)
        End Try
    End Sub
End Class


