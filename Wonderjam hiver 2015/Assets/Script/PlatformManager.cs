using UnityEngine;
using System.Collections;

public class PlatformManager : MonoBehaviour {
	public Transform petit;
	public Transform moyen;
	public Transform grand;
	public int numberOfObjects;
	public float minGap,maxGap,minY,maxY;
	public Vector3 startPosition;
	private Vector3 nextPosition1, nextPosition2;
	private Vector3 exitPosition;
	public Transform basicPlatform;
	public int nbElemPetit,nbElemMoyen,nbElemGrand;
	public Transform exit;
	// Use this for initialization
	void Start () {
		nextPosition1= new Vector3(0.0f,0.0f,0.0f);
		nextPosition2=startPosition;
		for (int i =0; i < numberOfObjects; i++)
			spawnPlateform();
		spawnExit();
	}
	
	// Update is called once per frame
	void Update () {
	}

	void spawnExit(){
		float X = (float) basicPlatform.renderer.bounds.size.x*1.5f;
		float Y = (float) basicPlatform.renderer.bounds.size.y*0.5f+exit.renderer.bounds.size.y * 0.5f;
		exitPosition += new Vector3(X, Y, 0.0f);
		Instantiate(exit,exitPosition,Quaternion.identity);
	}

	void spawnPlateform(){
		{
			int c = Random.Range(0,2);
			int nb1;
			if (c%3 == 0){
				Instantiate(petit,nextPosition1, Quaternion.identity);
				nb1 = nbElemPetit;
			}
			else if (c%3 ==1){
				Instantiate(moyen,nextPosition1, Quaternion.identity);
				nb1 = nbElemMoyen;
			}
			else{
				Instantiate(grand,nextPosition1, Quaternion.identity);
				nb1 = nbElemGrand;
			}
			c = Random.Range(0,2);
			int nb2;
			if (c%3 == 0){
				Instantiate(petit,nextPosition2, Quaternion.identity);
				nb2 = nbElemPetit;
			}
			else if (c%3 ==1){
				Instantiate(moyen,nextPosition2, Quaternion.identity);
				nb2 = nbElemMoyen;
			}
			else{
				Instantiate(grand,nextPosition2, Quaternion.identity);
				nb2 = nbElemGrand;
			}
			c = Random.Range(0,1);
			float size1,size2;
			size1 = nb1* basicPlatform.renderer.bounds.size.x;
			size2 = nb2* basicPlatform.renderer.bounds.size.x;
			if (c==0){
				exitPosition = nextPosition1;
				nextPosition2= nextPosition1 + new Vector3(Random.Range(minGap,maxGap) + size1,Random.Range(minY,maxY),0.0f);
				nextPosition1= nextPosition1 + new Vector3(Random.Range(minGap,maxGap) + size1,Random.Range(minY,maxY),0.0f);
			}
			else{
				exitPosition = nextPosition2;
				nextPosition1= nextPosition2 + new Vector3(Random.Range(minGap,maxGap) + size2,Random.Range(minY,maxY),0.0f);
				nextPosition2= nextPosition2 + new Vector3(Random.Range(minGap,maxGap) + size2,Random.Range(minY,maxY),0.0f);
			}
		}
	}
}

