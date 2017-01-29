﻿' Instat-R
' Copyright (C) 2015
'
' This program is free software: you can redistribute it and/or modify
' it under the terms of the GNU General Public License as published by
' the Free Software Foundation, either version 3 of the License, or
' (at your option) any later version.
'
' This program is distributed in the hope that it will be useful,
' but WITHOUT ANY WARRANTY; without even the implied warranty of
' MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
' GNU General Public License for more details.
'
' You should have received a copy of the GNU General Public License k
' along with this program.  If not, see <http://www.gnu.org/licenses/>.
Imports instat.Translations
Public Class dlgReoderDescriptives
    Public bFirstLoad As Boolean = True
    Private clsDefaultFunction As New RFunction
    Private Sub dlgReoderDescriptives_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        autoTranslate(Me)
        If bFirstLoad Then
            InitialiseDialog()
            SetDefaults()
            bFirstLoad = False
        Else
            ReopenDialog()
        End If
        'Checks if Ok can be enabled.
        TestOKEnabled()
    End Sub

    Private Sub InitialiseDialog()
        ucrBase.iHelpTopicID = 351

        ' ucrSelector DataFrame
        ucrDataFrameReorder.SetParameter(New RParameter("data_name", 0))
        ucrDataFrameReorder.SetParameterIsString()

        ' ucrReorderObjects
        '        ucrReorderObjects.SetParameter(New RParameter("new_order", 1))
        ucrReorderObjects.setDataType("object")
        ucrReorderObjects.setDataframes(ucrDataFrameReorder)

        clsDefaultFunction.SetRCommand(frmMain.clsRLink.strInstatDataObject & "$reorder_objects")
    End Sub
    Private Sub ReopenDialog()

    End Sub
    Private Sub TestOKEnabled()
        If Not ucrReorderObjects.isEmpty Then
            ucrBase.OKEnabled(True)
        Else
            ucrBase.OKEnabled(False)
        End If
    End Sub
    Private Sub SetDefaults()
        ucrBase.clsRsyntax.SetBaseRFunction(clsDefaultFunction.Clone())
        SetRCode(Me, ucrBase.clsRsyntax.clsBaseFunction, True)
        ucrDataFrameReorder.Reset()
    End Sub

    Private Sub ucrBase_ClickReset(sender As Object, e As EventArgs) Handles ucrBase.ClickReset
        SetDefaults()
        TestOKEnabled()
    End Sub

    '    Private Sub ucrReorderObjects_OrderChanged() Handles ucrReorderObjects.OrderChanged
    '   If Not ucrReorderObjects.isEmpty Then
    '          ucrBase.clsRsyntax.AddParameter("new_order", ucrReorderObjects.GetVariableNames)
    ' Else
    '        ucrBase.clsRsyntax.RemoveParameter("new_order")
    'End If
    '   TestOKEnabled()
    'End Sub
End Class