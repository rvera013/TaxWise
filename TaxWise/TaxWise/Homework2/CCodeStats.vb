Public Class CCodeStats
    Private _strCodeName As String
    Private _intEmpAmountTotal As Integer
    Private _intEmpWithBonus As Integer
    Private _dblAvgScore As Double
    Private _dblAvgTotalScore As Double
    Private _dblBonusTotal As Double
    Public Sub New(strName As String)
        _strCodeName = strName
    End Sub
    Public ReadOnly Property CodeName() As String
        Get
            Return _strCodeName
        End Get
    End Property
    Public Property getTotalBonuses() As Double
        Get
            Return _dblBonusTotal
        End Get
        Set(dblValue As Double)
            _dblBonusTotal = dblValue
        End Set
    End Property
    Public Property getEmpAmount() As Integer
        Get
            Return _intEmpAmountTotal
        End Get
        Set(intValue As Integer)
            _intEmpAmountTotal = intValue
        End Set
    End Property

    Public Property getTotalScoreAvg() As Double
        Get
            Return _dblAvgTotalScore
        End Get
        Set(dblValue As Double)
            _dblAvgTotalScore = dblValue
        End Set
    End Property
    Public Property getScoreAvg() As Double
        Get
            Return _dblAvgScore
        End Get
        Set(dblValue As Double)
            _dblAvgScore = dblValue
        End Set
    End Property
    Public Property getEmpWithBonus() As Integer
        Get
            Return _intEmpWithBonus
        End Get
        Set(intValue As Integer)
            _intEmpWithBonus = intValue
        End Set
    End Property
End Class
