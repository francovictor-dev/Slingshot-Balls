using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mono.Data.Sqlite;
using System.Data;
using System;
using System.IO;
using UnityEngine.Networking;
using UnityEngine.UI;

public class DataBase : MonoBehaviour
{
    private IDbConnection conn;
    private IDbCommand cmd;
    private IDataReader reader;

    private string platformPath;
    private readonly string databaseFolder = "/StreamingAssets";
    private readonly string dbName = "/SBDatabase.s3db";

    private string databasePath;

    //public Text text;
    // Start is called before the first frame update
    void Awake()
    {
        ToValidadePath(); 
    }
    private void Update()
    {
     
    }

    public int QueryInt(string campo)
    {
        conn = new SqliteConnection(databasePath);
        cmd = conn.CreateCommand();
        conn.Open();
        cmd.CommandText = "SELECT "+campo+" FROM Player;";
        reader = cmd.ExecuteReader();
        int res = 0;
        while (reader.Read())
        {
            res = reader.GetInt32(0);  
        }
        reader.Close();
        reader = null;
        conn.Close();
        cmd.Dispose();
        cmd = null;
        conn = null;
        return res;
    }

    public int QueryInt(string campo, string tabela)
    {
        conn = new SqliteConnection(databasePath);
        cmd = conn.CreateCommand();
        
        conn.Open();
        cmd.CommandText = "SELECT " + campo + " FROM " + tabela + ";";
        reader = cmd.ExecuteReader();
        int res = 0;
        while (reader.Read())
        {
            res = reader.GetInt32(0);
        }
        reader.Close();
        reader = null;
        conn.Close();
        cmd.Dispose();
        cmd = null;
        conn = null;
        return res;
    }

    public int QueryInt(string campo, string tabela, string campo2, string valor)
    {
        conn = new SqliteConnection(databasePath);
        cmd = conn.CreateCommand();
        conn.Open();
        cmd.CommandText = "SELECT " + campo + " FROM " + tabela + " WHERE " + campo2 + "='" + valor + "';";
        reader = cmd.ExecuteReader();
        int res = 0;
        while (reader.Read())
        {
            res = reader.GetInt32(0);
        }
        reader.Close();
        reader = null;
        conn.Close();
        cmd.Dispose();
        cmd = null;
        conn = null;
        return res;
    }

    public string QueryString(string campo, string tabela, string campo2, string valor)
    {
        conn = new SqliteConnection(databasePath);
        cmd = conn.CreateCommand();
        conn.Open();
        cmd.CommandText = "SELECT " + campo + " FROM " + tabela + " WHERE " + campo2 + "='" + valor +"';";
        reader = cmd.ExecuteReader();
        string res = null;
        while (reader.Read())
        {
            res = reader.GetString(0);
        }
        reader.Close();
        reader = null;
        conn.Close();
        cmd.Dispose();
        cmd = null;
        conn = null;
        return res;
    }

    public void UpdateBd(int valor)
    {
        IDbConnection conn;
        IDbCommand cmd;

        conn = new SqliteConnection(databasePath);
        cmd = conn.CreateCommand();
        conn.Open();
        cmd.CommandText = "UPDATE Player SET pontos = " + valor + " WHERE id = 1;";
        cmd.ExecuteScalar();
        conn.Close();
        cmd = null;


    }

    public void UpdateBd(string tabela, string campo, string valor, string condicao, string valorCondicao)
    {
        IDbConnection conn;
        IDbCommand cmd;

        conn = new SqliteConnection(databasePath);
        cmd = conn.CreateCommand();
        conn.Open();
        cmd.CommandText = 
            "UPDATE " + tabela + " SET " + campo + " = '" + valor + "' WHERE " + condicao + " = '" + valorCondicao + "';";
        cmd.ExecuteScalar();
        conn.Close();
        cmd = null;
    }

    public void InsertBd(string tabela, string nome)
    {
        IDbConnection conn;
        IDbCommand cmd;
        
        conn = new SqliteConnection(databasePath);
        
        cmd = conn.CreateCommand();
        conn.Open();
        cmd.CommandText = "INSERT INTO "+tabela+"(id, nome, escolhido, id_player) VALUES " +
            "((select MAX(id) from '" + tabela + "') + 1,'" + nome+"', '0', 1)";
        cmd.ExecuteScalar();
        conn.Close();
        cmd = null;
    }

    private void ToValidadePath()
    {
        

        /// Set path according to platform.
        if (Application.platform == RuntimePlatform.Android)
        {
            platformPath = Application.persistentDataPath;

            /// Looks for the DB in the persistent memory
            /// on Android.
            /// 
            if (!File.Exists(platformPath + dbName))
            {
                //text.text = "File doesn't exists!";
                StartCoroutine(GetDatabaseForAndroid());
            }

            databasePath = Path.Combine("URI=file:" + platformPath + dbName);
           
        }
        else
        {
            platformPath = Application.dataPath;
            databasePath = Path.Combine("URI=file:" + platformPath + databaseFolder + dbName);
           
        }
    }

    private IEnumerator GetDatabaseForAndroid()
    {
        string path = Path.Combine("jar:file://" + Application.dataPath + "!/assets" + dbName);

        UnityWebRequest unityWebRequest = UnityWebRequest.Get(path);

        yield return unityWebRequest.SendWebRequest();

        while (!unityWebRequest.isDone) { }

        try
        {
            /// Retrieve results as binary data.
            byte[] data = unityWebRequest.downloadHandler.data;

            /// Writes the DB in the persistent memory.
            File.WriteAllBytes(Path.Combine(Application.persistentDataPath + dbName), data);
        }
        catch (Exception ex)
        {
            Debug.Log(ex.Message);
        }
    }
}
