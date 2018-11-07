using Mono.Data.Sqlite;
using System;
using System.Data;
using System.IO;
using UnityEngine;

/// <summary>
/// Klasa obsługująca zdarzenia związane
/// z zapytaniem do bazy danych
/// 
/// Autor: Patryk Lubartowicz
/// Projekt: VR Escape Room - projekt inżynieryjski
/// </summary>
public class Database {

    // obiekty obsługujące wymiane danych z bazą
    private SqliteConnection DBConnetion;
    private IDbCommand DBCommand;
    private IDataReader DBDataReader;

    //zmienne dostępowe
    public string connectionLink;

    /// <summary>
    /// Konstruktor klasy
    /// </summary>
    public Database()
    {
        if (Application.platform != RuntimePlatform.Android) {
            connectionLink = Application.dataPath + "/StreamingAssets/Database.db";
        } else {
            connectionLink = Application.persistentDataPath + "/Database.db";
            if (!File.Exists(connectionLink))
            {
                WWW loadDB = new WWW("jar:file://" + Application.dataPath + "!/assets/Database.db");
                while (!loadDB.isDone) { }
                File.WriteAllBytes(connectionLink, loadDB.bytes);
            }
        }

        DBConnetion = new SqliteConnection("URI=file:"+ connectionLink);
        //byc moze to zalatwi problem z polaczeniem jezeli nadal bedzie
        // connectionLink = String.Format("Data Source={0};Version=3;", pathDB)
    }

    /// <summary>
    /// Zapytanie SELECT pobierajace wybrane dane z bazy
    /// Zapytanie budowane dynamicznie.
    /// </summary>
    /// <param name="tableName"> Nazwa przeszukiwanej tabeli</param>
    /// <param name="whereColumns"> Nazwy kolumn, według których ma być szukany wynik</param>
    /// <param name="whereValues"> Wartości pól dla szukanych wynikow</param>
    /// <returns> Zwraca obiekt z wyszukanymi danymi</returns>
    public IDataReader DBSelect(string tableName, string[] whereColumns, string[] whereValues)
    {
        string sqlQuery = "SELECT * FROM " + tableName;

        if (whereColumns.Length > 0)
        {
            sqlQuery += " WHERE ";

            for (int i = 0; i < whereColumns.Length; i++)
            {
                sqlQuery += whereColumns[i] + "='" + whereValues[i] + "'";

                if ((whereColumns.Length > 1) && (i < whereColumns.Length - 1))
                {
                    sqlQuery += " AND ";
                }
            }
        }
        
        //polacz sie z baza i wykonaj polecenie
        DBConnetion.Open();
        DBCommand = DBConnetion.CreateCommand();
        DBCommand.CommandText = sqlQuery;

        //pobierz dane z bazy
        DBDataReader = DBCommand.ExecuteReader();
        
        return DBDataReader;
    }

    /// <summary>
    /// Wstawianie nowych danych do bazy danych
    /// </summary>
    /// <param name="tableName"> Nazwa przeszukiwanej tabeli</param>
    /// <param name="Columns"> Nazwy kolumn do uzupełnienia</param>
    /// <param name="Values"> Wartości uzupełnianych kolumn</param>
    /// <returns>Zwraca TRUE jezeli doda poprawnie, FALSE w przypadku bledu.</returns>
    public bool DBInsert(string tableName, string[] columns, string[] values)
    {

        string sqlQuery = "INSERT INTO " + tableName + " (";

        for (int i = 0; i < columns.Length; i++)
        {
            sqlQuery += columns[i];

            if (i < columns.Length - 1)
            {
                sqlQuery += ", ";
            }

        }

        sqlQuery += ") VALUES (";

        for (int i = 0; i < values.Length; i++)
        {
            sqlQuery += "'" + values[i] + "'";

            if (i < values.Length - 1)
            {
                sqlQuery += ", ";
            }

        }

        sqlQuery += ");";
        try
        {
            //polacz sie z baza i wykonaj polecenie
            DBConnetion.Open();
            DBCommand = DBConnetion.CreateCommand();
            DBCommand.CommandText = sqlQuery;
            DBDataReader = DBCommand.ExecuteReader();
            
            return true;
        }
        catch (System.Exception e)
        {
            Debug.Log("Problem z Insertem, " + e.ToString());
            return false;
        }
    }

    /// <summary>
    /// Funkcja zamykająca połączenie i zerowanie informacji
    /// w obiekcie.
    /// </summary>
    public void DBClose()
    {
        DBDataReader.Close();
        DBDataReader = null;
        DBCommand.Dispose();
        DBCommand = null;
        DBConnetion.Close();
        DBConnetion = null;        
    }
}
