Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Linq
Imports System.Text
Imports System.Windows.Forms
Imports DevExpress.XtraBars.Ribbon
Imports System.Reflection
Imports DevExpress.XtraBars.Ribbon.Handler
Imports DevExpress.XtraBars.Ribbon.ViewInfo

Namespace WindowsFormsApplication4
	Partial Public Class Form1
		Inherits Form
		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub Form1_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
			ribbonControl1.Minimized = True

		End Sub

		Private Sub barButtonItem2_ItemClick(ByVal sender As Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles barButtonItem2.ItemClick
			ribbonControl1.SelectedPage = ribbonPage2
		End Sub

		Private Sub simpleButton1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles simpleButton1.Click
			Dim fi As FieldInfo = GetType(RibbonControl).GetField("handler", BindingFlags.NonPublic Or BindingFlags.Instance)
			Dim b As Object = fi.GetValue(ribbonControl1)
			Dim mi As MethodInfo = GetType(RibbonHandler).GetMethod("OnPressHeaderPage", BindingFlags.NonPublic Or BindingFlags.Instance)

			Dim hi As New RibbonHitInfo()
			hi.Page = ribbonPage2
			mi.Invoke(b, New Object() { hi })

		End Sub

	End Class
End Namespace
