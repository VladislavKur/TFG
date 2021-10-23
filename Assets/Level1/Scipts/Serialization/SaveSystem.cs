using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveSystem 
{

    public static void Save (PlayerMov player)
    {
        BinaryFormatter formater = new BinaryFormatter();
       
        string pathFile = Application.persistentDataPath  + "/player.fun";

        FileStream stream = new FileStream(pathFile, FileMode.Create);
        //objects to save
        PlayerData data = new PlayerData(player);
       

        formater.Serialize(stream, data);

        stream.Close();

        
    }
   

    public static PlayerData Load()
    {

        string pathFile = Application.persistentDataPath + "/player.fun";

        if (File.Exists(pathFile))
        {
            BinaryFormatter formater = new BinaryFormatter();

            FileStream stream = new FileStream(pathFile, FileMode.Open);
            PlayerData data = formater.Deserialize(stream) as PlayerData;
            stream.Close();
            return data;
        }
        else
        {
            Debug.LogError("Save file not found in " + pathFile);
            return null;
        }
       


    }



    public static void SaveHeart(List<CorazonVida> corazones)
    {
        BinaryFormatter formater = new BinaryFormatter();

        string pathFile = Application.persistentDataPath + "/heart.fun";

        FileStream stream = new FileStream(pathFile, FileMode.Create);
        //objects to save

        HeartData data = new HeartData(corazones);

        formater.Serialize(stream, data);

        stream.Close();


    }
    public static HeartData LoadCorazon ()
    {


        string pathFile = Application.persistentDataPath + "/heart.fun";

        if (File.Exists(pathFile))
        {
            BinaryFormatter formater = new BinaryFormatter();

            FileStream stream = new FileStream(pathFile, FileMode.Open);
            HeartData data = formater.Deserialize(stream) as HeartData;
            
            stream.Close();
            return data;
        }
        else
        {
            Debug.LogError("Save Heart file not found in " + pathFile);
            return null;
        }
    }

}
