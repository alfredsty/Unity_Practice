using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Board : MonoBehaviour
{
    [Serializable] // (직렬화) 
    public class Count
    {
        public int minimum; // 오브젝트의 최소값 
        public int maximum; // 오브젝트의 최대값 

        public Count(int min, int max) // 최소값과 최대값에 값을 넣어주기 위해 파라미터 min,max를 추가함. 
        {
            minimum = min;
            maximum = max;
        }
    }

    public int columns = 8; // 열을 8로 초기화
    public int rows = 8;    // 행을 8로 초기화
    // 8x8 게임보드를 가짐 
    public Count wallCount = new Count(5, 9); // 최소 5개의 벽, 최대 9개의 벽이 있음 
    public Count foodCount = new Count(1, 5); // 최소 1개의 음식아이템, 최대 5개의 음식아이템이 있음 
    public GameObject exit;

    public GameObject[] floorTiles;
    public GameObject[] wallTiles;
    public GameObject[] foodTiles;
    public GameObject[] enemyTiles;
    public GameObject[] outerWallTiles;

    private Transform boardHolder; //Hierarchy를 초기화하기 위해 만듦
    private List<Vector3> gridPositions = new List<Vector3>();  // 오브젝트가 해당 장소에 있는지 없는지를 확인함

    void InitializeList()
    {
        gridPositions.Clear();

        for(int x  = 1; x < columns -1; x++) // 3차원 벡터로 지정된 위치값을 리스트로 채움 
        {
            for(int y = 1; y < rows -1; y++)
            {
                gridPositions.Add(new Vector3(x, y, 0f));
            }
        }
    }

    void BoardSetup() //바깥과 바닥 벽을 생성 
    {
        boardHolder = new GameObject("Board").transform;
        for(int x = -1; x < columns +1; x++)
        {
            for(int y = -1; y < rows +1; y++)
            {
                GameObject toInstantiate = floorTiles[Random.Range(0, floorTiles.Length)]; //타일 오브젝트 변수 선언
                if (x == -1 || x == columns || y == -1 || y == rows)
                    toInstantiate = outerWallTiles[Random.Range(0, floorTiles.Length)]; // 바깥 벽 랜덤타일에서 인스턴스 준비

                GameObject instance = Instantiate(toInstantiate, new Vector3(x,y,0f),Quaternion.identity);
            }
        }
    }

    void Start()
    {

    }


    void Update()
    {

    }
}
