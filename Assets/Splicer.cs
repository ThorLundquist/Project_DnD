using UnityEngine;
using UnityEditor;
using System.IO;
using System.Text;
using System;
using System.Collections.Generic;
using System.Linq;

public class TexturePostProcessor : AssetPostprocessor
{
    void OnPostprocessTexture(Texture2D texture)
    {
        TextureImporter importer = assetImporter as TextureImporter;
        importer.anisoLevel = 0;
        importer.filterMode = FilterMode.Point;
        importer.spritePixelsPerUnit = 48;
        importer.spriteImportMode = SpriteImportMode.Multiple;

        string path = importer.assetPath;
        path = path.Replace(".png", ".txt");
        var animpath = path.Replace(".txt", ".anim");
        string[] lines = LoadTxt(path);

        List<SpriteMetaData> smds = new List<SpriteMetaData>();
        if (lines != null)
        {
            foreach (var line in lines)
            {
                Debug.Log(line);
                var split = line.Split('=');
                string name = split[0].Trim();
                string coords = split[1].Trim();
                var splitCoords = coords.Split(' ');
                Debug.Log(splitCoords[0]);
                var width = int.Parse(splitCoords[2]);
                var height = int.Parse(splitCoords[3]);

                var x = int.Parse(splitCoords[0]);
                var y = texture.height - int.Parse(splitCoords[1]) - height;
                var smd = new SpriteMetaData();
                smd.rect = new Rect(x, y, width, height);
                smd.name = name;
                smds.Add(smd);
            }
        }
        importer.spritesheet = smds.ToArray();

        UnityEngine.Object asset = AssetDatabase.LoadAssetAtPath(importer.assetPath, typeof(Texture2D));
        Sprite[] sprites = AssetDatabase.LoadAllAssetsAtPath(importer.assetPath)
     .OfType<Sprite>().ToArray();

        var test = AssetDatabase.LoadAllAssetsAtPath(importer.assetPath);

        //Animation anim = new Animation();
        AnimationClip clip = GetAnimationClipFromTextures(sprites);

        AssetDatabase.CreateAsset(clip, animpath);
        if (asset)
        {
            EditorUtility.SetDirty(asset);
        }
        else
        {
            texture.anisoLevel = 0;
            texture.filterMode = FilterMode.Point;
        }
    }

    private AnimationClip GetAnimationClipFromTextures(Sprite[] sheet)
    {
        //Sprite[] sprites = smd[0].sprit; // load all sprites in "assets/Resources/sprite" folder
        AnimationClip animClip = new AnimationClip();
        animClip.frameRate = 12;   // FPS
        EditorCurveBinding spriteBinding = new EditorCurveBinding();
        spriteBinding.type = typeof(SpriteRenderer);
        spriteBinding.path = "";
        spriteBinding.propertyName = "m_Sprite";
        ObjectReferenceKeyframe[] spriteKeyFrames = new ObjectReferenceKeyframe[sheet.Length];
        for (int i = 0; i < (sheet.Length); i++)
        {
            spriteKeyFrames[i] = new ObjectReferenceKeyframe();
            spriteKeyFrames[i].time = i;
            Texture2D tex = new Texture2D((int)sheet[i].rect.width, (int)sheet[i].rect.height);
            tex.SetPixels(tex.GetPixels((int)sheet[i].rect.x, (int)sheet[i].rect.y, (int)sheet[i].rect.width, (int)sheet[i].rect.height));


            spriteKeyFrames[i].value = sheet[i];
        }
        AnimationUtility.SetObjectReferenceCurve(animClip, spriteBinding, spriteKeyFrames);

        return animClip;
    }

    private string[] LoadTxt(string fileName)
    {
        // Handle any problems that might arise when reading the text
        try
        {
            string line;
            // Create a new StreamReader, tell it which file to read and what encoding the file
            // was saved as
            StreamReader theReader = new StreamReader(fileName, Encoding.Default);
            // Immediately clean up the reader after this block of code is done.
            // You generally use the "using" statement for potentially memory-intensive objects
            // instead of relying on garbage collection.
            // (Do not confuse this with the using directive for namespace at the 
            // beginning of a class!)
            List<string> entries = new List<string>();
            using (theReader)
            {
                // While there's lines left in the text file, do this:
                do
                {
                    line = theReader.ReadLine();

                    if (line != null)
                    {
                        // Do whatever you need to do with the text line, it's a string now
                        // In this example, I split it into arguments based on comma
                        // deliniators, then send that array to DoStuff()
                        entries.Add(line);

                    }
                }
                while (line != null);
                // Done reading, close the reader and return true to broadcast success    
                theReader.Close();
                if (entries.Count > 0)
                    return (entries.ToArray());
            }
        }
        // If anything broke in the try block, we throw an exception with information
        // on what didn't work
        catch (Exception e)
        {
            Console.WriteLine("{0}\n", e.Message);
            return null;
        }

        return null;
    }
}