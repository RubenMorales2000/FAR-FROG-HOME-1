using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class newWorldGenerator : MonoBehaviour
{

    public GameObject firstStreetPiece;
    public GameObject loopableStreetTemplate;
    private GameObject currentStreetPiece;
    private GameObject lastStreetPiece;
    private Queue<GameObject> queuedStreetPieces;
    public int startTiles;
    public float overlapOffset;

    void Start()
    {
        currentStreetPiece = firstStreetPiece;
        queuedStreetPieces = new Queue<GameObject>();
        for(int i = 1; i < startTiles; i++){
           generateNewTile(firstStreetPiece, this.overlapOffset, i, -0.05f*i);
        }
    }

    void Update () 
    {
        if(playerIsOnStreetPiece(currentStreetPiece)) {
            if(!currentStreetPiece.GetComponent<cityLife>().getHasGenerated()) {
                generateNewTile(currentStreetPiece, this.overlapOffset, this.startTiles, -0.05f*(this.startTiles+1));
                currentStreetPiece.GetComponent<cityLife>().setHasGenerated();
                if(this.lastStreetPiece != null) {
                    Destroy(this.lastStreetPiece);
                }
                lastStreetPiece = currentStreetPiece;
                currentStreetPiece = this.queuedStreetPieces.Dequeue();
            }
        } else {

        }
    }

    bool playerIsOnStreetPiece(GameObject streetPiece)
    {
        float playerCoord = this.transform.position.x;
        float streetPieceCoord = streetPiece.transform.position.x;
        float streetPieceLength = streetPiece.GetComponent<Collider>().bounds.size.x;
        if ( playerCoord >= streetPieceCoord && playerCoord <= streetPieceCoord+streetPieceLength) {
            return true;
        }
        return false;
    }

    void generateNewTile(GameObject streetPiece, float hosrizontalOffset, int numTilesDistance, float verticalOffset)
    {
                Vector3 pos = streetPiece.transform.position;
                pos.x -= (streetPiece.GetComponent<Collider>().bounds.size.x-hosrizontalOffset)*numTilesDistance;
                queuedStreetPieces.Enqueue(Instantiate(loopableStreetTemplate, pos, streetPiece.transform.rotation) as GameObject);
    }
}
