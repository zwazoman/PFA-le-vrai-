using System.IO;
using UnityEditor;
using UnityEngine;

public static class DialogueDirectory
{

    [MenuItem("DialogueSystem/rebuild Dialogue Directory")]

    static void Rebuild()
    {
        Debug.Log(Directory.GetCurrentDirectory());
        string[] files = Directory.GetFiles("Assets/scripts/DialogueSystem/dialogues", "*.cs");
        string[] FileNames = new string[] { "je meurs","ta mere","la pute", Path.GetFileName(files[0]).Substring(0, Path.GetFileName(files[0]).Length-3) };
        PlayerPrefs.SetString("DialogueRef_" + 0, FileNames[0]);
        //Path.GetFileName(files[0]) };
    }

    public static string getClassNameAt(int index)
    {
        return PlayerPrefs.GetString("DialogueRef_" + index);
    }
    //FileNames = files.ToArray();
}




