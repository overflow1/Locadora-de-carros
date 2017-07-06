<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPrincipal
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmPrincipal))
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.CadastroToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CidadeToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ModeloToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AutomóvelToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ClienteToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.LocaçõesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SobreToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SairToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CadastroToolStripMenuItem, Me.LocaçõesToolStripMenuItem, Me.SobreToolStripMenuItem, Me.SairToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(313, 24)
        Me.MenuStrip1.TabIndex = 0
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'CadastroToolStripMenuItem
        '
        Me.CadastroToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CidadeToolStripMenuItem, Me.ModeloToolStripMenuItem, Me.AutomóvelToolStripMenuItem, Me.ClienteToolStripMenuItem})
        Me.CadastroToolStripMenuItem.Image = CType(resources.GetObject("CadastroToolStripMenuItem.Image"), System.Drawing.Image)
        Me.CadastroToolStripMenuItem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.CadastroToolStripMenuItem.Name = "CadastroToolStripMenuItem"
        Me.CadastroToolStripMenuItem.Size = New System.Drawing.Size(82, 20)
        Me.CadastroToolStripMenuItem.Text = "Cadastro"
        '
        'CidadeToolStripMenuItem
        '
        Me.CidadeToolStripMenuItem.Name = "CidadeToolStripMenuItem"
        Me.CidadeToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.CidadeToolStripMenuItem.Text = "Cidade"
        '
        'ModeloToolStripMenuItem
        '
        Me.ModeloToolStripMenuItem.Name = "ModeloToolStripMenuItem"
        Me.ModeloToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.ModeloToolStripMenuItem.Text = "Modelo"
        '
        'AutomóvelToolStripMenuItem
        '
        Me.AutomóvelToolStripMenuItem.Name = "AutomóvelToolStripMenuItem"
        Me.AutomóvelToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.AutomóvelToolStripMenuItem.Text = "Automóvel"
        '
        'ClienteToolStripMenuItem
        '
        Me.ClienteToolStripMenuItem.Name = "ClienteToolStripMenuItem"
        Me.ClienteToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.ClienteToolStripMenuItem.Text = "Cliente"
        '
        'LocaçõesToolStripMenuItem
        '
        Me.LocaçõesToolStripMenuItem.Image = CType(resources.GetObject("LocaçõesToolStripMenuItem.Image"), System.Drawing.Image)
        Me.LocaçõesToolStripMenuItem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.LocaçõesToolStripMenuItem.Name = "LocaçõesToolStripMenuItem"
        Me.LocaçõesToolStripMenuItem.Size = New System.Drawing.Size(84, 20)
        Me.LocaçõesToolStripMenuItem.Text = "Locações"
        '
        'SobreToolStripMenuItem
        '
        Me.SobreToolStripMenuItem.Image = CType(resources.GetObject("SobreToolStripMenuItem.Image"), System.Drawing.Image)
        Me.SobreToolStripMenuItem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.SobreToolStripMenuItem.Name = "SobreToolStripMenuItem"
        Me.SobreToolStripMenuItem.Size = New System.Drawing.Size(65, 20)
        Me.SobreToolStripMenuItem.Text = "Sobre"
        '
        'SairToolStripMenuItem
        '
        Me.SairToolStripMenuItem.Image = CType(resources.GetObject("SairToolStripMenuItem.Image"), System.Drawing.Image)
        Me.SairToolStripMenuItem.Name = "SairToolStripMenuItem"
        Me.SairToolStripMenuItem.Size = New System.Drawing.Size(54, 20)
        Me.SairToolStripMenuItem.Text = "Sair"
        '
        'frmPrincipal
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), System.Drawing.Image)
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.ClientSize = New System.Drawing.Size(313, 260)
        Me.Controls.Add(Me.MenuStrip1)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "frmPrincipal"
        Me.Text = "Principal"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents CadastroToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents LocaçõesToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SobreToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SairToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CidadeToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ModeloToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AutomóvelToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ClienteToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem

End Class
