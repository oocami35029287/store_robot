using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

public class GridManager : MonoBehaviour {
    public static GridManager Instance;
    [SerializeField] private int _width = 50, _height = 50;
    [SerializeField] private Tile _Tile;
    public float TileSize = 0.3f;
	public ButtonHandler _btHandler;
	public ObjectOccupation _objectOccupation;
    //[SerializeField] private Transform _cam;

    public Dictionary<Vector2, Tile> _tiles;
	public List<ObjectOccupation> _occupationList;

    void Awake() {
        Instance = this;
    }
	void Start(){
		_occupationList = new List<ObjectOccupation>();
		GenerateGrid();
	}
	void Update(){
		
		
		if(_btHandler.manageSwitch&&Input.GetMouseButtonDown(0)){
			OnClick();
		}
	}
    public void GenerateGrid()
    {
        _tiles = new Dictionary<Vector2, Tile>();
        for (int x = 0; x < _width; x++)
        {
            for (int y = 0; y < _height; y++) {
                var spawnedTile = Instantiate(_Tile, new Vector3(x*TileSize,0,y*TileSize), Quaternion.identity);
				_Tile.transform.localScale = new Vector3(TileSize*0.1f,  TileSize*0.1f, TileSize*0.1f);
                spawnedTile.name = $"Tile {x} {y}";

              
                spawnedTile.Init(x,y);


                _tiles[new Vector2(x, y)] = spawnedTile;
            }
        }

        //_cam.transform.position = new Vector3((float)_width / 2 - 0.5f,  _height,(float)_height / 2 - 0.5f);

        //GameManager.Instance.ChangeState(GameState.SpawnHeroes);
    }
	
	public void OnClick(){
		foreach(var _tile in _tiles){
			if(_tile.Value.mouseEnter){
				Debug.Log("click"+_tile.Key);
				var spawnedObjOccu = Instantiate(_objectOccupation, new Vector3(_tile.Key.x*TileSize,0,_tile.Key.y*TileSize), Quaternion.Euler(-90,0, 0));
				_occupationList.Add(spawnedObjOccu);
                //spawnedTile.name = $"Tile {x} {y}";
			}
		}
	}
	void Occupied(){
		// foreach(var _tile in _tiles){
			// _tile.Value.Occupied(false);
		// }
		// foreach(var _obj in _occupationList){
			// var list = _obj.GetOccupies();
			// foreach(ocpTile in list){
				// foreach(var _tile in _tiles){   //findobject
					// if(_tile.Key == ocpTile){
						// _tile.Value.Occupied(true);
					// }
				
				// }
			
			// }
		// }
	}
    // public Tile GetHeroSpawnTile() {
        // return _tiles.Where(t => t.Key.x < _width / 2 && t.Value.Walkable).OrderBy(t => Random.value).First().Value;
    // }

    // public Tile GetEnemySpawnTile()
    // {
        // return _tiles.Where(t => t.Key.x > _width / 2 && t.Value.Walkable).OrderBy(t => Random.value).First().Value;
    // }

    // public Tile GetTileAtPosition(Vector2 pos)
    // {
        // if (_tiles.TryGetValue(pos, out var tile)) return tile;
        // return null;
    // }
}