<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmStats
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.lstTotalStats = New System.Windows.Forms.ListBox()
        Me.lstStats = New System.Windows.Forms.ListBox()
        Me.SuspendLayout()
        '
        'btnClose
        '
        Me.btnClose.Location = New System.Drawing.Point(551, 342)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(135, 47)
        Me.btnClose.TabIndex = 1
        Me.btnClose.Text = "Close"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'lstTotalStats
        '
        Me.lstTotalStats.FormattingEnabled = True
        Me.lstTotalStats.ItemHeight = 16
        Me.lstTotalStats.Location = New System.Drawing.Point(427, 12)
        Me.lstTotalStats.Name = "lstTotalStats"
        Me.lstTotalStats.Size = New System.Drawing.Size(352, 148)
        Me.lstTotalStats.TabIndex = 4
        '
        'lstStats
        '
        Me.lstStats.FormattingEnabled = True
        Me.lstStats.ItemHeight = 16
        Me.lstStats.Location = New System.Drawing.Point(12, 12)
        Me.lstStats.Name = "lstStats"
        Me.lstStats.Size = New System.Drawing.Size(409, 404)
        Me.lstStats.TabIndex = 5
        '
        'frmStats
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.ControlBox = False
        Me.Controls.Add(Me.lstStats)
        Me.Controls.Add(Me.lstTotalStats)
        Me.Controls.Add(Me.btnClose)
        Me.Name = "frmStats"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Statistics"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btnClose As Button
    Friend WithEvents lstTotalStats As ListBox
    Friend WithEvents lstStats As ListBox
End Class
