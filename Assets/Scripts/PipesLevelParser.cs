using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class PipesLevelParser : MonoBehaviour
{
    public GameObject v_pipe;
    public GameObject h_pipe;
    public GameObject cross_pipe;
    void Start()
    {
        ReadString();
    }

    void Update()
    {
        
    }

    void ReadString()
    {
        string path = "Assets/Resources/pipes.txt";

        StreamReader reader = new StreamReader(path);

        string s = reader.ReadLine();
        int[] nums = System.Array.ConvertAll(s.Split(' '), int.Parse);

        float x = 0;
        float y = 0;

        float x_offset = 0.2f;
        float y_offset = 0.2f;
        for (int rows = 0; rows < nums[0]; rows++)
        {
            y+=y_offset;
            string t = reader.ReadLine();
            for (int cols = 0; cols < nums[1]; cols++)
            {
                x+=x_offset;
                char c = t[cols];
                switch (c)
                {
                    /*case '.':
                        //continue;
                        break;*/
                    case '0':
                        Debug.Log("character is Zero");
                        break;
                    case '|':
                        Debug.Log(c);
                        Instantiate(v_pipe, new Vector3(x, 1f,y), Quaternion.identity);
                        break;
                    case '-':
                        Debug.Log(c);
                        Instantiate(h_pipe, new Vector3(x, 1f, y), Quaternion.identity);
                        break;
                    case '+':
                        x += 0.1f;
                        Instantiate(cross_pipe, new Vector3(x, 1f,y), Quaternion.identity);
                        break;
                    default:
                        Debug.Log("Unknown symbol " + c.ToString());
                        break;
                }
            }
            x = 0;
        }

        reader.Close();
    }
}
