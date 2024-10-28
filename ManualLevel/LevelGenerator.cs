using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    public Sprite[] sprites; // Assign sprites in the Inspector
    public float cellSize = 1.0f; // The size of each cell

    // Original level map
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

    int rows = levelMap.GetLength(0);
    int cols = levelMap.GetLength(1);

    int[,] fullMap = new int[rows*2, cols*2];

    void Start()
    {
        // Delete existing level
        GameObject[] levelObjects = GameObject.FindGameObjectsWithTag("LevelMap");
        foreach (GameObject obj in levelObjects)
        {
            Destroy(obj);
        }

        
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                fullMap[i, j] = levelMap[i, j];
            }
        }

        
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                
                fullMap[i, j + cols] = levelMap[i, cols - 1 - j];
               
                fullMap[i + rows, j] = levelMap[rows - 1 - i, j];
                
                fullMap[i + rows, j + cols] = levelMap[rows - 1 - i, cols - 1 - j];
            }
        }
      
        // Generate level
        GenerateLevel();
    }

    void GenerateLevel()
    {
        
        for (int y = 0; y < rows; y++)
        {
            for (int x = 0; x < cols; x++)
            {
                int spriteIndex = levelMap[y, x];
                if (spriteIndex >= 0 && spriteIndex < sprites.Length)
                {
                    Vector3 position = new Vector3(x * cellSize, -y * cellSize, 0);
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
                            rotation = Quaternion.identity;
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

                    if(spriteIndex == 3 && (y == 7) && (x == 5 || x == 13))
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

        // Mirror level
        MirrorLevel();
    }

    void MirrorLevel()
    {
        // Horizontal mirroring
        MirrorHorizontal();

        // Vertical mirroring
        MirrorVertical();
    }

    void MirrorHorizontal()
    {
        // Duplicate and flip sprites horizontally
        // ...
    }

    void MirrorVertical()
    {
        // Duplicate and flip sprites vertically, excluding the bottom row
        // ...
    }
}