using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection.Emit;
using System.Text.RegularExpressions;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

public static class DialogueDirectory
{
    public static string[] FileNames;

    [MenuItem("DialogueSystem/rebuild Dialogue Directory")]
    static void Rebuild()
    {
        Debug.Log(Directory.GetCurrentDirectory());
        string[] files = Directory.GetFiles( "Assets/scripts/DialogueSystem/dialogues","*cs" );
        for (int i =0;i< files.Count() -1;i++)
        {
            string actualName = "";
            for(int j = files[i].Length - 1-3; i >= 0; i--)
            {
                if(files[i][j] == '\\' )break; else actualName = files[i][j] + actualName;
            }
            files[i] = actualName;
            Debug.Log("nom trouvé: ");
        }
        FileNames = files.ToArray();
    }




}