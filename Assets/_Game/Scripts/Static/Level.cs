using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class Level
{
    public static bool CheckPathExist(int id)
    {
        string path = StringCache.Level.FILE_PATH + id.ToString() + StringCache.Level.FILE_EXTEND;
        return File.Exists(path);
    }

    public static List<Item> GetLevel(int id)
    {
        List<Item> map = new();
        string path = StringCache.Level.FILE_PATH + id.ToString() + StringCache.Level.FILE_EXTEND;

        using (StreamReader sr = new StreamReader(path))
        {
            string line;

            while ((line = sr.ReadLine()) != null)
            {
                string[] bits = line.Split(' ');
                int type = int.Parse(bits[0]);
                float posX = float.Parse(bits[1]);
                float posY = float.Parse(bits[2]);
                float posZ = float.Parse(bits[3]);
                float rotaX = float.Parse(bits[4]);
                float rotaY = float.Parse(bits[5]);
                float rotaZ = float.Parse(bits[6]);

                map.Add(new((ItemType)type, new Vector3(posX, posY, posZ), new Vector3(rotaX, rotaY, rotaZ)));
            }
        }

        return map;
    }
}
