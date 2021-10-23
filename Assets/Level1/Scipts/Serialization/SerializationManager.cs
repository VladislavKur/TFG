using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class SerializationManager
{

 /*   public static bool Save(string nameSave, object saveData)
    {
        BinaryFormatter formater = GetBinaryFormater();

        if (!Directory.Exists(Application.persistentDataPath + "/saves"))
        {
            Directory.CreateDirectory(Application.persistentDataPath + "/saves");
        }

        string path = Application.persistentDataPath + "/saves/" + nameSave + ".save";

        FileStream file = File.Create(path);

        formater.Serialize(file, saveData);
        file.Close();

        return true;
    }

    public static BinaryFormatter GetBinaryFormater()
    {
        BinaryFormatter formater = new BinaryFormatter();

        return formater;
    }

    public static object Load(string path)
    {
        if (!File.Exists(path))
        {
            return null;
        }

        BinaryFormatter formater = GetBinaryFormater();

        FileStream file = File.Open(path, FileMode.Open);


        try
        {
            object save = formater.Deserialize(file);
            file.Close();
            return save;
        }
        catch
        {
            Debug.LogErrorFormat("Failed to Load the file at {0} " + path);
            file.Close();
            return null;
        }

    }
 */
}
