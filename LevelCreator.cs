using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class LevelCreator : MonoBehaviour {

	public GameObject floorSp;
	public GameObject WallSp;

	public int MaxTiles;

	public int MaxWalls;

	public float TileSize;

	private int oldrnd;

	private List<GameObject> Tiles = new List<GameObject>();

	private Vector3 Position;


	public float TimeToCreate = 0.1f;

	// Use this for initialization
	void Start () {
		StartCoroutine(CreateLevel());
	}
	

	IEnumerator CreateLevel(){
		 

		for(int i = 0; i <= MaxTiles; i++){
			
			GameObject Tile = Instantiate(floorSp, new Vector3 (0, 0, 0),Quaternion.identity) as GameObject;
			

			if(Tiles.Count > 0){
				for(int e = 0; e < Tiles.Count; e++){
					int rnd = Mathf.RoundToInt(Random.Range(0,4));
					
						switch(rnd){
							case 0:
								Position += new Vector3(+TileSize,0,0);
							break;
							case 1:
								Position += new Vector3(-TileSize,0,0);
							break;
							case 2:
								Position += new Vector3(0,+TileSize,0);
							break;
							case 3:
								Position += new Vector3(0,-TileSize,0);
							break;
							default:
								Position += new Vector3(+TileSize,0,0);
							break;
						}

					bool taken = Tiles.Exists(x => x.transform.position == Position);
					if(!taken){
						e = Tiles.Count;
					}
				}
			}
	
				

			Tile.transform.position = Position;
			transform.position = Position;

			
			Tiles.Add(Tile);
			yield return new WaitForSeconds(TimeToCreate);
		}
		
	}


}
