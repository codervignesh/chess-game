Public Class bishop
    Public x_pos, y_pos As Integer
    Public piece_val As Integer
    Private flags(7, 7) As Boolean
    Public check_king(7, 7) As Boolean

    Public Sub New(ByVal x, ByVal y, ByVal p_val)
        x_pos = x
        y_pos = y
        piece_val = p_val
        re_flags()

    End Sub

    Public Function ret_x() As Integer
        Return x_pos
    End Function

    Public Function ret_y() As Integer
        Return y_pos
    End Function

    Public Function ret_val() As Integer
        Return piece_val
    End Function

    Public Function poss_mov() As Boolean(,)
        re_flags()
        If piece_val > 0 Then
            white_mov()
        End If
        If piece_val < 0 Then
            black_mov()
        End If
        Return flags
    End Function

    Public Sub white_mov()
        Dim i As Integer = x_pos
        Dim j As Integer = y_pos

        While (i < 7 And j > 0)
            i = i + 1
            j = j - 1
            If game_form.game.board(i, j) <= 0 Then
                flags(i, j) = True
                If game_form.game.board(i, j) < 0 Then
                    Exit While
                End If
            Else
                Exit While
            End If
        End While

        i = x_pos
        j = y_pos
        While (i > 0 And j < 7)
            i = i - 1
            j = j + 1
            If game_form.game.board(i, j) <= 0 Then
                flags(i, j) = True
                If game_form.game.board(i, j) < 0 Then
                    Exit While
                End If
            Else
                Exit While
            End If
        End While

        i = x_pos
        j = y_pos
        While (i < 7 And j < 7)
            i = i + 1
            j = j + 1
            If game_form.game.board(i, j) <= 0 Then
                flags(i, j) = True
                If game_form.game.board(i, j) < 0 Then
                    Exit While
                End If
            Else
                Exit While
            End If
        End While

        i = x_pos
        j = y_pos
        While (i > 0 And j > 0)
            i = i - 1
            j = j - 1
            If game_form.game.board(i, j) <= 0 Then
                flags(i, j) = True
                If game_form.game.board(i, j) < 0 Then
                    Exit While
                End If
            Else
                Exit While
            End If
        End While

    End Sub

    Public Sub black_mov()
        Dim i As Integer = x_pos
        Dim j As Integer = y_pos

        While (i < 7 And j > 0)
            i = i + 1
            j = j - 1
            If game_form.game.board(i, j) >= 0 Then
                flags(i, j) = True
                If game_form.game.board(i, j) > 0 Then
                    Exit While
                End If
            Else
                Exit While
            End If
        End While

        i = x_pos
        j = y_pos
        While (i > 0 And j < 7)
            i = i - 1
            j = j + 1
            If game_form.game.board(i, j) >= 0 Then
                flags(i, j) = True
                If game_form.game.board(i, j) > 0 Then
                    Exit While
                End If
            Else
                Exit While
            End If
        End While

        i = x_pos
        j = y_pos
        While (i < 7 And j < 7)
            i = i + 1
            j = j + 1
            If game_form.game.board(i, j) >= 0 Then
                flags(i, j) = True
                If game_form.game.board(i, j) > 0 Then
                    Exit While
                End If
            Else
                Exit While
            End If
        End While

        i = x_pos
        j = y_pos
        While (i > 0 And j > 0)
            i = i - 1
            j = j - 1
            If game_form.game.board(i, j) >= 0 Then
                flags(i, j) = True
                If game_form.game.board(i, j) > 0 Then
                    Exit While
                End If
            Else
                Exit While
            End If
        End While
    End Sub

    Public Sub re_flags()
        For i As Integer = 0 To 7
            For j As Integer = 0 To 7
                flags(i, j) = False
            Next
        Next
    End Sub

    Public Sub chk_king()
        poss_mov()
        For i As Integer = 0 To 7
            For j As Integer = 0 To 7
                If flags(i, j) = True Then
                    check_king(i, j) = True
                Else
                    check_king(i, j) = False
                End If
            Next
        Next
    End Sub

    Public Sub change_pos(ByVal x, ByVal y, ByVal pre_x, ByVal pre_y)
        game_form.game.board(x, y) = game_form.game.board(pre_x, pre_y)
        game_form.game.board(pre_x, pre_y) = 0
        x_pos = x
        y_pos = y
    End Sub
End Class
