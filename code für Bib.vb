Imports System

Module Program
    Structure Buch 'das Buch Strukturieren
        Public ISBN As String
        Public Titel As String
        Public Autor As String
        Public Status As String
    End Structure

    Structure Benutzer
        Public Id As String
        Public Name As String
    End Structure

    Dim Bücher As New List(Of Buch) 'Liste der Bücher
    Dim benutzer As New List(Of Benutzer) 'Liste der Benutzer

    Sub Main()

        LadeTestdaten()

        Dim Auswahl As String = ""

        Do
            Console.WriteLine("==== Bibliotheksverwaltung ====")
            Console.WriteLine("1 - Alle Bücher anzeigen")
            Console.WriteLine("2 - Alle Benutzer anzeigen")
            Console.WriteLine("3 - Neuer Benutzer")
            Console.WriteLine("4 - Buch ausleihen")
            Console.WriteLine("5 - Buch zurückgeben")
            Console.WriteLine("6 - Programm Beenden")
            Console.Write("Auswahl: ")

            Auswahl = Console.ReadLine()
            Console.WriteLine()

            Select Case Auswahl
                Case "1"
                    AlleBücher()
                Case "2"
                    AlleBenutzer()
                Case "3"
                    NeuerBenutzer()
                Case "4"
                    BuchAusleihen()
                Case "5"
                    BuchZurückgeben()
                Case "6"
                    Console.WriteLine("Programm wird beendet.")
                Case Else
                    Console.WriteLine("Ungültige Eingabe! Bitte neu versuchen")
            End Select

            Console.WriteLine()

        Loop While Auswahl <> "6"

    End Sub

End Module
