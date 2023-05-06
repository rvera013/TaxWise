
Imports System.IO
Public Class frmPayroll
    Private strFileName As String
    Private intTotalCount As Integer
    Private arrCodes As ArrayList
    'object variable for the frmStats class created to display the company's overall statistics'
    'frmStats is a separate class that holds a listbox control (lstStats) that displays a series of stats based on the function '
    Private stats As frmStats
    'new variables'
    Dim strNewHeaders As String
    Dim dblColVal As Double
    Dim dblSalary As New Double
    Dim dblBonus As Double
    Dim dblBonusAmt As New Double
    Dim dblTotalAmt As New Double
    Dim strFields() As String 'string array to hold the Fields from a record in the file'
    'new variables for statistical data'
    Dim blnErrors As Boolean
    Private dblScoreSum As Double
    Private intToalEmpWithBonus As Integer
    Private dblTotalBonusValue As Double
    Private dblAvgScoresTotal As Double
#Region "Columns"
    Private Const ID As Integer = 0
    Private Const LASTNAME As Integer = 1
    Private Const FIRSTNAME As Integer = 2
    Private Const JCODE As Integer = 3
    Private Const DEPT As Integer = 4
    Private Const SCORE As Integer = 5
    Private Const RATING As Integer = 6
    Private Const SALARY As Integer = 7
    Private Const BONUS As Integer = 8
    Private Const BONUSAMOUNT As Integer = 9
    Private Const TOTALPAID As Integer = 10
#End Region
    Private Sub fileCleansing()
        lvwPayRoll.Items.Clear()
        'new variables'
        strNewHeaders = ""
        strNewHeaders = 0
        dblColVal = 0
        dblSalary = 0
        dblBonus = 0
        dblBonusAmt = 0
        dblTotalAmt = 0
        'new variables for statistical data'
        intToalEmpWithBonus = 0
        dblTotalBonusValue = 0
        dblAvgScoresTotal = 0
        arrCodes = New ArrayList
        stats = New frmStats
        strFields = New String() {}
    End Sub
    Private Sub openFiles()
        fileCleansing()
        Dim intResults As Integer
        ofdOpen.InitialDirectory = Application.StartupPath
        ofdOpen.Filter = "all files  (*.*) |*.*|Text Files (*.txt*)|*.txt"
        ofdOpen.FilterIndex = 2
        intResults = ofdOpen.ShowDialog
        If intResults = DialogResult.Cancel Then
            Exit Sub
        End If
        strFileName = ofdOpen.FileName
        Try
            readInputFile(strFileName)
        Catch exNotFound As FileLoadException
            'insert error-handling role here'
        Catch exIOError As IOException
            'insert error-handling role here'
        Catch exOther As Exception 'everything else that maay go wrong'
            'insert error-handling role here'
        End Try

    End Sub

    Private Sub readInputFile(strIn As String)
        Dim fileIn As StreamReader
        Dim strLineIn As String
        Dim i As Integer

        Try
            fileIn = New StreamReader(strIn)
            If Not fileIn.EndOfStream Then
                strLineIn = fileIn.ReadLine
                strFields = strLineIn.Split(",")
                For i = 0 To strFields.Length - 1 'for column headings'
                    lvwPayRoll.Columns.Add(strFields(i))
                Next
                lvwPayRoll.Columns.Add("Rating")
                lvwPayRoll.Columns.Add("Base Salary")
                lvwPayRoll.Columns.Add("Bonus %")
                lvwPayRoll.Columns.Add("Bonus Amt")
                lvwPayRoll.Columns.Add("Total Paid")
                ''formatting for columns
                With lvwPayRoll
                    .Columns(ID).Width = 80
                    .Columns(LASTNAME).Width = 100
                    .Columns(FIRSTNAME).Width = 80
                    .Columns(JCODE).Width = 60
                    .Columns(JCODE).TextAlign = HorizontalAlignment.Center
                    .Columns(DEPT).Width = 60
                    .Columns(SCORE).Width = 80
                    .Columns(SCORE).TextAlign = HorizontalAlignment.Center
                    .Columns(RATING).Width = 80
                    .Columns(SALARY).Width = 100
                    .Columns(SALARY).TextAlign = HorizontalAlignment.Right
                    .Columns(BONUS).Width = 80
                    .Columns(BONUS).TextAlign = HorizontalAlignment.Right
                    .Columns(BONUSAMOUNT).Width = 80
                    .Columns(BONUSAMOUNT).TextAlign = HorizontalAlignment.Right
                    .Columns(TOTALPAID).Width = 90
                    .Columns(TOTALPAID).TextAlign = HorizontalAlignment.Right
                    '.Columns(TOTALPAID).Width = HorizontalAlignment.Right
                End With
            End If
            'get data for each row'
            While Not fileIn.EndOfStream
                strLineIn = fileIn.ReadLine
                strFields = strLineIn.Split(",")
                ''set up first column in  a new listview item (AKA row)
                ',Base Salary,Bonus %,Bonus Amt,Total Paid
                strNewHeaders = strFields(0)
                Dim lviRow As New ListViewItem(strNewHeaders)

                'add values pulled from the csv file to the new row (lviRow)'
                For i = 1 To strFields.Length - 1

                    Dim lsiCol As New ListViewItem.ListViewSubItem
                    lsiCol.Text = strFields(i)

                    lviRow.SubItems.Add(lsiCol) 'add the column to the row'

                Next

                'add rating values based on score to lviRow'

                dblColVal = CDbl(lviRow.SubItems(SCORE).Text)
                Select Case dblColVal
                    Case Is < 75
                        lviRow.SubItems.Add("Poor")
                    Case Is < 85
                        lviRow.SubItems.Add("Fair")
                    Case Is < 95
                        lviRow.SubItems.Add("Good")
                    Case Else
                        lviRow.SubItems.Add("Excellent")
                End Select

                'add values for base salary based on the job code to lviRow'

                Select Case lviRow.SubItems(JCODE).Text
                    Case "E428"
                        dblSalary = 49200
                    Case "E538"
                        dblSalary = 57700
                    Case "E425"
                        dblSalary = 42000
                    Case "E513"
                        dblSalary = 74800
                    Case "E535"
                        dblSalary = 82300
                    Case "E601"
                        dblSalary = 98700
                End Select

                lviRow.SubItems.Add(FormatCurrency(dblSalary))

                'add values for bonus % based on ratings to lviRow

                dblBonus = 0.065
                If lviRow.SubItems(RATING).Text = "Poor" Then
                    dblBonus = 0
                End If
                lviRow.SubItems.Add(dblBonus)
                lvwPayRoll.Items.Add(lviRow)

                'add values for bonus amount based on base salary times bonus amount to lviRow


                dblBonusAmt = dblBonus * dblSalary
                lviRow.SubItems.Add(FormatCurrency(dblBonusAmt))

                'add values for the total amount paid based on the sum of the salary and the bonus amount to lviRow

                dblTotalAmt = dblBonusAmt + dblSalary
                lviRow.SubItems.Add(FormatCurrency(dblTotalAmt))
                statCreation(lviRow)
            End While

            fileIn.Close()
            fileIn.Dispose()

        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub arrCodesAdd(aCodeReplica As CCodeStats, lviRowReplica As ListViewItem)
        'add what's inside of the bonus amount column to the total amount of bonuses paid throughout the company
        'getTotalBonuses is the function that adds initializes the (sets) the value of the TotalBonus variable, which is made to store the total amount of bonuses paid throughout the company.
        aCodeReplica.getTotalBonuses() += CDbl(lviRowReplica.SubItems(BONUSAMOUNT).Text)
        'add what's inside of the bonus score column to the sum of all scores throughout the company, which will later be used to get the average.
        'getScoreAvg is the function that initializes the (sets) the value of the _dblAvgTotalScore value, which holds the sum of all scores to later get the average score for the whole company
        aCodeReplica.getScoreAvg += CDbl(lviRowReplica.SubItems(SCORE).Text)
        'if statement to count all employees that got a bonus in the company'
        'getEmpyWithBonus is the variable that stores the total count of employees that got a bonus this year throughout the company
        If CInt(lviRowReplica.SubItems(BONUSAMOUNT).Text) > 0 Then
            aCodeReplica.getEmpWithBonus += 1
        End If
        'add to the total count of employees in the company
        'getEmpAmount is the function used to initialize the _intEmpAmountTotal variable, which holds the total value of employees working in the company.'
        aCodeReplica.getEmpAmount() += 1
    End Sub
    Private Sub statCreation(lviRow As ListViewItem)
        Dim blnFoundIt As Boolean
        'checking if new rows already exist in the arraylist'
        For Each aCode As CCodeStats In arrCodes

            If aCode.CodeName() = lviRow.SubItems(JCODE).Text Then
                arrCodesAdd(aCode, lviRow)

                blnFoundIt = True
                Exit For 'to leave the for loop early'
            End If
        Next
        If Not blnFoundIt Then 'need to create a new CCodeStats object'
            Dim newCode As New CCodeStats(lviRow.SubItems(JCODE).Text)
            arrCodesAdd(newCode, lviRow)
            arrCodes.Add(newCode)
        End If
        'updating all stats'
    End Sub


    Private Sub mnuOpen_Click(sender As Object, e As EventArgs) Handles mnuOpen.Click
        openFiles()
    End Sub

    Private Sub frmPayroll_Load(sender As Object, e As EventArgs) Handles Me.Load
        arrCodes = New ArrayList
        stats = New frmStats
    End Sub

    Private Sub mnuStats_Click(sender As Object, e As EventArgs) Handles mnuStats.Click
        blnErrors = False
        If Not ValidateListView(lvwPayRoll, ErrP) Then
            blnErrors = True
            MessageBox.Show("You must have values on the list view in order to generate stats", "Program error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
        With stats.lstStats
            For Each aCode As CCodeStats In arrCodes
                .Items.Add(aCode.CodeName & ":")
                .Items.Add("  Employee Count = " & CStr(aCode.getEmpAmount))
                .Items.Add("  Total Bonuses = " & FormatCurrency(aCode.getTotalBonuses))
                .Items.Add("  average score in this section = " & (aCode.getScoreAvg / aCode.getEmpAmount).ToString("0.00"))
                .Items.Add("  Employees with bonus in this section = " & CStr(aCode.getEmpWithBonus))
                intTotalCount += CInt(aCode.getEmpAmount)
                dblTotalBonusValue += CDbl(aCode.getTotalBonuses)
                intToalEmpWithBonus += CInt(aCode.getEmpWithBonus)
                dblScoreSum += CDbl(aCode.getScoreAvg)
            Next
            dblAvgScoresTotal += CDbl(dblScoreSum / intTotalCount)
        End With
        With stats.lstTotalStats
            .Items.Add("Total average score = " & dblAvgScoresTotal.ToString("0.0"))
            .Items.Add("total employees in the company = " & CStr(intTotalCount))
            .Items.Add("Total bonuses given = " & FormatCurrency(dblTotalBonusValue))
            .Items.Add("total employees in the company with a bonus = " & CStr(intToalEmpWithBonus))
        End With
        If blnErrors = False Then
            stats.ShowDialog()
        End If
        dblScoreSum = 0
        intToalEmpWithBonus = 0
        dblTotalBonusValue = 0
        dblAvgScoresTotal = 0
        intTotalCount = 0
        stats.lstStats.Items.Clear()
        stats.lstTotalStats.Items.Clear()

    End Sub
    'this section is for functions required to save files in csv format'
    Private Sub writeOutputFile(strName As String)
        Dim fileOut As StreamWriter
        Dim strLineOut As String = ""
        Dim i As Integer
        Dim j As Integer
        Try
            fileOut = New StreamWriter(strName)
            For i = 0 To lvwPayRoll.Columns.Count - 1
                If True <> lvwPayRoll.Columns.Count - 1 Then

                    strLineOut &= lvwPayRoll.Columns(i).Text & ","
                Else
                    strLineOut &= lvwPayRoll.Columns(i).Text
                End If
            Next
            fileOut.WriteLine(strLineOut)
            For i = 0 To lvwPayRoll.Items.Count - 1
                strLineOut = lvwPayRoll.Items(i).Text
                For j = 1 To lvwPayRoll.Items(i).SubItems.Count - 1
                    strLineOut &= "," & lvwPayRoll.Items(i).SubItems(j).Text
                Next
                fileOut.WriteLine(strLineOut)
            Next
            fileOut.Close()
            fileOut.Dispose()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub saveFile()
        Dim intREsult As Integer
        sfdSave.InitialDirectory = Application.StartupPath
        sfdSave.Filter = "all files  (*.*) |*.*|Text Files (*.txt*)|*.txt"
        sfdSave.FilterIndex = 2
        intREsult = sfdSave.ShowDialog
        If intREsult = DialogResult.Cancel Then
            Exit Sub
        End If
        strFileName = sfdSave.FileName
        Try
            writeOutputFile(strFileName)
        Catch exNotFound As FileNotFoundException

        Catch exIOError As IOException

        Catch exOther As Exception

        End Try

    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Application.Exit()
    End Sub

    Private Sub mnuExit_Click(sender As Object, e As EventArgs) Handles mnuExit.Click
        Application.Exit()
    End Sub

    Private Sub mnuSave_Click(sender As Object, e As EventArgs) Handles mnuSave.Click
        If Not ValidateListView(lvwPayRoll, ErrP) Then
            blnErrors = True
            MessageBox.Show("You must have values on the list view in order to save stats", "Program error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Else
            saveFile()
        End If

    End Sub

    Private Sub btnUpload_Click(sender As Object, e As EventArgs) Handles btnUpload.Click
        openFiles()
    End Sub

    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        fileCleansing()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If Not ValidateListView(lvwPayRoll, ErrP) Then
            blnErrors = True
            MessageBox.Show("You must have values on the list view in order to save stats", "Program error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Else
            saveFile()
        End If
    End Sub
End Class
