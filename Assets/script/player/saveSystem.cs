using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class saveSystem
{
    public static void SavePlayer(playerHealth playerH){
        BinaryFormatter formatter = new BinaryFormatter();

        string path = Application.persistentDataPath + "/player.save";
        FileStream stream = new FileStream(path, FileMode.Create);

        playerData data = new playerData(playerH);

        formatter.Serialize(stream, data);
        stream.Close();
        
    }
    public static playerData LoadPlayer(){
        string path = Application.persistentDataPath + "/player.save";
        if(File.Exists(path)){
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            playerData data = formatter.Deserialize(stream) as playerData;
            stream.Close();

            return data;
        }else {
            Debug.LogError("Save file not found in" + path);
            return null;
        }
    }
}
