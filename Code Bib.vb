Imports System

Module Program
    Structure Buch
        Public ISBN As String
        Public Titel As String
        Public Autor As String
        Public Status As String
    End Structure

    Structure Benutzer
        Public Id As String
        Public Name As String
    End Structure

    Dim Bücher As New List(Of Buch)
    Dim Benutzer As New List(Of Benutzer)

    Sub main()

        LadeTestdaten()

        Dim eingabe As String = ""

        Do
            Console.WriteLine("===== Bibliothekssystem =====")
            Console.WriteLine("1 - Alle Bücher anzeigen")
            Console.WriteLine("2 - Alle Benutzer anzeigen")
            Console.WriteLine("3 - Neuer Benutzer")
            Console.WriteLine("4 - Buch ausleihen")
            Console.WriteLine("5 - Buch zurückgeben")
            Console.WriteLine("6 - Beenden")
            Console.Write("Auswahl: ")

            eingabe = Console.ReadLine()
            Console.WriteLine()

            If eingabe = "1" Then
                AlleBücher()
            ElseIf eingabe = "2" Then
                AlleBenutzer()
            ElseIf eingabe = "3" Then
                NeuerBenutzer()
            ElseIf eingabe = "4" Then
                BuchAusleihen()
            ElseIf eingabe = "5" Then
                BuchZurückgeben()
            ElseIf eingabe = "6" Then
                Console.WriteLine("Programm beendet.")
            Else
                Console.WriteLine("Ungültige Eingabe!")
            End If
            Console.WriteLine()
        Loop While eingabe <> "6"

    End Sub

    End Sub
    End Sub

End Module
