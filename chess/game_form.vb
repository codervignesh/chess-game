Public Class game_form
    Dim pla1 As String
    Dim pla2 As String

    Public w_king As king
    Public w_queen As queen
    Public w_bishop(1) As bishop
    Public w_knight(1) As knight
    Public w_rook(1) As rook
    Public w_pawn(7) As pawn

    Public b_king As king
    Public b_queen As queen
    Public b_bishop(1) As bishop
    Public b_knight(1) As knight
    Public b_rook(1) As rook
    Public b_pawn(7) As pawn

    Public x, y, selec_x, selec_y As Integer
    Public selected As Boolean = False
    Public selec_coin As String = Nothing
    Public game As main_game

    Public box(7, 7) As PictureBox

    Public sw As New Stopwatch
    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles stp_timer.Tick
        Dim elapsed As TimeSpan = sw.Elapsed
        stp_clk.Text = String.Format("{0:00}:{1:00}:{2:00}:{3:00}", Math.Floor(elapsed.TotalHours), elapsed.Minutes, elapsed.Seconds, elapsed.Milliseconds)
    End Sub

    Private Sub Newgame_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles new_gme.Click
        If gu1.Enabled Then
            MsgBox("You can't exit current game unless give up!!!")
            Return
        End If

        sw.Reset()

        pla1 = ""
        pla2 = ""

        While (String.IsNullOrEmpty(pla1))
            pla1 = InputBox("Enter the name of player 1 : ")
        End While

        While (String.IsNullOrEmpty(pla2))
            pla2 = InputBox("Enter the name of player 2 : ")
        End While

        pla_1.Text = "Player 1 : " & pla1
        pla_2.Text = "Player 2 : " & pla2

        gu1.Enabled = True
        gu2.Enabled = True

        pla_1.BackColor = Color.MistyRose
        pla_2.BackColor = Color.MistyRose

        stp_timer.Start()
        sw.Start()

        p00.Enabled = True
        p01.Enabled = True
        p02.Enabled = True
        p03.Enabled = True
        p04.Enabled = True
        p05.Enabled = True
        p06.Enabled = True
        p07.Enabled = True
        p10.Enabled = True
        p11.Enabled = True
        p12.Enabled = True
        p13.Enabled = True
        p14.Enabled = True
        p15.Enabled = True
        p16.Enabled = True
        p17.Enabled = True
        p20.Enabled = True
        p21.Enabled = True
        p22.Enabled = True
        p23.Enabled = True
        p24.Enabled = True
        p25.Enabled = True
        p26.Enabled = True
        p27.Enabled = True
        p30.Enabled = True
        p31.Enabled = True
        p32.Enabled = True
        p33.Enabled = True
        p34.Enabled = True
        p35.Enabled = True
        p36.Enabled = True
        p37.Enabled = True
        p40.Enabled = True
        p41.Enabled = True
        p42.Enabled = True
        p43.Enabled = True
        p44.Enabled = True
        p45.Enabled = True
        p46.Enabled = True
        p47.Enabled = True
        p50.Enabled = True
        p51.Enabled = True
        p52.Enabled = True
        p53.Enabled = True
        p54.Enabled = True
        p55.Enabled = True
        p56.Enabled = True
        p57.Enabled = True
        p60.Enabled = True
        p61.Enabled = True
        p62.Enabled = True
        p63.Enabled = True
        p64.Enabled = True
        p65.Enabled = True
        p66.Enabled = True
        p67.Enabled = True
        p70.Enabled = True
        p71.Enabled = True
        p72.Enabled = True
        p73.Enabled = True
        p74.Enabled = True
        p75.Enabled = True
        p76.Enabled = True
        p77.Enabled = True

        box = New PictureBox(7, 7) {{Me.p00, Me.p01, Me.p02, Me.p03, Me.p04, Me.p05, Me.p06, Me.p07},
                                {Me.p10, Me.p11, Me.p12, Me.p13, Me.p14, Me.p15, Me.p16, Me.p17},
                                {Me.p20, Me.p21, Me.p22, Me.p23, Me.p24, Me.p25, Me.p26, Me.p27},
                                {Me.p30, Me.p31, Me.p32, Me.p33, Me.p34, Me.p35, Me.p36, Me.p37},
                                {Me.p40, Me.p41, Me.p42, Me.p43, Me.p44, Me.p45, Me.p46, Me.p47},
                                {Me.p50, Me.p51, Me.p52, Me.p53, Me.p54, Me.p55, Me.p56, Me.p57},
                                {Me.p60, Me.p61, Me.p62, Me.p63, Me.p64, Me.p65, Me.p66, Me.p67},
                                {Me.p70, Me.p71, Me.p72, Me.p73, Me.p74, Me.p75, Me.p76, Me.p77}}

        coins()
        game.re_can_move()
        game.show()
        game.re_back()
        game.chk_black()
        game.chk_white()

    End Sub

    Public Sub coins()
        w_king = New king(0, 4, 1)
        w_queen = New queen(0, 3, 2)
        w_bishop(0) = New bishop(0, 2, 3)
        w_bishop(1) = New bishop(0, 5, 3)
        w_knight(0) = New knight(0, 1, 4)
        w_knight(1) = New knight(0, 6, 4)
        w_rook(0) = New rook(0, 0, 5)
        w_rook(1) = New rook(0, 7, 5)
        w_pawn(0) = New pawn(1, 0, 6)
        w_pawn(1) = New pawn(1, 1, 6)
        w_pawn(2) = New pawn(1, 2, 6)
        w_pawn(3) = New pawn(1, 3, 6)
        w_pawn(4) = New pawn(1, 4, 6)
        w_pawn(5) = New pawn(1, 5, 6)
        w_pawn(6) = New pawn(1, 6, 6)
        w_pawn(7) = New pawn(1, 7, 6)

        b_king = New king(7, 4, -1)
        b_queen = New queen(7, 3, -2)
        b_bishop(0) = New bishop(7, 2, -3)
        b_bishop(1) = New bishop(7, 5, -3)
        b_knight(0) = New knight(7, 1, -4)
        b_knight(1) = New knight(7, 6, -4)
        b_rook(0) = New rook(7, 0, -5)
        b_rook(1) = New rook(7, 7, -5)
        b_pawn(0) = New pawn(6, 0, -6)
        b_pawn(1) = New pawn(6, 1, -6)
        b_pawn(2) = New pawn(6, 2, -6)
        b_pawn(3) = New pawn(6, 3, -6)
        b_pawn(4) = New pawn(6, 4, -6)
        b_pawn(5) = New pawn(6, 5, -6)
        b_pawn(6) = New pawn(6, 6, -6)
        b_pawn(7) = New pawn(6, 7, -6)

        game = New main_game()
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        gu1.Enabled = False
        gu2.Enabled = False

        p00.Enabled = False
        p01.Enabled = False
        p02.Enabled = False
        p03.Enabled = False
        p04.Enabled = False
        p05.Enabled = False
        p06.Enabled = False
        p07.Enabled = False
        p10.Enabled = False
        p11.Enabled = False
        p12.Enabled = False
        p13.Enabled = False
        p14.Enabled = False
        p15.Enabled = False
        p16.Enabled = False
        p17.Enabled = False
        p20.Enabled = False
        p21.Enabled = False
        p22.Enabled = False
        p23.Enabled = False
        p24.Enabled = False
        p25.Enabled = False
        p26.Enabled = False
        p27.Enabled = False
        p30.Enabled = False
        p31.Enabled = False
        p32.Enabled = False
        p33.Enabled = False
        p34.Enabled = False
        p35.Enabled = False
        p36.Enabled = False
        p37.Enabled = False
        p40.Enabled = False
        p41.Enabled = False
        p42.Enabled = False
        p43.Enabled = False
        p44.Enabled = False
        p45.Enabled = False
        p46.Enabled = False
        p47.Enabled = False
        p50.Enabled = False
        p51.Enabled = False
        p52.Enabled = False
        p53.Enabled = False
        p54.Enabled = False
        p55.Enabled = False
        p56.Enabled = False
        p57.Enabled = False
        p60.Enabled = False
        p61.Enabled = False
        p62.Enabled = False
        p63.Enabled = False
        p64.Enabled = False
        p65.Enabled = False
        p66.Enabled = False
        p67.Enabled = False
        p70.Enabled = False
        p71.Enabled = False
        p72.Enabled = False
        p73.Enabled = False
        p74.Enabled = False
        p75.Enabled = False
        p76.Enabled = False
        p77.Enabled = False

        p00.Parent = PictureBox1
        p01.Parent = PictureBox1
        p02.Parent = PictureBox1
        p03.Parent = PictureBox1
        p04.Parent = PictureBox1
        p05.Parent = PictureBox1
        p06.Parent = PictureBox1
        p07.Parent = PictureBox1
        p17.Parent = PictureBox1
        p16.Parent = PictureBox1
        p15.Parent = PictureBox1
        p14.Parent = PictureBox1
        p13.Parent = PictureBox1
        p12.Parent = PictureBox1
        p11.Parent = PictureBox1
        p10.Parent = PictureBox1
        p27.Parent = PictureBox1
        p26.Parent = PictureBox1
        p25.Parent = PictureBox1
        p24.Parent = PictureBox1
        p23.Parent = PictureBox1
        p22.Parent = PictureBox1
        p21.Parent = PictureBox1
        p20.Parent = PictureBox1
        p37.Parent = PictureBox1
        p36.Parent = PictureBox1
        p35.Parent = PictureBox1
        p34.Parent = PictureBox1
        p33.Parent = PictureBox1
        p32.Parent = PictureBox1
        p31.Parent = PictureBox1
        p30.Parent = PictureBox1
        p47.Parent = PictureBox1
        p46.Parent = PictureBox1
        p45.Parent = PictureBox1
        p44.Parent = PictureBox1
        p43.Parent = PictureBox1
        p42.Parent = PictureBox1
        p41.Parent = PictureBox1
        p40.Parent = PictureBox1
        p57.Parent = PictureBox1
        p56.Parent = PictureBox1
        p55.Parent = PictureBox1
        p54.Parent = PictureBox1
        p53.Parent = PictureBox1
        p52.Parent = PictureBox1
        p51.Parent = PictureBox1
        p50.Parent = PictureBox1
        p67.Parent = PictureBox1
        p66.Parent = PictureBox1
        p65.Parent = PictureBox1
        p64.Parent = PictureBox1
        p63.Parent = PictureBox1
        p62.Parent = PictureBox1
        p61.Parent = PictureBox1
        p60.Parent = PictureBox1
        p77.Parent = PictureBox1
        p76.Parent = PictureBox1
        p75.Parent = PictureBox1
        p74.Parent = PictureBox1
        p73.Parent = PictureBox1
        p72.Parent = PictureBox1
        p71.Parent = PictureBox1
        p70.Parent = PictureBox1
        PictureBox1.BackColor = Color.Transparent

        p00.BackgroundImageLayout = ImageLayout.Stretch
        p01.BackgroundImageLayout = ImageLayout.Stretch
        p02.BackgroundImageLayout = ImageLayout.Stretch
        p03.BackgroundImageLayout = ImageLayout.Stretch
        p04.BackgroundImageLayout = ImageLayout.Stretch
        p05.BackgroundImageLayout = ImageLayout.Stretch
        p06.BackgroundImageLayout = ImageLayout.Stretch
        p07.BackgroundImageLayout = ImageLayout.Stretch

        p10.BackgroundImageLayout = ImageLayout.Stretch
        p11.BackgroundImageLayout = ImageLayout.Stretch
        p12.BackgroundImageLayout = ImageLayout.Stretch
        p13.BackgroundImageLayout = ImageLayout.Stretch
        p14.BackgroundImageLayout = ImageLayout.Stretch
        p15.BackgroundImageLayout = ImageLayout.Stretch
        p16.BackgroundImageLayout = ImageLayout.Stretch
        p17.BackgroundImageLayout = ImageLayout.Stretch

        p20.BackgroundImageLayout = ImageLayout.Stretch
        p21.BackgroundImageLayout = ImageLayout.Stretch
        p22.BackgroundImageLayout = ImageLayout.Stretch
        p23.BackgroundImageLayout = ImageLayout.Stretch
        p24.BackgroundImageLayout = ImageLayout.Stretch
        p25.BackgroundImageLayout = ImageLayout.Stretch
        p26.BackgroundImageLayout = ImageLayout.Stretch
        p27.BackgroundImageLayout = ImageLayout.Stretch

        p30.BackgroundImageLayout = ImageLayout.Stretch
        p31.BackgroundImageLayout = ImageLayout.Stretch
        p32.BackgroundImageLayout = ImageLayout.Stretch
        p33.BackgroundImageLayout = ImageLayout.Stretch
        p34.BackgroundImageLayout = ImageLayout.Stretch
        p35.BackgroundImageLayout = ImageLayout.Stretch
        p36.BackgroundImageLayout = ImageLayout.Stretch
        p37.BackgroundImageLayout = ImageLayout.Stretch

        p40.BackgroundImageLayout = ImageLayout.Stretch
        p41.BackgroundImageLayout = ImageLayout.Stretch
        p42.BackgroundImageLayout = ImageLayout.Stretch
        p43.BackgroundImageLayout = ImageLayout.Stretch
        p44.BackgroundImageLayout = ImageLayout.Stretch
        p45.BackgroundImageLayout = ImageLayout.Stretch
        p46.BackgroundImageLayout = ImageLayout.Stretch
        p47.BackgroundImageLayout = ImageLayout.Stretch

        p50.BackgroundImageLayout = ImageLayout.Stretch
        p51.BackgroundImageLayout = ImageLayout.Stretch
        p52.BackgroundImageLayout = ImageLayout.Stretch
        p53.BackgroundImageLayout = ImageLayout.Stretch
        p54.BackgroundImageLayout = ImageLayout.Stretch
        p55.BackgroundImageLayout = ImageLayout.Stretch
        p56.BackgroundImageLayout = ImageLayout.Stretch
        p57.BackgroundImageLayout = ImageLayout.Stretch

        p60.BackgroundImageLayout = ImageLayout.Stretch
        p61.BackgroundImageLayout = ImageLayout.Stretch
        p62.BackgroundImageLayout = ImageLayout.Stretch
        p63.BackgroundImageLayout = ImageLayout.Stretch
        p64.BackgroundImageLayout = ImageLayout.Stretch
        p65.BackgroundImageLayout = ImageLayout.Stretch
        p66.BackgroundImageLayout = ImageLayout.Stretch
        p67.BackgroundImageLayout = ImageLayout.Stretch

        p70.BackgroundImageLayout = ImageLayout.Stretch
        p71.BackgroundImageLayout = ImageLayout.Stretch
        p72.BackgroundImageLayout = ImageLayout.Stretch
        p73.BackgroundImageLayout = ImageLayout.Stretch
        p74.BackgroundImageLayout = ImageLayout.Stretch
        p75.BackgroundImageLayout = ImageLayout.Stretch
        p76.BackgroundImageLayout = ImageLayout.Stretch
        p77.BackgroundImageLayout = ImageLayout.Stretch

    End Sub

    Private Sub gu1_Click(sender As Object, e As EventArgs) Handles gu1.Click
        Dim resp As Integer
        resp = MessageBox.Show("DO YOU WANT TO GIVE UP?", "Exit Application", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If resp = vbYes Then
            stp_timer.Stop()
            sw.Stop()
            MsgBox(pla_2.Text + " wins")
            pla_2.Text = pla_2.Text + " --- winner --- "
            pla_2.BackColor = Color.Green
            gu1.Enabled = False
            gu2.Enabled = False
        End If
    End Sub

    Private Sub gu2_Click(sender As Object, e As EventArgs) Handles gu2.Click
        Dim resp As Integer
        resp = MessageBox.Show("DO YOU WANT TO GIVE UP?", "Exit Application", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If resp = vbYes Then
            stp_timer.Stop()
            sw.Stop()
            MsgBox(pla_1.Text + " wins")
            pla_1.Text = pla_1.Text + " --- winner ---"
            pla_1.BackColor = Color.Green
            gu1.Enabled = False
            gu2.Enabled = False
        End If
    End Sub

    Function chk_clk()
        If selected <> True Then
            game.re_can_move()
            selec_coin = game.selection(x, y)
            selec_x = x
            selec_y = y
            selected = True
        Else
            If game.can_mve(x, y) = True Then
                game.mov(selec_coin, x, y, selec_x, selec_y)
            End If
            selected = False
            game.show()
        End If
    End Function

    Private Sub p00_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles p00.Click
        game.re_back()
        x = 0
        y = 0
        chk_clk()
    End Sub
    Private Sub p01_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles p01.Click
        game.re_back()
        x = 0
        y = 1
        chk_clk()
    End Sub
    Private Sub p02_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles p02.Click
        game.re_back()
        x = 0
        y = 2
        chk_clk()

    End Sub
    Private Sub p03_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles p03.Click
        game.re_back()
        x = 0
        y = 3
        chk_clk()

    End Sub
    Private Sub p04_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles p04.Click
        game.re_back()
        x = 0
        y = 4
        chk_clk()

    End Sub
    Private Sub p05_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles p05.Click
        game.re_back()
        x = 0
        y = 5
        chk_clk()
    End Sub
    Private Sub p06_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles p06.Click
        game.re_back()
        x = 0
        y = 6
        chk_clk()
    End Sub
    Private Sub p07_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles p07.Click
        game.re_back()
        x = 0
        y = 7
        chk_clk()

    End Sub

    Private Sub p10_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles p10.Click
        game.re_back()
        x = 1
        y = 0
        chk_clk()
    End Sub
    Private Sub p11_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles p11.Click
        game.re_back()
        x = 1
        y = 1
        chk_clk()
    End Sub
    Private Sub p12_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles p12.Click
        game.re_back()
        x = 1
        y = 2
        chk_clk()
    End Sub
    Private Sub p13_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles p13.Click
        game.re_back()
        x = 1
        y = 3
        chk_clk()
    End Sub
    Private Sub p14_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles p14.Click
        game.re_back()
        x = 1
        y = 4
        chk_clk()
    End Sub
    Private Sub p15_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles p15.Click
        game.re_back()
        x = 1
        y = 5
        chk_clk()
    End Sub
    Private Sub p16_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles p16.Click
        game.re_back()
        x = 1
        y = 6
        chk_clk()
    End Sub
    Private Sub p17_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles p17.Click
        game.re_back()
        x = 1
        y = 7
        chk_clk()
    End Sub

    Private Sub p20_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles p20.Click
        game.re_back()
        x = 2
        y = 0
        chk_clk()

    End Sub
    Private Sub p21_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles p21.Click
        game.re_back()
        x = 2
        y = 1
        chk_clk()
    End Sub
    Private Sub p22_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles p22.Click
        game.re_back()
        x = 2
        y = 2
        chk_clk()
    End Sub
    Private Sub p23_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles p23.Click
        game.re_back()
        x = 2
        y = 3
        chk_clk()
    End Sub
    Private Sub p24_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles p24.Click
        game.re_back()
        x = 2
        y = 4
        chk_clk()
    End Sub
    Private Sub p25_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles p25.Click
        game.re_back()
        x = 2
        y = 5
        chk_clk()
    End Sub
    Private Sub p26_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles p26.Click
        game.re_back()
        x = 2
        y = 6
        chk_clk()
    End Sub
    Private Sub p27_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles p27.Click
        game.re_back()
        x = 2
        y = 7
        chk_clk()
    End Sub

    Private Sub p30_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles p30.Click
        game.re_back()
        x = 3
        y = 0
        chk_clk()
    End Sub
    Private Sub p31_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles p31.Click
        game.re_back()
        x = 3
        y = 1
        chk_clk()
    End Sub
    Private Sub p32_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles p32.Click
        game.re_back()
        x = 3
        y = 2
        chk_clk()
    End Sub
    Private Sub p33_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles p33.Click
        game.re_back()
        x = 3
        y = 3
        chk_clk()
    End Sub
    Private Sub p34_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles p34.Click
        game.re_back()
        x = 3
        y = 4
        chk_clk()
    End Sub
    Private Sub p35_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles p35.Click
        game.re_back()
        x = 3
        y = 5
        chk_clk()
    End Sub
    Private Sub p36_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles p36.Click
        game.re_back()
        x = 3
        y = 6
        chk_clk()
    End Sub
    Private Sub p37_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles p37.Click
        game.re_back()
        x = 3
        y = 7
        chk_clk()
    End Sub

    Private Sub p40_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles p40.Click
        game.re_back()
        x = 4
        y = 0
        chk_clk()
    End Sub
    Private Sub p41_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles p41.Click
        game.re_back()
        x = 4
        y = 1
        chk_clk()
    End Sub
    Private Sub p42_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles p42.Click
        game.re_back()
        x = 4
        y = 2
        chk_clk()
    End Sub
    Private Sub p43_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles p43.Click
        game.re_back()
        x = 4
        y = 3
        chk_clk()
    End Sub
    Private Sub p44_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles p44.Click
        game.re_back()
        x = 4
        y = 4
        chk_clk()
    End Sub
    Private Sub p45_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles p45.Click
        game.re_back()
        x = 4
        y = 5
        chk_clk()
    End Sub
    Private Sub p46_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles p46.Click
        game.re_back()
        x = 4
        y = 6
        chk_clk()
    End Sub
    Private Sub p47_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles p47.Click
        game.re_back()
        x = 4
        y = 7
        chk_clk()
    End Sub

    Private Sub p50_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles p50.Click
        game.re_back()
        x = 5
        y = 0
        chk_clk()
    End Sub
    Private Sub p51_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles p51.Click
        game.re_back()
        x = 5
        y = 1
        chk_clk()
    End Sub
    Private Sub p52_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles p52.Click
        game.re_back()
        x = 5
        y = 2
        chk_clk()
    End Sub
    Private Sub p53_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles p53.Click
        game.re_back()
        x = 5
        y = 3
        chk_clk()
    End Sub
    Private Sub p54_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles p54.Click
        game.re_back()
        x = 5
        y = 4
        chk_clk()
    End Sub
    Private Sub p55_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles p55.Click
        game.re_back()
        x = 5
        y = 5
        chk_clk()
    End Sub
    Private Sub p56_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles p56.Click
        game.re_back()
        x = 5
        y = 6
        chk_clk()
    End Sub
    Private Sub p57_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles p57.Click
        game.re_back()
        x = 5
        y = 7
        chk_clk()
    End Sub

    Private Sub p60_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles p60.Click
        game.re_back()
        x = 6
        y = 0
        chk_clk()
    End Sub
    Private Sub p61_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles p61.Click
        game.re_back()
        x = 6
        y = 1
        chk_clk()
    End Sub
    Private Sub p62_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles p62.Click
        game.re_back()
        x = 6
        y = 2
        chk_clk()
    End Sub
    Private Sub p63_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles p63.Click
        game.re_back()
        x = 6
        y = 3
        chk_clk()
    End Sub
    Private Sub p64_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles p64.Click
        game.re_back()
        x = 6
        y = 4
        chk_clk()
    End Sub
    Private Sub p65_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles p65.Click
        game.re_back()
        x = 6
        y = 5
        chk_clk()
    End Sub
    Private Sub p66_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles p66.Click
        game.re_back()
        x = 6
        y = 6
        chk_clk()
    End Sub
    Private Sub p67_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles p67.Click
        game.re_back()
        x = 6
        y = 7
        chk_clk()
    End Sub

    Private Sub p70_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles p70.Click
        game.re_back()
        x = 7
        y = 0
        chk_clk()
    End Sub
    Private Sub p71_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles p71.Click
        game.re_back()
        x = 7
        y = 1
        chk_clk()
    End Sub
    Private Sub p72_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles p72.Click
        game.re_back()
        x = 7
        y = 2
        chk_clk()
    End Sub
    Private Sub p73_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles p73.Click
        game.re_back()
        x = 7
        y = 3
        chk_clk()
    End Sub
    Private Sub p74_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles p74.Click
        game.re_back()
        x = 7
        y = 4
        chk_clk()
    End Sub
    Private Sub p75_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles p75.Click
        game.re_back()
        x = 7
        y = 5
        chk_clk()
    End Sub

    Private Sub p76_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles p76.Click
        game.re_back()
        x = 7
        y = 6
        chk_clk()
    End Sub
    Private Sub p77_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles p77.Click
        game.re_back()
        x = 7
        y = 7
        chk_clk()
    End Sub
End Class