using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveSystem {
    
    public static void SaveGame(int score){
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/score.bin";
        FileStream stream = new FileStream(path, FileMode.Create);
        formatter.Serialize(stream, score);
        stream.Close();
    }

    public static int LoadData(){
        string path = Application.persistentDataPath+"/score.bin";
        if (File.Exists(path)){
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);
            int score = (int) formatter.Deserialize(stream);
            stream.Close();
            return score;
        }
        else{
            return 0;
        }
    }
}