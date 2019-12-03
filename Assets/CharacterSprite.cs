using UnityEngine;
using UnityEditor;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System;
using System.Threading;

public class CharacterSprite : MonoBehaviour
{
    private static int totalSprites = 2; // change depending on the total sprites in this batch!

    [MenuItem("EditorHelper/SliceSprites")]
     static void SliceSprites()
     {
        

        Sprite[] Sproits = new Sprite[totalSprites];
         //Texture2D[] textures = new Texture2D[totalSprites];
 
         for (int z = 1; z < totalSprites; z++)
         {
            //string path = AssetDatabase.GetAssetPath(textures[z]);
            string path = AssetDatabase.GetAssetPath(Sproits[z]);
           
            try
            {
                // path is Assets/Resources/Sprites/Sprite (1).png
                // Sproits[z] = Resources.Load<Sprite>(path);

                object[] loadedSprites = Resources.LoadAll("Sprites", typeof(Sprite));
                Sproits = new Sprite[loadedSprites.Length];

                TextureImporter ti = null;

                ti = AssetImporter.GetAtPath(path) as TextureImporter;
                
                ti.isReadable = true;
                ti.spriteImportMode = SpriteImportMode.Multiple;

                List<SpriteMetaData> newData = new List<SpriteMetaData>();

                int SliceWidth = 64;
                int SliceHeight = 64;
                Debug.Log("You got this far");


                //for (int i = 0; i < Sproits[z].width; i += SliceWidth)
                //{
                //    for (int j = Sproits[z].height; j > 0; j -= SliceHeight)
                //    {
                //        SpriteMetaData smd = new SpriteMetaData();
                //        smd.pivot = new Vector2(0.5f, 0.5f);
                //        smd.alignment = 9;
                //        smd.name = (Sproits[z].height - j) / SliceHeight + ", " + i / SliceWidth;
                //        smd.rect = new Rect(i, j - SliceHeight, SliceWidth, SliceHeight);

                //        newData.Add(smd);
                //    }
                //}

               // ti.spritesheet = newData.ToArray();
                AssetDatabase.ImportAsset(path, ImportAssetOptions.ForceUpdate);
            }
            catch (NullReferenceException ex)
            {
                Debug.Log("Something went wrong " + ex);                
            }
         }
         Debug.Log("Done Slicing!");
     }
}

