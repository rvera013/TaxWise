Module modErrHandler
    Public Function validateTextBoxLength(ByRef obj As TextBox, ByRef errP As ErrorProvider) As Boolean
        If obj.Text.Length = 0 Then
            errP.SetIconAlignment(obj, ErrorIconAlignment.MiddleLeft)
            errP.SetError(obj, "You must enter a value here")
            obj.Focus()
            Return False
        Else
            errP.SetError(obj, "")
            Return True
        End If
    End Function
    Public Function validateTextBoxNumeric(ByRef obj As TextBox, ByRef errP As ErrorProvider) As Boolean
        If Not IsNumeric(obj.Text) Then
            errP.SetIconAlignment(obj, ErrorIconAlignment.MiddleLeft)
            errP.SetError(obj, "You must enter a number value here")
        Else
            errP.SetError(obj, "")
            Return True
        End If
    End Function
    Public Function validateTextBoxDate(ByRef obj As TextBox, ByRef errP As ErrorProvider) As Boolean
        If Not IsDate(obj.Text) Then
            errP.SetIconAlignment(obj, ErrorIconAlignment.MiddleLeft)
            errP.SetError(obj, "You must enter a valid date value here")
        Else
            errP.SetError(obj, "")
            Return True
        End If
    End Function
    Public Function validateCombo(ByRef obj As ComboBox, ByRef errP As ErrorProvider) As Boolean
        If obj.SelectedIndex = -1 Then
            errP.SetIconAlignment(obj, ErrorIconAlignment.MiddleLeft)
            errP.SetError(obj, "You must enter a selection here")
        Else
            errP.SetError(obj, "")
            Return True
        End If
    End Function
    Public Function validateMaskedTextBox(ByRef obj As MaskedTextBox, ByRef errP As ErrorProvider) As Boolean
        If obj.Text.Length = 0 Then
            errP.SetIconAlignment(obj, ErrorIconAlignment.MiddleLeft)
            errP.SetError(obj, "You must enter a value here")
            obj.Focus()
            Return False
        Else
            errP.SetError(obj, "")
            Return True
        End If
    End Function
    Public Function ValidateListBox(ByRef obj As ListBox, ByRef ErrP As ErrorProvider) As Boolean
        If obj.SelectedIndex = -1 Then
            ErrP.SetIconAlignment(obj, ErrorIconAlignment.MiddleLeft)
            ErrP.SetError(obj, "You must enter a selection here")
            obj.Focus()
        Else
            ErrP.SetError(obj, "")
            Return True
        End If
    End Function
    Public Function ValidateListView(ByRef obj As ListView, ByRef ErrP As ErrorProvider) As Boolean
        If obj.Items.Count = 0 Then
            ErrP.SetIconAlignment(obj, ErrorIconAlignment.MiddleLeft)
            ErrP.SetError(obj, "You must enter a selection here")
            obj.Focus()
        Else
            ErrP.SetError(obj, "")
            Return True
        End If
    End Function
End Module
