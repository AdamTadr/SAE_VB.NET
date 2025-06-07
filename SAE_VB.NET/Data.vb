Imports System.IO

Module Data
    Structure Stats
        Dim score As Integer
        Dim tpsCumul As Integer
        Dim temps As Integer
        Dim nbPartieJoue As Integer
    End Structure

    Structure Param
        Dim nbTypeCarte As Integer
        Dim nbCartesParType As Integer
        Dim tempsImpartis As Integer
        Dim theme As String
        Dim sauvegarde As Boolean
    End Structure

    Public Sub SauvegarderParam()
        Dim p As Param
        p.nbTypeCarte = FormJeu.getNbTypeCarte()
        p.nbCartesParType = FormJeu.getNbCartesParType()
        p.tempsImpartis = FormJeu.getTempsImpartis()
        p.theme = FormJeu.getTheme()
        p.sauvegarde = FormJeu.getSauvegarde()

        Using fs As New FileStream("Parametres.bin", FileMode.OpenOrCreate, FileAccess.Write)
            Using bw As New BinaryWriter(fs)
                bw.Write(p.nbTypeCarte)
                bw.Write(p.nbCartesParType)
                bw.Write(p.tempsImpartis)
                bw.Write(p.theme)
                bw.Write(p.sauvegarde)
            End Using
        End Using
    End Sub

    Public Function LireParam() As Param
        Const tempsDefaut As Integer = 61
        Const nbTypeCarteDefaut As Integer = 5
        Const nbCartesParTypeDefaut As Integer = 4
        Const themeDefaut As String = "Planete"
        Const sauvegardeDefaut As Boolean = True
        Dim p As New Param()

        If Not File.Exists("Parametres.bin") Then
            p.nbTypeCarte = nbTypeCarteDefaut
            p.nbCartesParType = nbCartesParTypeDefaut
            p.tempsImpartis = tempsDefaut
            p.theme = themeDefaut
            p.sauvegarde = sauvegardeDefaut
            Return p
        End If

        Using fs As New FileStream("Parametres.bin", FileMode.Open, FileAccess.Read)
            Using br As New BinaryReader(fs)
                p.nbTypeCarte = br.ReadInt32()
                p.nbCartesParType = br.ReadInt32()
                p.tempsImpartis = br.ReadInt32()
                p.theme = br.ReadString()
                p.sauvegarde = br.ReadBoolean()
            End Using
        End Using

        Return p
    End Function

    Private Statistiques As New Dictionary(Of String, Stats)

    Public Sub SupprimerStats()
        Statistiques = New Dictionary(Of String, Stats)
        File.Delete("Statistiques.bin")
        Score.Refresh()
    End Sub

    Public Function listeStats() As List(Of Tuple(Of String, Stats))
        Dim personnes As New List(Of Tuple(Of String, Stats))
        Dim keyCourante As String
        Dim keyPlusGrande As String

        Dim StatistiquesCopie As New Dictionary(Of String, Stats)(Statistiques)

        For i As Integer = 0 To StatistiquesCopie.Count - 1
            Dim keysList = StatistiquesCopie.Keys.ToList()
            keyPlusGrande = keysList(0)
            For j As Integer = 0 To StatistiquesCopie.Count - 1
                keyCourante = keysList(j)
                If StatistiquesCopie(keyCourante).score > StatistiquesCopie(keyPlusGrande).score Then
                    keyPlusGrande = keyCourante
                ElseIf StatistiquesCopie(keyCourante).score = StatistiquesCopie(keyPlusGrande).score Then
                    If StatistiquesCopie(keyCourante).temps < StatistiquesCopie(keyPlusGrande).temps Then
                        keyPlusGrande = keyCourante
                    End If
                End If
            Next
            personnes.Add(Tuple.Create(keyPlusGrande, StatistiquesCopie(keyPlusGrande)))
            StatistiquesCopie.Remove(keyPlusGrande)

        Next

        Return personnes
    End Function

    Public Sub SauvegarderStatistiques(nom As String, score As Integer, temps As Integer)
        Dim s As Stats
        If Statistiques.ContainsKey(nom) Then
            s = Statistiques(nom)
            s.tpsCumul += temps
            s.nbPartieJoue = s.nbPartieJoue + 1
            If s.score < score Then
                s.score = score
                s.temps = temps
            ElseIf s.temps > temps And s.score = score Then
                s.temps = temps
            End If
            Statistiques.Remove(nom)
            Statistiques.Add(nom, s)
        Else
            s = New Stats()
            s.score = score
            s.temps = temps
            s.tpsCumul = temps
            s.nbPartieJoue = 1
            Statistiques.Add(nom, s)
        End If
        saveDansFichier()
    End Sub

    Public Sub LireSave()
        If Not File.Exists("Statistiques.bin") Then Exit Sub
        Statistiques.Clear()
        Using fs As New FileStream("Statistiques.bin", FileMode.Open, FileAccess.Read)
            Using br As New BinaryReader(fs)
                While fs.Position < fs.Length
                    Dim nom As String = br.ReadString()
                    Dim s As Stats
                    s.score = br.ReadInt32()
                    s.tpsCumul = br.ReadInt32()
                    s.temps = br.ReadInt32()
                    s.nbPartieJoue = br.ReadInt32()
                    Statistiques.Add(nom, s)
                End While
            End Using
        End Using

    End Sub

    Public Sub saveDansFichier()
        Using fs As New FileStream("Statistiques.bin", FileMode.OpenOrCreate, FileAccess.Write)
            Using bw As New BinaryWriter(fs)
                For Each k As String In Statistiques.Keys
                    Dim s As String = k
                    bw.Write(s)
                    bw.Write(Statistiques(k).score)
                    bw.Write(Statistiques(k).tpsCumul)
                    bw.Write(Statistiques(k).temps)
                    bw.Write(Statistiques(k).nbPartieJoue)
                Next
            End Using
        End Using
    End Sub

    Public Function getNom(i As Integer) As String
        Return Statistiques.Keys(i)
    End Function

    Public Function getScore(n As String) As Integer
        Return Statistiques(n).score
    End Function

    Public Function getScoreC(n As String) As Integer
        Return Statistiques(n).tpsCumul
    End Function

    Public Function getTemps(n As String) As Integer
        Return Statistiques(n).temps
    End Function

    Public Function getNbPartieJ(n As String) As Integer
        Return Statistiques(n).nbPartieJoue
    End Function
    Public Function nbNom() As Integer
        Return Statistiques.Count
    End Function

End Module
