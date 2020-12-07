Public Class main_game
    Public board(7, 7) As Integer
    Public can_mve(7, 7) As Boolean
    Public check_white(7, 7) As Boolean
    Public check_black(7, 7) As Boolean
    Public gme_flg As Boolean = True
    Public player As Integer = 1
    Public b_danger As Boolean = False
    Public w_danger As Boolean = False
    Public Sub New()
        board = {{5, 4, 3, 2, 1, 3, 4, 5},
                 {6, 6, 6, 6, 6, 6, 6, 6},
                 {0, 0, 0, 0, 0, 0, 0, 0},
                 {0, 0, 0, 0, 0, 0, 0, 0},
                 {0, 0, 0, 0, 0, 0, 0, 0},
                 {0, 0, 0, 0, 0, 0, 0, 0},
                 {-6, -6, -6, -6, -6, -6, -6, -6},
                 {-5, -4, -3, -2, -1, -3, -4, -5}}

        re_chk_black()
        re_chk_white()

    End Sub

    Public Sub show()
        For i As Integer = 0 To 7
            For j As Integer = 0 To 7
                Select Case board(i, j)
                    Case 1
                        game_form.box(i, j).Image = My.Resources.wk
                    Case 2
                        game_form.box(i, j).Image = My.Resources.wq
                    Case 3
                        game_form.box(i, j).Image = My.Resources.wb
                    Case 4
                        game_form.box(i, j).Image = My.Resources.wkn
                    Case 5
                        game_form.box(i, j).Image = My.Resources.wr
                    Case 6
                        game_form.box(i, j).Image = My.Resources.wp
                    Case -1
                        game_form.box(i, j).Image = My.Resources.bk
                    Case -2
                        game_form.box(i, j).Image = My.Resources.bq
                    Case -3
                        game_form.box(i, j).Image = My.Resources.bb
                    Case -4
                        game_form.box(i, j).Image = My.Resources.bkn
                    Case -5
                        game_form.box(i, j).Image = My.Resources.br
                    Case -6
                        game_form.box(i, j).Image = My.Resources.bp
                    Case Else
                        game_form.box(i, j).Image = Nothing
                End Select
            Next
        Next
    End Sub

    Public Sub chk_winner(ByVal selected, ByVal x, ByVal y)
        show()
        If b_danger = True Then
            gme_flg = False
            game_form.b_king.poss_mov()
            For i As Integer = 0 To 7
                For j As Integer = 0 To 7
                    If game_form.b_king.flags(i, j) = True Then
                        gme_flg = True
                    End If
                Next
            Next
        End If
        If game_form.b_king.x_pos = x And game_form.b_king.y_pos = y And selected <> "b_king" Then
            gme_flg = False
        End If
        If gme_flg = False Then
            game_form.stp_timer.Stop()
            game_form.sw.Stop()
            MsgBox(game_form.pla_1.Text + " wins")
            game_form.pla_1.Text = game_form.pla_1.Text + " --- winner --- "
            game_form.pla_1.BackColor = Color.Green
            game_form.gu1.Enabled = False
            game_form.gu2.Enabled = False
            Exit Sub
        End If

        If w_danger = True Then
            gme_flg = False
            game_form.w_king.poss_mov()
            For i As Integer = 0 To 7
                For j As Integer = 0 To 7
                    If game_form.w_king.flags(i, j) = True Then
                        gme_flg = True
                    End If
                Next
            Next
        End If

        If game_form.w_king.x_pos = x And game_form.w_king.y_pos = y And selected <> "w_king" Then
            gme_flg = False
        End If
        If gme_flg = False Then
            game_form.stp_timer.Stop()
            game_form.sw.Stop()
            MsgBox(game_form.pla_2.Text + " wins")
            game_form.pla_2.Text = game_form.pla_2.Text + " --- winner ---"
            game_form.pla_2.BackColor = Color.Green
            game_form.gu1.Enabled = False
            game_form.gu2.Enabled = False
            Exit Sub
        End If
    End Sub

    Public Function selection(ByVal x, ByVal y) As String
        If gme_flg = True Then
            If board(x, y) <> 0 Then
                game_form.box(x, y).BackgroundImage = My.Resources.selection
            End If
            Select Case board(x, y)
                Case 1
                    If player = 1 Then
                        show_possible_move(game_form.w_king.poss_mov())
                        Return "w_king"
                    End If
                Case 2
                    If player = 1 Then
                        show_possible_move(game_form.w_queen.poss_mov())
                        Return "w_queen"
                    End If
                Case 3
                    If player = 1 Then
                        For i As Integer = 0 To 1
                            If game_form.w_bishop(i).ret_x = x And game_form.w_bishop(i).ret_y = y Then
                                show_possible_move(game_form.w_bishop(i).poss_mov())
                            End If
                        Next
                        Return "w_bishop"
                    End If
                Case 4
                    If player = 1 Then
                        For i As Integer = 0 To 1
                            If game_form.w_knight(i).ret_x = x And game_form.w_knight(i).ret_y = y Then
                                show_possible_move(game_form.w_knight(i).poss_mov())
                            End If
                        Next
                        Return "w_knight"
                    End If
                Case 5
                    If player = 1 Then
                        For i As Integer = 0 To 1
                            If game_form.w_rook(i).ret_x = x And game_form.w_rook(i).ret_y = y Then
                                show_possible_move(game_form.w_rook(i).poss_mov())
                            End If
                        Next
                        Return "w_rook"
                    End If
                Case 6
                    If player = 1 Then
                        For i As Integer = 0 To 7
                            If game_form.w_pawn(i).ret_x = x And game_form.w_pawn(i).ret_y = y Then
                                show_possible_move(game_form.w_pawn(i).poss_mov())
                            End If
                        Next
                        Return "w_pawn"
                    End If
                Case -1
                    If player = 2 Then
                        show_possible_move(game_form.b_king.poss_mov())
                        Return "b_king"
                    End If
                Case -2
                    If player = 2 Then
                        show_possible_move(game_form.b_queen.poss_mov())
                        Return "b_queen"
                    End If
                Case -3
                    If player = 2 Then
                        For i As Integer = 0 To 1
                            If game_form.b_bishop(i).ret_x = x And game_form.b_bishop(i).ret_y = y Then
                                show_possible_move(game_form.b_bishop(i).poss_mov())
                            End If
                        Next
                        Return "b_bishop"
                    End If
                Case -4
                    If player = 2 Then
                        For i As Integer = 0 To 1
                            If game_form.b_knight(i).ret_x = x And game_form.b_knight(i).ret_y = y Then
                                show_possible_move(game_form.b_knight(i).poss_mov())
                            End If
                        Next
                        Return "b_knight"
                    End If
                Case -5
                    If player = 2 Then
                        For i As Integer = 0 To 1
                            If game_form.b_rook(i).ret_x = x And game_form.b_rook(i).ret_y = y Then
                                show_possible_move(game_form.b_rook(i).poss_mov())
                            End If
                        Next
                        Return "b_rook"
                    End If
                Case -6
                    If player = 2 Then
                        For i As Integer = 0 To 7
                            If game_form.b_pawn(i).ret_x = x And game_form.b_pawn(i).ret_y = y Then
                                show_possible_move(game_form.b_pawn(i).poss_mov())
                            End If
                        Next
                        Return "b_pawn"
                    End If
                Case Else
                    Return Nothing
            End Select
        End If
    End Function

    Public Sub re_back()
        For i As Integer = 0 To 7
            For j As Integer = 0 To 7
                game_form.box(i, j).BackgroundImage = Nothing
            Next
        Next
    End Sub

    Public Sub re_can_move()
        For i As Integer = 0 To 7
            For j As Integer = 0 To 7
                can_mve(i, j) = False
            Next
        Next
    End Sub

    Public Sub re_chk_white()
        For i As Integer = 0 To 7
            For j As Integer = 0 To 7
                check_white(i, j) = False
            Next
        Next
    End Sub

    Public Sub re_chk_black()
        For i As Integer = 0 To 7
            For j As Integer = 0 To 7
                check_black(i, j) = False
            Next
        Next
    End Sub

    Public Sub chk_black()
        re_chk_black()
        For i As Integer = 0 To 7
            game_form.w_pawn(i).chk_king()
            For j As Integer = 0 To 7
                For k As Integer = 0 To 7
                    If game_form.w_pawn(i).check_king(j, k) = True Then
                        check_black(j, k) = True
                    End If
                Next
            Next
        Next

        For i As Integer = 0 To 1
            game_form.w_rook(i).chk_king()
            For j As Integer = 0 To 7
                For k As Integer = 0 To 7
                    If game_form.w_rook(i).check_king(j, k) = True Then
                        check_black(j, k) = True
                    End If
                Next
            Next
        Next
        For i As Integer = 0 To 1
            game_form.w_bishop(i).chk_king()
            For j As Integer = 0 To 7
                For k As Integer = 0 To 7
                    If game_form.w_bishop(i).check_king(j, k) = True Then
                        check_black(j, k) = True
                    End If
                Next
            Next
        Next

        For i As Integer = 0 To 1
            game_form.w_knight(i).chk_king()
            For j As Integer = 0 To 7
                For k As Integer = 0 To 7
                    If game_form.w_knight(i).check_king(j, k) = True Then
                        check_black(j, k) = True
                    End If
                Next
            Next
        Next

        game_form.w_queen.chk_king()
        For j As Integer = 0 To 7
            For k As Integer = 0 To 7
                If game_form.w_queen.check_king(j, k) = True Then
                    check_black(j, k) = True
                End If
            Next
        Next

    End Sub

    Public Sub chk_white()
        re_chk_white()

        For i As Integer = 0 To 7
            game_form.b_pawn(i).chk_king()
            For j As Integer = 0 To 7
                For k As Integer = 0 To 7
                    If game_form.b_pawn(i).check_king(j, k) = True Then
                        check_white(j, k) = True
                    End If
                Next
            Next
        Next

        For i As Integer = 0 To 1
            game_form.b_rook(i).chk_king()
            For j As Integer = 0 To 7
                For k As Integer = 0 To 7
                    If game_form.b_rook(i).check_king(j, k) = True Then
                        check_white(j, k) = True
                    End If
                Next
            Next
        Next
        For i As Integer = 0 To 1
            game_form.b_bishop(i).chk_king()
            For j As Integer = 0 To 7
                For k As Integer = 0 To 7
                    If game_form.b_bishop(i).check_king(j, k) = True Then
                        check_white(j, k) = True
                    End If
                Next
            Next
        Next

        For i As Integer = 0 To 1
            game_form.b_knight(i).chk_king()
            For j As Integer = 0 To 7
                For k As Integer = 0 To 7
                    If game_form.b_knight(i).check_king(j, k) = True Then
                        check_white(j, k) = True
                    End If
                Next
            Next
        Next

        game_form.b_queen.chk_king()
        For j As Integer = 0 To 7
            For k As Integer = 0 To 7
                If game_form.b_queen.check_king(j, k) = True Then
                    check_white(j, k) = True
                End If
            Next
        Next

    End Sub

    Public Sub show_chk()
        w_danger = False
        b_danger = False

        For i As Integer = 0 To 7
            For j As Integer = 0 To 7
                If check_black(i, j) = True And game_form.b_king.x_pos = i And game_form.b_king.y_pos = j Then
                    game_form.box(i, j).BackgroundImage = My.Resources.check
                    b_danger = True
                End If
            Next
        Next

        For i As Integer = 0 To 7
            For j As Integer = 0 To 7
                If check_white(i, j) = True And game_form.w_king.x_pos = i And game_form.w_king.y_pos = j Then
                    game_form.box(i, j).BackgroundImage = My.Resources.check
                    w_danger = True
                End If
            Next
        Next
    End Sub

    Public Sub show_possible_move(ByVal move As Boolean(,))
        For i As Integer = 0 To 7
            For j As Integer = 0 To 7
                If move(i, j) = True Then
                    game_form.box(i, j).BackgroundImage = My.Resources.V_Move
                    can_mve(i, j) = True
                End If
            Next
        Next
    End Sub

    Public Sub mov(ByVal selected, ByVal x, ByVal y, ByVal pre_x, ByVal pre_y)
        Select Case selected
            Case "w_king"
                game_form.w_king.change_pos(x, y, pre_x, pre_y)
                re_chk_white()
                re_chk_black()
                chk_white()
                chk_black()
                show_chk()
                player = 2
                chk_winner(selected, x, y)

            Case "w_queen"
                game_form.w_queen.change_pos(x, y, pre_x, pre_y)
                re_chk_white()
                re_chk_black()
                chk_white()
                chk_black()
                show_chk()
                player = 2
                chk_winner(selected, x, y)
            Case "w_bishop"
                For i As Integer = 0 To 1
                    If game_form.w_bishop(i).ret_x = pre_x And game_form.w_bishop(i).ret_y = pre_y Then
                        game_form.w_bishop(i).change_pos(x, y, pre_x, pre_y)
                    End If
                Next
                re_chk_white()
                re_chk_black()
                chk_white()
                chk_black()
                show_chk()
                player = 2
                chk_winner(selected, x, y)
            Case "w_knight"
                For i As Integer = 0 To 1
                    If game_form.w_knight(i).ret_x = pre_x And game_form.w_knight(i).ret_y = pre_y Then
                        game_form.w_knight(i).change_pos(x, y, pre_x, pre_y)
                    End If
                Next
                re_chk_white()
                re_chk_black()
                chk_white()
                chk_black()
                show_chk()
                player = 2
                chk_winner(selected, x, y)
            Case "w_rook"
                For i As Integer = 0 To 1
                    If game_form.w_rook(i).ret_x = pre_x And game_form.w_rook(i).ret_y = pre_y Then
                        game_form.w_rook(i).change_pos(x, y, pre_x, pre_y)
                    End If
                Next
                re_chk_white()
                re_chk_black()
                chk_white()
                chk_black()
                show_chk()
                player = 2
                chk_winner(selected, x, y)
            Case "w_pawn"
                For i As Integer = 0 To 7
                    If game_form.w_pawn(i).ret_x = pre_x And game_form.w_pawn(i).ret_y = pre_y And board(x, y) <= 0 Then
                        game_form.w_pawn(i).change_pos(x, y, pre_x, pre_y)
                    End If
                Next
                re_chk_white()
                re_chk_black()
                chk_white()
                chk_black()
                show_chk()
                player = 2
                chk_winner(selected, x, y)

            Case "b_king"
                game_form.b_king.change_pos(x, y, pre_x, pre_y)
                re_chk_white()
                re_chk_black()
                chk_white()
                chk_black()
                show_chk()
                player = 1
                chk_winner(selected, x, y)
            Case "b_queen"
                game_form.b_queen.change_pos(x, y, pre_x, pre_y)
                re_chk_white()
                re_chk_black()
                chk_white()
                chk_black()
                show_chk()
                player = 1
                chk_winner(selected, x, y)
            Case "b_bishop"
                For i As Integer = 0 To 1
                    If game_form.b_bishop(i).ret_x = pre_x And game_form.b_bishop(i).ret_y = pre_y Then
                        game_form.b_bishop(i).change_pos(x, y, pre_x, pre_y)
                    End If
                Next
                re_chk_white()
                re_chk_black()
                chk_white()
                chk_black()
                show_chk()
                player = 1
                chk_winner(selected, x, y)
            Case "b_knight"
                For i As Integer = 0 To 1
                    If game_form.b_knight(i).ret_x = pre_x And game_form.b_knight(i).ret_y = pre_y Then
                        game_form.b_knight(i).change_pos(x, y, pre_x, pre_y)
                    End If
                Next
                re_chk_white()
                re_chk_black()
                chk_white()
                chk_black()
                show_chk()
                player = 1
                chk_winner(selected, x, y)
            Case "b_rook"
                For i As Integer = 0 To 1
                    If game_form.b_rook(i).ret_x = pre_x And game_form.b_rook(i).ret_y = pre_y Then
                        game_form.b_rook(i).change_pos(x, y, pre_x, pre_y)
                    End If
                Next
                re_chk_white()
                re_chk_black()
                chk_white()
                chk_black()
                show_chk()
                player = 1
                chk_winner(selected, x, y)
            Case "b_pawn"
                For i As Integer = 0 To 7
                    If game_form.b_pawn(i).ret_x = pre_x And game_form.b_pawn(i).ret_y = pre_y And board(x, y) >= 0 Then
                        game_form.b_pawn(i).change_pos(x, y, pre_x, pre_y)
                    End If
                Next
                re_chk_white()
                re_chk_black()
                chk_white()
                chk_black()
                show_chk()
                player = 1
                chk_winner(selected, x, y)
            Case Else

        End Select


    End Sub

End Class
