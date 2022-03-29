using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
	public string TileName;
    [SerializeField] protected GameObject _renderer;
    //[SerializeField] private GameObject _highlight;
    [SerializeField] private bool _isWalkable;
    [SerializeField] private Color _baseColor, _offsetColor, _highlightColor;

	private int X,Y;
	private Color _Color;
	public bool mouseEnter = false;
    public void Init(int x, int y) {
        var isOffset = (x + y) % 2 == 1;
		_Color = isOffset ? _offsetColor : _baseColor;
        _renderer.GetComponent<Renderer>().material.SetColor("_Color",_Color) ;
		X=x;Y=y;
    }
	void OnMouseEnter()
    {
		_renderer.GetComponent<Renderer>().material.SetColor("_Color",_highlightColor) ;
		mouseEnter = true;
    }

    void OnMouseExit()
    {
        _renderer.GetComponent<Renderer>().material.SetColor("_Color",_Color) ;
		mouseEnter = false;
	}
}
