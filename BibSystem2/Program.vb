Option Strict On

Module Program

    ' Struktur für Benutzer
    ' Speichert Benutzer-ID und Name
    Structure UserRecord
        Dim Id As String
        Dim Name As String
    End Structure

    ' Struktur für Bücher
    ' Speichert Buchdaten und wer das Buch ausgeliehen hat
    Structure BookRecord
        Dim Isbn As String
        Dim Title As String
        Dim Author As String
        Dim Status As String
        Dim BorrowerId As String
    End Structure

    ' Rohdaten für Benutzer (werden später in ein Array umgewandelt)
    Dim userRaw As String =
        "U001,Max Johnson|" &
        "U002,Emily Smith|" &
        "U003,Daniel Brown|" &
        "U004,Laura Wilson|" &
        "U005,Michael Taylor|" &
        "U006,Sarah Anderson|" &
        "U007,James Miller|" &
        "U008,Anna Davis|" &
        "U009,Robert Clark|" &
        "U010,Linda Moore|" &
        "U011,Thomas Martin|" &
        "U012,Jessica Thompson|" &
        "U013,Kevin White|" &
        "U014,Rachel Harris|" &
        "U015,Steven Lewis"

    ' Rohdaten für Bücher
    Dim libraryRaw As String =
        "978-0-13-110362-7,Introduction to Programming,John Smith,available|" &
    "978-0-201-03801-9,Data Structures Basics,Alice Brown,available|" &
    "978-0-262-03384-8,Algorithms Explained,Thomas White,available|" &
    "978-0-321-48681-3,Software Engineering Fundamentals,Emily Johnson,available|" &
    "978-1-491-94600-8,Learning VB.NET,Michael Green,available|" &
    "978-0-596-52068-7,Clean Code,Robert Martin,available|" &
    "978-0-13-235088-4,Agile Development,James Wilson,available|" &
    "978-1-59327-584-6,Programming Logic,Sarah Miller,available|" &
    "978-0-201-70073-2,Computer Systems,David Lee,available|" &
    "978-0-321-12742-6,Object-Oriented Design,Laura Clark,available|" &
    "978-0-07-352332-3,Engineering Mathematics,Peter Adams,available|" &
    "978-0-262-16209-8,Discrete Mathematics,Brian Scott,available|" &
    "978-1-118-09387-9,Introduction to Databases,Kevin Turner,available|" &
    "978-0-596-15806-4,Operating Systems Concepts,Nancy Hall,available|" &
    "978-0-13-468599-1,Modern Software Testing,Richard Young,available|" &
    "978-1-4842-0077-9,Beginning Algorithms,Steven King,available|" &
    "978-0-321-35668-0,System Analysis and Design,Angela Moore,available|" &
    "978-0-07-337622-6,Technical Communication,Mark Taylor,available|" &
    "978-1-491-94729-6,Programming Basics,Rachel Evans,available|" &
    "978-0-13-708107-3,Introduction to Networks,Daniel Harris,available|" &
    "978-0-262-53205-1,Artificial Intelligence Basics,Helen Brooks,available|" &
    "978-1-59327-282-1,Problem Solving with Computers,Chris Baker,available|" &
    "978-0-596-51774-8,Linux Fundamentals,Paul Walker,available|" &
    "978-0-13-187325-4,Computer Architecture,Andrew Collins,available|" &
    "978-1-491-94618-3,Programming in Practice,Olivia Reed,available|" &
    "978-0-321-99278-8,Human Computer Interaction,Jason Turner,available|" &
    "978-0-07-180855-2,Information Systems,Rebecca Lewis,available|" &
    "978-1-59327-599-0,Software Development Tools,Matthew Perez,available|" &
    "978-0-596-52067-0,Coding Standards,Benjamin Foster,available|" &
    "978-0-13-117705-5,Fundamentals of Computing,Sophia Anderson,available"

    ' Arrays für Benutzer und Bücher
    Dim Users() As UserRecord
    Dim Books() As BookRecord

    Sub Main()

        ' Rohdaten werden in strukturierte Arrays umgewandelt
        Users = ParseUsers(userRaw)
        Books = ParseBooks(libraryRaw)

        Dim selection As Integer

        ' Hauptmenü läuft in einer Schleife
        Do
            Console.Clear()

            Console.WriteLine("Please choose one of the options")
            Console.WriteLine("(1) New user")
            Console.WriteLine("(2) Book variety")
            Console.WriteLine("(3) All Users")
            Console.WriteLine("(4) Borrow a book (ISBN)")
            Console.WriteLine("(5) Show borrowed books (User ID)")
            Console.WriteLine("(6) Give Back (ISBN)")
            Console.WriteLine("(7) Close")

            Console.Write("Input: ")

            Dim input As String = Console.ReadLine()

            ' Eingabe prüfen
            If Not Integer.TryParse(input, selection) Then
                Console.WriteLine("Invalid input.")
                Pause()
                Continue Do
            End If

            ' Menüauswahl
            Select Case selection

                Case 1
                    AddUser()

                Case 2
                    ShowBooks()

                Case 3
                    ShowUsers()

                Case 4
                    BorrowBook()

                Case 5
                    ShowBorrowedBooks()

                Case 6
                    GiveBack()

                Case 7
                    Console.WriteLine("Goodbye!")
                    Exit Sub

            End Select

            If selection <> 7 Then Pause()

        Loop While selection <> 7

    End Sub


    ' Wandelt den Benutzer-String in ein Benutzer-Array um
    Function ParseUsers(ByVal raw As String) As UserRecord()

        Dim parts() As String = raw.Split("|"c, StringSplitOptions.RemoveEmptyEntries)
        Dim result(parts.Length - 1) As UserRecord

        For i As Integer = 0 To parts.Length - 1

            Dim fields() As String = parts(i).Split(","c)

            If fields.Length >= 2 Then
                result(i).Id = fields(0).Trim()
                result(i).Name = fields(1).Trim()
            End If

        Next

        Return result

    End Function


    ' Wandelt den Bücher-String in ein Bücher-Array um
    Function ParseBooks(ByVal raw As String) As BookRecord()

        Dim parts() As String = raw.Split("|"c, StringSplitOptions.RemoveEmptyEntries)
        Dim result(parts.Length - 1) As BookRecord

        For i As Integer = 0 To parts.Length - 1

            Dim fields() As String = parts(i).Split(","c)

            If fields.Length >= 4 Then
                result(i).Isbn = fields(0).Trim()
                result(i).Title = fields(1).Trim()
                result(i).Author = fields(2).Trim()
                result(i).Status = fields(3).Trim()
                result(i).BorrowerId = ""
            End If

        Next

        Return result

    End Function


    ' Zeigt alle Benutzer an
    Sub ShowUsers()

        For i As Integer = 0 To Users.Length - 1
            Console.WriteLine(Users(i).Id & "," & Users(i).Name)
        Next

    End Sub


    ' Zeigt alle Bücher und ihren Status an
    Sub ShowBooks()

        For i As Integer = 0 To Books.Length - 1

            If Books(i).Status = "available" Then
                Console.WriteLine(Books(i).Title & " - available")
            Else
                Console.WriteLine(Books(i).Title & " - lend to " & Books(i).BorrowerId)
            End If

        Next

    End Sub


    ' Fügt einen neuen Benutzer hinzu
    Sub AddUser()

        Console.Write("First name: ")
        Dim first As String = Console.ReadLine().Trim()

        Console.Write("Last name: ")
        Dim last As String = Console.ReadLine().Trim()

        Dim maxNum As Integer = 0

        ' höchste Benutzer-ID finden
        For i As Integer = 0 To Users.Length - 1

            Dim id As String = Users(i).Id

            If id.StartsWith("U") Then

                Dim n As Integer

                If Integer.TryParse(id.Substring(1), n) Then
                    If n > maxNum Then maxNum = n
                End If

            End If

        Next

        ' neue ID generieren
        Dim newId As String = "U" & (maxNum + 1).ToString("D3")

        ' Array vergrößern
        ReDim Preserve Users(Users.Length)

        Users(Users.Length - 1).Id = newId
        Users(Users.Length - 1).Name = first & " " & last

        Console.WriteLine("Added: " & newId)

    End Sub


    ' Buch ausleihen
    Sub BorrowBook()

        Console.Write("ISBN: ")
        Dim isbn As String = Console.ReadLine().Trim()

        Console.Write("User ID: ")
        Dim userId As String = Console.ReadLine().Trim()

        Dim userIndex As Integer = FindUserIndex(userId)

        If userIndex = -1 Then
            Console.WriteLine("User not found.")
            Return
        End If

        Dim bookIndex As Integer = FindBookIndex(isbn)

        If bookIndex = -1 Then
            Console.WriteLine("Book not found.")
            Return
        End If

        If Books(bookIndex).Status <> "available" Then
            Console.WriteLine("Book not available.")
            Return
        End If

        Books(bookIndex).Status = "lend"
        Books(bookIndex).BorrowerId = userId

        Console.WriteLine("Book borrowed successfully.")

    End Sub


    ' Zeigt alle Bücher eines bestimmten Benutzers
    Sub ShowBorrowedBooks()

        Console.Write("User ID: ")
        Dim userId As String = Console.ReadLine().Trim()

        For i As Integer = 0 To Books.Length - 1

            If Books(i).BorrowerId = userId Then
                Console.WriteLine(Books(i).Title)
            End If

        Next

    End Sub


    ' Buch zurückgeben
    Sub GiveBack()

        Console.Write("ISBN: ")
        Dim isbn As String = Console.ReadLine().Trim()

        Dim bookIndex As Integer = FindBookIndex(isbn)

        If bookIndex = -1 Then
            Console.WriteLine("Book not found.")
            Return
        End If

        If Books(bookIndex).Status <> "lend" Then
            Console.WriteLine("This book is not borrowed.")
            Return
        End If

        Books(bookIndex).Status = "available"
        Books(bookIndex).BorrowerId = ""

        Console.WriteLine("Book returned successfully.")

    End Sub


    ' Sucht einen Benutzer im Array
    Function FindUserIndex(ByVal userId As String) As Integer

        For i As Integer = 0 To Users.Length - 1
            If Users(i).Id = userId Then Return i
        Next

        Return -1

    End Function


    ' Sucht ein Buch anhand der ISBN
    Function FindBookIndex(ByVal isbn As String) As Integer

        For i As Integer = 0 To Books.Length - 1
            If Books(i).Isbn = isbn Then Return i
        Next

        Return -1

    End Function


    ' Wartet auf eine Taste (Pause im Menü)
    Sub Pause()

        Console.WriteLine()
        Console.WriteLine("Press any key...")
        Console.ReadKey()

    End Sub

End Module