using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EpPathFinding.cs;
using EPF = EpPathFinding.cs;


public class grid : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
		int width = 64,height = 32; 
		//method  1
		
        // BaseGrid searchGridMap = new StaticGrid(width, height);
		// searchGridMap.SetWalkableAt(10, 20, true);
		//method 2
		bool [][] movableMatrix = new bool [width][];
		for(int widthTrav=0; widthTrav< width; widthTrav++)
		{
		   movableMatrix[widthTrav]=new bool[height];
		   for(int heightTrav=0; heightTrav < height;  heightTrav++)
		   { 
			
			if (widthTrav == 16)
				movableMatrix[widthTrav][heightTrav]=false; 
			else
				movableMatrix[widthTrav][heightTrav]=true; 
		   }  
		}
		movableMatrix[16][22]=true;
		
		
		BaseGrid searchGrid = new StaticGrid(64,32, movableMatrix);
		//jump
		JumpPointParam jpParam = new JumpPointParam(searchGrid,true, true,true,HeuristicMode.EUCLIDEAN);
		jpParam.Reset(new GridPos(10,10), new GridPos(20,10)); 
		List<GridPos> resultPathList = JumpPointFinder.FindPath(jpParam); 
			Debug.Log("dsas");
		foreach( GridPos pathpoint in resultPathList)
			Debug.Log(pathpoint);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}