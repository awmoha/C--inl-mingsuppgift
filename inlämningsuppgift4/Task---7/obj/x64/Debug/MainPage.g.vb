﻿#ExternalChecksum("C:\Users\moham\source\repos\inlämningsuppgift4\Task---7\MainPage.xaml", "{8829d00f-11b8-4213-878b-770e8597ac16}", "43074684FD361E7730A27F59FFA01B784FCD7975DC6936940B591F937370302D")
'------------------------------------------------------------------------------
' <auto-generated>
'     This code was generated by a tool.
'
'     Changes to this file may cause incorrect behavior and will be lost if
'     the code is regenerated.
' </auto-generated>
'------------------------------------------------------------------------------

Option Strict Off
Option Explicit On

Namespace Global.Task___7

    Partial Class MainPage
        Implements Global.Windows.UI.Xaml.Markup.IComponentConnector
        Implements Global.Windows.UI.Xaml.Markup.IComponentConnector2


        <Global.System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks", " 0.0.0.0")>  _
        <Global.System.Diagnostics.DebuggerNonUserCodeAttribute()>  _
        Public Sub Connect(ByVal connectionId As Integer, ByVal target As Global.System.Object) Implements Global.Windows.UI.Xaml.Markup.IComponentConnector.Connect
            Select Case connectionId
            Case 2 ' MainPage.xaml line 14
                    Me.txtFahrenheit = CType(target, Global.Windows.UI.Xaml.Controls.TextBox)
                    Exit Select
            Case 3 ' MainPage.xaml line 15
                    Dim element3 As Global.Windows.UI.Xaml.Controls.Button = CType(target, Global.Windows.UI.Xaml.Controls.Button)
                AddHandler DirectCast(element3, Global.Windows.UI.Xaml.Controls.Button).Click, AddressOf Me.ConvertButton_Click
                    Exit Select
            Case 4 ' MainPage.xaml line 16
                    Me.txtResult = CType(target, Global.Windows.UI.Xaml.Controls.TextBlock)
                    Exit Select
                    Case Else
                        Exit Select
            End Select
                Me._contentLoaded = true
        End Sub

        <Global.System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks", " 0.0.0.0")>  _
        <Global.System.Diagnostics.DebuggerNonUserCodeAttribute()>  _
        Public Function GetBindingConnector(connectionId As Integer, target As Object) As Global.Windows.UI.Xaml.Markup.IComponentConnector Implements Global.Windows.UI.Xaml.Markup.IComponentConnector2.GetBindingConnector
            Dim returnValue As Global.Windows.UI.Xaml.Markup.IComponentConnector = Nothing
            Return returnValue
        End Function
    End Class

End Namespace


