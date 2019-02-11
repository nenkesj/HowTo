Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration
Imports DBAccessSubsystem
Imports BaseSubsystem

Public Class SearchKey
    Inherits BaseClass
    Dim fldKeyID, fldTreeID, fldNodeID, fldTypeID As Integer
    Dim fldKeyText As String
    Dim AccDB As AccessDB

    Sub New()
        fldKeyID = 0
        fldTreeID = 1
        fldNodeID = 0
        fldTypeID = 7
        fldKeyText = ""
        CreateObjects()
    End Sub

    Sub New(ByVal environment As String)
        fldKeyID = 0
        fldTreeID = 1
        fldNodeID = 0
        fldTypeID = 7
        fldKeyText = ""
        Me.Environment = environment
        CreateObjects()
    End Sub

    Sub New(ByVal KID As Integer, ByVal TID As Integer, _
            ByVal NID As Integer, ByVal TyID As Integer, _
            ByVal KT As String)
        fldKeyID = KID
        fldTreeID = TID
        fldNodeID = NID
        fldTypeID = TyID
        fldKeyText = KT
        CreateObjects()
    End Sub

    Sub New(ByVal KID As Integer, ByVal TID As Integer, _
            ByVal NID As Integer, ByVal TyID As Integer, _
            ByVal KT As String, ByVal environment As String)
        fldKeyID = KID
        fldTreeID = TID
        fldNodeID = NID
        fldTypeID = TyID
        fldKeyText = KT
        Me.Environment = environment
        CreateObjects()
    End Sub

    Sub CreateObjects()
        Me.AccDB = New AccessDB
        Me.AccDB.Environment = Me.Environment
    End Sub

    Public Property KeyID() As Integer
        Get
            Return fldKeyID
        End Get
        Set(ByVal Value As Integer)
            fldKeyID = Value
        End Set
    End Property

    Public Property TreeID() As Integer
        Get
            Return fldTreeID
        End Get
        Set(ByVal Value As Integer)
            fldTreeID = Value
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

    Public Property TypeID() As Integer
        Get
            Return fldTypeID
        End Get
        Set(ByVal Value As Integer)
            fldTypeID = Value
        End Set
    End Property

    Public Property KeyText() As String
        Get
            Return fldKeyText
        End Get
        Set(ByVal Value As String)
            fldKeyText = Value
        End Set
    End Property

    Sub AssignFlds(ByRef AccDB As AccessDB, ByVal recd As Integer)
        If (AccDB.Succeeded) Then
            Me.KeyID = Integer.Parse(AccDB.Records(recd, 0))
            Me.TreeID = Integer.Parse(AccDB.Records(recd, 1))
            Me.NodeID = Integer.Parse(AccDB.Records(recd, 2))
            Me.TypeID = Integer.Parse(AccDB.Records(recd, 3))
            Me.KeyText = AccDB.Records(recd, 4)
        Else
            Me.AccumulateErrors(AccDB.ErrorMsgs, AccDB.NoOfErrorMsgs)
        End If
    End Sub

    Sub AssignFld(ByRef AccDB As AccessDB, ByVal recd As Integer, _
            ByVal FldName As String)
        If (AccDB.Succeeded) Then
            Select Case FldName
                Case "KeyID"
                    Me.KeyID = Integer.Parse(AccDB.Records(recd, 0))
                Case "TreeID"
                    Me.TreeID = Integer.Parse(AccDB.Records(recd, 1))
                Case "NodeID"
                    Me.NodeID = Integer.Parse(AccDB.Records(recd, 2))
                Case "TypeID"
                    Me.TypeID = Integer.Parse(AccDB.Records(recd, 3))
                Case "KeyText"
                    Me.KeyText = AccDB.Records(recd, 4)
            End Select
        Else
            Me.AccumulateErrors(AccDB.ErrorMsgs, AccDB.NoOfErrorMsgs)
        End If
    End Sub

    Sub Check()
        Try
            Me.AccDB.SelectWithKey(Me.TypeID, "TypeID", "Types")
            If (Not Me.AccDB.Succeeded) Then
                Throw New Exception("Key Check Failed: Invalid " & _
                 "Key Type specified")
            End If
            If (Me.KeyText = "") Then
                Throw New Exception("Key Check Failed: Key Text " & _
                 "not specified")
            End If
        Catch
            Me.AccumulateErrors(Me.AccDB.ErrorMsgs, _
              Me.AccDB.NoOfErrorMsgs, Err.Description)
        End Try
    End Sub

    Public Sub Copy(ByRef SearchKey As SearchKey)
        Me.KeyID = SearchKey.KeyID
        Me.TreeID = SearchKey.TreeID
        Me.NodeID = SearchKey.NodeID
        Me.TypeID = SearchKey.TypeID
        Me.KeyText = SearchKey.KeyText
    End Sub

    Sub GetAttempt(ByVal KeyID As Integer)
        Me.AccDB.SelectWithKey(KeyID, "KeyID", "Keys")
        AssignFlds(Me.AccDB, 0)
    End Sub

    Public Sub Insert()
        Try
            Check()
            If (Not Me.Succeeded) Then
                Throw New Exception("Key Checks Failed")
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

            Me.AccDB.Command.CommandText = "INSERT INTO Keys(" & _
                "TreeID, NodeID, TypeID, KeyText) " & _
                "VALUES (" & _
                "@TreeID, @NodeID, @TypeID, @KeyText)"
            Me.AccDB.Command.Parameters.Clear()
            Me.AccDB.Command.Parameters.Add("@TreeID", SqlDbType.Int)
            Me.AccDB.Command.Parameters.Add("@NodeID", SqlDbType.Int)
            Me.AccDB.Command.Parameters.Add("@TypeID", SqlDbType.Int)
            Me.AccDB.Command.Parameters.Add("@KeyText", SqlDbType.VarChar)
            Me.AccDB.Command.Parameters("@TreeID").Value = fldTreeID
            Me.AccDB.Command.Parameters("@NodeID").Value = fldNodeID
            Me.AccDB.Command.Parameters("@TypeID").Value = fldTypeID
            Me.AccDB.Command.Parameters("@KeyText").Value = fldKeyText
            Me.AccDB.ExecNonQuery()
        Catch
            Me.AccumulateErrors(Me.AccDB.ErrorMsgs, _
              Me.AccDB.NoOfErrorMsgs, Err.Description)
        End Try
    End Sub
End Class


