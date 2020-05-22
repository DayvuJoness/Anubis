using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class Saver : MonoBehaviour
{
    public static List<Game> savedAnubis = new List<Game>();

    //методы загрузки и сохранения статические, поэтому их можно вызвать откуда угодно
    /*public static void Save()
    {
        Saver.savedGames.Add(Game.current);
        BinaryFormatter bf = new BinaryFormatter();
        //Application.persistentDataPath это строка; выведите ее в логах и вы увидите расположение файла сохранений
        FileStream file = File.Create(Application.persistentDataPath + "/savedAnubis.hf");
        bf.Serialize(file, Saver.savedGames);
        file.Close();
    }

    public static void Load()
    {
        if (File.Exists(Application.persistentDataPath + "/savedAnubis.hf"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/savedAnubis.hf", FileMode.Open);
            Saver.savedGames = (List<Game>)bf.Deserialize(file);
            file.Close();
        }
    }*/
}
