using UnityEngine;
using System.Collections;

public class TileObject : MonoBehaviour {

	// Materials for tile object (most likely will change this to textures in future)
	public Material unassignedMat;
	public Material walkwayMat;
	public Material rocksMat;
	public Material treesMat;
	public Material discoveredMat;
	public Material duggedtreasureMat;

	public int type; // what kind of tile is it?
	public Vector3 loc; // location of tile
	public  bool isTreasure; // is it a treasure

	// tile types 
	public  enum TileType {
		UNASSIGNED=-1,
		PlayerSpawn=0,
		Walkway=1,
		Rock=2,
		Trees=3,
		HiddenTreasure=4,
		DiscoveredTreasure=5,
		DuggedUpTreasure=6
	}

	[HideInInspector]
	public  TileObject North, South, East, West;// so we can access the tiles neighbours quickly
	private TileObject[]Neighbours; // so we can access the tiles neighbours quickly
	
	private Renderer rend; // allows us to edit how the object is displayed
	private bool scanned; // has it been scanned
	
	// Constructor
	public TileObject(){
		scanned = false;
		loc = new Vector3 ();
	}

	// switches object based on type
	public void  Material ()
	{
		rend = gameObject.GetComponent<Renderer> ();
		
		if (rend == null) {
			//	Debug.Log ("root null!");
		}

		switch (type){
		case (int)TileType.UNASSIGNED:rend.material = unassignedMat;
			break;
		case (int)TileType.PlayerSpawn:rend.material = walkwayMat;
			break;
		case (int)TileType.Walkway:rend.material = walkwayMat;
			break;
		case (int)TileType.Rock:rend.material = rocksMat;
			break;
		case (int)TileType.Trees:rend.material = treesMat;
			break;
		case (int)TileType.HiddenTreasure:rend.material = walkwayMat;
			break;
		case (int)TileType.DiscoveredTreasure:rend.material= discoveredMat;
			break;
		case (int)TileType.DuggedUpTreasure:rend.material= duggedtreasureMat;
			break;
		default: rend.material = unassignedMat;
			break;
		}
	}


	public void Scanning (TileObject[] neighbourhood){
		foreach (TileObject tile in neighbourhood){
			if (tile!=null){tile.scanned = true;}
			if (tile.isTreasure) {
				tile.type= (int) TileType.DiscoveredTreasure;
				tile.Material();
			}
		}
	}

	public void Neighbourhood (){
		Neighbours= new TileObject[4];
		Neighbours [0] = North;
		Neighbours [1] = South;
		Neighbours [2] = East;
		Neighbours [3] = West;
	}






	
}
