using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class Dices {

	static System.Random ran = new System.Random();
	
	///<summary>
	///Tira un dado de 'max' caras.
	///</summary>
	public static int dice(int max)
	{
		return ran.Next(0,max)+1;
	}
	
	//<summary>
	//Entrega un numero entero aletorio entre min y max.
	//</summary>
	public static int dice(int min,int max)
	{
		return ran.Next(min,max)+1;
	}
	
	/// <summary>
	/// Retorna si es que ocurre o no un evento con cierta probabilidad gt.
	/// </summary>
	/// <param name="gt">Gt.</param>
	public static bool prob(float gt)
	{
		float aux;
		aux = UnityEngine.Random.value;
		UnityEngine.Debug.Log(aux);
		if(aux > gt){ return true; }
		else return false;	
	}
	
	/// <summary>
	/// Retorna un numero aleatorio entre min y max con cierta cantidad dec de decimales.
	/// </summary>
	/// <param name="min">Minimum.</param>
	/// <param name="max">Max.</param>
	/// <param name="dec">Dec.</param>
	public static float fdice(float min, float max)
	{
		return UnityEngine.Random.Range(min,max);
	}
	
	public static bool isEven(int value)
	{
		return (value & 1) == 0;
	}
	/// <summary>
		/// Returns a string that is a random even or odd numer between min and max.
	/// </summary>

	public static string evenString(int min, int max,bool even)
	{
		int num = ran.Next(min,max)+1;

		if(isEven(num) == even) return num.ToString();
		else 
		{
			if(num-1 < min) return (num+1).ToString();
			if(num+1 > max) return (num-1).ToString();

			return (num-1).ToString();
		}
		
	}
}
