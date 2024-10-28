using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelBuilder : MonoBehaviour
{
    [SerializeField]
    public Sprite[] sprites; // Assign this in the inspector
    public float cellSize = 1.0f; // The size of each cell
    int Vertical, Horizontal; 
    //public GameObject tile; 

   

    void Start()
    {
        int[,] levelMap =
        {
            {1,2,2,2,2,2,2,2,2,2,2,2,2,7},
            {2,5,5,5,5,5,5,5,5,5,5,5,5,4},
            {2,5,3,4,4,3,5,3,4,4,4,3,5,4},
            {2,6,4,0,0,4,5,4,0,0,0,4,5,4},
            {2,5,3,4,4,3,5,3,4,4,4,3,5,3},
            {2,5,5,5,5,5,5,5,5,5,5,5,5,5},
            {2,5,3,4,4,3,5,3,3,5,3,4,4,4},
            {2,5,3,4,4,3,5,4,4,5,3,4,4,3},
            {2,5,5,5,5,5,5,4,4,5,5,5,5,4},
            {1,2,2,2,2,1,5,4,3,4,4,3,0,4},
            {0,0,0,0,0,2,5,4,3,4,4,3,0,3},
            {0,0,0,0,0,2,5,4,4,0,0,0,0,0},
            {0,0,0,0,0,2,5,4,4,0,3,4,4,0},
            {2,2,2,2,2,1,5,3,3,0,4,0,0,0},
            {0,0,0,0,0,0,5,0,0,0,4,0,0,0},
        };

        Vertical = (int)Camera.main.orthographicSize; 
        Horizontal = Vertical * (Screen.width / Screen.height); 
        PlaceSprites(levelMap);
    }

    void PlaceSprites(int[,] map)
    {
        int rows = map.GetLength(0);
        int cols = map.GetLength(1);

        for (int y = 0; y < rows; y++)
        {
            for (int x = 0; x < cols; x++)
            {
                int spriteIndex = map[y, x]; // Array is 0-indexed
                
                Vector3 position = new Vector3(x * cellSize - (float)(1.1*Vertical), -y * cellSize + (float)(0.499999*Horizontal), 0);
                Quaternion rotation = Quaternion.identity;
                // Determine rotation based on adjacent sprites (if necessary)
                if (spriteIndex == 2 && y == 0 || y == 9 || y== 13)
                {
                    rotation = Quaternion.AngleAxis(-90, Vector3.forward);
                }

                if(spriteIndex == 4 && (y== 2|| y== 4 || y== 6) && x != 13)
                {
                    rotation = Quaternion.AngleAxis(-90, Vector3.forward);
                }

                if(spriteIndex == 4 && (y == 7) && x != 8  && x != 7 )
                {
                    rotation = Quaternion.AngleAxis(-90, Vector3.forward);
                }

                if(spriteIndex == 4 && (y == 9) && (x == 7 || x == 13))
                {
                        rotation = Quaternion.identity;
                }

                if(spriteIndex == 4 && (y == 6) && (x == 13))
                {
                        rotation = Quaternion.AngleAxis(-90, Vector3.forward);
                }

                if(spriteIndex == 4 && (y == 10) && (x == 9 || x == 10))
                {
                    rotation = Quaternion.AngleAxis(-90, Vector3.forward);
                }

                if(spriteIndex == 4 && (y == 12) && (x == 11 || x == 12))
                {
                    rotation = Quaternion.AngleAxis(-90, Vector3.forward);
                }

                if(spriteIndex == 4 && (y == 13) && (x == 10))
                {
                        rotation = Quaternion.identity;
                }

                if(spriteIndex == 1 && y == 9 && x == 0)
                {
                    rotation = Quaternion.AngleAxis(90, Vector3.forward);
                }else if (spriteIndex == 1 && y == 9 && x == 5)
                {
                    rotation = Quaternion.AngleAxis(270, Vector3.forward);
                }

                if(spriteIndex == 1 && y == 13 && x == 5)
                {
                    rotation = Quaternion.AngleAxis(180, Vector3.forward);
                }

                if(spriteIndex == 3 && (y == 4) && (x == 2 || x == 7 || x == 13))
                {
                    rotation = Quaternion.AngleAxis(90, Vector3.forward);
                }

                if(spriteIndex == 3 && (y == 2) && (x == 5 || x == 11))
                {
                    rotation = Quaternion.AngleAxis(270, Vector3.forward);
                }

                if(spriteIndex == 3 && (y == 10) && ( x == 13))
                {
                    rotation = Quaternion.AngleAxis(270, Vector3.forward);
                }

                if(spriteIndex == 3 && (y == 4) && (x == 5 || x == 11))
                {
                    rotation = Quaternion.AngleAxis(180, Vector3.forward);
                }

                if(spriteIndex == 3 && (y == 6) && (x == 5 || x == 8))
                {
                    rotation = Quaternion.AngleAxis(270, Vector3.forward);
                }

                if(spriteIndex == 3 && (y == 7) && (x == 2 || x == 10))
                {
                    rotation = Quaternion.AngleAxis(90, Vector3.forward);
                }

                if(spriteIndex == 3 && (y == 7) && (x == 5))
                {
                        rotation = Quaternion.AngleAxis(180, Vector3.forward);
                }

                if(spriteIndex == 3 && (y == 9) && (x == 8))
                {
                    rotation = Quaternion.AngleAxis(90, Vector3.forward);
                }

                if(spriteIndex == 3 && (y == 10) && (x == 11))
                {
                    rotation = Quaternion.AngleAxis(180, Vector3.forward);
                }
                if(spriteIndex == 3 && (y == 10) && (x == 13))
                {
                    rotation = Quaternion.AngleAxis(90, Vector3.forward);
                }
                if(spriteIndex == 3 && (y == 13) && (x == 7))
                {
                    rotation = Quaternion.AngleAxis(90, Vector3.forward);
                }

                if(spriteIndex == 3 && (y == 13) && (x == 8))
                {
                    rotation = Quaternion.AngleAxis(180, Vector3.forward);
                }

                if(spriteIndex == 3 && (y == 7) && (x == 13))
                {
                    rotation = Quaternion.AngleAxis(270, Vector3.forward);
                }

                // Instantiate sprite
                GameObject spriteObject = new GameObject("Sprite_" + spriteIndex, typeof(SpriteRenderer));
                spriteObject.transform.position = position;
                spriteObject.transform.rotation = rotation;
                spriteObject.transform.parent = transform; // Attach to LevelGenerator
                SpriteRenderer renderer = spriteObject.GetComponent<SpriteRenderer>();
                renderer.sprite = sprites[spriteIndex];
            }
        }
    }

    void Update()
    {

    }
}
